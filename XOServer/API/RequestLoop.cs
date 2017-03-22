using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XOServer.Authentification;
using XOServer.Sessions;
using System.Net.UniversalSockets;
using XOServer.Debug;

namespace XOServer.API
{
    public class RequestLoop
    {
        private Thread threadListener;
        private object locker;
        private ConnectionList connList;
        private Commander commander;


        public RequestLoop(ConnectionList connList, object locker)
        {
            this.locker = locker;
            this.connList = connList;
            commander = new Commander(connList);
            threadListener = new Thread(new ThreadStart(ListenLoop));
            threadListener.Start();
        }

        private void ListenLoop()
        {
            try
            {
                while (true)
                {
                    if (connList.IsEmpty())
                        continue;

                    lock (locker)
                    {
                        GetRequest();
                    }
                }
            }
            catch (Exception ex)
            {
                // CRASH
                CrashReport.WriteCrash(ex.Message, ex.InnerException?.ToString());
            }
        }

        private void GetRequest()
        {
            try
            {
                for (int i = 0; i < connList.Count; i++)
                {
                    if (connList[i].User.GetStream().DataAvailable)
                    {
                        RequestSelection(connList[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("", ex.InnerException);
            }
        }

        private void RequestSelection(Client wanter)
        {
            try
            {
                string message = wanter.Us.Read();
                message = (wanter.Us.Type == ClientType.Web) ? wanter.Us.Decode() : message;
                if (message.Contains(':'))
                {
                    commander.Dispatch(message, wanter);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace + "", ex.InnerException);
            }
        }

    }
}
