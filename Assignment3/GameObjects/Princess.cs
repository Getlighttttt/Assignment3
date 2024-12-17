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
            throw new NotImplementedException();
        }

        public void EmptyBackPack()
        {
            throw new NotImplementedException();
        }

        public override void ChangeHealth(int delta)
        {
            throw new NotImplementedException();
        }

        public void MoveToRoom(Room newRoom)
        {
            throw new NotImplementedException();
        }

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
