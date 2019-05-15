using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserInfoModel
    {

        public UserInformation GetUserInformation(string guId)
        {
            GarageDBEntities3 db = new GarageDBEntities3();
            UserInformation info = (from x in db.UserInformation
                                    where x.GUID == guId
                                    select x).FirstOrDefault();
            return info;
        }
        public void InsertUserInformation(UserInformation info)
        {
            GarageDBEntities3 db = new GarageDBEntities3();
            db.UserInformation.Add(info);
            db.SaveChanges();
        }
    }
}