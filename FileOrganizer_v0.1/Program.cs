using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOrganizer_v0._1
{
    class Program
    {

        static int Rename(FileInfo fi, int counter)
        {
            string oldName = fi.Name;
            string appName = System.AppDomain.CurrentDomain.FriendlyName;
            if (oldName == appName)
            {
                return 1;
            }
            oldName = fi.FullName;
            int index = oldName.LastIndexOf('.');

            string extenstion = oldName.Substring(index, oldName.Length - index);

            index = oldName.LastIndexOf('\\');
            Console.WriteLine(oldName);
            string newName = oldName.Substring(0, index);

            newName = newName + "\\" + counter.ToString() + extenstion;

            File.Move(oldName, newName);
            return 0;
            //there has to be a better way
        }


        static void Main(string[] args)
        {
            Console.WriteLine("ATTENTION! This program will rename EVERY FILE in the directory it is placed and name it from 0-x. BE WARNED! ");
            if(Console.ReadKey().KeyChar != 'y')
            {
                Environment.Exit(0);
            }
            Console.Clear();
            Console.WriteLine("ARE YOU SURE?");
            if (Console.ReadKey().KeyChar != 'y')
            {
                Environment.Exit(0);
            }
            Console.Clear();


            DirectoryInfo di = new DirectoryInfo(@".\test");
            FileInfo[] rgFiles = di.GetFiles("*.*");
            int counter = 0;

            Console.WriteLine("Old names:");
            foreach (FileInfo fi in rgFiles)
            {
                Console.WriteLine("Name: " + fi.Name + ", directory: " + fi.Directory);

                int check = Rename(fi, counter);
                if (check == 0)
                {
                    counter++;
                }
            }


            Console.WriteLine("\nNew names:");
            rgFiles = di.GetFiles("*.*");
            foreach (FileInfo fi in rgFiles)
            {
                Console.WriteLine("Name: " + fi.Name + ", directory: " + fi.Directory);
            }
            Console.ReadLine();
        }
    }
}
