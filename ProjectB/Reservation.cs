using System;

public class Reservation
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime Endtime { get; set; }
    public int PersonCount { get; set; }

    public Reservation(
            string name,
            string email,
            DateTime datetime,
            int personcount)
    {
        this.Name = name;
        this.Email = email;
        this.PersonCount = personcount;
        this.StartTime = datetime;
        this.Endtime = this.StartTime.AddHours(2.0);
        
    }
}
