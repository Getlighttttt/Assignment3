using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public class FrogPrince : AbstractActor, IPrince
    {
        public FrogPrince(string name, string description) : base(name, description)
        {
        }

        public void Kissed()
        {
            HumanPrince prince = new HumanPrince(name, "prince in his human form");
            currentRoom.AddToRoom(prince);
            prince.AddToRoom(currentRoom);

            currentRoom.RemoveFromRoom(this);
        }
    }
}
