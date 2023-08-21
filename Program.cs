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
            LetterService letter = new LetterService();
            // get all .txt files in input folder
            string[] filePaths = Directory.GetFiles(@"C:\Users\sonit\OneDrive\Desktop\UIOWA\ConsoleApp\CombinedLetters01\Input\", "*.txt",
                                         SearchOption.AllDirectories);

            // 1- Move file in Input folder to Achive Folder
            foreach (var fileName in filePaths)
            {
                // Console.WriteLine(fileName);
                File.Move(fileName, Path.Combine(@"C:\Users\sonit\OneDrive\Desktop\UIOWA\ConsoleApp\CombinedLetters01\Archive\", Path.GetFileName(fileName)));
            }

            string[] archiveFolder = Directory.GetFiles(@"C:\Users\sonit\OneDrive\Desktop\UIOWA\ConsoleApp\CombinedLetters01\Archive\", "*.txt",
                                         SearchOption.AllDirectories);

            Console.WriteLine(archiveFolder.Length);
            // store all student IDs
            string[] numID = new string[archiveFolder.Length];

            //store all file names
            string[] fileNames = new string[archiveFolder.Length];

            // //get all file names. eg. 00001010.txt
            for (int i = 0; i < archiveFolder.Length; i++)
            {
                fileNames[i] = archiveFolder[i].Substring(archiveFolder[i].Length - 12, 12);
                // Console.WriteLine(fileNames[i]);
            }

            // get all student ids. eg. 00001010
            for (int i = 0; i < archiveFolder.Length; i++)
            {
                numID[i] = archiveFolder[i].Substring(archiveFolder[i].Length - 12, 8);
                // Console.WriteLine(numID[i]);
            }

            // sort student id in acending order
            Array.Sort(numID); // assume already sort when store in the folder

            var outputFolder = new ArrayList();
            var output = new ArrayList();

            int index = 0;

            for (int i = 1; i < numID.Length; i++)
            {
                //if we see a duplicate element, increment the index
                //move file to output folder
                if (numID[i - 1] == numID[i])
                {
                    // Console.WriteLine(numID[i]);
                    outputFolder.Add(numID[i]);
                    output.Add(archiveFolder[i - 1]);
                    output.Add(archiveFolder[i]);

                    string moveDir1 = @"C:\Users\sonit\OneDrive\Desktop\UIOWA\ConsoleApp\CombinedLetters01\Output\";
                    string moveDir2 = numID[i].ToString();
                    string moveDir3 = ".txt";
                    string movePath1 = moveDir1 + moveDir2;
                    string movePathFinal = movePath1 + moveDir3;
                    // Console.WriteLine("MOVE DIR:........................ " + movePathFinal);
                    string dir = $@"{movePathFinal}";
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    // Console.WriteLine("HERE: ==============" + archiveFolder[i]);

                    // Console.WriteLine("HERE: ==============" + archiveFolder.Length);

                    // call CombineTwoLetter method to merger content of two letters
                    letter.CombineTwoLetters(archiveFolder[i], archiveFolder[i - 1], dir);

                    // remove inputfile 1 and input file to before combine from the archive folder
                    // string filePath1 = archiveFolder[i];
                    // string filePath2 = archiveFolder[i - 1];

                    // // Delete the file
                    // File.Delete(filePath1);
                    // File.Delete(filePath2);

                    // if (!File.Exists(filePath1))
                    // {
                    //     Console.WriteLine($"File {filePath1} is successfully deleted.");
                    // }
                    // if (!File.Exists(filePath2))
                    // {
                    //     Console.WriteLine($"File {filePath2} is successfully deleted.");
                    // }

                    index++;
                }
            }
            // Console.WriteLine(outputFolder.Count);
            // Console.WriteLine("OUTPUT: " + output.Count);
            // // Console.WriteLine("OUTPUT Name: " + output[0]);
            // for (int i = 0; i < output.Count; i++)
            // {
            //     Console.WriteLine(output[i]);
            // }


            // LetterService letter = new LetterService();
            // int n = output.Count;
            // for (int i = 0; i < output.Count / 2; i++)
            // {
            //     string name = outputFolder[i];
            //     string dir = "C:\Users\sonit\OneDrive\Desktop\UIOWA\ConsoleApp\CombinedLetters4\Output" + ${ name};
            //     letter.CombineTwoLetters(output[i], output[n / 2 + i], dir);
            // }


            // StreamWriter sw = new StreamWriter("C:\Users\sonit\OneDrive\Desktop\UIOWA\ConsoleApp\CombinedLetters4\Output\report.txt");
            // //Write a line of text
            // sw.WriteLine("Hello World!!");
            // //Write a second line of text
            // sw.WriteLine("From the StreamWriter class");
            // //Close the file
            // sw.Close();

            //Pass the filepath and filename to the StreamWriter ConstructorFile
            // StreamWriter sw = new StreamWriter("C:\Users\sonit\OneDrive\Desktop\UIOWA\ConsoleApp\CombinedLetters3\Output\report.txt");


            string currentDate = DateTime.Now.ToString("dd MMMM yyyy");

            string md1 = @"C:\Users\sonit\OneDrive\Desktop\UIOWA\ConsoleApp\CombinedLetters01\Output\";
            string md2 = currentDate.ToString();

            string md3 = ".txt";
            string move1 = md1 + md2;
            string movePath = move1 + md3;
            string direct = $@"{movePath}";
            if (!Directory.Exists(direct))
            {
                Directory.CreateDirectory(direct);
            }

            Console.WriteLine(currentDate + " Report");
            // sw.WriteLine(currentDate + " Report");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Number of Combined Letters:  " + outputFolder.Count);
            // sw.WriteLine("Number of Combined Letters:  " + outputFolder.Count);

            foreach (string i in outputFolder)
            {
                Console.WriteLine(i);
                // sw.WriteLine(i);
            }
            // sw.Close();
            // Console.ReadLine();
            Console.WriteLine("=========================================");


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
                // Console.WriteLine("inputFile1: " + inputFile1);
                // Console.WriteLine("inputFile2 : " + inputFile2);
                // Console.WriteLine("resultFile: " + resultFile);

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