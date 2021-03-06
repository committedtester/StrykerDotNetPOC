using Xunit;
using BikeDistributor.Infrastructure.Domain.Orders.Print.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using BikeDistributor.Domain.Dtos;

namespace BikeDistributor.Infrastructure.Domain.Orders.Print.Receipt.Tests
{
    public class ReceiptHtmlStrategyTests
    {
        [Theory]
        [AutoData]
        public void Print_NullableReceiptDto_ThrowsArgumentNullException(ReceiptHtmlStrategy strategy)
        {
            // Act
            Action act = () => strategy.Print(null);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Theory]
        [AutoData]
        public void Print_NullableReceiptDtoReceiptLineDtos_ThrowsArgumentException(ReceiptHtmlStrategy strategy, ReceiptDto receiptDto)
        {
            // Arrange 
            receiptDto.ReceiptLineDtos = Enumerable.Empty<ReceiptLineDto>().ToList();

            // Act
            Action act = () => strategy.Print(receiptDto);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [AutoData]
        public void Print_ReceiptDto_ReturnsPrintedString(ReceiptHtmlStrategy strategy)
        {
            // Arrange
            var receiptDto = new ReceiptDto { Company = "Company name", SubTotal = 12.3, Tax = 4.2, Total = 16.5,
                ReceiptLineDtos = new List<ReceiptLineDto> { 
                    new ReceiptLineDto { Amount = 8.20, BikeBrand = "Brand name", BikeModel = "model name", LineQuantity = 45  },
                    new ReceiptLineDto { Amount = 4.10, BikeBrand = "Brand namer2", BikeModel = "model name2", LineQuantity = 5  },
                } };

            // Act
            string result = strategy.Print(receiptDto);

            // Assert
            var expectedResult = @"<html><body><h1>Order Receipt for Company name</h1><ul><li>45 x Brand name model name = $8.20</li><li>5 x Brand namer2 model name2 = $4.10</li></ul><h3>Sub-Total: $12.30</h3><h3>Tax: $4.20</h3><h2>Total: $16.50</h2></body></html>";

            Assert.Equal(expectedResult, result);
        }
    }
}