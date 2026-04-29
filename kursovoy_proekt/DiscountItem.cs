namespace kursovoy_proekt
{
    public class DiscountItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Percent { get; set; }
        public int MinDays { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
