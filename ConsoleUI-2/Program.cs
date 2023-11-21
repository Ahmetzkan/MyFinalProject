using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//SOLID
//Open Closed Principle
ProductManager productManager = new ProductManager(new EfProductDal());

foreach (var product in productManager.GetAll())
{
    Console.WriteLine(product.ProductName);
}

Console.WriteLine("--------------");

foreach (var categoryId in productManager.GetAllByCategoryId(2))
{
    Console.WriteLine(categoryId.ProductName);
}

Console.WriteLine("--------------");

foreach (var unitPrice in productManager.GetByUnitPrice(50,100))
{
    Console.WriteLine(unitPrice.ProductName);
}

