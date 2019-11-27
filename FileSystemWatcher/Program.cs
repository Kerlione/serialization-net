using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotNamespace = System.IO.FileSystemWatcher;

namespace FileSystemWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Amazing File Watcher App *****\n");
            NotNamespace watcher = new NotNamespace();
            try
            {
                watcher.Path = @".\PERSON";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            watcher.NotifyFilter = NotifyFilters.LastAccess
            | NotifyFilters.LastWrite
            | NotifyFilters.FileName
            | NotifyFilters.DirectoryName;

            watcher.Filter = "persons*.dat";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.EnableRaisingEvents = true;
            Console.WriteLine(@"Press q to quit app.");
            while (Console.Read() != 'q') ;
        }
        static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Показать, что сделано, если файл изменен, создан или удален.
            Console.WriteLine("File : {0} {1}!,", e.FullPath, e.ChangeType);
        }
        static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Показать, что файл был переименован.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }

    }
}
