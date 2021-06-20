using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        private LeXuanVienContext db;

        public CategoryDao()
        {
            db = new LeXuanVienContext();
        }

        public Category Find(string categoryid)
        {
            return db.Categories.Find(categoryid);
        }

        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }

        public Category ViewDetail(string id)
        {
            return db.Categories.Find(id);
        }

        public IEnumerable<Category> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.CategoryName.Contains(keysearch));
            }
            return model.OrderBy(x => x.CategoryName).ToPagedList(page, pagesize);
        }

        //public bool ChangeStatus(string id)
        //{
        //    var user = db.UserAccounts.Find(id);
        //    user.Status = !user.Status;
        //    db.SaveChanges();
        //    return user.Status;
        //}

        public string Insert(Category entitycategory)
        {
            var dao = Find(entitycategory.CategoryID);
            if (dao == null)
            {
                db.Categories.Add(entitycategory);
            }
            else
            {
                dao.CategoryName = entitycategory.CategoryName;
            }
            db.SaveChanges();
            return entitycategory.CategoryID;
        }

        public bool Delete(string id)
        {
            try
            {
                var cate = db.Categories.Find(id);
                db.Categories.Remove(cate);
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
