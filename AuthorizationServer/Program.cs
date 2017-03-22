using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AuthorizationServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerAPI server = new ServerAPI();
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
