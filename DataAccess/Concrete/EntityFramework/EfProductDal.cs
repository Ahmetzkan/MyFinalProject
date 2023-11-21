using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //Performans iyileştirme amaçlı işi bitince GarbageCollector'dan atılır ve bellek temizlenir
            //Idisposable pattern implementation of C#
            using (NorthwindContext context = new NorthwindContext( ))
            {
                var addedEntity = context.Entry(entity); //Referansa ulaşmak için
                addedEntity.State = EntityState.Added;   //Referansı gelen eklenecek nesne
                context.SaveChanges();                   //Değişiklikleri kaydet
            }
        }

        public void Delete(Product entity)
        {
            //Performans iyileştirme amaçlı işi bitince GarbageCollector'dan atılır ve bellek temizlenir
            //Idisposable pattern implementation of C#
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //Referansa ulaşmak için
                deletedEntity.State = EntityState.Deleted; //Referansı gelen silinecek nesne
                context.SaveChanges();                      //Değişiklikleri kaydet
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //Producta bağlan bu filtreyi uygula
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }


        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //Filtre null ise Producta yerleş ve listele
                //select *from products kodu gibi
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            //Performans iyileştirme amaçlı işi bitince GarbageCollector'dan atılır ve bellek temizlenir
            //Idisposable pattern implementation of C#
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);  //Referansa ulaşmak için
                updatedEntity.State = EntityState.Modified; //Referansı gelen güncellenecek nesne
                context.SaveChanges();                      //Değişiklikleri kaydet
            }
        }
    }
}
