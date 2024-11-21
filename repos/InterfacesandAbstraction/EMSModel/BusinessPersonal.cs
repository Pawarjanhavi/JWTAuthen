using EMSModel;
using EMSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSModels
{
    public class BusinessPersonal : ITaxCalculations, ISalaryCalculations
    {
        //Director
        public int Sal { get; set; }
        public string PanNo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long Aadhar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long PassportNo { get; set; }

        public double CalculateDeductions(double amt)
        {
            throw new NotImplementedException();
        }

        public double CalculateSalary(double bs, double hra, double ta)
        {
            throw new NotImplementedException();
        }

        public double CalculateSalaryAfterTax(double sal)
        {
            throw new NotImplementedException();
        }

        public double CalculateTax(double sal)
        {
            throw new NotImplementedException();
        }
    }
}