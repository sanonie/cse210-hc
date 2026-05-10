namespace Resumes
{
    public class Job
    {
        public string _company = string.Empty;
        public string _jobTitle = string.Empty;
        public int _startYear;
        public int _endYear;

        public void Display()
        {
            System.Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
        }
    }
}
