using App.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Abstractions
{
    public interface IAppDbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
