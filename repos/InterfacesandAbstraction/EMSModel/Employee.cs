using EMSModel;
 namespace EMSModel
    {
        public class Employee : GeneralEmployee, ISalaryCalculations, ITaxCalculations
        {
            public int Sal { get; set; }

            public double Deductions { get; set; }
            public string? PanNo { get; set; }
            public long Aadhar { get; set; }
            public long PassportNo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public double CalculateDeductions(double amt)
            {
                // throw new NotImplementedException();

                Deductions = amt - (amt * .50);
                return Deductions;
            }

            public double CalculateSalary(double bs, double hra, double ta)
            {
                return bs + hra + ta;
            }

            public double CalculateSalaryAfterTax(double sal)
            {
                return sal - (sal * .10);
            }

            public double CalculateTax(double sal)
            {
                return Sal - Deductions;

            }
        }
    }
