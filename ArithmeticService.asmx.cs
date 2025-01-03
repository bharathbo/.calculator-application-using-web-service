using System;
using System.Web.Services;

namespace XmlLoginRegisterApp
{
   
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ArithmeticService : System.Web.Services.WebService
    {
        [WebMethod]
        public double Add(double value1, double value2)
        {
            return value1 + value2;
        }

        [WebMethod]
        public double Subtract(double value1, double value2)
        {
            return value1 - value2;
        }

        [WebMethod]
        public double Multiply(double value1, double value2)
        {
            return value1 * value2;
        }

        [WebMethod]
        public double Divide(double value1, double value2)
        {
            if (value2 != 0)
                return value1 / value2;
            else
                throw new DivideByZeroException("Cannot divide by zero.");
        }
    }
}
