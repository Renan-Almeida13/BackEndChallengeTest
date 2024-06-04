using Domain.Entities.TaskManagement.Commands;
using Domain.Entities.TaskManagement.Queries;
using Domain.Entities.TaskManagement.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.TaskManagement
{
    public interface ITaskManagementRepository
    {
        IEnumerable<TaskManagementListResponse> List();
        int Add(AddTaskManagementCommand request);
        int Edit(EditTaskManagementCommand request);
        bool Exist(ExistTaskManagementQuery request);
        int Remove(RemoveTaskManagementCommand request);
    }
}
