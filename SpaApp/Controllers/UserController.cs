using System.Linq;
using SpaApp.Common;
using SpaApp.Models;

namespace SpaApp.Controllers
{
    using System.Web.Http;

    public class UserController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(_useRepository.Query().ToArray());
        }

        public UserController(IRepository<User> useRepository)
        {
            _useRepository = useRepository;
        }

        private readonly IRepository<User> _useRepository;
    }
}
