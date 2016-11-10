using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Customer:IFormattable
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        /// <summary>
        /// String representation of Customer object.
        /// </summary>
        /// <returns>Default string representation of object</returns>
        public override string ToString() => 
            this.ToString("G", CultureInfo.CurrentCulture);

        /// <summary>
        /// String representation of Customer object using the specified format
        /// </summary>
        /// <param name="format">String format. Can be "G","A","B","C","D". "G" by default</param>
        /// <returns>String representation of object with dafault culture</returns>
        public string ToString(string format) =>
            this.ToString(format, CultureInfo.CurrentCulture);

        /// <summary>
        /// String representation of Customer object using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">String format. Can be "G","A","B","C","D". "G" by default</param>
        /// <param name="provider">Format provider. CurrentCulture by default</param>
        /// <exception cref="FormatException">
        /// Throws if format specifier is not supported.
        /// </exception>
        /// <returns>String representation of object</returns>
        public string ToString(string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format)) format = "G";
            if (provider == null) provider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G": return $"Customer record: {Name}, {Revenue.ToString("0,0.00", provider)}, {ContactPhone}";
                case "A": return $"Customer record: {ContactPhone}";
                case "B": return $"Customer record: {Name}, {Revenue.ToString("0,0.00", provider)}";
                case "C": return $"Customer record: {Name}";
                case "D": return $"Customer record: {Revenue}";
                default:
                    throw new FormatException($"The {format} format specifier is not supported.");

            }
        }
    }
}
