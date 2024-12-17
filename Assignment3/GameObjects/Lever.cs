using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public class Lever : AbstractObject, IUsable
    {
        private bool active;
        private Spikes spikes;

        public Lever(string name, string description, Spikes spikes) : base(name, description)
        {
            ConnectSpikes(spikes);
        }

        public void ConnectSpikes(Spikes spikes)
        {
            this.spikes = spikes;
            active = true;
            if (!this.spikes.GetActive())
            {
                this.spikes.Toggle();
            }
        }

        public void Use()
        {
            active = !active;
            if (spikes != null)
            {
                spikes.Toggle();
            }
        }

        public bool WasUsed()
        {
            return false;
        }
    }
}
