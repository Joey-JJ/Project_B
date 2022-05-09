using System;
using System.Collections.Generic;

public static class Restaurant
{
    public static List<Table> RestaurantLayout = new List<Table>(){
        new Table(1, 8),
        new Table(2, 8),
        new Table(3, 6),
        new Table(4, 6),
        new Table(5, 6),
        new Table(6, 6),
        new Table(7, 4),
        new Table(8, 4),
        new Table(9, 4),
        new Table(10, 4),
        new Table(11, 3),
        new Table(12, 3),
        new Table(13, 2),
        new Table(14, 2),
        new Table(15, 2),
        new Table(16, 2),
        new Table(17, 2),
        new Table(18, 2),
        };
}


public class RestaurantDay
{
    public List<Table> Tables { get; set; }
    public DateTime Date { get; set; }
    public RestaurantDay(DateTime Date) {
        this.Date = Date.Date;
        this.Tables = new();
        for (var i = 0; i < Restaurant.RestaurantLayout.Count; i++) 
        {
            Tables.Add(new Table(Restaurant.RestaurantLayout[i].TableNumber, Restaurant.RestaurantLayout[i].NumberOfSeats));
        }
    }

    public RestaurantDay() { }
}


public class Table {
    public int TableNumber { get; set; }
    public int NumberOfSeats { get; set; }
    public bool Taken { get; set; }

    public Table(int TableNumber, int NumberOfSeats) {
        this.TableNumber = TableNumber;
        this.NumberOfSeats = NumberOfSeats;
        this.Taken = false;
    }
}