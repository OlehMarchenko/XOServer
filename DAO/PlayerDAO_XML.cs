using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOServer.DAO.Model;

namespace XOServer.DAO
{
    public class PlayerDAO_XML
    {
        private IOManager io;

        public PlayerDAO_XML()
        {
            io = new IOManager();
        }

        public void Create(Player player)
        {
            try
            {
                List<Player> players = io.Deserialize().ToList();
                players.Add(player);
                io.Serialize(players);
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        public IEnumerable<Player> Read()
        {
            try
            {
                return io.Deserialize().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        public void Update(Player player)
        {
            try
            {
                List<Player> players = io.Deserialize().ToList();
                var pl = players.First((p) => p.Name.Equals(player.Name));
                pl.Copy(player);
                io.Serialize(players);
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        public void Delete(Player player)
        {
            try
            {
                List<Player> players = io.Deserialize().ToList();
                players.Remove(players.First((p) => p.ToString().Equals(player.ToString())));
                io.Serialize(players);
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }
    }
}
