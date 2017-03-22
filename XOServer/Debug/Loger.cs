using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOServer.Debug
{
    public static class Loger
    {
        private const string FILE_PATH = "ClientLogs";

        static Loger()
        {
            var sessionTime = String.Format("{0}{1}", DateTime.Now, "\n\r");
            File.AppendAllText(FILE_PATH, sessionTime);
        }

        public static void WriteToLog(params string[] logMessages)
        {
            string singleMessage = String.Empty;
            foreach (var item in logMessages)
            {
                singleMessage += String.Format("{0}{1}", item, " ");
            }
            singleMessage += "\n\r";

            File.AppendAllText(FILE_PATH, singleMessage);
        }
    }
}
