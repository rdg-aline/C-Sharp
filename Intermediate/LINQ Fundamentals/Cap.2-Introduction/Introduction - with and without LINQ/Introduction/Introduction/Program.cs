using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
            Console.WriteLine(" ShowLargeFilesWithoutLinq ");
            ShowLargeFilesWithoutLinq(path);

            Console.WriteLine("\n ********************** \n");

            Console.WriteLine(" ShowLargeFilesWithLinq ");
            ShowLargeFilesWithLinq(path);
        }

          private static void ShowLargeFilesWithLinq(string path)
           {
            var query = new DirectoryInfo(path).GetFiles()
                            .OrderByDescending(f => f.Length)
                            .Take(5);

            foreach (var file in query)
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }
            

            /* Another way to do is: 
              var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;

               foreach (var file in query.Take(5))
               {
                   Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
               }*/
           }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path); // 1- instance DirectoryInfo with path wished
            FileInfo[] files = directory.GetFiles();          //  2- get all files 
            Array.Sort(files, new FileInfoComparer());       //   3- order the files from greater to small using the interface ICOMPARE  - Array is static method of FileInfo Class
            
            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
                // {file.Name,-20}-> -20 means - left justify
                // {file.Length,10:N0} -> 10 means: right-justify 10spaces
                // {file.Length,10:N0} ->N means: format as a number with commas
                // {file.Length,10:N0} -> 0 position after decimal 

            }
        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y) // 4 - compare the lenght of files, return -0 if files has the same lenght,-1 if first file is bigger than second file
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
