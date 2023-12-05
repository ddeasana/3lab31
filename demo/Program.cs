using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;

namespace demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            List<Rectangle> rectangles = new()
            {
                new Rectangle("blue", "white", 5, 4),
                new Rectangle("green", "red", 9, 9),
                new Rectangle("black", "white", 1, 8),
                new Rectangle("yellow", "orange", 2, 6),
                new Rectangle("pink", "black", 12, 3)
            };

            JSONSerializer<Rectangle> JSONSerializer = new("json.json");
            JSONSerializer.Save(rectangles);
            Console.WriteLine("Saved to JSON:");
            foreach (Rectangle rectangle in rectangles)
            {
                Console.WriteLine(rectangle);
            }
            rectangles = JSONSerializer.Load();
            Console.WriteLine("Loaded from JSON:");
            foreach (Rectangle rectangle in rectangles)
            {
                Console.WriteLine(rectangle);
            }

            CustomSerializer<Rectangle> CustomSerializer = new("list.dat");
            CustomSerializer.Save(rectangles);
            Console.WriteLine("Saved to Custom:");
            foreach (Rectangle rectangle in rectangles)
            {
                Console.WriteLine(rectangle);
            }
            List<Rectangle> list2;
            list2 = CustomSerializer.Load();
            Console.WriteLine("Loaded from Custom:");
            foreach (Rectangle rectangle in list2)
            {
                Console.WriteLine(rectangle);
            }

            XMLSerializer<Rectangle> XMLSerializer = new("xml.xml");
            XMLSerializer.Save(rectangles);
            Console.WriteLine("Saved to XML:");
            foreach (Rectangle rectangle in rectangles)
            {
                Console.WriteLine(rectangle);
            }
            rectangles = XMLSerializer.Load();
            Console.WriteLine("Loaded from XML:");
            foreach (Rectangle rectangle in rectangles)
            {
                Console.WriteLine(rectangle);
            }

            BinarySerializer<Rectangle> BinarySerializer = new("binary.bin");
            BinarySerializer.Save(rectangles);
            Console.WriteLine("Saved to Binary:");
            foreach (Rectangle rectangle in rectangles)
            {
                Console.WriteLine(rectangle);
            }
            rectangles = BinarySerializer.Load();
            Console.WriteLine("Loaded from Binary:");
            foreach (Rectangle rectangle in rectangles)
            {
                Console.WriteLine(rectangle);
            }
        }
    }
}