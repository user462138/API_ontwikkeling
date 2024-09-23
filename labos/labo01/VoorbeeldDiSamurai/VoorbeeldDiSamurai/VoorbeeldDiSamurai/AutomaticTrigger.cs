using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoorbeeldDiSamurai;

namespace OplossingDiOefeningSamurai
{
    public class AutomaticTrigger : ITrigger
    {
        public void Pull()
        {
            Console.WriteLine("Pulling the automatic trigger");
        }
    }
}