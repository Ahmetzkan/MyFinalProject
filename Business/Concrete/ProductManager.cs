using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constans;

namespace Business.Concrete
{

    
    public class ProductManager : IProductService
    {   //[LogAspect] -->AOP.Bir metod hata verdiğinde çalışan kodlar AOP'dir.Burada tanımlandığında bütün class log'unu alır.
        //Bİr iş sınıfı başka sınıfları newlemez.Bundan dolayı böyle yapılır.
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        //[LogAspect]-->AOP.Bir metod hata verdiğinde çalışan kodlar AOP'dir.
        //[Validate]-[Performance]-RemoveCache]-[Transaction]

        public IResult Add(Product product)
        {
            
            //Business codes

            if (product.ProductName.Length<2)
            {
                //magic strings
                return new ErrorResult(Messages.ProductNameInvalid);
            }
             _productDal.Add(product);

             //Return olarak Add veremeyeceğimiz için Resultı newleyip verdik.Ve sonuç döndürüyoruz.
             return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            //_productDal'dan gelen CategoryId parametre olarak gelen id eşitse bunu döndür
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            //Get = ,İçerideki sorguya göre döndür denilebilir.   
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {

            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

     
    }
}

