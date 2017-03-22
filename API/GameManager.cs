using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOServer.Authentification;
using XOServer.RealJope;
using XOServer.Sessions;
using System.IO;
using System.Net.UniversalSockets;
using System.Threading;

namespace XOServer.API
{
    public class GameManager
    {
        public GameManager(Action broadcast, Action<string> removeClientFromConnList)
        {
            gameRooms = new List<GameRoom>();
            Broadcast += broadcast;
            RemoveClientFromConnList += removeClientFromConnList;
        }

        private List<GameRoom> gameRooms;
        private event Action Broadcast;
        private event Action<string> RemoveClientFromConnList;

        public GameRoom GetByNames(string key)
        {
            try
            {
                return gameRooms.First(gRoom =>
                {
                    return gRoom.Key.Equals(key);
                });
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        public void Play(string key, string packetString)
        {
            try
            {
                var room = GetByNames(key);
                if (packetString.StartsWith("quit"))
                {
                    try
                    {
                        Thread.Sleep(1000);
                        QuitGame(room);
                    }
                    catch (ArgumentException ex)
                    {
                        RemoveClientFromConnList(ex.Message);
                    }
                }
                else
                {
                    var packet = JsonPacketDecoder.Decode(packetString);
                    SendInGamePackage(packet, room);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        public void QuitGame(GameRoom room)
        {
            try
            {
                room.player1.Us.Write("game:quit");
                room.player2.Us.Write("game:quit");

                RemoveFromGame(room.player1, room.player2);
                gameRooms.Remove(room);
                Broadcast();
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        private void SendInGamePackage(TTTPacket packet, GameRoom room)
        {
            try
            {
                bool isGameOver;
                if (room.game.IsWrongStep(packet.ButtonNumber - 1))
                {
                    return;
                }
                room.Turn += 1;

                room.game.Turn(packet.ButtonNumber - 1, packet.Unit);
                isGameOver = room.game.IsGameOver();
                if (isGameOver)
                {
                    packet.GameResult = room.game.Result;
                }
                packet.Matrix = room.game.GetMatrix();

                UniversalStream us1, us2;
                if (room.Turn == 1)
                {
                    us1 = room.player1.Us;
                    us2 = room.player2.Us;
                }
                else
                {
                    us1 = room.player2.Us;
                    us2 = room.player1.Us;
                }

                us2.Write(JsonPacketDecoder.Encode(packet));

                packet.PlayerTurn = ~packet.PlayerTurn;

                us1.Write(JsonPacketDecoder.Encode(packet));

                if (isGameOver)
                {
                    RemoveFromGame(room.player1, room.player2);
                    gameRooms.Remove(room);
                    Broadcast();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        public void SendInitPackage(Client wanter, Client wanted)
        {
            try
            {
                AddToGame(wanter, wanted);
                TTTPacket packet = new TTTPacket(PlayerTurn.Turn, "X", 0, null, null);
                wanter.Us.Write(JsonPacketDecoder.Encode(packet));

                packet = new TTTPacket(PlayerTurn.Wait, "O", 0, null, null);
                wanted.Us.Write(JsonPacketDecoder.Encode(packet));

                gameRooms.Add(new GameRoom(wanter, wanted, GameType.XO));
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        private void AddToGame(Client wanter, Client wanted)
        {
            try
            {
                wanted.IsInGame = true;
                wanter.IsInGame = true;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        private void RemoveFromGame(Client wanter, Client wanted)
        {
            try
            {
                wanted.IsInGame = false;
                wanter.IsInGame = false;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }
    }
}
