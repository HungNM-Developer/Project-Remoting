using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppShared;

namespace AppService
{
    class ShoeDAO
    {
        MyDBDataContext db = new MyDBDataContext("SERVER=den1.mssql8.gear.host;DATABASE=hungnguyen;USER=hungnguyen;PASSWORD=hungnguyen@571999!");
        public List<Shoe> SelectAll()
        {
            db.ObjectTrackingEnabled = false;
            List<Shoe> shoes = db.Shoes.ToList();
            return shoes;
        }
        public bool Insert(Shoe newShoe)
        {
            
            try
            {
                db.Shoes.InsertOnSubmit(newShoe);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }

        }
        public bool Update(Shoe newShoe)
        {
            
            Shoe dbShoe = db.Shoes.SingleOrDefault(x => x.Code == newShoe.Code);
            if (dbShoe != null)
            {
                dbShoe.Name = newShoe.Name;
                dbShoe.Type = newShoe.Type;
                dbShoe.Size = newShoe.Size;
                dbShoe.Price = newShoe.Price;
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }
        public bool Delete(int code)
        {
            
            Shoe dbShoe = db.Shoes.SingleOrDefault(x => x.Code == code);
            if (dbShoe != null)
            {
                try
                {
                    db.Shoes.DeleteOnSubmit(dbShoe);
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public List<Shoe> SelectByName(String keyword)
        {
            db.ObjectTrackingEnabled = false;
            List<Shoe> shoes = db.Shoes.Where(x => x.Name.Contains(keyword)).ToList();
            return shoes;
        }
        public Shoe SelectByCode(int code)
        {
            db.ObjectTrackingEnabled = false;
            Shoe shoe = db.Shoes.SingleOrDefault(x => x.Code == code);
            return shoe;
        }
    }
}
