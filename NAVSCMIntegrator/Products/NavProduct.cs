using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NAVSCMIntegrator
{
    using SCMProductsSVC;

    [Serializable]
    [DataContract]
    public class NavProduct
    {
        [DataMember]
            public string ProductID     {get; set;}
        [DataMember]
            public string Name          { get; set;}
        [DataMember]
            public string UOM           {get; set;}
        [DataMember]
            public string ProdGroup     {get; set;}
        [DataMember]
            public string Pack          {get; set;}
        [DataMember]
            public decimal  UnitPrice   {get; set;}
        [DataMember]
            public string InventGroup   {get; set;}
        [DataMember]
            public string Location      {get; set;}
        [DataMember]
            public string ItemTrackngID { get; set; }
        [DataMember]
            public string Family        { get; set; }

        public decimal getItemPrice(string itemCode, string priceGroup)
        {
            decimal itemPrice = 0;
            //add logic to get the item price
            return itemPrice;
        }

        public string getItemLocation(string itemLoc)
        {
            string LocationCode = "UNDEF"; //add code for this

            return LocationCode;
        }
    }

}
