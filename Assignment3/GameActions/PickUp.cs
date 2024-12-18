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
            if (actor == null) return;
            throw new NotImplementedException();
        }
    }
}
