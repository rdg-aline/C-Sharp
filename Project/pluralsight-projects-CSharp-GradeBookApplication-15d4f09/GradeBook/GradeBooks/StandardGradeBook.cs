using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, Boolean IsWeighted) : base(name, IsWeighted)
        {
            Type = GradeBookType.Standard;          
        }
    }
}
   
      
