using Moq;
using QLESS.Transport.Business.Contracts.Managers;
using QLESS.Transport.Business.Contracts.Services;
using QLESS.Transport.Business.Managers;
using QLESS.Transport.Contracts.DTO;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace QLESS.Transport.Business.Test.Managers
{
    public class CommuteManagerTest
    {
        private Mock<ICardService> _cardService;
        private Mock<ICommuteHistoryService> _commuteHistoryService;
        private ICommuteManager _instanceUnderTest;

        private static readonly DateTime _currentDate = DateTime.UtcNow;
        private static readonly DateTime _expiredDate = DateTime.UtcNow.AddYears(-5).AddHours(-1);

        public CommuteManagerTest()
        {
            _cardService = new Mock<ICardService>();
            _commuteHistoryService = new Mock<ICommuteHistoryService>();

            _instanceUnderTest = new CommuteManager(_commuteHistoryService.Object, _cardService.Object);
        }

        public static IEnumerable<object[]> DepartAsyncTheories = new[]
        {
            CreateDepartAsyncTheories(
                new CardDTO
                {
                    Load = 100,
                    CreatedDate = _currentDate,                   
                    CardType = new CardTypeDTO
                    {                       
                        Rate = 15
                    }                   
                },
                null,
                addHistoryCount: 1,
                new DepartureResponseDTO
                {
                    LoadBalance = 100,
                    IsEntryAllowed = true,
                    IsExpired = false,
                }
            ),
            CreateDepartAsyncTheories(
                new CardDTO
                {
                    Load = 15,
                    CreatedDate = _currentDate,
                    CardType = new CardTypeDTO
                    {
                        Rate = 15
                    }
                },
                null,
                addHistoryCount: 1,
                new DepartureResponseDTO
                {
                    LoadBalance = 15,
                    IsEntryAllowed = true,
                    IsExpired = false,
                }
            ),
            CreateDepartAsyncTheories(
                new CardDTO
                {
                    Load = 10,
                    CreatedDate = _currentDate,
                    CardType = new CardTypeDTO
                    {
                        Rate = 15
                    }
                },
                null,
                addHistoryCount: 0,
                new DepartureResponseDTO
                {
                    LoadBalance = 10,
                    IsEntryAllowed = false,
                    IsExpired = false,
                }
            ),
            CreateDepartAsyncTheories(
                new CardDTO
                {
                    Load = 15,
                    CreatedDate = _expiredDate,
                    CardType = new CardTypeDTO
                    {
                        Rate = 15
                    }
                },
                null,
                addHistoryCount: 0,
                new DepartureResponseDTO
                {
                    LoadBalance = 15,
                    IsEntryAllowed = false,
                    IsExpired = true,
                }
            ),
        };

        private static object[] CreateDepartAsyncTheories(CardDTO cardInfo, CommuteHistoryDTO historyEntry, int addHistoryCount, DepartureResponseDTO expected) =>
            new object[] { cardInfo, historyEntry, addHistoryCount, expected };

        public static IEnumerable<object[]> ArriveAsyncTheories = new[]
        {
            CreateArriveAsyncTheories(
                new CardDTO
                {
                    Load = 100,                    
                    CardType = new CardTypeDTO
                    {
                        Rate = 15
                    }
                },
                new CommuteHistoryDTO
                {
                    IsDeparture = true
                },
                addHistoryCount: 1,
                new ArrivalResponseDTO
                {
                    LoadBalance = 85,
                    Fare = 15,
                    IsExitAllowed = true
                }
            ),
            CreateArriveAsyncTheories(
                new CardDTO
                {
                    Load = 15,                   
                    CardType = new CardTypeDTO
                    {
                        Rate = 15
                    }
                },
                new CommuteHistoryDTO
                {
                    IsDeparture = true
                },
                addHistoryCount: 1,
                new ArrivalResponseDTO
                {
                    LoadBalance = 0,
                    Fare = 15,
                    IsExitAllowed = true
                }
            ),
            CreateArriveAsyncTheories(
                new CardDTO
                {
                    Load = 100,                    
                    CardType = new CardTypeDTO
                    {
                        Rate = 15
                    }
                },
                new CommuteHistoryDTO
                {
                    IsDeparture = false
                },
                addHistoryCount: 0,
                new ArrivalResponseDTO
                {
                    LoadBalance = 100,
                    Fare = 15,
                    IsExitAllowed = false
                }
            ),
            CreateArriveAsyncTheories(
                new CardDTO
                {
                    Load = 10,                   
                    CardType = new CardTypeDTO
                    {
                        Rate = 15
                    }
                },
                new CommuteHistoryDTO
                {
                    IsDeparture = true
                },
                addHistoryCount: 0,
                new ArrivalResponseDTO
                {
                    LoadBalance = 10,
                    Fare = 15,
                    IsExitAllowed = false                    
                }
            )           
        };

        private static object[] CreateArriveAsyncTheories(CardDTO cardInfo, CommuteHistoryDTO historyEntry, int addHistoryCount, ArrivalResponseDTO expected) =>
            new object[] { cardInfo, historyEntry, addHistoryCount, expected };
        
        [Theory, MemberData(nameof(DepartAsyncTheories))]
        public async Task DepartAsync_Returns_Expected(CardDTO cardInfo, CommuteHistoryDTO historyEntry, int addHistoryCount, DepartureResponseDTO expected)
        {
            _cardService.Setup(s => s.GetByIdAsync(It.IsAny<long>())).ReturnsAsync(cardInfo);
            _commuteHistoryService.Setup(s => s.AddAsync(It.IsAny<long>(), It.IsAny<int>(), It.IsAny<bool>())).Returns(Task.CompletedTask);
            _commuteHistoryService.Setup(s => s.GetLatestEntryAsync(It.IsAny<long>())).ReturnsAsync(historyEntry);

            var actual = await _instanceUnderTest.DepartAsync(1, 1);

            _commuteHistoryService.Verify(s => s.AddAsync(It.IsAny<long>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Exactly(addHistoryCount));

            actual.ShouldBeEquivalentTo(expected);
        }

        [Theory, MemberData(nameof(ArriveAsyncTheories))]
        public async Task ArriveAsync_Returns_Expected(CardDTO cardInfo, CommuteHistoryDTO historyEntry, int addHistoryCount, ArrivalResponseDTO expected)
        {
            _cardService.Setup(s => s.GetByIdAsync(It.IsAny<long>())).ReturnsAsync(cardInfo);
            _cardService.Setup(s => s.UpdateLoadBalanceAsync(It.IsAny<long>(), It.IsAny<decimal>())).Returns(Task.CompletedTask);
            _commuteHistoryService.Setup(s => s.AddAsync(It.IsAny<long>(), It.IsAny<int>(), It.IsAny<bool>())).Returns(Task.CompletedTask);
            _commuteHistoryService.Setup(s => s.GetLatestEntryAsync(It.IsAny<long>())).ReturnsAsync(historyEntry);

            var actual = await _instanceUnderTest.ArriveAsync(1, 2);

            _cardService.Verify(s => s.UpdateLoadBalanceAsync(It.IsAny<long>(), It.IsAny<decimal>()), Times.Exactly(addHistoryCount));
            _commuteHistoryService.Verify(s => s.AddAsync(It.IsAny<long>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Exactly(addHistoryCount));

            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
