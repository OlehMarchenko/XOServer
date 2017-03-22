using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.UniversalSockets;
using System.Threading;

namespace XOServer.Authentification
{
    public class ConnectionList
    {
        #region Indexer
        public Client this[int index]
        {
            set
            {
                this.userList[index] = value;
            }
            get
            {
                return userList[index];
            }
        }
        #endregion

        private List<Client> userList;
        private object locker;
        public int Count { get { return userList.Count; } }

        public ConnectionList(object locker)
        {
            userList = new List<Client>();
            this.locker = locker;
        }

        public bool IsEmpty()
        {
            return userList.Count == 0;
        }

        public Client GetByName(string name)
        {
            try
            {
                name = name.Replace("\r\n", "");

                IEnumerable<Client> client = null;
                client = from cl in userList
                         where cl.Name.Equals(name)
                         select cl;
                return client.First();
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        public void AddUser(Client user)
        {
            try
            {
                lock (locker)
                {
                    userList.Add(user);
                }
                BroadcastSend();
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        public void RemoveUser(Client user)
        {
            try
            {
                lock (locker)
                {
                    userList.Remove(user);
                }
                BroadcastSend();
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        public void RemoveUsers(IEnumerable<Client> users)
        {
            try
            {
                lock (locker)
                {
                    foreach (var item in users)
                    {
                        userList.Remove(item);
                    }
                }
                BroadcastSend();
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        public void RemoveUserByName(string name)
        {
            try
            {
                RemoveUser(GetByName(name));
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        private void BroadcastSend()
        {
            Client currItem = null;
            try
            {
                string freeUsers = "broadcast:";
                foreach (var item in userList)
                {
                    if (!item.IsInGame) freeUsers += item.Name + ",";
                }
                freeUsers = freeUsers.Remove(freeUsers.Length - 1);

                foreach (var item in userList)
                {
                    if (!item.IsInGame)
                    {
                        currItem = item;
                        item.Us.Write(freeUsers);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        public void RefreshBroadcast()
        {
            try
            {
                BroadcastSend();
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        public bool Any(Func<Client, bool> predicate)
        {
            try
            {
                return this.userList.Any(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

    }
}
