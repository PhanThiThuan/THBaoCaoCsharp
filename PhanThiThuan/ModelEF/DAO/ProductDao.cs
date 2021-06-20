using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ModelEF.DAO
{
    public class ProductDao
    {
        PhanThiThuanContext db = null;

        public ProductDao()
        {

            db = new PhanThiThuanContext();
        }
        public List<Product> ListAll()
        {
            return db.Products.OrderBy(x => x.Quantity).ThenByDescending(x => x.UnitCost).ToList();
        }
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));

            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pageSize);
        }
        public long Find(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;

        }
        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ID);
                product.Name = entity.Name;
                product.UnitCost = entity.UnitCost;
                product.Quantity = entity.Quantity;
                product.Image = entity.Image;
                product.Description = entity.Description;  
                product.Status = entity.Status;
                product.ProductType = entity.ProductType;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Products.Find(id);
                db.Products.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Product View(long id)
        {
            return db.Products.Find(id);
        }

        public List<Product> ListAllProduct()
        {
            return db.Products.ToList();
        }
    }
}

