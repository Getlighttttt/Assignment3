using Assignment3.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameObjects
{
    public class Princess : AbstractActor
    {
        private IItem backpack;

        public Princess(string name, string description) : base(name, description)
        {
            backpack = null;
        }

        public void AddToBackPack(IItem toBeAdded)
        {
            if (backpack != null)
            {
                currentRoom.AddToRoom(backpack as AbstractObject);
            }
            backpack = toBeAdded;
            currentRoom.RemoveFromRoom(backpack as AbstractObject);
        }

        public void EmptyBackPack()
        {
            if (backpack != null)
            {
                currentRoom.AddToRoom(backpack as AbstractObject);
                backpack = null;
            }
        }

        public override void ChangeHealth(int delta)
        {
            health = Math.Max(0, Math.Min(health + delta, 100));
            currentRoom.GetWorld().SetLoss();
        }

        public void MoveToRoom(Room newRoom)
        {
            if (backpack != null)
            {
                (backpack as AbstractObject).AddToRoom(newRoom);
            }

            currentRoom = newRoom;
        }

        public IItem GetBackpack () { return backpack; }

        public void ProcessInput(string userInput)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            Console.WriteLine($"You are in {currentRoom.GetName()}.");
            Console.Write("You can go");
            foreach (string direction in currentRoom.GetDirections())
            {
                Console.Write($" {direction}");
            }
            Console.WriteLine();
            Console.WriteLine("What do you do?");
            string userInput = Console.ReadLine();
            ProcessInput(userInput);
            Console.WriteLine();
        }
    }
}
