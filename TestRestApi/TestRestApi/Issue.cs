namespace TestRestApi
{
    public class Issue
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public List<string> WordList { get; set; }

    }

    public class FixedIssue
    {
        public string OldText { get; set; }
        public string NewText { get; set; }
    }
}
