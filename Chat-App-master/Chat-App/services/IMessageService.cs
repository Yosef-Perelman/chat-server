using Chat_App.Models;

namespace Chat_App.services
{
    public interface IMessageService
    {
        public List<Message> GetAll();

        public Message Get(int id);

        //public Message Search();

        public void Create(string content);
       
        public void Edit(int id, string content);

        public void Delete(int id);
    }
}
