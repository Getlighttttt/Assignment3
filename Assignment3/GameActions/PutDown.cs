using Assignment3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameActions
{
    public class PutDown : IAction
    {
        public PutDown() { }

        public void Execute(AbstractActor actor)
        {
            if (actor == null && actor is Princess) return;
            if ((actor as Princess).GetBackpack() == null)
            {
                Console.WriteLine("There is nothing in my backpack.");
            }
            else
            {
                (actor as Princess).EmptyBackPack();
            }
        }
    }
}
