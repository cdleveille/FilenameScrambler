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

                Dictionary<char, char> charLookup = CreateCharLookup();
                string path = System.IO.Directory.GetCurrentDirectory();
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo file in files)
                {
                    if (file.Extension != ".exe" && file.Extension != ".pdb")
                    {
                        string newFilename = Scramble(file.Name, charLookup);
                        string newPath = path + "\\" + newFilename;

                        // make sure a file with the new name does not already exist before renaming
                        File.Delete(newPath);
                        File.Move(path + "\\" + file.Name, newPath);

                        SwapBytes(newPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
                Environment.Exit(1);
            }
        }

        private static void PasswordPrompt()
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        private static string Scramble(string filename, Dictionary<char, char> charLookup)
        {
            try
            {
                string toReturn = "";
                char[] filenameChar = filename.ToCharArray();

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
            catch (Exception)
            {
                throw;
            }
        }

        private static Dictionary<char, char> CreateCharLookup()
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        private static void SwapBytes(string path)
        {
            try
            {
                // break down the file into a list of bytes
                byte[] bytes = File.ReadAllBytes(path);
                byte tempByte;

                // swap each byte with its immediate neighbor
                for (int i = 0; i < bytes.Length - 1; i += 2)
                {
                    tempByte = bytes[i];
                    bytes[i] = bytes[i + 1];
                    bytes[i + 1] = tempByte;
                }

                File.WriteAllBytes(path, bytes);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}