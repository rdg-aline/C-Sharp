using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        /// <summary>
        /// This constructor is required to invoke a constructor from BaseGradeBook.
        /// </summary>
        /// <param name="name"></param>
        public RankedGradeBook(string name): base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
    }
}
