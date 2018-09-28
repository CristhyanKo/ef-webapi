using MyApi.Data.DataContext;
using MyApi.Domain.Model;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApi.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class AtividadeController : ApiController
    {
        private MyApiDataContext db = new MyApiDataContext();

        [Route("atividades")]
        public HttpResponseMessage GetAtividades()
        {
            var result = db.Atividades.Include("Categoria").Include("Situacao").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("atividades/{id}")]
        public HttpResponseMessage GetAtividades(int id)
        {
            var result = db.Atividades.Include("Categoria").Include("Situacao").FirstOrDefault(coluna => coluna.Id == id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("atividades")]
        [HttpPost]
        public HttpResponseMessage PostAtividades(Atividade atividade)
        {
            if (atividade == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Atividade inválida.");

            db.Atividades.Add(atividade);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, atividade);
        }

        [Route("atividades")]
        [HttpPost]
        public HttpResponseMessage PutAtividades(Atividade atividade)
        {
            if (atividade == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Atividade inválida.");

            db.Entry(atividade).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, atividade);
        }

        [Route("atividades/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteAtividades(int id)
        {
            db.Atividades.Remove(db.Atividades.Find(id));
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Atividade excluída.");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}