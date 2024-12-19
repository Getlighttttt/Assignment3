using Assignment3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameActions
{
    public class PickUp : IAction
    {
        private IItem toBePicked;

        public PickUp(IItem toBePickedUp)
        {
            toBePicked = toBePickedUp;
        }

        public void Execute(AbstractActor actor)
        {
            if (actor == null && actor is Princess) return;
            if (toBePicked is IItem)
            {
                if ((actor as Princess).GetBackpack() == null)
                {
                    Console.WriteLine("My backpack is full.");
                }
                else
                {
                    (actor as Princess).AddToBackPack(toBePicked);
                }
            }
            else
            {
                Console.WriteLine("I do not understand what you mean.");
            }
        }
    }
}
