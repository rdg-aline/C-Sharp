using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        /// <summary>
        /// This constructor is required to invoke a constructor from BaseGradeBook.
        /// </summary>
        /// <param name="name"></param>
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked - grading requires a minimum of 5 students to work");
            }


            /*
              Ranked-grading grades students not based on their individual performance,but rather their performance compared to their peers. 
              This means the 20% of the students with the highest grade of a class get an A, 
              the next highest 20% get a B, etc. There are many ways to calculate this. 
              I'd recommend figuring out how many students it takes to drop a letter grade (20% of the total number of students) X,
              put all the average grades in order, then figure out where the input grade would fit in the series of grades.
              Every X students with higher grades than the input grade knocks the letter grade down until you reach F.
            */

            int B = (int)((Students.Count * 0.8));
            int C = (int)((Students.Count * 0.6) );
            int D = (int)((Students.Count * 0.4));
            int F = (int)(Students.Count * 0.2);


            if (averageGrade > Students[B].AverageGrade)
            {
                return 'A';
            }
            else if ((averageGrade <= Students[B].AverageGrade) && (averageGrade > Students[C].AverageGrade))
            {
                return 'B';
            }
            else if ((averageGrade <= Students[C].AverageGrade) && (averageGrade > Students[D].AverageGrade))
            {
                return 'C';
            }
            else if ((averageGrade < Students[C].AverageGrade) && (averageGrade > Students[F].AverageGrade))
            {
                return 'D';
            }
            else
            {
                return 'F';
            }

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade");
                return;
            }
            else
            {
                base.CalculateStudentStatistics();
            }
        }

    }
}
