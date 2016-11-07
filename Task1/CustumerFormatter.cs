using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class CustumerFormatter:IFormatProvider,ICustomFormatter
    {
        public object GetFormat(Type formatType)=>
             formatType == typeof(ICustomFormatter) ? this : null;
        
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (ReferenceEquals(arg, null))
                throw new ArgumentNullException(nameof(arg));

            // Check whether this is an appropriate callback.
            if (!this.Equals(formatProvider))
                return null;

            Customer customer = arg as Customer;
            if (ReferenceEquals(customer, null))
                return arg.ToString();

            if (string.IsNullOrEmpty(format))
                format = "G";

            switch (format.ToUpperInvariant())
            {
                case "E": return $"Customer record: {customer.Name}, {customer.Revenue.ToString("F2", formatProvider)}, {customer.ContactPhone}";
                case "F": return $"Customer record: Name {customer.Name}, Telehpone {customer.ContactPhone}";
                default:
                    throw new FormatException($"The {format} format specifier is not supported.");

            }
        }
    }
}
