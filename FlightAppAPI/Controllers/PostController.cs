using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightAppAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PostController : Controller
    {
        [HttpPost("feedback")]
        public ActionResult<DTO> PostFeedback(DTO obj)
        {
            return new DTO();
        }

        [AllowAnonymous]
        [HttpPost("order")]
        public ActionResult<DTO2> PostOrder(DTO2 obj)
        {
            return new DTO2();
        }

        public class DTO
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Rating { get; set; }
        }

        public class DTO2
        {
            public int ProductId { get; set; }
            public int UserId { get; set; }
        }
    }
}