using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Queries.Application
{
    public class GetAllApplicationQueryRequest:IRequest<List<GetAllApplicationQueryResponse>>
    {


    }
} 