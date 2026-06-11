namespace EternalQuest
{
    internal class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            return base.RecordEvent();
        }

        public override string GetSaveLine()
        {
            return $"Eternal|{Name}|{Description}|{Points}|{IsComplete}";
        }
    }
}
