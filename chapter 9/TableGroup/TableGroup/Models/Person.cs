namespace TableGroup.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string LoginName { get; set; } = string.Empty;
        public DateTime TimeLogin { get; set; }
        public DateTime TimeExit { get; set; }
        public int idOffice { get; set; }
    }
}
