using System;

namespace ExerciseTracking
{
    internal class Swimming : Activity
    {
        private const double MetersPerLap = 50.0;
        private const double MetersPerKilometer = 1000.0;
        private readonly int _laps;

        public Swimming(DateTime date, int minutes, int laps)
            : base(date, minutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            return _laps * MetersPerLap / MetersPerKilometer;
        }

        public override double GetSpeed()
        {
            double distance = GetDistance();
            return distance == 0 ? 0 : (distance / Minutes) * 60;
        }

        public override double GetPace()
        {
            double distance = GetDistance();
            return distance == 0 ? 0 : Minutes / distance;
        }
    }
}
