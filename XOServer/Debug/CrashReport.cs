using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOServer.Debug
{
    public static class CrashReport
    {
        private static object Locker;
        private const string FILE_PATH = "CrashLogs";

        static CrashReport()
        {
            Locker = new object();
            var sessionTime = String.Format("{0}{1}", DateTime.Now, Environment.NewLine);
            File.AppendAllText(FILE_PATH, sessionTime);
        }

        public static void WriteCrash(params string[] logMessages)
        {
            string singleMessage = String.Empty;
            foreach (var item in logMessages)
            {
                singleMessage += String.Format("{0}{1}", item, " ");
            }
            singleMessage += Environment.NewLine;

            lock (Locker)
            {
                File.AppendAllText(FILE_PATH, singleMessage);
            }
        }
    }
}
