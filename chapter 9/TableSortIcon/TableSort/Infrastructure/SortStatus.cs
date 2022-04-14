namespace TableSort.Infrastructure
{
    public enum SortStatus
    {
        IdAsc,    // по коду по возрастанию
        IdDesc,   // по коду по убыванию
        FirstNameAsc, // по имени по возрастанию
        FirstNameDesc,    // по имени по убыванию
        LastNameAsc, // по фамилии по возрастанию
        LastNameDesc, // по фамилии по убыванию
        DateOfBirthAsc, // по дате рождения по возрастанию
        DateOfBirthDesc // по дате рождения по убыванию
    }
}
