using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProductTypeModel
    {
        public string InsertProductType(ProductType productType)
        {
            try
            {
                GarageDBEntities3 db = new GarageDBEntities3();
                db.ProductType.Add(productType);
                db.SaveChanges();
                return productType.Name + " was succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error" + e;
            }
        }

        public string UpdateProductType(int id, ProductType productType)
        {
            try
            {
                GarageDBEntities3 db = new GarageDBEntities3();

                ProductType p = db.ProductType.Find(id);
                p.Name = productType.Name;


                db.SaveChanges();

                return productType.Name + " was successfully updated";
            }
            catch (Exception e)
            {
                return "Error" + e;
            }
        }

        public string DeleteProductType(int id)
        {
            try
            {
                GarageDBEntities3 db = new GarageDBEntities3();
                ProductType productType = db.ProductType.Find(id);

                db.ProductType.Attach(productType);
                db.ProductType.Attach(productType);
                db.SaveChanges();

                return productType.Name + " was successully deleted";
            }
            catch (Exception e)
            {
                return "Error" + e;
            }
        }
    }
}