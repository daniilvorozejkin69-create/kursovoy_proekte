namespace kursovoy_proekt
{
    public class ServiceItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
        public string Description { get; set; }
        public int Duration { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Price:N2}₽ ({Duration} мин.)";
        }
    }
}