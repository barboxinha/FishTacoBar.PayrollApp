namespace FishTacoBar.PayrollApp.Models
{
    public class Admin : Staff
    {
        private const float _overtimeRate = 15.5f;
        private const float _adminHourlyRate = 30;

        public float Overtime { get; private set; }

        public Admin(string name) : base(name, _adminHourlyRate)
        {
        }

        public override void CalculatePay()
        {
            base.CalculatePay();

            if (HoursWorked > 160)
            {
                Overtime = _overtimeRate * (HoursWorked - 160);
            }
        }

        public override string ToString()
        {
            return "\nStaffName = " + StaffName +
                   "\n_overtimeRate = " + _overtimeRate +
                   "\n_adminHourlyRate = " + _adminHourlyRate +
                   "\nHoursWorked = " + HoursWorked +
                   "\nOvertime = " + Overtime +
                   "\nBasicPay = " + BasicPay +
                   "\n\nTotalPay = " + TotalPay;
        }
    }
}
