using System.Collections.Generic;

namespace Resumes
{
    public class Resume
    {
        public string _name = string.Empty;
        public List<Job> _jobs = new List<Job>();

        public void Display()
        {
            System.Console.WriteLine(_name);
            foreach (Job job in _jobs)
            {
                job.Display();
            }
        }
    }
}
