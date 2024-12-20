﻿using Assignment3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameActions
{
    public class Exit : IAction
    {
        public Exit() { }

        public void Execute(AbstractActor actor)
        {
            if (actor == null || actor is not Princess) return;
            actor.GetRoom().GetWorld().SetDone();
        }
    }
}
