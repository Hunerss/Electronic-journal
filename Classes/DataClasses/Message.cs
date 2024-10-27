namespace Electronic_journal.Classes.DataClasses
{
    public class Message
    {
        public int Id { get; set; }
        public int Author_id { get; set; }
        public string AuthorEmail { get; set; }
        public int Target_id { get; set; }
        public string TargetInfo { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int School_role {  get; set; }
        public bool Single_target { get; set; }
        public int Target_school_role {  get; set; }
        public string Group_id { get; set; }
    }
}
