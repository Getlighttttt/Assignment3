using Assignment3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameActions
{
    public class LookAround : IAction
    {
        public LookAround() { }

        public void Execute(AbstractActor actor)
        {
            if (actor == null) return;

            string backpackName = null;
            if ((actor as Princess).GetBackpack() is AbstractObject backpackObject)
            {
                backpackName = backpackObject.GetName();
            }

            List<string> names = actor.GetRoom().GetObjectNames();
            names = names.Where(name => name != actor.GetName() && name != backpackName).ToList();

            if (names.Count == 0)
            {
                Console.WriteLine("You don’t see anything.");
            }
            else
            {
                Console.WriteLine($"You see: {string.Join(" ", names)}");   
            }
        }
    }
}
