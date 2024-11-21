using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSModel
{
    //student, employee,business, houseMaker,wage employed,kid,etc
    public abstract class Person : IGeneralRules
    {
        public string PersonName { get; set; }
        public string PanNo { get; set; }
        public long Aadhar { get; set; }

        long? _passport;
        public long? PassportNo
        {
            get
            {
                if (_passport == null)
                {
                    Console.WriteLine("Passport not available");
                    return null;
                }
                else
                {
                    return _passport;
                }

            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Passport not available");
                }
                else
                {
                    _passport = value;

                }
            }
        }

        int _age;
        public int Age
        {
            get
            {
                _age = DateTime.Now.Year - DOB.Year;
                return _age;

            }
            private set
            {
                _age = value;
            }
        }

        public DateTime DOB { private get; set; }
        long IGeneralRules.PassportNo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public abstract void PrintDetails();



    }


    public class Student : Person
    {
        public override void PrintDetails()
        {
            throw new NotImplementedException();

        }
    }


    public class HouseMaker : Person
    {
        public override void PrintDetails()
        {
            Console.WriteLine(base.Aadhar);
            Console.WriteLine(base.Age);
            Console.WriteLine(base.PersonName);
            Console.WriteLine(base.PanNo);
            Console.WriteLine(base.PassportNo);
        }
    }

}