using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemDriveInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Drivelnfo *****\n");
            // Получить информацию обо всех устройствах.
            DriveInfo[] myDrives = DriveInfo.GetDrives();
            // Вывести сведения об устройствах.
            foreach (DriveInfo d in myDrives)
            {
                Console.WriteLine("Name: {0}", d.Name); // имя
                Console.WriteLine("Type: {0}", d.DriveType); // тип
                                                             // Проверить, смонтировано ли устройство.
                if (d.IsReady)
                {
                    Console.WriteLine("Free space: {0}", d.TotalFreeSpace);
                    // Свободное пространство
                    Console.WriteLine("Format: {0}", d.DriveFormat); // формат
                    Console.WriteLine("Label: {0}", d.VolumeLabel); // метка
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
