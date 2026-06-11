using System;

namespace EternalQuest
{
    internal class ChecklistGoal : Goal
    {
        private int _completedCount;
        private readonly int _targetCount;
        private readonly int _bonusPoints;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            _completedCount = 0;
            _targetCount = targetCount;
            _bonusPoints = bonusPoints;
        }

        public int CompletedCount => _completedCount;
        public int TargetCount => _targetCount;

        public override int RecordEvent()
        {
            _completedCount += 1;
            int earned = Points;

            if (_completedCount >= _targetCount)
            {
                earned += _bonusPoints;
                MarkComplete();
                Console.WriteLine($"Bonus! You earned {_bonusPoints} extra points for finishing {Name}.");
            }

            Console.WriteLine($"You earned {earned} points for {Name}.");
            return earned;
        }

        public override string GetStatus()
        {
            return _completedCount >= _targetCount ? "[X]" : "[ ]";
        }

        public override string GetProgressText()
        {
            return $"{Description} (Completed {CompletedCount}/{TargetCount} times)";
        }

        public override string GetSaveLine()
        {
            return $"Checklist|{Name}|{Description}|{Points}|{IsComplete}|{_completedCount}|{_targetCount}|{_bonusPoints}";
        }

        public override void LoadFromLine(string[] parts)
        {
            base.LoadFromLine(parts);
            _completedCount = int.Parse(parts[5]);
        }
    }
}
