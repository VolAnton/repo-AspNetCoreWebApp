using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataTDD
{
    public class PaymentTypeCollectionManager : IPaymentTypeCollectionManager
    {
        private readonly IPaymentTypeRepository _repository;
        private IReadOnlyList<PaymentType> _index;
        public PaymentTypeCollectionManager(IPaymentTypeRepository repository)
        {
            _repository = repository;
        }
        public IReadOnlyList<PaymentType> GetAll()
        {
            if (_index is null)
            {
                _index = _repository.GetAll();
            }
            return _index;

        }

        public bool ContainsType(int id)
        {
            foreach (PaymentType paymentType in _index)
            {
                if (paymentType.Id == id)
                {

                return true;
                }
            }
            return false;
        }

    }

}
