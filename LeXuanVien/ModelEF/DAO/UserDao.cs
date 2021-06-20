using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class UserDao
    {
        private LeXuanVienContext db;

        public UserDao()
        {
            db = new LeXuanVienContext();
        }

        public int login(string user, string pass)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.Username.Contains(user) && x.Password.Contains(pass));
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public UserAccount Find(string username)
        {
            return db.UserAccounts.Find(username);
        }

        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }

        public IEnumerable<UserAccount> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Username.Contains(keysearch));
            }
            return model.OrderBy(x => x.Username).ToPagedList(page, pagesize);
        }

        public bool ChangeStatus(string id)
        {
            var user = db.UserAccounts.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }

        public string Insert(UserAccount entityUser)
        {
            var user = Find(entityUser.UserID);
            if (user == null)
            {
                db.UserAccounts.Add(entityUser);
            }
            else
            {
                user.UserID = entityUser.UserID;
                user.Username = entityUser.Username;
                if (!String.IsNullOrEmpty(entityUser.Password))
                {
                    user.Password = entityUser.Password;
                }
            }
            db.SaveChanges();
            return entityUser.UserID;
        }

        public string Update(UserAccount entity)
        {
            var user = Find(entity.UserID);
            if (user == null)
            {
                db.UserAccounts.Add(entity);
            }
            else
            {
                user.UserID = entity.UserID;
                user.Username = entity.Username;
                if (!String.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
            }
            db.SaveChanges();
            return entity.UserID;
        }

        public bool Delete(string id)
        {
            try
            {
                var user = db.UserAccounts.Find(id);
                db.UserAccounts.Remove(user);
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
