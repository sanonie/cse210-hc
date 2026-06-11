using System;

namespace EternalQuest
{
    internal abstract class Goal
    {
        private readonly string _name;
        private readonly string _description;
        private readonly int _points;
        private bool _isComplete;

        protected Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isComplete = false;
        }

        public string Name => _name;
        public string Description => _description;
        public int Points => _points;
        public bool IsComplete => _isComplete;

        protected void MarkComplete() => _isComplete = true;

        public virtual int RecordEvent()
        {
            if (_isComplete)
            {
                Console.WriteLine("That goal is already finished.");
                return 0;
            }

            Console.WriteLine($"You earned {_points} points for {_name}!");
            return _points;
        }

        public virtual string GetStatus()
        {
            return _isComplete ? "[X]" : "[ ]";
        }

        public virtual string GetProgressText()
        {
            return _description;
        }

        public abstract string GetSaveLine();

        public virtual void LoadFromLine(string[] parts)
        {
            _isComplete = bool.Parse(parts[4]);
        }
    }
}

