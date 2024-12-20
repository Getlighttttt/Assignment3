using Assignment3.GameActions;
using Assignment3.GameWorld;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
                (backpack as AbstractObject).AddToRoom(currentRoom);
            }
            backpack = toBeAdded;
            currentRoom.RemoveFromRoom(toBeAdded as AbstractObject);
        }

        public void EmptyBackPack()
        {
            if (backpack != null)
            {
                currentRoom.AddToRoom(backpack as AbstractObject);
                (backpack as AbstractObject).AddToRoom(currentRoom);
                backpack = null;
            }
        }

        public override void ChangeHealth(int delta)
        {
            health = Math.Max(0, Math.Min(health + delta, 100));
            if (health == 0)
            {
                currentRoom.GetWorld().SetLoss();
            }
        }

        public void MoveToRoom(Room newRoom)
        {
            if (backpack != null)
            {
                (backpack as AbstractObject).AddToRoom(newRoom);
            }

            AddToRoom(newRoom);
            newRoom.AddToRoom(this);
        }

        public IItem GetBackpack () { return backpack; }

        public void ProcessInput(string userInput)
        {
            string[] inputParts = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (inputParts.Length == 0)
            {
                Console.WriteLine("I do not understand what you mean.");
                return;
            }
            else
            {
                for (int i = 0; i < inputParts.Length; i++)
                {
                    inputParts[i] = inputParts[i].ToLower();
                }
            }

            if (inputParts.Length == 1)
            {
                string command = inputParts[0];
                if (command == "exit")
                {
                    Exit exit = new Exit();
                    exit.Execute(this);
                    return;
                }
                else
                {
                    Console.WriteLine("I do not understand what you mean.");
                    return;
                }
            }

            if (inputParts[0] == "check" && inputParts[1] == "bag" && inputParts.Length == 2)
            {
                if (backpack != null)
                {
                    CheckBag check = new CheckBag();
                    check.Execute(this);
                }
                return;
            }
            else if (inputParts[0] == "inspect") {
                inputParts[1] = string.Join(" ", inputParts.Skip(1));
                AbstractObject obj = currentRoom.GetObjectWithName(inputParts[1]);
                if (obj != null)
                {
                    Inspect inspect = new Inspect(obj);
                    inspect.Execute(this);
                    return;
                }
                else if (backpack != null)
                {
                    if ((backpack as AbstractObject).GetName().ToLower() == inputParts[1])
                    {
                        Inspect inspect = new Inspect(backpack as AbstractObject);
                        inspect.Execute(this);
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("I do not understand what you mean.");
                    return;
                }
            }
            else if (inputParts[0] == "kiss")
            {
                inputParts[1] = string.Join(" ", inputParts.Skip(1));
                IPrince prince = (currentRoom.GetObjectWithName(inputParts[1]) as IPrince);
                Kiss kiss = new Kiss(prince);
                kiss.Execute(this);
                return;
            }
            else if (inputParts[0] == "look" && inputParts[1] == "around" && inputParts.Length == 2)
            {
                LookAround look = new LookAround();
                look.Execute(this);
                return;
            }
            else if (inputParts[0] == "move" && new[] {"north", "south", "east", "west" }.Contains(inputParts[1]) && inputParts.Length == 2)
            {
                Move move = new Move(Enum.Parse<Directions>(inputParts[1], true));
                move.Execute(this);
                return;
            }
            else if (inputParts[0] == "pick" && inputParts[1] == "up" && inputParts.Length > 2)
            {
                if (currentRoom.GetObjectNames().Count != 0)
                {
                    inputParts[2] = string.Join(" ", inputParts.Skip(2));
                    IItem item = (currentRoom.GetObjectWithName(inputParts[2]) as IItem);
                    PickUp pick = new PickUp(item);
                    pick.Execute(this);
                    return;
                }
                else
                {
                    Console.WriteLine("I do not understand what you mean.");
                    return;
                }
            }
            else if (inputParts[0] == "put" && inputParts[1] == "down" && inputParts.Length == 2)
            {
                PutDown put = new PutDown();
                put.Execute(this);
                return;
            }
            else if (inputParts[0] == "use" )
            {
                inputParts[1] = string.Join(" ", inputParts.Skip(1));
                AbstractObject obj = currentRoom.GetObjectWithName(inputParts[1]);
                if (backpack != null)
                {
                    if ((backpack as AbstractObject).GetName().ToLower() == inputParts[1])
                    {
                        Use use = new Use(backpack as IUsable);
                        use.Execute(this);
                        return;
                    }
                }
                else if (obj != null)
                {
                    Use use = new Use(obj as IUsable);
                    use.Execute(this);
                    return;
                }
                else
                {
                    Console.WriteLine("I do not understand what you mean.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("I do not understand what you mean.");
                return;
            }
        }

        public override void Update()
        {
            if (health == 0)
            {
                return;
            }
            Console.WriteLine($"You are in {currentRoom.GetName()}.");
            Console.Write("You can go");
            foreach (string direction in currentRoom.GetDirections())
            {
                Console.Write($" {direction}");
            }
            Console.WriteLine();
            Console.WriteLine($"health: {health}");
            Console.WriteLine("What do you do?");
            string userInput = Console.ReadLine();
            ProcessInput(userInput);
            Console.WriteLine();
            foreach (AbstractObject obj in currentRoom.GetObjects().GetRange(0, currentRoom.GetObjects().Count))
            {
                if (obj != this)
                {
                    obj.Update();
                }
            }
        }
    }
}
