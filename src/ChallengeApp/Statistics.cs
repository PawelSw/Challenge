public class Statistics
{
    public double High;
    public double Low;
    public double Sum;
    public int Count;

    public Statistics()
    {
        Sum = 0.0;
        Count = 0;
        Low = double.MaxValue;
        High = double.MinValue;
    }
    public double Average
    {
        get
        {
            return Sum / Count;
        }
    }
    public char Letter
    {
        get
        {

            switch (Average)
            {
                case >= 6:
                    return 'A';

                case >= 5:
                    return 'B';

                case >= 4:
                    return 'C';

                case >= 3:
                    return 'D';

                default:
                    return 'F';
            }
        }
    }
    public void Add(double number)
    {
        Sum += number;
        Count += 1;
        Low = Math.Min(number, Low);
        High = Math.Max(number, High);
    }
}