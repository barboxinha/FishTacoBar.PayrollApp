using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FishTacoBar.PayrollApp.Models;

namespace FishTacoBar.PayrollApp
{
    public class PayStub
    {
        private int _month;
        private int _year;

        public PayStub(int payMonth, int payYear)
        {
            _month = payMonth;
            _year = payYear;
        }

        public void GeneratePayStub(List<Staff> employees)
        {
            Console.WriteLine("...Generating paystubs for {0} employees.", employees.Count);
            string filePath;

            if (employees != null)
            {
                foreach (Staff employee in employees)
                {
                    filePath = employee.StaffName + ".txt";

                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        sw.WriteLine("PAYSTUB FOR {0} {1}", (MonthsOfYear)_month, _year);
                        sw.WriteLine("==============================");
                        sw.WriteLine("Name: {0}", employee.StaffName);
                        sw.WriteLine("Hours Worked: {0}", employee.HoursWorked);
                        sw.WriteLine("");
                        sw.WriteLine("Basic Pay: {0:C}", employee.BasicPay);

                        if (employee.GetType() == typeof(Manager))
                        {
                            sw.WriteLine("Allowance: {0:C}", ((Manager)employee).Allowance);
                        }
                        else if (employee.GetType() == typeof(Admin))
                        {
                            sw.WriteLine("Overtime: {0:C}", ((Admin)employee).Overtime);
                        }

                        sw.WriteLine("");
                        sw.WriteLine("==============================");
                        sw.WriteLine("Total Pay: {0:C}", employee.TotalPay);
                        sw.WriteLine("==============================");

                        sw.Close();
                    }
                }

                Console.WriteLine("Completed! Paystubs generated successfully.");
            }
            else
            {
                Console.WriteLine("Failed: No paystubs generated. No employees provided.");
            }
        }

        public void GenerateShortTimeSummary(List<Staff> employees)
        {
            Console.WriteLine("...Generating short-time summary.");

            var shortTimeQuery = from employee in employees
                                 where employee.HoursWorked < 10
                                 orderby employee.StaffName ascending
                                 select new { employee.StaffName, employee.HoursWorked};

            string filePath = "summary.txt";

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");

                foreach (var emp in shortTimeQuery)
                {
                    sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", emp.StaffName, emp.HoursWorked); 
                }

                sw.Close();
            }

            Console.WriteLine("Completed! Short-time summary generated successfully.");
        }

        public override string ToString()
        {
            return "_month = " + _month + 
                   "\n_year = " + _year;
        }

        enum MonthsOfYear
        {
            JAN = 1, FEB = 2, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC
        }
    }
}
