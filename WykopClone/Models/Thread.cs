using Newtonsoft.Json.Linq;

namespace WykopClone.Models
{
    public class Thread
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public int Photo { get; set; }
        public int Votes { get; set; }
        //public List<User> VotesList { get; set; }
        //public User Author { get; set; }
        public CategoryType Category { get; set; } = Thread.CategoryType.Inna;
        public List<Comment> Comments { get; set; }

        public enum CategoryType
        {
            Inna,Ciekawostki,Informacje,Rozrywka
            ,Sport,Motoryzacja,Technologia,
            Gospodarka,Podróże,Polityka
        }
    }
}
