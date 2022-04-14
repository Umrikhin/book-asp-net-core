namespace SiteDocs.Models
{
    public class Doc
    {
        //Код документа
        public int Code { get; set; }
        //Заголовок
        public string Title { get; set; } = string.Empty;
        //Кем выдан
        public string IssuedBy { get; set; } = string.Empty;
    }
}
