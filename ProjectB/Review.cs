using System;

public class Review
{
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string ReviewText { get; set; }
    public int Rating { get; set; }
    public DateTime Date { get; set; }

    public Review(
            string fullname,
            string username,
            string reviewtext,
            int rating,
            DateTime date)
    {
        this.FullName = fullname;
        this.UserName = username;
        this.ReviewText = reviewtext;
        this.Rating = rating;
        this.Date = date;
    }
}
