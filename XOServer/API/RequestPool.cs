using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.UniversalSockets;
using XOServer.Authentification;

namespace XOServer.API
{
    public class RequestPool
    {
        public RequestPool()
        {
            Item = new List<Request>();
        }

        public List<Request> Item { get; private set; }

        public Request GetByWantedName(string wantedName)
        {
            try
            {
                IEnumerable<Request> req = null;
                req = from r in Item
                      where r.Wanted.Name.Equals(wantedName)
                      select r;

                return req.First();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void Add(Request request)
        {
            try
            {
                Item.Add(request);
                SendRequest(request);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void SendRequest(Request request)
        {
            try
            {
                request.Wanted.Us.Write("invite:" + request.Wanter.Name);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void SendResponse(Request request, string response)
        {
            try
            {
                request.Wanted.Us.Write("success:" + response);
                request.Wanter.Us.Write("success:" + response);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
