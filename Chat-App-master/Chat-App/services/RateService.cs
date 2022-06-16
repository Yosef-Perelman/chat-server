using Chat_App.Models;

namespace Chat_App.services
{
    public class RateService : IRateService
    {
        private static List<Rate> rates = new List<Rate>();

        public List<Rate> GetAll() { 
            return rates;
        }

        public double Average()
        {
            double sum = 0;
            foreach (Rate rate in rates)
            {
                sum += rate.Value;
            }
            if(sum > 0)
            return sum / rates.Count;
            return 0;
        }

        public Rate Get(int Id) { 
            return rates.Find(x => x.Id == Id);
        }

        public void Create(string userName, string description, int value) {
            int nextId = 0;
            if (rates.Count > 0)
            {
                nextId = rates.Max(x => x.Id) + 1;
            }
            rates.Add(new Rate { Id = nextId, UserName = userName, Description = description, Value = value, DateTime = DateTime.Now });
        }

        public void Edit(int id, string userName, string description, int value) {
            Rate rate = Get(id);
            rate.UserName = userName;
            rate.Description = description;
            rate.Value = value;
            rate.DateTime = DateTime.Now;
        }

        public void Delete(int id) { 
            rates.Remove(Get(id));
        }
    }
}
