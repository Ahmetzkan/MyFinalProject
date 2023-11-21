using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework;

//Context,DbContext:Db tabloları ile proje classlarını ilişkilendirme işlemi
public class NorthwindContext : DbContext

{
    //Projenin hangi veritabanı ile alakalı olduğunu belirtir
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //@"Server=(localdb\mssqllocaldb; = dosya konumu
        //Database=Northwind; Database ismi
        //Trusted_Connection=true"  kullanıcı ismi ve şifre istemesin kısımları
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
    }
    //Bizdeki Product sınıfını Northwindeki Products olarak al ve eşitle
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
   
}

