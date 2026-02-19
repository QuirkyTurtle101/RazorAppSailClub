using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SailClubLibrary.Models;

namespace SailClubLibrary.Helpers.Sorters
{
    public class BoatComparerYear : IComparer<Boat>
    {
        public int Compare(Boat? x, Boat? y)
        {
            return Int32.Parse(y.YearOfConstruction) - Int32.Parse(x.YearOfConstruction);
        }
    }
}
