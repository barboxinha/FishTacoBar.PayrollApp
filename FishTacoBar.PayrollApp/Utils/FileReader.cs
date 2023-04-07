using System;
using System.Collections.Generic;
using System.IO;
using FishTacoBar.PayrollApp.Models;

namespace FishTacoBar.PayrollApp.Utils
{
    public class FileReader
    {
        public List<Staff> ReadFile() 
        {
            List<Staff> employees = new List<Staff>();
            string filePath = "staff.txt";
            string[] separator = { ", " };
            string[] result = new string[2];

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        result = sr.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

                        if (result[1] == "Manager")
                        {
                            employees.Add(new Manager(result[0]));
                        }
                        else if (result[1] == "Admin")
                        {
                            employees.Add(new Admin(result[0]));
                        }
                        else
                        {
                            employees.Add(new Staff(result[0], 25f));
                        }
                    }

                    sr.Close();
                }
            }
            else
            {
                Console.WriteLine("ERROR: File does not exist. Please add a file \"staff.txt\" to the app directory.");
            }

            return employees;
        }
    }
}
