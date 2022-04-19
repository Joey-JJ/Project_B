using System;
using System.Collections.Generic;


public static class ReservationSchedule {
    public static Dictionary<DateTime, List<Reservation>> Schedule = new Dictionary<DateTime, List<Reservation>>();
    
    public static void InitSchedule() {
        var date = DateTime.Today.Date;
        for(var i = 0; i < 14; i++) {
            Schedule.Add(date.AddDays(i), new List<Reservation>());
        }
    }
}
