using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LR_4
{
    class Program
    {
        private static string filePath = @".\PERSON\persons.dat";
        static void Main(string[] args)
        {
            var persons = new ArrayList();
            CheckDirectory();
            CheckForFile();
            Console.Write("\n\nPlease, enter the count of persons: ");
            var personCount = Convert.ToInt32(Console.ReadLine());
            if (personCount > 0)
            {
                persons = ReadFromFile();
                var newPersons = GeneratePersons(personCount);
                foreach(var person in newPersons)
                {
                    persons.Add(person);
                }
                WriteToFile(persons);
            }            Console.ReadLine();
            persons = ReadFromFile();
            foreach(Person person in persons)
            {
                Console.WriteLine($"{person.FirstName}, {person.LastName}, {person.PersonalIdentifier}");
            }            Console.ReadLine();
        }

        private static ArrayList ReadFromFile()
        {
            ArrayList res = new ArrayList();
            BinaryFormatter binFormat = new BinaryFormatter();
            using (var fStream = new FileStream(filePath,
             FileMode.Open, FileAccess.Read))
            {
                if(fStream.Length > 0)
                {
                    fStream.Seek(0, 0);
                    res = binFormat.Deserialize(fStream) as ArrayList;
                    fStream.Close();
                }
            }
            return res;
        }

        private static ArrayList GeneratePersons(int personCount)
        {
            var persons = new ArrayList();
            for (int i = 0; i < personCount; i++)
            {
                persons.Add(new Person());
            }
            return persons;
        }

        private static void CheckDirectory()
        {
            DirectoryInfo dir1 = new DirectoryInfo(@".\PERSON");
            if (!dir1.Exists)
            {
                Console.WriteLine("Folder PERSON does not exist!\nCreating folder PERSON");
                dir1.Create();
            }
            else Console.WriteLine("The folder PERSON exist!");
        }

        private static void CheckForFile()
        {
            FileInfo file = new FileInfo(filePath);
            if (!file.Exists)
            {
                Console.WriteLine("The file persons.dat does not exist!\nCreating file persons.dat");


                file.Create().Close();
            }
            file = new FileInfo(@".\PERSON\persons.dat");
            Console.WriteLine("The file persons.dat exist!");
            Console.WriteLine("***************************");
            Console.WriteLine("File name: {0}", file.Name);
            Console.WriteLine("File size: {0}", file.Length);
            Console.WriteLine("Creation: {0}", file.CreationTime);
            Console.WriteLine("Attributes: {0}", file.Attributes);
            Console.WriteLine("***************************\n");
        }

        public static void WriteToFile(ArrayList target)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using(var fStream = new FileStream(filePath,
             FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                binFormat.Serialize(fStream, target);
                fStream.Close();
            }
        }
    }
}