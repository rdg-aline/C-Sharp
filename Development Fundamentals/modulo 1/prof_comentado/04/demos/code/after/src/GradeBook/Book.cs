using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            //adiciono a nota na lista (grades)
            grades.Add(grade);
        }

        //declaração de varivel 
        private List<double> grades;
        private string name;
    }
}