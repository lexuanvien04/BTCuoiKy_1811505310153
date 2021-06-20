using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ProductDao
    {
        private LeXuanVienContext db;

        public ProductDao()
        {
            db = new LeXuanVienContext();
        }

        public Product Find(string id)
        {
            return db.Products.Find(id);
        }

        public List<Product> ListAll()
        {
            return db.Products.OrderBy(x => x.Quantity).ThenByDescending(x => x.UnitCost).ToList();
        }

        public Product Details(string id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.ProductName.Contains(keysearch));
            }
            return model.OrderBy(x => x.ProductName).ToPagedList(page, pagesize);
        }

        //public bool ChangeStatus(string id)
        //{
        //    var user = db.UserAccounts.Find(id);
        //    user.Status = !user.Status;
        //    db.SaveChanges();
        //    return user.Status;
        //}


        public string Insert(Product entityProduct)
        {
            var dao = Find(entityProduct.ProductID);
            if (dao == null)
            {
                db.Products.Add(entityProduct);
            }
            else
            {
                dao.ProductName = entityProduct.ProductName;
            }
            db.SaveChanges();
            return entityProduct.ProductID;
        }

        public string Update(Product entity)
        {
            var dao = Find(entity.ProductID);
            if (dao == null)
            {
                db.Products.Add(entity);
            }
            else
            {
                dao.ProductName = entity.ProductName;
            }
            db.SaveChanges();
            return entity.ProductID;
        }


        public bool Delete(string id)
        {
            try
            {
                var prod = db.Products.Find(id);
                db.Products.Remove(prod);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

