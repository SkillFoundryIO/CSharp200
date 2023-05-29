using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter
{
    public class Temperature
    {
        private double _kelvin;
        public double Kelvin
        {
            get
            {
                return _kelvin;
            }
            set
            {
                if (value < 0)
                {
                    _kelvin = 0;
                }
                else
                {
                    _kelvin = value;
                }
            }
        }

        public double Celsius
        {
            get { return _kelvin - 273.15; }
        }

        public double Fahrenheit
        {
            get { return (_kelvin - 273.15) * 9 / 5 + 32; }
        }
    }
}
