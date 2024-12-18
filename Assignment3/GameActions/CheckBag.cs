using Assignment3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameActions
{
    public class CheckBag : IAction
    {
        public CheckBag() { }

        public void Execute(AbstractActor actor)
        {
            if (actor == null) return;
            AbstractObject backpack = (actor as Princess).GetBackpack() as AbstractObject;
            if (backpack != null)
            {
                Console.WriteLine($"The princess has {backpack.GetName()} in her backpack");
            }
        }
    }
}
