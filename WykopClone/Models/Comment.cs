namespace WykopClone.Models
{
    public class Comment
    {
        public int Id { get; set; } 
        //public User Author { get; set; }
        public string Description{ get; set; }
        public int Votes { get; set; }
        public List<Comment> Replies { get; set; } = null;

    }
}
