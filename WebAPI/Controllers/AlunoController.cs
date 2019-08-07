using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Aluno")]
    public class AlunoController : ApiController
    {
        // GET: api/Aluno
        [HttpGet]
        [Route("Recuperar")]
        public IHttpActionResult Recuperar()
        {
            try
            {
                AlunoModel al = new AlunoModel();

                return Ok(al.ListarAlunos());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // GET: api/Aluno/5
        [HttpGet]
        [Route("Recuperar/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                AlunoModel al = new AlunoModel();

                return Ok(al.ListarAlunos(id).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route(@"RecuperarPorDataNome/{data:regex([0-9]{4}\-[0-9]{2})}/{nome:minlength(5)}/")]
        public IHttpActionResult Recuperar(string data, string nome)
        {
            try
            {
                AlunoModel al = new AlunoModel();

                IEnumerable<AlunoDTO> alunos = al.ListarAlunos().Where(x => x.Data == data || x.Nome == nome);

                if (!alunos.Any())
                    return NotFound();

                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPost]
        public IHttpActionResult Post(AlunoDTO aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                AlunoModel _aluno = new AlunoModel();
                _aluno.Inserir(aluno);

                return Ok(_aluno.ListarAlunos());

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]AlunoDTO aluno)
        {
            try
            {
                AlunoModel _aluno = new AlunoModel();
                aluno.Id = id;
                _aluno.Atualizar(aluno);

                return Ok(_aluno.ListarAlunos(id).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                AlunoModel _aluno = new AlunoModel();
                _aluno.Deletar(id);

                return Ok("Deletado com sucesso");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
