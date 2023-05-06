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

        public IActionResult Apagar(int id) {

            try {

            bool apagado = _cursoRepositorio.Apagar(id);

                if (apagado) {
                    TempData["MensagemSucesso"] = "Curso apagado com sucesso";
                }
                else {
                    TempData["MensagemErro"] = "Erro ao apagar curso, tente novamente";

                }

                return RedirectToAction("Index");

            }catch (Exception ex) {

                TempData["MensagemErro"] = $"Erro ao cadastrado curso, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id) {
            CursosModel curso = _cursoRepositorio.ListarPorId(id);
            return View(curso);
        }

        public IActionResult ApagarConfirmacao(int id) {
            CursosModel curso = _cursoRepositorio.ListarPorId(id);
            return View(curso);
        }

        [HttpPost]
        public IActionResult Criar(CursosModel curso) {

            try {
                if (ModelState.IsValid) {

                    _cursoRepositorio.Adicionar(curso);
                    TempData["MensagemSucesso"] = "Curso cadastrado com sucesso";
                    return RedirectToAction("Index");

                }

                return View(curso);
            }
            catch (Exception ex) {
                TempData["MensagemErro"] = $"Erro ao cadastrado curso, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(CursosModel curso) {

            try {
                if (ModelState.IsValid) {
                    _cursoRepositorio.Atualizar(curso);
                    TempData["MensagemSucesso"] = "Curso alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", curso);
            }
            catch(Exception ex) {
                TempData["MensagemErro"] = $"Erro ao alterar curso, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
