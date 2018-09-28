using MyApi.Data.DataContext;
using MyApi.Domain.Model;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApi.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class SituacaoController : ApiController
    {
        private MyApiDataContext db = new MyApiDataContext();

        [Route("situacoes")]
        public HttpResponseMessage GetSituacoes()
        {
            var result = db.Situacoes.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("situacoes/{id}")]
        public HttpResponseMessage GetSituacoes(int id)
        {
            var result = db.Situacoes.FirstOrDefault(coluna => coluna.Id == id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("situacoes")]
        [HttpPost]
        public HttpResponseMessage PostSituacao(Situacao situacao)
        {
            if (situacao == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Situação inválida.");

            db.Situacoes.Add(situacao);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, situacao);
        }

        [Route("situacoes")]
        [HttpPut]
        public HttpResponseMessage PutSituacao(Situacao situacao)
        {
            if (situacao == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Situação inválida.");

            db.Entry(situacao).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, situacao);
        }

        [Route("situacoes/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteSituacao(int id)
        {
            db.Situacoes.Remove(db.Situacoes.Find(id));
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Situação excluída.");

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}