using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public class Sword : AbstractObject, IItem, IUsable
    {
        private int damage;

        public Sword(string name, string description, int damage) : base(name, description)
        {
            this.damage = damage;
        }

        public void Use()
        {
            AbstractObject dragon = currentRoom.GetObjectWithName("Smaug");
            if (dragon != null)
            {
                (dragon as Dragon).ChangeHealth(damage);
            }
        }

        public bool WasUsed()
        {
            return false;
        }
    }
}
