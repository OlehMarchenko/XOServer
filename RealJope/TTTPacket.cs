using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOServer.API
{
    public class TTTPacket
    {
        public TTTPacket()
        {
            Matrix = null;
        }

        public TTTPacket(PlayerTurn playerTurn, string unit, int buttonNumber, string[] matrix, string gameResult)
        {
            PlayerTurn = playerTurn;
            Unit = unit;
            ButtonNumber = buttonNumber;
            Matrix = matrix;
            GameResult = gameResult;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public PlayerTurn PlayerTurn { get; set; }
        public string Unit { get; set; }
        public int ButtonNumber { get; set; }
        public string[] Matrix { get; set; }
        public string GameResult { get; set; }

    }
}
