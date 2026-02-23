namespace kursovoy_proekt
{
    public class HouseData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerDay { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Class}) - {Capacity} чел., {PricePerDay:N2}₽/день";
        }
    }
}