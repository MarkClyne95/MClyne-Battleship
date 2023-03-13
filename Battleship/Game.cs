using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Battleship
{
    // Imagine a game of battleships.
    //   The player has to guess the location of the opponent's 'ships' on a 10x10 grid
    //   Ships are one unit wide and 2-4 units long, they may be placed vertically or horizontally
    //   The player asks if a given co-ordinate is a hit or a miss
    //   Once all cells representing a ship are hit - that ship is sunk.
    public class Game
    {
        // ships: each string represents a ship in the form first co-ordinate, last co-ordinate
        //   e.g. "3:2,3:5" is a 4 cell ship horizontally across the 4th row from the 3rd to the 6th column
        // guesses: each string represents the co-ordinate of a guess
        //   e.g. "7:0" - misses the ship above, "3:3" hits it.
        // returns: the number of ships sunk by the set of guesses

        public static int hitAmount = 0;
        public static int Play(string[] ships, string[] guesses)
        {
            List<Ship> shipList = new List<Ship>();

            foreach (var i in ships)
            {
                //remove all of the useless information from the string
                var temp = i.Split(new char[] { ':', ',' });

                //these can just be written in-line but constant references take time and are harder to read.
                int x1 = int.Parse(temp[0]);
                int y1 = int.Parse(temp[1]);
                int x2 = int.Parse(temp[2]);
                int y2 = int.Parse(temp[3]);

                //if the x1 and x2 are the same, the ship is vertical.
                if (Equals(x1, x2))
                {
                    Ship ship = new(x1, x2, y1, y2);
                    shipList.Add(ship);
                    Console.WriteLine(ship.size);
                }

                //conversely, if y1 and y2 are the same, the ship is horizontal
                if (Equals(y1, y2))
                {
                    Ship ship = new(x1, x2, y1, y2);
                    shipList.Add(ship);
                    Console.WriteLine(ship.size);
                }

            }

            foreach (var j in guesses)
            {
                var temp = j.Split(':');
                int x1 = int.Parse(temp[0]);
                int y1 = int.Parse(temp[1]);

                //check and see if the shiplist of Ships has the x or y value we want.
                Ship? found = (Ship?)shipList.Where(i => i.x.Contains(x1) && i.y.Contains(y1)).FirstOrDefault();

                //constant validaty checking to ensure that the ship that was found, was indeed valid.
                try
                {
                    if (found != null && found.hit <= found.size)
                    {
                        found.hit++;
                    }
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message); //xunit testing doesn't support console output in the traditional way so this was for personal testing only. 
                } 
                finally
                {
                    if (found != null && found.hit >= found.size)
                    {
                        found.sunk = true;
                    }
                }
                //check the "sunk" variable of found
                if (found != null && found.sunk)
                {
                    hitAmount++;
                }
            }

            return hitAmount;
        }
    }
}
