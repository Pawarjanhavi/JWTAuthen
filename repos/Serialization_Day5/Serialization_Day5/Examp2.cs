using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization_Day5
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
    internal class Examp2
    {
        public static string SerializeToXml(Customer customer)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Customer));
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, customer);
                return sw.ToString();
            }
        }

        public static Customer DeserializerFromXml(string xml)

        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Customer));
            using (StringReader sr = new StringReader(xml))
            {
                return (Customer)xmlSerializer.Deserialize(sr);
            }
        }

        static void Main(string[] args)
        {
            Customer customer = new Customer { CustomerId = 123, FirstName = "Janhavi", LastName = "Pawar" };
            string xml = SerializeToXml(customer);
            Console.WriteLine("Serialized to XML : \n" + xml);

            Customer deCust = DeserializerFromXml(xml);
            Console.WriteLine("Deserialized XML");
            Console.WriteLine(deCust.FirstName);
        }
    }
}
