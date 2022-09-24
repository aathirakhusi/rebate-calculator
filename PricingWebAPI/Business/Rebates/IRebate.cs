using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rebates
{
    public interface IRebate
    {
        IEnumerable<ApplicableRebate> DiscountsApplicable(PurchaseWithSubTotal product);
    }
}
