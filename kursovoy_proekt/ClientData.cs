namespace kursovoy_proekt
{
    public class ClientData
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Passport { get; set; }

        public override string ToString()
        {
            return $"{FIO} (пасспорт: {Passport})";
        }
    }
}