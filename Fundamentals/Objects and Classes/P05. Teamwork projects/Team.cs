using System.Net;
using System.Reflection.Metadata;

namespace P05._Teamwork_projects
{
    public class Team
    {

        public Team(string name, User user)
        {
            this.Name = name;
            this.User = user;
            this.Members= new List<Member>();
        }

        public string Name { get; set; }

        public User User { get; set; }

        public List<Member> Members { get; set; }

        public override string ToString()
        {
            return $"Team {this.Name} has been created by {this.User.Name}!";
        }
    }
}
