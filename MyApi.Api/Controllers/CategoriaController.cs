using MyApi.Data.DataContext;
using MyApi.Domain.Model;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApi.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class CategoriaController : ApiController
    {
        private MyApiDataContext db = new MyApiDataContext();

        [Route("categorias")]
        public HttpResponseMessage GetCategorias()
        {
            var result = db.Categorias.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("categorias/{id}")]
        public HttpResponseMessage GetCategoria(int id)
        {
            var result = db.Categorias.FirstOrDefault(coluna => coluna.Id == id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("categorias")]
        [HttpPost]
        public HttpResponseMessage PostCategorias(Categoria categoria)
        {
            if (categoria == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Categoria inválida.");

            db.Categorias.Add(categoria);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, categoria);
        }

        [Route("categorias")]
        [HttpPut]
        public HttpResponseMessage PutCategorias(Categoria categoria)
        {
            if (categoria == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Categoria inválida.");

            db.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, categoria);
        }

        [Route("categorias/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteCategorias(int id)
        {
            db.Categorias.Remove(db.Categorias.Find(id));
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Categoria excluída.");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}