using College.DAO;
using College.Models;

namespace College.Repositorio
{
    public class CursosRepositorio : ICursoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public CursosRepositorio(BancoContext bancoContext) { 
            _bancoContext = bancoContext;
        }

        public CursosModel Adicionar(CursosModel curso) {
           
            _bancoContext.Cursos.Add(curso);
            _bancoContext.SaveChanges();
            return curso;
        }

        public List<CursosModel> BuscarTodos() {
           
            return _bancoContext.Cursos.ToList();
        }
    }
}
