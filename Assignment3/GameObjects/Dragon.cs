using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public class Dragon : AbstractActor
    {
        public Dragon(string name, string description) : base(name, description)
        {
        }

        public override void ChangeHealth(int delta)
        {
            health = Math.Max(0, Math.Min(health + delta, 100));
            if (health <= 0)
            {
                currentRoom.RemoveFromRoom(this);
            }
        }

        public override void Update()
        {
            foreach (AbstractObject obj in currentRoom.GetObjects())
            {
                if(obj is Princess) {
                    (obj as Princess).ChangeHealth(20);
                    return;
            }
        }
    }
}
