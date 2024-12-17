using Assignment3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.GameWorld
{
    public class World
    {
        private List<Room> map;
        private bool won;
        private bool done;
        private bool lost;

        private ObjectFactory factory;

        public World(string mapPath)
        {
            won = false;
            done = false;
            lost = false;
            map = new List<Room>();
            factory = new ObjectFactory();
            LoadMap(mapPath);
        }

        public void SetWin()
        {
            won = true;
        }

        public void SetDone()
        {
            done = true;
        }

        public void SetLoss()
        {
            lost = true;
        }

        public void RunGame()
        {
            while (!won && !done && !lost)
            {
                foreach (Room room in map)
                {
                    foreach (AbstractObject obj in room.GetObjects().GetRange(0, room.GetObjects().Count))
                    {
                        obj.Update();
                    }
                }
            }

            if (won)
            {
                Console.WriteLine("YOU WIN!");
            }
            if (lost)
            {
                Console.WriteLine("YOU LOSE!");
            }
        }

        public void LoadMap(string mapPath)
        {
            throw new NotImplementedException();
        }
    }
}
