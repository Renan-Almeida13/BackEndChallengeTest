using Domain.Commons;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TaskManagement.Queries
{
    public class TaskManagementQueries { }

    public class ListTaskManagementQuery : IRequest<Response> { }
    public class ExistTaskManagementQuery : IRequest<Response>
    {
        public int Id { get; set; }
        public string Subject { get; set; }
    }
}
