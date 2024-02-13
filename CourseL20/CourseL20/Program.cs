using static System.Console;
using static System.IO.Directory;
using System.Text;
using System.Diagnostics;
using System.IO.Compression;

namespace CourseL20
{
    public class Program
    {
        public static void Main()
        {
            // Ex1
            // Ex1_L20();

            //Ex2
            //Ex2_L20();

            //Ex3
            Ex3_L20();
        }

        private static void Ex1_L20()
        {
            try
            {
                string path = @".\Folder_";
                string rootPath = @".\";
                for (int i = 0; i < 51; i++)
                    CreateDirectory(path + i);

                WriteLine("Directories created!");
                var DInfo = new DirectoryInfo(rootPath).GetDirectories();
                foreach (var info in DInfo)
                    WriteLine($"{info.Name} - {info.CreationTime}");

                for (int i = 0; i < 51; i++)
                    Delete(path + i);

                WriteLine("Directories deleted!");

            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        private static void Ex2_L20()
        {
            try
            {
                string path = @".\Ex2.txt";
                FileStream fSC = File.Create(path);
                fSC.Close(); // без цього -> The process cannot access the file ...
                             // because it is being used by another process.

                using FileStream fSW = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None);
                var bytes = new UTF8Encoding(true).GetBytes("Some text");
                fSW.Write(bytes, 0, bytes.Length);
                fSW.Close();


                using FileStream fsR = File.Open(path, FileMode.Open);
                byte[] b = new byte[1024];

                while (fsR.Read(b, 0, b.Length) > 0)
                    WriteLine(new UTF8Encoding(true).GetString(b));
                fsR.Close();

                //Or

                string newPath = @".\Ex2_1.txt";

                File.WriteAllText(newPath, "New some text" + Environment.NewLine + "big");

                WriteLine(File.ReadAllText(newPath));

                // варіантів безліч

            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        private static void Ex3_L20()
        {
            string? directive = @".\";
            string? fileName = "";
            string? fullFileName = "";
            while (true)
            {
                WriteLine($"Enter a file name to find on directive {directive} or nothing to exit.");
                fileName = ReadLine();
                fullFileName = directive + fileName;

                if (fileName == "")
                    break;

                var listOfFiles = GetFiles(directive).ToList();
                
                try
                {
                    //if(listOfFiles.Contains(directive + fileName))
                    if (listOfFiles.Exists(e => e == fullFileName))
                    {
                        WriteLine("File found!");
                        FileStream fS = File.Open(fullFileName, FileMode.Open);
                        
                        fS.Close();

                        //Text editor
                        string notepadPath = Environment.SystemDirectory + @"\notepad.exe";

                        var startInfo = new ProcessStartInfo(notepadPath)
                        {
                            WindowStyle = ProcessWindowStyle.Maximized,
                            Arguments = fullFileName
                        };

                        Process.Start(startInfo); // це перший варіант який я знайшов для відкривання
                                                  // в текстовому редакторі

                        //ZipArchive
                        using FileStream fSN = File.OpenRead(fullFileName);
                        using FileStream zipS = new(directive + "release.zip", FileMode.Create);
                        GZipStream gZipCompressor = new(zipS, CompressionMode.Compress);

                        int fileByte = fSN.ReadByte();

                        while (fileByte != -1)
                        {
                            gZipCompressor.WriteByte((byte)fileByte);
                            fileByte = fSN.ReadByte();
                        }

                        WriteLine($"File {fileName} comressed successfully!");
                        zipS.Close();
                    }
                    else
                        WriteLine("File not found =(");
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                } // Залишив так як є, бо немає часу перевіряти по правильному всі exceptions окремо
            }
            //очевидно що можна використати рекурсію щоб йти по дереву і шукати в під-папках файл,
            //але для прикладу цього мабуть достатньо + таж причина що зверху
        }
    }
}