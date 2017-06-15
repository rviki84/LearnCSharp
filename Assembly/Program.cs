using System;
using System.Reflection;

namespace Assembly
{
    public class Calculator
    {
        public Calculator(double number)
        { 
            _number = number;
        }
        public Calculator() { }
        private double _number;
        public double Number { get; set; }
        public void Clear() { }
        private void DoClear() { }
        public double Add(double number) 
        { 
            return number + _number;
        }
        public static double Pi { get; }
        public static double GetPi() { return 3.14; }


        public static void Main(string[] args)
        {
            // create instance of DateTime, use constructor with parameters (year, month, day)
            //DateTime dateTime = (DateTime)Activator.CreateInstance(typeof(DateTime), new object[] { 2008, 7, 4 });
            //Console.WriteLine(dateTime.Date);

            // dynamically load assembly from file Test.dll
            System.Reflection.Assembly testAssembly = typeof(Calculator).Assembly;

            // get type of class Calculator from just loaded assembly
            Type calcType = testAssembly.GetType("Assembly.Calculator");

            // create instance of class Calculator
            object calcInstance = Activator.CreateInstance(calcType);

            // get info about property: public double Number
            PropertyInfo numberPropertyInfo = calcType.GetProperty("Number");

            // set value of property: public double Number
            numberPropertyInfo.SetValue(calcInstance, 10.0, null);

            // get value of property: public double Number
            double value = (double)numberPropertyInfo.GetValue(calcInstance, null);

            Console.WriteLine("Value: {0}", value);
        }
    }
}
