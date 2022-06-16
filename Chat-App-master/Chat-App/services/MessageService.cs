//using Chat_App.Models;

//namespace Chat_App.services
//{
//    public class MessageService : IMessageService
//    {
//        private static List<Message> messages = new List<Message>();
//        public List<Message> GetAll()
//        {
//            return messages;
//        }

//        public Message Get(int id)
//        {
//            return messages.Find(x => x.Id == id);
//        }

//        //public Message Search();

//        public void Create(string content)
//        {
//            int nextId = 0;
//            if (messages.Count > 0)
//            {
//                nextId = messages.Max(x => x.Id) + 1;
//            }
//            messages.Add(new Message { Id = nextId, Content = content, Created = DateTime.Now, Sent = true });
//        }

        
//        public void Edit(int id, string content)
//        {
//            Message message = messages.Find(x => x.Id == id);
//            message.Content = content;  
//        }

//        public void Delete(int id)
//        {
//            messages.Remove(messages.Find(x => x.Id == id));
//        }
//    }
//}
