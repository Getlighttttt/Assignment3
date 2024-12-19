using Assignment3.GameObjects;
using Assignment3.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameActions
{
    public class Inspect : IAction
    {
        private AbstractObject toBeExplored;

        public Inspect(AbstractObject toBeExplored)
        {
            this.toBeExplored = toBeExplored;
        }

        public void Execute(AbstractActor actor)
        {
            if (actor == null || actor is not Princess) return;
            if (toBeExplored != null && (actor.GetRoom().GetObjectWithName(toBeExplored.GetName()) != null || toBeExplored == ((actor as Princess).GetBackpack() as AbstractObject)))
            {
                Console.WriteLine(toBeExplored.GetDescription());
            }
            else
            {
                Console.WriteLine("I do not understand what you mean.");
            }
        }
    }
}
