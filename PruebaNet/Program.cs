

using System;
namespace PruebaNet
{
    public class Program

    {
        public static void Main(string[] args)
        {
            string url = "https://raddarstudios.com/problems/design-tinyurl";
            TinyUrl tiny = new TinyUrl();
            string encodeUrl = tiny.Encode(url);
            Console.WriteLine("Encode URL: ");
            Console.WriteLine(encodeUrl);
            Console.WriteLine("\nDecode URL: ");
            string original = tiny.Decode(encodeUrl);
            Console.WriteLine(original);
        }

    }
}