using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqCourse
{


    public static partial class Example
    {


        /*
            Create a new variable query that contains our query that selects all values in our numbers variable. Then return query.Count()
            In our query, add a where clause with a condition that only returns records whose value is greater than 6.
         */
        public static int GetNumbers()
        {
            var numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };


            var query =
                from number in numbers
                where number > 6
                select number;


            return query.Count();

        }



        /*
            Update our query to include an orderby clause that sorts the numbers in ascending order.   
         */
        public static IEnumerable<int> GetNumbers2()
        {
            var numbers = new int[] { 9, 1, 5, 8, 6, 7, 3, 2, 0, 4 };

            var query = from number in numbers
                        orderby number ascending
                        select number;

            return query;
        }




        /*
         1-   We've started writing a query stored in the userQuery variable.
            Add a group clause to that query that groups our users by their Active property.
            Don't forget the select clause.
        

        2 - First, create a foreach loop that iterates through all of the groups contained within our userQuery.

        Then, inside the foreach loop, write to the console using Console.WriteLine with the value "Active: true" or "Active: false" based on the group's Key property.


        3- Inside of the foreach loop you just created, and after the console message you just added, create another foreach loop that iterates through all of the users within each group.

            Inside this foreach loop, write each user's Name property to console using Console.WriteLine.
         */
        public static void GetUsers(List<User> users)
        {
            var userQuery = from user in users
                            group user by user.Active into userGroup
                            select userGroup;

            foreach (var userGroup in userQuery)
            {
                Console.WriteLine("Active: {0}", userGroup.Key);
                foreach (var user in userGroup)
                {
                    Console.WriteLine(user.Name);
                }
            }
        }




    }
}