namespace RiskProfile.Domain.Models
{
    public class Vehicle
    {
        public Vehicle(int year)
        {
            Year = year;
        }

        public int Year { get; }
    }
}