using HrmsLibrary.DataAccess;
using HrmsObjects.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmsLibrary.BusinessLogic
{
    [Serializable]
    public class ProductMgr
    {
        public List<Product> ModuleList()
        {
            ProductDbo ProductDbo = new ProductDbo();
            return ProductDbo.ModuleList();
        }
        public List<Product> MainGrid(int PageNo, int RowsPerPage, string SearchText)
        {
            ProductDbo ProductDbo = new ProductDbo();
            return ProductDbo.MainGrid(PageNo, RowsPerPage, SearchText);
        }
        public Int32 CheckProductName(string strcode)
        {
            ProductDbo ProductDbo = new ProductDbo();
            return ProductDbo.CheckProductName(strcode);
        }
        public string Create(Product objProduct)
        {
            ProductDbo ProductDbo = new ProductDbo();
            return ProductDbo.Create(objProduct);
        }
        public string Update(Product objProduct)
        {
            ProductDbo ProductDbo = new ProductDbo();
            return ProductDbo.Update(objProduct);
        }
    }
}
