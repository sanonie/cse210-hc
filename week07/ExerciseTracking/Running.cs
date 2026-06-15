using System;

namespace ExerciseTracking
{
    internal class Running : Activity
    {
        private readonly double _distance;

        public Running(DateTime date, int minutes, double distance)
            : base(date, minutes)
        {
            _distance = distance;
        }

        public override double GetDistance()
        {
            return _distance;
        }

        public override double GetSpeed()
        {
            return _distance == 0 ? 0 : (_distance / Minutes) * 60;
        }

        public override double GetPace()
        {
            return _distance == 0 ? 0 : Minutes / _distance;
        }
    }
}
