using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    internal class GoalManager
    {
        private readonly List<Goal> _goals = new();
        private int _score;
        private int _streakCount;
        private readonly string _saveFile;

        public GoalManager(string saveFile)
        {
            _saveFile = saveFile;
        }

        public int Score => _score;
        public IReadOnlyList<Goal> Goals => _goals;

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

        public void RecordGoal(int index)
        {
            if (index < 0 || index >= _goals.Count)
            {
                Console.WriteLine("That goal number does not exist.");
                return;
            }

            int gained = _goals[index].RecordEvent();
            _score += gained;
            _streakCount += 1;

            if (_streakCount % 3 == 0)
            {
                _score += 10;
                Console.WriteLine("Quest streak bonus! +10 points for three actions in a row.");
            }
        }

        public void DisplayGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet. Create one first.");
                return;
            }

            Console.WriteLine("\nYour Quest Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].Name} - {_goals[i].GetProgressText()}");
            }
        }

        public void DisplayScore()
        {
            int level = _score / 100 + 1;
            Console.WriteLine($"\nCurrent score: {_score}");
            Console.WriteLine($"Quest level: {level}");
            Console.WriteLine("You are on your way to becoming a legendary quest master!");
        }

        public void SaveProgress()
        {
            using StreamWriter writer = new(_saveFile);
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetSaveLine());
            }
            Console.WriteLine("Progress saved.");
        }

        public void LoadProgress()
        {
            if (!File.Exists(_saveFile))
            {
                Console.WriteLine("No saved quest found.");
                return;
            }

            string[] lines = File.ReadAllLines(_saveFile);
            if (lines.Length == 0)
            {
                return;
            }

            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                Goal goal = parts[0] switch
                {
                    "Simple" => new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])),
                    "Eternal" => new EternalGoal(parts[1], parts[2], int.Parse(parts[3])),
                    "Checklist" => new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[6]), int.Parse(parts[7])),
                    _ => throw new InvalidOperationException("Unknown goal type")
                };

                if (goal is ChecklistGoal checklist)
                {
                    checklist.LoadFromLine(parts);
                }
                else
                {
                    goal.LoadFromLine(parts);
                }

                _goals.Add(goal);
            }

            Console.WriteLine("Saved quest loaded.");
        }
    }
}
