namespace ProjectB
{
    internal class Reservation
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Date_time { get; set; }
        public int Person_count { get; set; }

        public Reservation(
            string name,
            string email,
            string date_time,
            int person_count)
        {
            this.Name = name;
            this.Email = email;
            this.Date_time = date_time;
            this.Person_count = person_count;
        }
    }
}
