using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public class HumanPrince : AbstractActor, IPrince
    {
        public HumanPrince(string name, string description) : base(name, description)
        {
        }

        public void Kissed()
        {
            currentRoom.GetWorld().SetWin();
        }
    }
}
