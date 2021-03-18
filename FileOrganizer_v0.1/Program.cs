using System;
using System.IO;

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
            //checks the name in case if its the app itself, so then it skips
            //probably you can check for the app ITSELF, as an unique thing, so even if something else is named the same it still works how it should, but idk

            oldName = fi.FullName; //full name with path
            
            int index = oldName.LastIndexOf('.'); //index is path till the . of the extension

            string extenstion = oldName.Substring(index, oldName.Length - index); //extension saved

            index = oldName.LastIndexOf('\\'); //changing index so its till \, so afterwards is only the files name

            string newName = oldName.Substring(0, index); //new name is path (ye could just path), practice with strings

            newName = newName + "\\" + counter.ToString() + extenstion; //path + \ + number + .txt

            File.Move(oldName, newName);
            return 0;
        }


        static void Main(string[] args)
        {
            //you sure?
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

            DirectoryInfo di = new DirectoryInfo(@".");
            FileInfo[] rgFiles = di.GetFiles("*.*");
            //gets all the files from the folder the app is in
            int counter = 0; //naming

            Console.WriteLine("Old names:");
            foreach (FileInfo fi in rgFiles)
            {
                Console.WriteLine("Name: " + fi.Name + ", directory: " + fi.Directory);

                int check = Rename(fi, counter);
                if (check == 0)
                {
                    counter++; //if the method returns 0, the counter gets updated, if not, it doesnt, which means its the app and it skips it
                }
            }


            Console.WriteLine("\nNew names:");
            rgFiles = di.GetFiles("*.*");
            foreach (FileInfo fi in rgFiles)
            {
                Console.WriteLine("Name: " + fi.Name + ", directory: " + fi.Directory); //new names
            }
            Console.ReadLine(); //press enter
        }
    }
}
