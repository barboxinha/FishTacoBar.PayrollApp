namespace FishTacoBar.PayrollApp.Models
{
    public class Manager : Staff
    {
        private const float _managerHourlyRate = 60;
        public int Allowance { get; private set; }

        public Manager(string name) : base(name, _managerHourlyRate)
        {
        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;

            if (HoursWorked > 160)
            {
                TotalPay = BasicPay + Allowance;
            }
        }

        public override string ToString()
        {
            return "\nStaffName = " + StaffName +
                   "\n_managerHourlyRate = " + _managerHourlyRate +
                   "\nHoursWorked = " + HoursWorked +
                   "\nBasicPay = " + BasicPay +
                   "\nAllowance = " + Allowance +
                   "\n\nTotalPay = " + TotalPay;
        }
    }
}
