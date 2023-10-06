using System;

namespace Project
{
    public class Discussion
    {
        public int DiscussionId { get; set; }
        public int ClassId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public DateTime DiscussionDate { get; set; }

        public string Username {  get; set; }
    }
}
