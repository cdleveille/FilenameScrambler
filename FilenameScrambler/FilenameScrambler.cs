using System;
using System.Collections.Generic;
using System.IO;

namespace FilenameScrambler
{
    class FilenameScrambler
    {
        static void Main(string[] args)
        {
            try
            {
                PasswordPrompt();

                string path = System.IO.Directory.GetCurrentDirectory();
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo file in files)
                {
                    if (file.Extension != ".exe")
                    {
                        string newFilename = Scramble(file.Name);

                        File.Delete(path + "\\" + newFilename);
                        File.Move(path + "\\" + file.Name, path + "\\" + newFilename);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void PasswordPrompt()
        {
            bool locked = true;
            while (locked)
            {
                Console.Write("password: ");
                if (Console.ReadLine() == "asdf")
                {
                    locked = false;
                }
                else
                {
                    Console.WriteLine("incorrect!");
                }
            }
        }

        private static string Scramble(string filename)
        {
            Dictionary<char, char> charLookup = CreateCharLookup();
            char[] filenameChar = filename.ToCharArray();
            string toReturn = "";

            foreach (char c in filenameChar)
            {
                if (charLookup.ContainsKey(c))
                {
                    toReturn += charLookup[c];
                }
                else
                {
                    toReturn += c;
                }
            }

            return toReturn;
        }

        private static Dictionary<char, char> CreateCharLookup()
        {
            Dictionary<char, char> toReturn = new Dictionary<char, char>();

            toReturn.Add('a', 'n');
            toReturn.Add('b', 'o');
            toReturn.Add('c', 'p');
            toReturn.Add('d', 'q');
            toReturn.Add('e', 'r');
            toReturn.Add('f', 's');
            toReturn.Add('g', 't');
            toReturn.Add('h', 'u');
            toReturn.Add('i', 'v');
            toReturn.Add('j', 'w');
            toReturn.Add('k', 'x');
            toReturn.Add('l', 'y');
            toReturn.Add('m', 'z');
            toReturn.Add('n', 'a');
            toReturn.Add('o', 'b');
            toReturn.Add('p', 'c');
            toReturn.Add('q', 'd');
            toReturn.Add('r', 'e');
            toReturn.Add('s', 'f');
            toReturn.Add('t', 'g');
            toReturn.Add('u', 'h');
            toReturn.Add('v', 'i');
            toReturn.Add('w', 'j');
            toReturn.Add('x', 'k');
            toReturn.Add('y', 'l');
            toReturn.Add('z', 'm');
            toReturn.Add('A', 'N');
            toReturn.Add('B', 'O');
            toReturn.Add('C', 'P');
            toReturn.Add('D', 'Q');
            toReturn.Add('E', 'R');
            toReturn.Add('F', 'S');
            toReturn.Add('G', 'T');
            toReturn.Add('H', 'U');
            toReturn.Add('I', 'V');
            toReturn.Add('J', 'W');
            toReturn.Add('K', 'X');
            toReturn.Add('L', 'Y');
            toReturn.Add('M', 'Z');
            toReturn.Add('N', 'A');
            toReturn.Add('O', 'B');
            toReturn.Add('P', 'C');
            toReturn.Add('Q', 'D');
            toReturn.Add('R', 'E');
            toReturn.Add('S', 'F');
            toReturn.Add('T', 'G');
            toReturn.Add('U', 'H');
            toReturn.Add('V', 'I');
            toReturn.Add('W', 'J');
            toReturn.Add('X', 'K');
            toReturn.Add('Y', 'L');
            toReturn.Add('Z', 'M');
            toReturn.Add('1', '6');
            toReturn.Add('2', '7');
            toReturn.Add('3', '8');
            toReturn.Add('4', '9');
            toReturn.Add('5', '0');
            toReturn.Add('6', '1');
            toReturn.Add('7', '2');
            toReturn.Add('8', '3');
            toReturn.Add('9', '4');
            toReturn.Add('0', '5');

            return toReturn;
        }
    }
}