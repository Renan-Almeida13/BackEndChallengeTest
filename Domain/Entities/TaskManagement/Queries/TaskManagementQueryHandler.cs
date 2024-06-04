using Domain.Commons;
using Domain.Interfaces.TaskManagement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TaskManagement.Queries
{
    public class TaskManagementQueryHandler { }

    public class ListTaskManagementQueryHandlers : IRequestHandler<ListTaskManagementQuery, Response>
    {
        private readonly ITaskManagementRepository _iTaskManagementRepository;

        public ListTaskManagementQueryHandlers(ITaskManagementRepository iTaskManagementRepository)
        {
            _iTaskManagementRepository = iTaskManagementRepository;
        }

        public Task<Response> Handle(ListTaskManagementQuery request, CancellationToken cancellationToken)
        {
            var response = _iTaskManagementRepository.List();

            return Task.FromResult(new Response(System.Net.HttpStatusCode.OK, null, response));
        }
    }
}
