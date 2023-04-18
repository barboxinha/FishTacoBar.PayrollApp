#region Namespaces
using System;
using System.Collections.Generic;
using FishTacoBar.PayrollApp.Models;
using FishTacoBar.PayrollApp.Utils;
#endregion

namespace FishTacoBar.PayrollApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Staff> _employees;
            FileReader _reader = new FileReader();
            int _payMonth = 0;
            int _payYear = 0;

            Console.WriteLine("FISH TACO BAR - Payroll App");
            Console.WriteLine("***** =============== *****");

            // ***** Prompt user to input the year.
            while (_payYear == 0)
            {
                Console.WriteLine("\nPlease enter the year: ");

                try
                {
                    _payYear = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"Error: {fe.Message} \r\nPlease try again...");
                }
            }

            // ***** Prompt user to input the month.
            while (_payMonth == 0)
            {
                Console.WriteLine("\nPlease enter the month: ");

                try
                {
                    _payMonth = Convert.ToInt32(Console.ReadLine());

                    if (_payMonth < 1 || _payMonth > 12)
                    {
                        _payMonth = 0;
                        throw new FormatException("Month must be a value between 1-12.");
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"Error: {fe.Message} \r\nPlease try again...");
                }
            }

            // ***** Read the staff file.
            _employees = _reader.ReadFile();

            for (int i = 0; i < _employees.Count; i++)
            {
                try
                {
                    Console.WriteLine("\nEnter the hours worked by {0}:", _employees[i].StaffName);
                    _employees[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    _employees[i].CalculatePay();
                    Console.WriteLine(_employees[i].ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: Something went wrong. {e.Message} \r\nPlease try entering a value for hours worked again...");
                    i--;
                }
            }

            // ***** Generate pay stubs for each employee.
            PayStub payStub = new PayStub(_payMonth, _payYear);
            payStub.GeneratePayStub(_employees);
            payStub.GenerateShortTimeSummary(_employees);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
