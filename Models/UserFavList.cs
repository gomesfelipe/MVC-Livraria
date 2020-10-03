using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_LIVRARIA.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC_LIVRARIA.Models
{
    public class UserFavList
    {
        public int ID;
        public int UserID;

        public UserFavList(DbContextOptions<UserFavList> options) : base(options)
        {
        }

        public DbSet<Livro> FavoriteBands { get; set; }
    }
}