// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System;
using System.IO;
using System.Collections;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // get all .txt files in input folder
            string[] filePaths = Directory.GetFiles(@"C:\Users\sonit\OneDrive\Desktop\UIOWA\ConsoleApp\CombinedLetters1\Input\", "*.txt",
                                         SearchOption.AllDirectories);

            string[] numID = new string[filePaths.Length];
            Console.WriteLine("Number files: " + numID.Length);

            // Move all files to achive folder
            var archiveFolder = new ArrayList();
            archiveFolder.AddRange(numID);


            // get all student ids
            for (int i = 0; i < filePaths.Length; i++)
            {
                numID[i] = filePaths[i].Substring(filePaths[i].Length - 12, 8);
                // Console.WriteLine(numID[i]);
            }

            Console.WriteLine("==============================");

            // sort student id in acending order
            Array.Sort(numID);

            // use Array
            string[] output = new string[numID.Length];
            string[] archive = new string[numID.Length];

            int indexA = 0;
            int indexO = 0;

            for (int i = 1; i < numID.Length; i++)
            {
                //skip to next index if we see a duplicate element
                if (numID[i - 1] != numID[i])
                {
                    archive[indexA] = numID[i];
                    indexA++;
                }
                else
                {
                    output[indexO] = numID[i];
                    indexO++;
                }
            }

            //useArrayList
            var outputL = new ArrayList();
            var archiveL = new ArrayList();

            int indexArc = 0;
            int indexOut = 0;

            for (int i = 1; i < numID.Length; i++)
            {
                // Console.WriteLine(numID[i]);
                //skip to next index if we see a duplicate element
                if (numID[i - 1] != numID[i])
                {
                    archiveL.Add(numID[i]);
                    indexArc++;
                }
                else
                {
                    outputL.Add(numID[i]);
                    indexOut++;
                }
            }

            // Console.WriteLine(archiveL.Count);
            // Console.WriteLine(outputL.Count);

            string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            Console.WriteLine(currentDate + " Report");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Number of Combined Letters:  " + outputL.Count);

            foreach (string i in outputL)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("=========================================");


            string a = filePaths[0];
            string b = filePaths[1];
            string c = filePaths[2];
            LetterService letter = new LetterService();
            letter.CombineTwoLetters(a, b, c);


            // delete all .txt files in input folder
            // foreach (string filePath in filePaths)
            // {
            //     File.Delete(filePath);
            // }

        }

        interface ILetterService
        {
            /// <summary>
            /// Combine two letter files into one file
            /// </summary>
            /// <param name="inputFile1">File path for the first letter.</param>
            /// <param name="inputFile2">File path for the second letter.</param>
            /// <param name="resultFile">File path for the combined letter.</param>
            void CombineTwoLetters(string inputFile1, string inputFile2, string resultFile);
        }

        class LetterService : ILetterService
        {
            public void CombineTwoLetters(string inputFile1, string inputFile2, string resultFile)
            {
                Console.WriteLine("In progress");
                Console.WriteLine(inputFile1);
                Console.WriteLine(inputFile2);
                Console.WriteLine(resultFile);

                String line;
                String line2;
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(inputFile1);
                    StreamReader sr2 = new StreamReader(inputFile2);

                    //Pass the filepath and filename to the StreamWriter ConstructorFile
                    StreamWriter sw = new StreamWriter(resultFile);

                    //Read the first line of text
                    line = sr.ReadLine();
                    line2 = sr2.ReadLine();

                    //Continue to read until you reach end of file inputFile1
                    while (line != null)
                    {
                        //write the line to console window
                        Console.WriteLine(line);
                        //Write a line of text of line
                        sw.WriteLine(line);
                        //Read the next line
                        line = sr.ReadLine();
                    }
                    //Continue to read until you reach end of file inputFile2
                    while (line2 != null)
                    {
                        //write the line to console window
                        Console.WriteLine(line2);
                        //Write a line of text of line1
                        sw.WriteLine(line2);
                        //Read the next line
                        line2 = sr2.ReadLine();
                    }
                    //close the file
                    sr.Close();
                    sr2.Close();
                    //Close the file
                    sw.Close();
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }

        }

    }
}