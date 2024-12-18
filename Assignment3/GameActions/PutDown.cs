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
            if (actor == null) return;
            throw new NotImplementedException();
        }
    }
}
