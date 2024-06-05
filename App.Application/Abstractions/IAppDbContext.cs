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
        DbSet<UserModel> Users { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<Categories> Categories { get; set; }
        DbSet<Book> Books { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
