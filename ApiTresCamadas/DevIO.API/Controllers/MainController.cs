using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevIO.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected bool OperacaoValida()
        {
            return true;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return new ObjectResult(result);
            }

            return BadRequest(new
            {

            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if(!modelState.IsValid) { }

            return CustomResponse();
        }

        protected void NotificaErro(string mensagem)
        {

        }
    }
}
