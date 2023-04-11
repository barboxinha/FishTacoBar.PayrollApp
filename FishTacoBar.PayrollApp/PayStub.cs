using System.Collections.Generic;
using System.IO;
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
            string path;

            if (employees != null)
            {
                foreach (Staff employee in employees)
                {
                    path = employee.StaffName + ".txt";

                    using (StreamWriter sw = new StreamWriter(path, false))
                    {
                        sw.WriteLine("PAYSTUB FOR {0} {1}", (MonthsOfYear)_month, _year);
                        sw.WriteLine("==============================");
                        sw.WriteLine("Name: {0}", employee.StaffName);
                        sw.WriteLine("Hours Worked: {0}", employee.HoursWorked);
                        sw.WriteLine("");
                        sw.WriteLine("Basic Pay: {0:C}", employee.BasicPay);
                        // TODO - finish Paystub implementation
                    }
                } 
            }
        }

        enum MonthsOfYear
        {
            JAN = 1, FEB = 2, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC
        }
    }
}
