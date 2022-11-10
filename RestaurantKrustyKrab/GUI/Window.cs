namespace RestaurantKrustyKrab.GUI
{
    internal class Window
    {

        public static void OurDraw(string header, int fromLeft, int fromTop, string[,] graphics)
        {
            Console.SetCursorPosition(fromLeft, fromTop);
            Console.Write('┌' + " ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(header);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" " + new String('─', graphics.GetLength(1) - header.Length) + '┐');
            Console.WriteLine();
            for (int i = 0; i < graphics.GetLength(0); i++)
            {
                Console.SetCursorPosition(fromLeft, fromTop + i + 1);
                Console.Write('│' + " " + new string(' ', graphics.GetLength(1)) + " " + '│');
            }
            Console.SetCursorPosition(fromLeft, fromTop + graphics.GetLength(0) + 1);
            Console.Write('└' + new String('─', graphics.GetLength(1) + 2) + '┘');
        }




        public static void OurDrawBottomLess(string header, int fromLeft, int fromTop, string[,] graphics)
        {
            Console.SetCursorPosition(fromLeft, fromTop);
            Console.Write('┌' + " ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(header);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" " + new String('─', graphics.GetLength(1) - header.Length) + '┐');
            Console.WriteLine();
            for (int i = 0; i < graphics.GetLength(0); i++)
            {
                Console.SetCursorPosition(fromLeft, fromTop + i + 1);
                Console.Write('│' + " " + new string(' ', graphics.GetLength(1)) + " " + '│');
            }
        }



    }


        }
    


