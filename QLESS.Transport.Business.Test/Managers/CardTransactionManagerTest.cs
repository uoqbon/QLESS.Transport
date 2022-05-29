using Moq;
using QLESS.Transport.Business.Contracts.Managers;
using QLESS.Transport.Business.Contracts.Services;
using QLESS.Transport.Business.Managers;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace QLESS.Transport.Business.Test.Managers
{
    public class CardTransactionManagerTest
    {
        private Mock<ICardService> _cardService;
        private Mock<ICardTypeService> _cardTypeService;
        private ICardTransactionManager _instanceUnderTest;

        public CardTransactionManagerTest()
        {
            _cardService = new Mock<ICardService>();
            _cardTypeService = new Mock<ICardTypeService>();
            _instanceUnderTest = new CardTransactionManager(_cardService.Object, _cardTypeService.Object);
        }

        public static IEnumerable<object[]> ValidateReferenceIdTheories = new[]
        {
            CreateValidateReferenceIdTheory("A1-1234-1234", true),
            CreateValidateReferenceIdTheory("A112-1234-1234", true),
            CreateValidateReferenceIdTheory("A11-1234-1234", false),
            CreateValidateReferenceIdTheory("A11-123412341", false),
            CreateValidateReferenceIdTheory("A11-1234W-1234w", false),
        };

        private static object[] CreateValidateReferenceIdTheory(string referenceId, bool expected) => new object[] { referenceId, expected };

        [Theory, MemberData(nameof(ValidateReferenceIdTheories))]
        public void ValidateDiscountReferenceId_Returns_Expected(string referenceId, bool expected)
        {
            var actual = _instanceUnderTest.ValidateDiscountReferenceId(referenceId);
            actual.ShouldBe(expected); 
        }
    }
}
