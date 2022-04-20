using System;

namespace ProjectB
{
    class Reviews
    {
        public static void WriteReview() 
        {
            Console.WriteLine("Please let us know what you think of the restaurant");
            string review;
            review = Console.ReadLine();
            Console.WriteLine("Thank you for your review");
        }
    }
}
