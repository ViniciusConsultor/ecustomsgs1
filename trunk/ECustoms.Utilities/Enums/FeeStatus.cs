using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECustoms.Utilities.Enums
{
    public enum FeeStatus
    {
        NotNeedPayFee = 0, // khong can thu phi
        HasNotPayFee = 1,  //chua tra phi
        PaidFee = 2,       //da thu phi
    }
}
