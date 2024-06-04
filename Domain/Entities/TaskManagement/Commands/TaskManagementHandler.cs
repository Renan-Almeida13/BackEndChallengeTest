using Domain.Commons;
using Domain.Interfaces.TaskManagement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TaskManagement.Commands
{
    public class TaskManagementHandler { }

    public class AddTaskManagementCommandHandler : Handler, IRequestHandler<AddTaskManagementCommand, Response>
    {
        private readonly ITaskManagementRepository _iTaskManagementRepository;

        public AddTaskManagementCommandHandler(ITaskManagementRepository iTaskManagementRepository)
        {
            _iTaskManagementRepository = iTaskManagementRepository;
        }

        public Task<Response> Handle(AddTaskManagementCommand request, CancellationToken cancellationToken)
        {
            Errors = new TaskManagementValidations(_iTaskManagementRepository).AddTaskManagementValidation(request);
            if (Errors.Count > 0)
            {
                return Task.FromResult(new Response(System.Net.HttpStatusCode.BadRequest, Errors, null));
            }

            var response = _iTaskManagementRepository.Add(request);

            return Task.FromResult(new Response(System.Net.HttpStatusCode.OK, null, response));
        }
    }
    public class EditTaskManagementCommandHandler : Handler, IRequestHandler<EditTaskManagementCommand, Response>
    {
        private readonly ITaskManagementRepository _iTaskManagementRepository;

        public EditTaskManagementCommandHandler(ITaskManagementRepository iTaskManagementRepository)
        {
            _iTaskManagementRepository = iTaskManagementRepository;
        }

        public Task<Response> Handle(EditTaskManagementCommand request, CancellationToken cancellationToken)
        {
            Errors = new TaskManagementValidations(_iTaskManagementRepository).EditTaskManagementValidation(request);
            if (Errors.Count > 0)
            {
                return Task.FromResult(new Response(System.Net.HttpStatusCode.BadRequest, Errors, null));
            }

            var response = _iTaskManagementRepository.Edit(request);

            return Task.FromResult(new Response(System.Net.HttpStatusCode.OK, null, response));
        }
    }
    public class RemoveTaskManagementCommandHandler : Handler, IRequestHandler<RemoveTaskManagementCommand, Response>
    {
        private readonly ITaskManagementRepository _iTaskManagementRepository;

        public RemoveTaskManagementCommandHandler(ITaskManagementRepository iTaskManagementRepository)
        {
            _iTaskManagementRepository = iTaskManagementRepository;
        }

        public Task<Response> Handle(RemoveTaskManagementCommand request, CancellationToken cancellationToken)
        {
            var response = _iTaskManagementRepository.Remove(request);

            return Task.FromResult(new Response(System.Net.HttpStatusCode.OK, null, response));
        }
    }
}
