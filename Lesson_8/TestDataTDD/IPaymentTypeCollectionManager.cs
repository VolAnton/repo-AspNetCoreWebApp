using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataTDD
{
    public interface IPaymentTypeCollectionManager
    {
        IReadOnlyList<PaymentType> GetAll();
        bool ContainsType(int id);
    }
}
