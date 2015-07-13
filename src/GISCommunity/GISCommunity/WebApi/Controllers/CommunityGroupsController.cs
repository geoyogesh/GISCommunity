using GISCommunity.WebApi.Models;
using System.Web.Http;

namespace GISCommunity.WebApi.Controllers
{
    public class CommunityGroupsController : ApiController
    {
        [AllowAnonymous]
        [Route("sharing/rest/community/groups/{groupid}")]
        [HttpGet]
        public Group GetGroupDetials(string groupid)
        {
            return new Group();
        }
    }
}
