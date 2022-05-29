using AutoMapper;
using QLESS.Transport.Contracts.DTO;
using QLESS.Transport.Domain.Entities;

namespace QLESS.Transport.Domain.Automapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Card, CardDTO>(MemberList.Destination)                
                .ReverseMap()
                .ForPath(d => d.CardTypeId, o => o.MapFrom(s => (short)s.CardTypeId));
            CreateMap<CardType, CardTypeDTO>(MemberList.Destination).ReverseMap();
            CreateMap<CommuteHistory, CommuteHistoryDTO>(MemberList.Destination).ReverseMap();
        }
    }
}
