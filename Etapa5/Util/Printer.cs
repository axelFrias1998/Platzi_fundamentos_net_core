using static System.Console;

namespace Etapa5.Util
{
    public static class Printer
    {
        private static void PrintLine(int size = 0) => WriteLine("".PadLeft(size, '='));

        public static void PrintTitle(string title)
        {
            int size = title.Length + 4; 
            PrintLine(size);
            WriteLine($"| {title} |");
            PrintLine(size);
        }
    }
}