using System;
using VoorbeeldDiSamurai;

namespace OplossingDiOefeningSamurai
{
    public class ManualTrigger : ITrigger
    {
        public void Pull()
        {
            Console.WriteLine("Pulling the manual trigger");
        }
    }
}
