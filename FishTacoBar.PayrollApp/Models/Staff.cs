using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTacoBar.PayrollApp.Models
{
    public class Staff
    {
        private float _hourlyRate;
        private int _hoursWorked;

        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string StaffName { get; private set; }

        public int HoursWorked
        {
            get { return _hoursWorked; }
            set 
            {
                _hoursWorked = value > 0 ? value : 0;
            }
        }

        public Staff(string name, float rate)
        {
            StaffName = name;
            _hourlyRate = rate;
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");

            BasicPay = _hoursWorked * _hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "\nStaffName = " + StaffName +
                   "\n_houryRate = " + _hourlyRate +
                   "\n_hoursWorked = " + _hoursWorked +
                   "\nBasicPay = " + BasicPay +
                   "\n\nTotalPay = " + TotalPay;
        }
    }
}
