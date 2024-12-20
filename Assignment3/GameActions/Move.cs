﻿using Assignment3.GameObjects;
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
            if (actor == null && actor is Princess) return;

            Room room = actor.GetRoom();

            if (room.GetObjectNames().Contains("Smaug"))
            {
                Console.WriteLine("There is a dragon in the current room");
                return;
            }

            if (room.GetDirections().Contains(direction.ToString().ToLower()))
            {
                (actor as Princess).MoveToRoom(room.GetNeighbor(direction));
            }
            else
            {
                Console.WriteLine("I cannot go there.");
            }
        }
    }
}
