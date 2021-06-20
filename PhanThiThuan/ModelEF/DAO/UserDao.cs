using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;

namespace ModelEF.DAO
{
    public class UserDao
    {
        PhanThiThuanContext db = null;

        public UserDao()
        {

            db = new PhanThiThuanContext();
        }
        public long Find(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.ID;

        }
        public long Insert(UserAccount entity)
        {
            db.UserAccounts.Add(entity);
            db.SaveChanges();
            return entity.ID;

        }
        public bool Update(UserAccount entity)
        {
            try
            {
                var user = db.UserAccounts.Find(entity.ID);
                user.UserName = entity.UserName;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;

                }
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public UserAccount GetById(string userName)
        {
            return db.UserAccounts.SingleOrDefault(x => x.UserName == userName);
        }
        public UserAccount ViewDetail(int id)
        {
            return db.UserAccounts.Find(id);
        }
       

        public int Login(string userName, string passWord)
        {
            //kiểm tra giá trị trong bảng với gtri truyền vào
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName == userName);
            //nếu có giá trị đó
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == "Blocked")
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                        return 1;
                    else
                        return -2;
                }

            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.UserAccounts.Find(id);
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<UserAccount> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.UserName.Contains(searchString));

            }
            return model.OrderByDescending(x => x.UserName).ToPagedList(page, pageSize);
        }
    }
}

