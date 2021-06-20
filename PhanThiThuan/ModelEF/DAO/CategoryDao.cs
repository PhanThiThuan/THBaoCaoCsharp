using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        PhanThiThuanContext db = null;

        public CategoryDao()
        {

            db = new PhanThiThuanContext();
        }
        public IEnumerable<Category> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories;

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));

            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pageSize);
        }

        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
        public bool Update(Category entity)
        {
            try
            {
                var menu = db.Categories.Find(entity.ID);
                menu.Name = entity.Name;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var menuType = db.Categories.Find(id);
                db.Categories.Remove(menuType);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Category ViewDetail(int id)
        {
            return db.Categories.Find(id);
        }
        public Category Find(int? id)
        {
            return db.Categories.Find(id);
        }

    }
}
