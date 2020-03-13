using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Text.Json;

namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            String path, resultPath, dataType;
            if (args.Length != 3)
            {
                path = "data.csv";
                resultPath = "żesult.xml";
                dataType = "xml";
            } else
            {
                path = args[0];
                resultPath = args[1];
                dataType = args[2];
            }
            if (args[2] != "xml" || args[2] != "json")
            {
                args[2] = "xml";
            }
            try
            {
                var lines = File.ReadLines(path);

                StreamWriter sw = new StreamWriter("log.txt");

                var hashSet = new HashSet<Student>(new OwnComparer());

                var parsedDate = DateTime.Parse("2020-03-09");
                var today = DateTime.Today;


                foreach (var line in lines)
                {
                    String[] data = line.Split(",");
                    if (data.Length == 9)
                    {
                        foreach (var item in data)
                        {
                            if (string.IsNullOrEmpty(item))
                            {
                                sw.WriteLine(line);
                            }
                            else
                            {
                                var student = new Student()
                                {
                                    FirstName = data[0],
                                    LastName = data[1],
                                    Studies = new Studies
                                    {
                                        StudiesName = data[2],
                                        StudiesMode = data[3]
                                    },
                                    Index = data[4],
                                    BirthDate = DateTime.Parse(data[5]).ToShortDateString(),
                                    Mail = data[6],
                                    Mother = data[7],
                                    Father = data[8]
                                };
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

                var list = new List<Student>();
                foreach (var item in hashSet)
                {
                    list.Add(item);
                }

                if (dataType == "xml")
                {
                    FileStream writer = new FileStream(resultPath, FileMode.Create);
                    XmlRootAttribute xmlRootAttribute = new XmlRootAttribute();
                    xmlRootAttribute.ElementName = "uczelnia";

                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("createdAt", today.ToShortDateString());
                    ns.Add("author", "Michał Pazio");

                    XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), xmlRootAttribute);
                    serializer.Serialize(writer, list, ns);
                }
                if (dataType == "json")
                {
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };

                    var jsonString = JsonSerializer.Serialize(list, options);
                    File.WriteAllText(resultPath, jsonString);
                }



                //Console.WriteLine(today.ToShortDateString());
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Podana ścieżka jest niepoprawna");
                StreamWriter sw = new StreamWriter("log.txt");
                sw.WriteLine("Podana ścieżka jest niepoprawna");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Plik nazwa nie istnieje");
                StreamWriter sw = new StreamWriter("log.txt");
                sw.WriteLine("Plik nazwa nie istnieje");
            }
            
        }
    }
}
