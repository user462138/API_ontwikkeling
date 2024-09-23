using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoorbeeldDiSamurai
{
    public class Gun : IWeapon
    {
        private readonly ITrigger _trigger;

        public Gun(ITrigger trigger)
        {
            _trigger = trigger;
        }

        public void Hit(string target)
        {
            Console.WriteLine($"Chopped {target} clean in half");
/*            _trigger.Pull();
*/        }
    }
}
