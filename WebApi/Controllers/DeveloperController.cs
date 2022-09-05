using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        //Here are injecting only the IUnitOfWork object.
        //This way, you can completely avoid writing lines and lines of injections to your controllers.
        private readonly IUnitOfWork _unitOfWork;
        public DeveloperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Using the _unitofWork object,
        // we are able to acces the custom method ‘GetPopularDeveloper’ we created.
        // This returns a set of developers sorted by the descending order of the follower count.
        //Returns a 200 Status Ok with the developers.
        public IActionResult GetPopularDevelopers([FromQuery] int count)
        {
            var popularDevelopers = _unitOfWork.Developers.GetPopularDevelopers(count);
            return Ok(popularDevelopers);
        }

        //- is where I build sample entity objects just for demonstration purpose.
        //– Add the developer object to the uow context.
        //– Add the project object to the uow context.
        //– Finally commits the changes to the database.
        
        [HttpPost]
        public IActionResult AddDeveloperAndProject()
        {
            var developer = new Developer
            {
                Followers = 35,
                Name = "Luchulumanco Gontshi"
            };
            var project = new Project
            {
                Name = "codewithmukesh"
            };
            _unitOfWork.Developers.Add(developer);
            _unitOfWork.Projects.Add(project);
            _unitOfWork.Complete();
            return Ok();

        }
    }
}
