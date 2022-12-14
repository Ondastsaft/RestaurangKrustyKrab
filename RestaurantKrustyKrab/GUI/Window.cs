using RestaurantKrustyKrab.Restaurant;
namespace RestaurantKrustyKrab.GUI
{
    internal class Window
    {
        public static void OurDraw(string header, int fromLeft, int fromTop, string[,] graphics)
        {
            Console.SetCursorPosition(fromTop, fromLeft);
            Console.Write('┌' + " ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(header);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" " + new String('─', graphics.GetLength(1) - header.Length) + '┐');
            Console.WriteLine();
            for (int i = 0; i < graphics.GetLength(0); i++)
            {
                Console.SetCursorPosition(fromTop, fromLeft + i + 1);
                Console.Write('│' + " " + new string(' ', graphics.GetLength(1)) + " " + '│');
            }
            Console.SetCursorPosition(fromTop, fromLeft + graphics.GetLength(0) + 1);
            Console.Write('└' + new String('─', graphics.GetLength(1) + 2) + '┘');
        }

        public static void OurDraw(RestaurantArea restaurantArea)
        {
            Console.SetCursorPosition(restaurantArea.FromLeft, restaurantArea.FromTop);
            Console.Write('┌' + " ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(restaurantArea.Name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" " + new String('─', restaurantArea.Frame.GetLength(1) - restaurantArea.Name.Length) + '┐');
            Console.WriteLine();
            for (int i = 0; i < restaurantArea.Frame.GetLength(0); i++)
            {
                Console.SetCursorPosition(restaurantArea.FromLeft, restaurantArea.FromTop + i + 1);
                Console.Write('│' + " " + new string(' ', restaurantArea.Frame.GetLength(1)) + " " + '│');
            }
            Console.SetCursorPosition(restaurantArea.FromLeft, restaurantArea.FromTop + restaurantArea.Frame.GetLength(0) + 1);
            Console.Write('└' + new String('─', restaurantArea.Frame.GetLength(1) + 2) + '┘');
        }




        public static void Draw(string header, int fromLeft, int fromTop, string[] graphics)
        {

            //int width = 0;
            //for (int i = 0; i < graphics.Length; i++)
            //{
            //    if (graphics[i].Length > width)
            //    {
            //        width = graphics[i].Length;
            //    }
            //}
            //if (width < header.Length + 4)
            //{ width = header.Length + 4; };

            //Console.SetCursorPosition(FromLeft, FromTop);
            //if (header != "")
            //{
            //    Console.Write('┌' + " ");
            //    Console.ForegroundColor = ConsoleColor.DarkGray;
            //    Console.Write(header);
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.Write(" " + new String('─', width - header.Length) + '┐');
            //}
            //else
            //{
            //    Console.Write('┌' + new String('─', width + 2) + '┐');
            //}
            //Console.WriteLine();
            //int maxRows = 0;
            //for (int j = 0; j < graphics.Length; j++)
            //{
            //    Console.SetCursorPosition(FromLeft, FromTop + j + 1);
            //    Console.WriteLine('│' + " " + graphics[j] + new String(' ', width - graphics[j].Length + 1) + '│');
            //    maxRows = j;
            //}
            //Console.SetCursorPosition(FromLeft, FromTop + maxRows + 2);
            //Console.Write('└' + new String('─', width + 2) + '┘');

        }
    }
}

