using Assignment3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameWorld
{
    public class DarkRoom : Room
    {
        public DarkRoom(string roomName, string description, World world) : base(roomName, description, world) { }

        public override List<string> GetObjectNames()
        {
            if (objects.OfType<Torch>().Any(torch => (torch as Torch).IsActive()))
            {
                return objects.Select(obj => obj.GetName()).ToList();
            }

            return new List<string>();
        }
    }
}
