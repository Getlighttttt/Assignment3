using Assignment3.GameObjects;
using Assignment3.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameActions
{
    public class Move : IAction
    {
        private Directions direction;

        public Move(Directions direction)
        {
            this.direction = direction;
        }

        public void Execute(AbstractActor actor)
        {
            throw new NotImplementedException();
        }
    }
}
