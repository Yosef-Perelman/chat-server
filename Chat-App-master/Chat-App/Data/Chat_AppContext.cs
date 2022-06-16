using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chat_App.Models;

namespace Chat_App.Data
{
    public class Chat_AppContext : DbContext
    {
        public Chat_AppContext (DbContextOptions<Chat_AppContext> options)
            : base(options)
        {
        }

        public DbSet<Chat_App.Models.Rate>? Rate { get; set; }

        public DbSet<Chat_App.Models.User> User { get; set; }

        public DbSet<Chat_App.Models.Message> Message { get; set; }

        public DbSet<Chat_App.Models.Contact> Contact { get; set; }
    }
}
