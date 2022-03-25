using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMasterDetails.Utility
{
    public class HelperClass
    {
        public bool compareprice(float _productCost, float _productPrice)
        {
            if (_productCost < 0 || _productPrice < 0)
                return false;
            if ((_productCost > _productPrice) )
                return false;
            

            return true;
        }
    }
}
