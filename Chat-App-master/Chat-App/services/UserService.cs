using Chat_App.Models;

namespace Chat_App.services
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>()
        {
            new User{ Id = "Yosef", Password = "1234"}, new User{ Id = "Ariel", Password = "1234"}
        };

        public List<User> GetAll() {
            return users; 
        }

        public User Get(string id) { 
            return users.Find(x => x.Id == id);
        }

        public Boolean LogIn(string id, string password)
        {
            var user = Get(id);
            if (user != null)
            {
                if (user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean Register(string id, string password)
        {
            var user = Get(id);
            if (user != null)
            {
                return false;
            }
            else
            {
                Create(id, password);
                return true;

            }

        }

        public void Create(string id, string password) {
            users.Add(new User { Id = id, Password = password });
        }

        public void Edit(string id, string password) {
            User user = Get(id);
            user.Id = id;
            user.Password = password;
        }

        public void Delete(string id) { 
            users.Remove(users.Find(x => x.Id == id));
        }

    }
}
