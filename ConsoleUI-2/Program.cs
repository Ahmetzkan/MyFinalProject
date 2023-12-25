using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//SOLID
//Open Closed Principle
//ProductTest();
//IoC
//CategoryTest();
//Data Transformantion Object

//Type typeProduct = typeof(ProductValidator);
//Console.WriteLine("ProductValidator türünün tipi: " + typeProduct);


static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

    var result = productManager.GetProductDetails();
    if (result.Success)
    { 
        foreach (var product in result.Data)
        {
            Console.WriteLine(product.ProductName + " " + product.CategoryName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }

    //foreach (var product in productManager.GetProductDetails().Data)
    //{
    //    Console.WriteLine(product.ProductName + " " + product.CategoryName);
    //}
}

static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var category in categoryManager.GetAll().Data)
    {
        Console.WriteLine(category.CategoryName);
    }
}