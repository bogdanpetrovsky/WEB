using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProductModel
    {
        public string InsertProduct(Product product)
        {
            try
            {
                GarageDBEntities3 db = new GarageDBEntities3();
                db.Product.Add(product);
                db.SaveChanges();
                return product.Name + " was succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error" + e;
            }
        }

        public string UpdateProduct(int id, Product product)
        {
            try
            {
                GarageDBEntities3 db = new GarageDBEntities3();

                Product p = db.Product.Find(id);
                p.Name = product.Name;
                p.Price = product.Price;
                p.TypeID = product.TypeID;
                p.Description = product.Description;
                p.Image = product.Image;

                db.SaveChanges();

                return product.Name + " was successfully updated";
            }
            catch (Exception e)
            {
                return "Error" + e;
            }
        }

        public string DeleteProduct(int id)
        {
            try
            {
                GarageDBEntities3 db = new GarageDBEntities3();
                Product product = db.Product.Find(id);

                db.Product.Attach(product);
                db.Product.Attach(product);
                db.SaveChanges();

                return product.Name + " was successully deleted";
            }
            catch (Exception e)
            {
                return "Error" + e;
            }
        }

        public Product GetProduct(int id)
        {
            try
            {
                using (GarageDBEntities3 db = new GarageDBEntities3())
                {
                    Product product = db.Product.Find(id);
                    return product;
                }
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<Product>GetAllProducts()
        {
            try
            {
                using (GarageDBEntities3 db = new GarageDBEntities3())
                {
                    List<Product> products = (from x in db.Product
                                              select x).ToList();
                    return products;
                }
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<Product> GetProductsByType(int typeid)
        {
            try
            {
                using (GarageDBEntities3 db = new GarageDBEntities3())
                {
                    List<Product> products = (from x in db.Product
                                              where x.TypeID == typeid
                                              select x).ToList();
                    return products;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}