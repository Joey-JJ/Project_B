using System;

class Reservation
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string DateTime { get; set; }
    public int PersonCount { get; set; }

    public Reservation(
            string name,
            string email,
            string datetime,
            int personcount)
    {
        this.Name = name;
        this.Email = email;
        this.DateTime = datetime;
        this.PersonCount = personcount;
    }
}
