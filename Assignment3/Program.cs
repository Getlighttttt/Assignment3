using Assignment3.GameWorld;

namespace Assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            World test = new World("sample_map.json");
            test.RunGame();
            Console.ReadLine();
        }
    }
}
