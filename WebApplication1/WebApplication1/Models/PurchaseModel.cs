using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PurchaseModel
    {
        public string InsertPurchase(Purchase purchase)
        {
            try
            {
                GarageDBEntities3 db = new GarageDBEntities3();
                db.Purchase.Add(purchase);
                db.SaveChanges();
                return purchase.Date + " was succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error" + e;
            }
        }

        public string UpdatePurchase(int id, Purchase purchase)
        {
            try
            {
                GarageDBEntities3 db = new GarageDBEntities3();

                Purchase p = db.Purchase.Find(id);
                p.Date = purchase.Date;
                p.CustomerID = purchase.CustomerID;
                p.Amount = purchase.Amount;
                p.IsInCart = purchase.IsInCart;
                p.ProductID = purchase.ProductID;

                db.SaveChanges();

                return purchase.Date + " was successfully updated";
            }
            catch (Exception e)
            {
                return "Error" + e;
            }
        }

        public string DeletePurchase(int id)
        {
            try
            {
                GarageDBEntities3 db = new GarageDBEntities3();
                Purchase purchase = db.Purchase.Find(id);

                db.Purchase.Attach(purchase);
                db.Purchase.Remove(purchase);
                db.SaveChanges();

                return purchase.Date + " was successully deleted";
            }
            catch (Exception e)
            {
                return "Error" + e;
            }
        }

        public List<Purchase> GetOrdersInPurchase(string userId)
        {
            int i = 0;
            if (!Int32.TryParse(userId, out i))
            {
                i = 1;
            }
            GarageDBEntities3 db = new GarageDBEntities3();
            List<Purchase> orders = (from x in db.Purchase
                                     where x.CustomerID == i
                                     && x.IsInCart
                                     orderby x.Date
                                     select x).ToList();
            return orders;
        }

        public int GetAmountOfOrders(string userId)
        {
            
            try
            {
                int i = 0;
                if (!Int32.TryParse(userId, out i))
                {
                    i = 1;
                }
                GarageDBEntities3 db = new GarageDBEntities3();
                int amount = (from x in db.Purchase
                              where x.CustomerID == i
                              && x.IsInCart
                              select x.Amount).Sum();
                return amount;
            }
            catch
            {
                return 0;
            }
        }

        public void UpdateQuantity(int id,int quantity)
        {
            GarageDBEntities3 db = new GarageDBEntities3();
            Purchase purchase = db.Purchase.Find(id);
            purchase.Amount = quantity;
            db.SaveChanges();
        }

        public void MarkOrderAsPaid(List<Purchase> purchases)
        {
            GarageDBEntities3 db = new GarageDBEntities3();
            if(purchases != null)
            {
                foreach(Purchase purchase in purchases)
                {
                    Purchase oldpurchase = db.Purchase.Find(purchase.ID);
                    oldpurchase.Date = DateTime.Now;
                    oldpurchase.IsInCart = false;

                }
                db.SaveChanges();
            }
        }
    }
}