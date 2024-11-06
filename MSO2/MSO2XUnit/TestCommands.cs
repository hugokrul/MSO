using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO2XUnit
{
    public static class TestCommands
    {
        public static readonly string[] TestFacingSquare =
        {
            "Turn left",
            "Repeat 4 times",
            "    Move 10",
            "    Turn right"
        };

        public static readonly string[] TestMoveNoRepeat =
        {
            "Turn left",
            "Move 10",
            "Turn right",
            "Move 10",
            "Turn right",
            "Move 10",
            "Turn right",
            "Move 10",
            "Turn right"
        };

        public static readonly string[] TestMoveWithRepeat =
        {
            "Turn left",
            "Repeat 4 times",
            "    Move 10",
            "    Turn right"
        };

        public static readonly string[] TestMoveWithRepeatUntil =
        {
            "Repeat 4 times",
            "    Repeatuntill gridEdge",
            "        Move 1",
            "    Turn left"
        };
    }
}
