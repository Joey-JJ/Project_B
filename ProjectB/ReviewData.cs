using System;

public class ReviewData
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string ReviewText { get; set; }
    public string Rating { get; set; }

    public ReviewData(
            string name,
            string email,
            string reviewtext,
            string rating)
    {
        this.Name = name;
        this.Email = email;
        this.ReviewText = reviewtext;
        this.Rating = rating;
    }
}
