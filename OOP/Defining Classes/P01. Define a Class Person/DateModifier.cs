using System;

namespace P01._Define_a_Class_Person
{
    public class DateModifier
    {
        public void DifferenceBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            var ts = firstDate - secondDate;
            var totalDays = Math.Abs(ts.Days);

            Console.Write(totalDays);
        }
    }
}
