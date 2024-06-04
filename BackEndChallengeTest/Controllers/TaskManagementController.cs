using Domain.Entities.TaskManagement.Commands;
using Domain.Entities.TaskManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/taskManagement")]
    [ApiController]
    public class TaskManagementController : Controller
    {
        private readonly IMediator _mediator;

        public TaskManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var response = await _mediator.Send(new ListTaskManagementQuery());
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTaskManagementCommand request)
        {
            var response = await _mediator.Send(request);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditTaskManagementCommand request)
        {
            var response = await _mediator.Send(request);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut("remove")]
        public async Task<IActionResult> Remove(RemoveTaskManagementCommand request)
        {
            var response = await _mediator.Send(request);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
