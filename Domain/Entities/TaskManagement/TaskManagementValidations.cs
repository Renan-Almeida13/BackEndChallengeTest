using Domain.Commons;
using Domain.Entities.TaskManagement.Commands;
using Domain.Interfaces.TaskManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TaskManagement
{
    public class TaskManagementValidations : Validation
    {
        private readonly ITaskManagementRepository _iTaskManagementRepository;

        public TaskManagementValidations(ITaskManagementRepository iTaskManagementRepository)
        {
            _iTaskManagementRepository = iTaskManagementRepository;
        }

        public List<string> AddTaskManagementValidation(AddTaskManagementCommand request)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(request.Subject))
            {
                errors.Add("Please, inform the subject.");
            }

            if (errors.Count == 0 && _iTaskManagementRepository.Exist(new Queries.ExistTaskManagementQuery() { Subject = request.Subject }))
                errors.Add("TaskManagement already exists.");

            return errors;
        }

        public List<string> EditTaskManagementValidation(EditTaskManagementCommand request)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(request.Subject))
            {
                errors.Add("Please, inform the subject.");
            }

            if (errors.Count == 0 && _iTaskManagementRepository.Exist(new Queries.ExistTaskManagementQuery() { Subject = request.Subject, Id = request.Id }))
                errors.Add("TaskManagement already exists.");

            return errors;
        }
    }
}
