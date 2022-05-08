using System;
using System.Collections.Generic;

namespace MarsRoverProblem
{
    public enum Directions
    {
        N = 1,//North
        S = 2,//South
        E = 3,//East
        W = 4//West
    }

    public interface IPosition
    {
        void Start_Moving(List<int> maxPoints, string moves);
    }

    public class Position : IPosition
    {
        public int X { get; set; }    // X coordinates of the current position of the rover
        public int Y { get; set; }    // Y coordinates of the current position of the rover
        public Directions Direction { get; set; }   // direction of the current position of the rover

        public Position()
        {
            X = Y = 0;
            Direction = Directions.N;
        }

     //   rover spin 90 degrees left 
        private void Rotate_90_Left()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.W;
                    break;
                case Directions.S:
                    this.Direction = Directions.E;
                    break;
                case Directions.E:
                    this.Direction = Directions.N;
                    break;
                case Directions.W:
                    this.Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }

        // rover spin 90 degrees right
        private void Rotate_90_Right()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.E;
                    break;
                case Directions.S:
                    this.Direction = Directions.W;
                    break;
                case Directions.E:
                    this.Direction = Directions.S;
                    break;
                case Directions.W:
                    this.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }

      //  'M' means move forward one grid point and maintain the same heading
        private void Move_In_Same_Direction()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Y += 1;
                    break;
                case Directions.S:
                    this.Y -= 1;
                    break;
                case Directions.E:
                    this.X += 1;
                    break;
                case Directions.W:
                    this.X -= 1;
                    break;
                default:
                    break;
            }
        }

        public void Start_Moving(List<int> maxPoints, string moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':  // Move forward
                        this.Move_In_Same_Direction();
                        break;
                    case 'L':     // L = spin left
                        this.Rotate_90_Left();
                        break;
                    case 'R':    // R = spin right
                        this.Rotate_90_Right();
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {move}");
                        break;
                }

                if (this.X < 0 || this.X > maxPoints[0] || this.Y < 0 || this.Y > maxPoints[1])
                {
                    throw new Exception($"Oops! Position can not be beyond boundaries (0 , 0) and ({maxPoints[0]} , {maxPoints[1]})");
                }
            }
        }
    }
}
