using Chat_App.Models;

namespace Chat_App.services
{
    public interface IRateService
    {
        public List<Rate> GetAll();
        
        public double Average();

        public Rate Get(int Id);

        public void Create(string userName, string description, int value);

        public void Edit(int id, string userName, string description, int value);

        public void Delete(int id);
    }
}
