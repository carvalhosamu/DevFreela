
using DevFreela.Application.Commands.CreateCommentProject;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.InputModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DevFreela.Application.Queries.GetProjectsById;
using Microsoft.AspNetCore.Authorization;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController( IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        [Authorize(Roles = ("client, freelancer"))]
        public async Task<IActionResult> GetProjects(string query)
        {
            return Ok( await _mediator.Send(new GetAllProjectsQuery(query))); 
        }

        [HttpGet("{id}")]
        [Authorize(Roles = ("client, freelancer"))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetProjectByIdQuery(id));
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        [Authorize(Roles = ("client"))]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand createProject)
        {
            if (createProject.Title.Length > 50)
            {
                return BadRequest();
            }

            /* int id = _service.Create(createProject);*/
            int id = await _mediator.Send(createProject);
            return CreatedAtAction(nameof(GetById), new {id = id}, createProject);
        }

        [HttpPut]
        [Authorize(Roles = ("client"))]
        public async Task<IActionResult> Put([FromBody] UpdateProjectCommand updateProject)
        {
            try
            {
                if (updateProject.Description.Length > 200)
                {
                    return BadRequest();
                }

                await _mediator.Send(updateProject);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = ("client"))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteProjectCommand(id));
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
           
        }

        [HttpPost("/comments")]
        [Authorize(Roles = ("client, freelancer"))]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand createCommentModel)
        {
            try
            {
                // _service.CreateComment(createCommentModel);
                 await _mediator.Send(createCommentModel);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }   

        }

        [HttpPut("{id}/start")]
        [Authorize(Roles = ("client"))]
        public async Task<IActionResult> Start(int id)
        {
            try
            {
                await _mediator.Send(new StartProjectCommand(id));
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);   
            }
            
           
        }

        [HttpPut("{id}/finish")]
        [Authorize(Roles = ("client"))]
        public async Task<IActionResult> Finish(int id)
        {
            try
            {
                // _service.Finish(id);
                await _mediator.Send(new FinishProjectCommand(id));
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
