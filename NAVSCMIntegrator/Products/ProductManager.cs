using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAVSCMIntegrator
{
    using SCMProductsSVC;

    class ProductManager
    {
        public List<NavProduct> getAllNavProducts()
        {
            SalesItems_Service ProductsSVC = new SalesItems_Service();
            ProductsSVC.UseDefaultCredentials = true;

            List<NavProduct> allNavProducts = new List<NavProduct>();

            const int fetchsize = 0;
            string bookMarkKey = null;
            SalesItems[] results = ProductsSVC.ReadMultiple(new SalesItems_Filter[] { }, bookMarkKey, fetchsize);

            foreach (SalesItems item in results)
            {
                NavProduct currProduct = new NavProduct();
                currProduct = ConvertItemToProduct(item);
                allNavProducts.Add(currProduct);
            };

            return allNavProducts;
        }

        public NavProduct getNavProduct(string ProductCode)
        {
            SalesItems_Service ProductsSVC = new SalesItems_Service();
            ProductsSVC.UseDefaultCredentials = true;

            NavProduct salesItem = new NavProduct();
            SalesItems NavItem = ProductsSVC.Read(ProductCode);

            NavProduct currProduct = ConvertItemToProduct(NavItem);

            return currProduct;
        }

        public NavProduct ConvertItemToProduct(SalesItems NavItemRec)
        {
            //transpose Nav Product to Router Product Rec
            NavProduct newItemRec = new NavProduct();
            newItemRec.ProdGroup = NavItemRec.Product_Group_Code; //create the lookups for this
            newItemRec.ProductID = NavItemRec.No;
            newItemRec.UOM = NavItemRec.Base_Unit_of_Measure; //create the lookups for this
            newItemRec.Pack = NavItemRec.Pack;
            newItemRec.UnitPrice = NavItemRec.Standard_Cost; //change this to look at an actual price ist
            newItemRec.InventGroup = NavItemRec.Inventory_Posting_Group; //create the lookups for this
            newItemRec.Location = newItemRec.getItemLocation(NavItemRec.No);
            newItemRec.ItemTrackngID = NavItemRec.Item_Tracking_Code; //major code for this operation
            return newItemRec;
        }
    }
}
