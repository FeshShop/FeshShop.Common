namespace FeshShop.Common.Mvc
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        public const string PathSeparator = "/";
        public const string Id = "{id}";

        protected ActionResult<T> Single<T>(T data)
        {
            if (data == null)
            {
                return this.NotFound();
            }

            return this.Ok(data);
        }
    }
}
