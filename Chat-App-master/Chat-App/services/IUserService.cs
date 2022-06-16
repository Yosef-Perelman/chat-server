using Chat_App.Models;

namespace Chat_App.services
{
    public interface IUserService
    {
        public List<User> GetAll(); 

        public User Get(string id);

        public Boolean LogIn(string id, string password);

        public Boolean Register(string id, string password);

        public void Create(string id, string password);

        public void Edit(string id, string password);

        public void Delete(string id);

    }
}
