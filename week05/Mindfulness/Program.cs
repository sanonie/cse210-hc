using System;
using System.Threading;
using System.Collections.Generic;

namespace Mindfulness
{
    // Exceeded requirements: Added a simple session logger and ensured prompts/questions are not repeated until all have been used.
    class Program
    {
        static void Main(string[] args)
        {
            var app = new MindfulnessApp();
            app.Run();
        }
    }
}
