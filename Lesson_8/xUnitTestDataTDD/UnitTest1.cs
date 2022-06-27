using Moq;
using System;
using System.Collections.Generic;
using TestDataTDD;
using Xunit;

namespace xUnitTestDataTDD
{
    public class UnitTest1
    {
        [Fact]
        public void CachePaymentType_CollectionManager_Test()
        {
            Mock<IPaymentTypeRepository> paymentRepositoryMock = new Mock<IPaymentTypeRepository>();

            paymentRepositoryMock.Setup(mock => mock.GetAll()).Returns(new
            List<PaymentType>()
            {
                new PaymentType() { Id = 1, Name = "Наличная оплата"},
                new PaymentType() { Id = 2, Name = "Картой онлайн"},
            });

            IPaymentTypeCollectionManager paymentTypeCollectionManager =
                new PaymentTypeCollectionManager(paymentRepositoryMock.Object);
            
            paymentTypeCollectionManager.GetAll();
            paymentTypeCollectionManager.GetAll();
            paymentTypeCollectionManager.GetAll();
            
            paymentRepositoryMock.Verify(mock => mock.GetAll(), Times.Once);
        }

        [Fact]
        public void CachePaymentType_CollectionManager_Data_Test()
        {
            Mock<IPaymentTypeRepository> paymentRepositoryMock = new Mock<IPaymentTypeRepository>();

            paymentRepositoryMock.Setup(mock => mock.GetAll()).Returns(new
            List<PaymentType>()
            {
                new PaymentType() { Id = 1, Name = "Наличная оплата"},
                new PaymentType() { Id = 2, Name = "Картой онлайн"},
            });

            IPaymentTypeCollectionManager paymentTypeCollectionManager =
                new PaymentTypeCollectionManager(paymentRepositoryMock.Object);
            
            IReadOnlyList<PaymentType> data_one = paymentTypeCollectionManager.GetAll();
            IReadOnlyList<PaymentType> data_two = paymentTypeCollectionManager.GetAll();
            
            Assert.NotEmpty(data_one);
            Assert.Equal(2, data_one.Count);
            Assert.Equal(data_one, data_two);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]

        public void CachePaymentType_CollectionManager_If_Data_Exists_By_ID_Test(int uniqueId)
        {
            Mock<IPaymentTypeRepository> paymentRepositoryMock = new Mock<IPaymentTypeRepository>();

            paymentRepositoryMock.Setup(mock => mock.GetAll()).Returns(new List<PaymentType>()
            {
                new PaymentType() { Id = 1, Name = "Наличная оплата"},
                new PaymentType() { Id = 2, Name = "Картой онлайн"},
            });

            IPaymentTypeCollectionManager paymentTypeCollectionManager =
                new PaymentTypeCollectionManager(paymentRepositoryMock.Object);

            IReadOnlyList<PaymentType> data_one = paymentTypeCollectionManager.GetAll();

            Assert.True(paymentTypeCollectionManager.ContainsType(uniqueId));
        }
    }
}