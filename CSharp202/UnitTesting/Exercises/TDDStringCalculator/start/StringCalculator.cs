namespace TDDStringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if(string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            else if (numbers.IndexOf(',') != -1)
            {
                string[] vals = numbers.Split(",");
                return int.Parse(vals[0]) + int.Parse(vals[1]);
            }
            else
            {
                return int.Parse(numbers);
            }
        }
    }
}
