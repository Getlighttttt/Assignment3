using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public class Spikes : AbstractObject
    {
        private bool active;

        public Spikes(string name, string description) : base(name, description)
        {
            active = true;
        }

        public void Toggle()
        {
            active = !active;
        }

        public override void Update()
        {
            foreach (AbstractObject obj in currentRoom.GetObjects())
            {
                if (obj is Princess)
                {
                    (obj as Princess).ChangeHealth(100);
                    return;
                }
            }
        }

        public bool GetActive()
        {
            return active;
        }
    }
}
