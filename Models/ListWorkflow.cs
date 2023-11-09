namespace GetsDoneApi.Models
{
    public class ListWorkflow
    {
        public int WFId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int WOwner { get; set; }
        public string WUser { get; set; }
    }
}
