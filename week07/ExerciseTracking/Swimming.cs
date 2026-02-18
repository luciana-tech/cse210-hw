using System;

public class Swimming : Activity
{
    private int _laps;
    private const double LAP_LENGTH_MILES = 0.031; // 50 meters in miles (50/1000 * 0.62)

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * LAP_LENGTH_MILES;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}