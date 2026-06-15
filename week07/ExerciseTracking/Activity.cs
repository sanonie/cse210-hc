using System;

namespace ExerciseTracking
{
    internal abstract class Activity
    {
        private readonly DateTime _date;
        private readonly int _minutes;

        protected Activity(DateTime date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        public DateTime Date => _date;
        public int Minutes => _minutes;

        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - " +
                   $"Distance {GetDistance():0.2} km, Speed {GetSpeed():0.2} kph, Pace: {GetPace():0.2} min per km";
        }
    }
}
