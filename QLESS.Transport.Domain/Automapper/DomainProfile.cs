using AutoMapper;
using QLESS.Transport.Core.DTO;
using QLESS.Transport.Data.Entities;

namespace QLESS.Transport.Data.Automapper
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
