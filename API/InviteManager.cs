using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XOServer.Authentification;
using XOServer.Sessions;

namespace XOServer.API
{
    public class InviteManager
    {
        public InviteManager()
        {
            requestPool = new RequestPool();
        }

        private RequestPool requestPool;


        public void Invite(Client wanter, Client wanted)
        {
            try
            {
                if (wanted != null)
                {
                    bool exists = false;

                    if (requestPool.Item.Count != 0)
                    {
                        exists = requestPool.Item.Any(r =>
                        {
                            return r.Wanted.Name.Equals(wanted.Name);
                        });
                    }

                    if (!exists)
                    {
                        requestPool.Add(new Request(wanted, wanter));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        public void InviteYes(Client wanter, Client wanted)
        {
            try
            {
                SessionResult(wanter.Name, "yes," + wanter.Name + wanted.Name);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        public void InviteNo(Client wanter)
        {
            try
            {
                SessionResult(wanter.Name, "no");
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }

        private void SessionResult(string wantedName, string modifier)
        {
            try
            {
                Request req = requestPool.GetByWantedName(wantedName);
                requestPool.SendResponse(req, modifier);
                requestPool.Item.Remove(req);
            }
            catch (Exception ex)
            {
                throw new Exception("", ex.InnerException);
            }
        }
    }
}
