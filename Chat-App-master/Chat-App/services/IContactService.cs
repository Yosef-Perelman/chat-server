using Chat_App.Models;

namespace Chat_App.services
{
    public interface IContactService
    {
        public List<Contact> GetAll();

        public List<Contact> UserGetAll(string user);

        public Contact Get(string id);

        public Contact UserGet(string user, string id);

        public void Create(string id, string name, string server);

        public void UserCreate(string id, string name, string server, string user);

        public void Edit(string id, string name, string server);

        public void UserEdit(string user, string id, string name, string server);

        public void Delete(string id);

        public void UserDelete(string user, string id);

        public List<Message> GetAllMessages(string id);

        public List<Message> UserGetAllMessages(string user, string id);

        public Message GetMessage(string id, int messageID);

        public int CreateMessage(string id, string content);

        public int UserCreateMessage(string user, string id, string content);

        public int CreateMessageFrom(string user, string id, string content);

        public void DeleteMessage(string id, int messageID);

        public void EditMessage(string id, int messageID, string content);
    }
}
