using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public class Key : AbstractObject, IItem, IUsable
    {
        public Key(string name, string description) : base(name, description)
        {
        }

        public void Use()
        {
            foreach (AbstractObject obj in currentRoom.GetObjects())
            {
                if (obj is Cage)
                {
                    (obj as Cage).Open();
                    return;
                }
            }
        }

        public bool WasUsed()
        {
            return false;
        }
    }
}
