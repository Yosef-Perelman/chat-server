using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace Chat_App.services
{
    public class FireBaseService
    {
        private static FirebaseMessaging messaging = FirebaseMessaging.GetMessaging(
            FirebaseApp.Create(new AppOptions() { Credential = GoogleCredential.FromFile("private_key.json").CreateScoped("https://www.googleapis.com/auth/firebase.messaging") }));
        private static Dictionary<string, string> _tokens = new Dictionary<string, string>();

        public void addToken(string user, string token) { _tokens[user] = token; }

        public string getToken(string user)
        {
            if (_tokens.ContainsKey(user))
                return _tokens[user];
            return null;
        }

        private FirebaseAdmin.Messaging.Message CreateNotification(string title, string notificationBody, string token)
        {
            return new FirebaseAdmin.Messaging.Message()
            {
                Token = token,
                Notification = new Notification()
                {
                    Body = notificationBody,
                    Title = title
                }
            };
        }

        public void SendNotification(string token, string title, string body)
        {
            messaging.SendAsync(CreateNotification(title, body, token));
        }
    }
}
