using BlogApp.Core.Enums;
using BlogApp.Utility.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlogApp.Utility.Attributes
{
    public class ActionAccessAttribute : ActionFilterAttribute
    {
        public UserType[] AllowedUserTypes;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var currentUserType = context.HttpContext.User.Identity.GetUserType();

            if (!AllowedUserTypes.Contains(currentUserType))
            {
                context.Result = new ContentResult()
                {
                    Content = "Bu işleme erişim hakkınız bulunmuyor.",
                    StatusCode = (int)HttpStatusCode.BadRequest,
                };
            }

            base.OnActionExecuting(context);
        }
    }
}
