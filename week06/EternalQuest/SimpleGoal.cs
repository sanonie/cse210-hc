namespace EternalQuest
{
    internal class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            int earned = base.RecordEvent();
            if (earned > 0)
            {
                MarkComplete();
            }

            return earned;
        }

        public override string GetSaveLine()
        {
            return $"Simple|{Name}|{Description}|{Points}|{IsComplete}";
        }
    }
}
