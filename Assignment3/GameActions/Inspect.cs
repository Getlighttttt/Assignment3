using Assignment3.GameObjects;
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
            throw new NotImplementedException();
        }
    }
}
