using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Generic constraint = generic kısıtlama
    //where T:class,IEntity = sadece IEntity olabilir ya da IEntity implemente edilen nesne olabilir
    //new() kısmı ise newlenebilir olmalı anlamını taşır
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //Her Dal classında ayrı ayrı tanımlama yapmamak için Expression kısmını kullanıyoruz
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        //Hesap detayları gibi hesaplar içinden tekli hesap seçmeyi filtrelemek gibi düşünülebilir
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
