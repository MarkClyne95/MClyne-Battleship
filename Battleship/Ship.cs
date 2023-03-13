using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Ship
    {
        public List<int> x = new List<int>();
        public List<int> y = new List<int>();
        public int hit { get; set; }
        public int size { get; set; }
        public bool alignment { get; set; }

        public bool sunk { get; set; }

        /// <summary>
        /// Default constructor for a Ship object.
        /// </summary>
        /// <param name="x1">Start X Position of the ship</param>
        /// <param name="x2">End X Position of the ship</param>
        /// <param name="y1">Start Y Position of the ship</param>
        /// <param name="y2">End Y Position of the ship</param>
        /// <param name="alignment">True = horizontal, false = vertical</param>
        public Ship(int x1, int x2, int y1, int y2)
        {
            #region fill in all of the ships missing info
            for (int k = 0; k <= y2 - y1; k++)
            {

                if (Equals(x1, x2))
                {
                    var tempInt = y1 + k;
                    this.size = y2 - y1 + 1;
                    y.Add(tempInt);
                    x.Add(x1);
                }
            }

            for (int k = 0; k <= x2 - x1; k++)
            {

                if (Equals(y1, y2))
                {
                    var tempInt = x1 + k;
                    this.size = x2 - x1 + 1;
                    x.Add(tempInt);
                    y.Add(y1);
                }
            }
            #endregion
        }
    }
}
