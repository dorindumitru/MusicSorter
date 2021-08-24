using System;
using System.Collections.Generic;
using System.IO;

namespace musicsorter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filePaths = Directory.GetFiles(@"d:\MusicTest\", "*.mp3" , SearchOption.AllDirectories); 

            foreach(var file in filePaths)
            {
                string[] pathFile = file.Split("\\");
                var count = pathFile.Length;
                string fileName = pathFile[count-1];
                string artist = fileName.Split(" -")[0];
                string trimArtist = artist.Trim();
                    Console.WriteLine("The current file is " + file);

                string unsorted = @"D:\MusicTest\Sorted Music\Unsorted\";
                if(!Directory.Exists(unsorted))
                {
                    Directory.CreateDirectory(unsorted);
                }
                
                    Console.WriteLine("The current artist is " + trimArtist);
               
                //string path = Directory.GetCurrentDirectory();
                string target = @"D:\MusicTest\Sorted Music\" + trimArtist + "\\";
                    Console.WriteLine("The current directory is "+ target);
                    
                string destination = target+fileName;
                    Console.WriteLine("The destination is " + destination);
                
                if (file.Contains(" - ") & !Directory.Exists(target)) 
                {
                    Directory.CreateDirectory (target);
                    File.Copy(file,target + fileName, true);
                }    
                else
                {
                    if(!file.Contains(" - "))
                
                   
                    try

                    {
                        File.Copy(file,unsorted + fileName, true);
                    }
                    
                    catch (UnauthorizedAccessException) 
                    {
                        FileAttributes attr = (new FileInfo(destination)).Attributes;
                            Console.Write("UnAuthorizedAccessException: Unable to access file. ");
                        if ((attr & FileAttributes.ReadOnly) > 0)
                            Console.Write("The file is read-only.");
                    }
                }
            }   
        }    
    }
}