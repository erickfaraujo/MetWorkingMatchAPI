using AutoMapper;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetWorkingMatch.Application.Mapping
{
    public class DomainToPedidoMatchResponse : Profile
    {
        public DomainToPedidoMatchResponse()
        {
            CreateMap<PedidoMatch,PedidosMatchResponse>();
            CreateMap<PedidoMatch, PedidoResponse>();
            CreateMap<CreatePedidoRequest, PedidoMatch>();
            CreateMap<UpdatePedidoRequest, PedidoMatch>();
            CreateMap<UpdatePedidoRequest, PedidoResponse>();
        }

    }
}
