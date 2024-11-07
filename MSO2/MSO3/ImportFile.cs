using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO3
{
    public static class ImportFile
    {
        public static string[]? ImportBoardArrayByPath()
        {
            string? boardFile = Interaction.InputBox("Give the full path of the file where the board is stored", "Board file");
            if (boardFile == "") return null;
            if (File.Exists(boardFile)) return File.ReadAllLines(boardFile);
            else return null;
        }
    }
}
