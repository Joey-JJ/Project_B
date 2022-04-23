//using System;
//using System.Collections.Generic;
//using System.Text.Json;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//class Orders
//{
//    public static List<ReviewData> Reviews = new();
//    private static readonly string file = "Reviews.json";

//    public static void WriteReview(string name, string email, string reviewtext, string rating)
//    {
//        var newReview = new ReviewData(name, email, reviewtext, rating);
//        Reviews.Add(newReview);
//    }
//    public static void SaveReviews()
//    {
//        var indent = new JsonSerializerOptions { WriteIndented = true };
//        string reviewString = JsonSerializer.Serialize(Reviews, indent);
//        File.WriteAllText(file, reviewString);
//    }
//    public static void MenuCourses()
//    {

//    }

//    public static void PlaceOrder(int ProductIndex)
//    {
//        int index = product
//        for (int a = 0; a < Reviews.Count; a++)
//        {
//            if (Reviews[a].Name.ToLower() == ProductName.ToLower())
//                index = a;
//        }

//        if (index != -1)
//        {
//            Reviews.RemoveAt(index);
//            Console.Clear();
//            Console.WriteLine("Review removed");
//            ListReviews();
//        }
//        else
//        {
//            Console.WriteLine("No review has been written by this name");
//        }
//    }
//}

