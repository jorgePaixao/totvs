using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TotvsPDV.Models;
using TotvsPDV.Repository;

namespace TotvsPDV.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : Controller
    {

        IPostRepository postRepository;

        public PagamentoController(IPostRepository _postRepository)
        {
            postRepository = _postRepository;
        }


        [HttpPost]
        [Route("ProcessaPagamento")]
        public async Task<IActionResult> ProcessaPagamento([FromBody]RegistroCaixa model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CalculaTroco();

                    var postId = await postRepository.AddRegistro(model);
                    if (postId > 0)
                    {
                        return Ok(model);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {

                    return BadRequest(ex);
                }

            }

            return BadRequest();
        }
    }
}