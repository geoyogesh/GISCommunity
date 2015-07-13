using GISCommunity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace GISCommunity.WebApi.Controllers
{

    public class CommunityUsersController : ApiController
    {
        [AllowAnonymous]
        [Route("sharing/rest/community/users/{username}/notifications")]
        [HttpGet]
        public Dictionary<string, Object> GetNotifications(string username)
        {
            return new Dictionary<string, object>
            {
                {"notifications",new List<String>()}
            };
        }

        [AllowAnonymous]
        [Route("sharing/rest/community/users/{username}/tags")]
        [HttpGet]
        public object GetTags(string username)
        {
            return new
            {
                Tags = new List<TagEntry>
                {
                    new TagEntry{
                        Tag="html",Count=1
                    },new TagEntry{
                        Tag="html",Count=1
                    }
                }
            };
        }
    }
}
