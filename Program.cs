using System;
using System.Linq;

namespace MarsRoverProblem
{
    /// <summary>
    ///  Driver class
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {

            var maxPoints = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            // here its Start position of rover
            var startPositions = Console.ReadLine().Trim().Split(' ');
            Position position = new Position();

            if (startPositions.Count() == 3)
            {
                // X coordinates of the start position of the rover
                position.X = Convert.ToInt32(startPositions[0]);

                // Y coordinates of the start position of the rover
                position.Y = Convert.ToInt32(startPositions[1]); 
                
                // direction of the rover at the start
                position.Direction = (Directions)Enum.Parse(typeof(Directions), startPositions[2]);
            }

            // get the input line eg: LMLMLMMM or MMRMMRMRRM
            var moves = Console.ReadLine().ToUpper();

            try
            {
                position.Start_Moving(maxPoints, moves);
                Console.WriteLine($"{position.X} {position.Y} {position.Direction.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }  
    }
}
