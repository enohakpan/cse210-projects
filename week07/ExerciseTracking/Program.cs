using System;
using System.Collections.Generic;

abstract class Activity
{
    private DateTime _date;
    private int _duration; // in mins

    public Activity(DateTime date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    public DateTime GetDate() => _date;
    public int GetDuration() => _duration;

    public abstract double GetDistance(); // in miles
    public abstract double GetSpeed();    // in mph
    public abstract double GetPace();     // in min per mile

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_duration} min) - " +
               $"Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min/mile";
    }
}

class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int duration, double distance)
        : base(date, duration)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / GetDuration()) * 60;
    public override double GetPace() => GetDuration() / _distance;
}

class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int duration, double speed)
        : base(date, duration)
    {
        _speed = speed;
    }

    public override double GetSpeed() => _speed;
    public override double GetDistance() => (_speed * GetDuration()) / 60;
    public override double GetPace() => 60 / _speed;
}

class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int duration, int laps)
        : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0 * 0.62; // miles
    public override double GetSpeed() => (GetDistance() / GetDuration()) * 60;
    public override double GetPace() => GetDuration() / GetDistance();
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 04, 3), 15, 3.0),
            new Cycling(new DateTime(2025, 04, 4), 60, 15.0),
            new Swimming(new DateTime(2025, 4, 7), 40, 30)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}