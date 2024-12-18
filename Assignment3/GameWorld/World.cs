using Assignment3.GameObjects;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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
            // Load and parse the JSON file
            string jsonContent = File.ReadAllText(mapPath);
            JArray jsonMap = JArray.Parse(jsonContent);

            // A dictionary to store rooms by their index for easy neighbor linking
            Dictionary<int, Room> roomDictionary = new Dictionary<int, Room>();

            Dictionary<string, Lever> levers = new Dictionary<string, Lever>();
            // Step 1: Create all rooms and objects
            foreach (var roomData in jsonMap)
            {
                string roomType = roomData["type"].ToString();
                string name = roomData["name"].ToString();
                string description = roomData["description"].ToString();

                Room room;
                if (roomType.Equals("DarkRoom", StringComparison.OrdinalIgnoreCase))
                {
                    room = new DarkRoom(name, description, this);
                }
                else
                {
                    room = new Room(name, description, this);
                }

                map.Add(room);
                roomDictionary[map.Count] = room; // Store room with index

                
                foreach (var objData in (roomData["objects"] as JArray))
                {
                    string objType = objData["type"].ToString();
                    string objName = objData["name"].ToString();
                    string objDescription = objData["description"].ToString();

                    AbstractObject obj = factory.CreateObject(objType, objName, objDescription);
                    if (objType.ToLower() == "lever")
                    {
                        string spikesName = objData["spikes"].ToString();
                        levers[spikesName] = obj as Lever;
                    }

                    room.AddToRoom(obj);
                    obj.AddToRoom(room);
                }
            }

            foreach (Room room in map)
            {
                foreach (AbstractObject obj in room.GetObjects())
                {
                    if (obj is Spikes)
                    {
                        Lever lever = levers[obj.GetName()];
                        lever.ConnectSpikes(obj as Spikes);
                    }
                }
            }

            foreach (var roomData in jsonMap)
            {
                int roomIndex = map.FindIndex(r => r.GetName() == roomData["name"].ToString()) + 1;
                Room currentRoom = roomDictionary[roomIndex];

                foreach (string direction in new[] { "north", "south", "east", "west" })
                {
                    if (roomData[direction] != null)
                    {
                        int neighborIndex = (int)roomData[direction];
                        currentRoom.AddNeighbor(roomDictionary[neighborIndex], Enum.Parse<Directions>(direction, true));
                    }
                }
            }
        }
    }
}
