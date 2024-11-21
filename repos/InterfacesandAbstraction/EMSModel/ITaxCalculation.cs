using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSModel
{
    internal interface IGeneralRules
    {

        public string PanNo { get; set; }
        public long Aadhar { get; set; }

        public long PassportNo { get; set; }

    }


    internal interface ITaxCalculations : IGeneralRules
    {

        int Sal { get; set; }

        double CalculateTax(double sal);

        double CalculateDeductions(double amt);

        double CalculateSalaryAfterTax(double sal);



    }

    internal interface ISalaryCalculations
    {
        double CalculateSalary(double bs, double hra, double ta);


    }





}