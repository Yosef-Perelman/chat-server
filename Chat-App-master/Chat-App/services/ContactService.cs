using Chat_App.Models;

namespace Chat_App.services
{
    public class ContactService : IContactService
    {
        private static List<Contact> contacts = new List<Contact>() {
                        new Contact { Id = "yosef", Name = "yossi", UserName = "Ariel", Messages = new List<Message>(){
                            new Message { Id = 0, Content = "hello darkness", Created = DateTime.Now.ToString("HH:mm:ss"), Sent = false },
                            new Message { Id = 1, Content = "my old friend", Created = DateTime.Now.ToString("HH:mm:ss"), Sent = true }}, 
                            Last = "my old friend" },
                        new Contact { Id = "ariel", Name = "ari" , UserName = "Ariel", Messages = new List<Message>(){
                            new Message { Id = 0, Content = "how are you", Created = DateTime.Now.ToString("HH:mm:ss"), Sent = false },
                            new Message { Id = 1, Content = "good", Created = DateTime.Now.ToString("HH:mm:ss"), Sent = true }},
                        Last = "good" },
                        new Contact { Id = "dad", Name = "dad" , UserName = "Ariel", Messages = new List<Message>(){
                            new Message { Id = 0, Content = "hi", Created = DateTime.Now.ToString("HH:mm:ss"), Sent = false },
                            new Message { Id = 1, Content = "thanks", Created = DateTime.Now.ToString("HH:mm:ss"), Sent = true }},
                        Last = "thanks" },
                        new Contact { Id = "mom", Name = "mom" , UserName = "Ariel", Messages = new List<Message>(){
                            new Message { Id = 0, Content = "maccabi", Created = DateTime.Now.ToString("HH:mm:ss"), Sent = false },
                            new Message { Id = 1, Content = "haifa!", Created = DateTime.Now.ToString("HH:mm:ss"), Sent = true }},
                        Last = "haifa!" },
                        new Contact { Id = "bob", Name = "bob" , UserName = "Ariel", Messages = new List<Message>(){
                            new Message { Id = 0, Content = "yes!", Created = DateTime.Now.ToString("HH:mm:ss"), Sent = false },
                            new Message { Id = 1, Content = "no!", Created = DateTime.Now.ToString("HH:mm:ss"), Sent = true }},
                        Last = "no!"}
                        };

        public List<Contact> GetAll()
        {
            return contacts;
        }

        public List<Contact> UserGetAll(string user) 
        {
            List<Contact> userContacts = new List<Contact>();
            foreach (Contact contact in contacts)
                if(contact.UserName == user)
                    userContacts.Add(contact); 
            return userContacts; 
        }

        public Contact Get(string id)
        {
            return contacts.Find(x => x.Id == id);
        }

        public Contact UserGet(string user, string id)
        {
            return contacts.Find(x => (x.Id == id) && (x.UserName == user));
        }

        public void Create(string id, string name, string server)
        {
            contacts.Add(new Contact { Id = id, Name = name, Server = server, Messages = new List<Message>() });
        }

        public void UserCreate(string id, string name, string server, string user) 
        {
            contacts.Add(new Contact { Id = id, Name = name, Server = server, Messages = new List<Message>(), UserName = user });
        }

        public void Edit(string id, string name, string server)
        {
            Contact contact = Get(id);
            contact.Name = name;
            contact.Server = server;
        }
        public void UserEdit(string user, string id, string name, string server)
        {
            Contact contact = UserGet(user, id);
            contact.Name = name;
            contact.Server = server;
        }

        public void Delete(string id)
        {
            contacts.Remove(contacts.Find(x => x.Id == id));
        }

        public void UserDelete(string user, string id)
        {
            contacts.Remove(contacts.Find(x => (x.Id == id) && (x.UserName == user)));
        }

        public List<Message> GetAllMessages(string id)
        {
            Contact contact = contacts.Find(x => x.Id == id);
            return contact.Messages;
        }

        public List<Message> UserGetAllMessages(string user, string id)
        {
            Contact contact = contacts.Find(x => (x.Id == id) && (x.UserName == user));
            return contact.Messages;
        }

        public Message GetMessage(string id, int messageID)
        {
            Contact contact = contacts.Find(x => x.Id == id);
            Message message = contact.Messages.Find(c => c.Id == messageID);
            return message;
        }

        public int CreateMessage(string id, string content)
        {
            Contact contact = contacts.Find(x => x.Id == id);
            int nextId = 0;
            if (contact.Messages.Count > 0)
            {
                nextId = contact.Messages.Max(x => x.Id) + 1;
            }
            contact.Messages.Add(new Message { Id = nextId, Content = content, Created = DateTime.Now.ToString("HH:mm:ss"), Sent = true });
            return nextId;
        }

        public int UserCreateMessage(string user, string id, string content)
        {
            Contact contact = contacts.Find(x => (x.Id == id) && (x.UserName == user));
            int nextId = 0;
            if (contact.Messages.Count > 0)
            {
                nextId = contact.Messages.Max(x => x.Id) + 1;
            }
            contact.Messages.Add(new Message { Id = nextId, Content = content, Created = DateTime.Now.ToString("HH:mm:ss"), Sent = true });
            return nextId;
        }

        public int CreateMessageFrom(string user, string id, string content)
        {
            Contact contact = contacts.Find(x => (x.Id == id) && (x.UserName == user));
            int nextId = 0;
            if (contact.Messages.Count > 0)
            {
                nextId = contact.Messages.Max(x => x.Id) + 1;
            }
            contact.Messages.Add(new Message { Id = nextId, Content = content, Created = DateTime.Now.ToString("HH:mm:ss"), Sent = false });
            return nextId;
        }

        public void DeleteMessage(string id, int messageID)
        {
            Contact contact = contacts.Find(x => x.Id == id);
            contact.Messages.Remove(contact.Messages.Find(c => c.Id == messageID));
        }

        public void EditMessage(string id, int messageID, string content)
        {
            Contact contact = contacts.Find(x => x.Id == id);
            contact.Messages.Find(c => c.Id == messageID).Content = content;
        }
    }
}
