using Domain.Commons;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TaskManagement.Commands
{
    public class TaskManagementCommands { }

    public class AddTaskManagementCommand : Command, IRequest<Response>
    {
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }

    public class EditTaskManagementCommand : Command, IRequest<Response>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }

    public class RemoveTaskManagementCommand : Command, IRequest<Response>
    {
        public int Id { get; set; }
    }
}
