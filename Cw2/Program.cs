using System;
using System.Collections.Generic;
using System.IO;

namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\s18451\Desktop\dane.csv";

            var lines = File.ReadLines(path);

            var sw = new StreamWriter("log.txt");

            var hashSet = new HashSet<Student>();

            var parsedDate = DateTime.Parse("2020-03-09");
            var today = DateTime.Today;


            foreach (var line in lines)
            {
                String[] data = line.Split(",");
                if(data.Length == 9)
                {
                    foreach (var item in data)
                    {
                        if (string.IsNullOrEmpty(item))
                        {
                            sw.WriteLine(line);
                        } else
                        {
                            var student = new Student() { FirstName = data[0], LastName = data[1], StudiesName = data[2], StudiesMode = data[3], Index = data[4], BirthDate = DateTime.Parse(data[5]).ToString(), Mail = data[6], Mother = data[7], Father = data[8] };
                            if (!hashSet.Contains(student))
                            {
                                hashSet.Add(student);
                            }
                        }
                    }
                }
                else
                {
                    sw.WriteLine(line);
                }
                //Console.WriteLine(line);
            }
            sw.Close();

            foreach (var item in hashSet)
            {
                Console.WriteLine(item);
            }



            //Console.WriteLine(today.ToShortDateString());
        }
    }
}
