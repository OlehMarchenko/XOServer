using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOClient.API
{
    [Flags]
    public enum PlayerTurn : uint
    {
        Wait = 0x00000000,
        Turn = 0xFFFFFFFF
    }
}
