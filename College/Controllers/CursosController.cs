using College.Models;
using College.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    public class CursosController : Controller
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public CursosController(ICursoRepositorio cursoRepositorio){
            _cursoRepositorio = cursoRepositorio;
        }

        public IActionResult Index() {
            List<CursosModel> cursos = _cursoRepositorio.BuscarTodos();
            return View(cursos);
        }

        public IActionResult Criar() {
            return View();
        }

        public IActionResult Editar(int id) {
            CursosModel curso = _cursoRepositorio.ListarPorId(id);
            return View(curso);
        }

        public IActionResult ApagarConfirmacao(int id) {
            CursosModel curso = _cursoRepositorio.ListarPorId(id);
            return View();
        }

        [HttpPost]
        public IActionResult Criar(CursosModel curso) { 
                
            _cursoRepositorio.Adicionar(curso);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(CursosModel curso) {

            _cursoRepositorio.Atualizar(curso);
            return RedirectToAction("Index");
        }
    }
}
