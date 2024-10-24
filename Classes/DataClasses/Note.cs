namespace Electronic_journal.Classes.DataClasses
{
    public class Note
    {
        public int Id { get; set; }
        public int Author_id { get; set; }
        public int Target_id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Date { get; set; }
        public int Hour { get; set; }
    }
}
