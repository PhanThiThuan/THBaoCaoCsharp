using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class SlideDao
    {
       PhanThiThuanContext db = null;
        public SlideDao()
        {
            db = new PhanThiThuanContext();

        }
        public List<Product> ListAll()
        {
            return db.Products.OrderBy(x => x.Quantity).ThenByDescending(x => x.UnitCost).ToList();
        }
    }
}
