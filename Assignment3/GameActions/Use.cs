using Assignment3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameActions
{
    public class Use : IAction
    {
        private IUsable toBeUsed;

        public Use(IUsable toBeUsed)
        {
            this.toBeUsed = toBeUsed;
        }

        public void Execute(AbstractActor actor)
        {
            throw new NotImplementedException();
        }
    }
}
