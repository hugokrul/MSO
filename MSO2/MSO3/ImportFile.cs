using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MSO3
{
    public static class ImportFile
    {
        // imports the boardarray with a path that is filled in from an inputbox
        public static string[]? ImportBoardArrayByPath()
        {
            string? boardFile = Interaction.InputBox("Give the full path of the file where the board is stored", "Board file");
            if (boardFile == "") return null;
            if (File.Exists(boardFile)) return File.ReadAllLines(boardFile);
            else return null;
        }

        // exports the text to a sepcified name and gives back the full path
        public static string ExportWriteYourOwn(string name, string text)
        {
            string file = @"..\..\..\" + name + ".txt";
            File.Create(file).Close();
            File.WriteAllText(file, text);
            return Path.GetFullPath(file);
        }

        // checks for the existence of .txt files, this way it is open for multiple allowed extensions
        public static bool CheckExistence(string file)
        {
            string[] allowedFiles = { ".txt" };
            return File.Exists(file) || allowedFiles.Contains(Path.GetExtension(file));
        }
    }
}
