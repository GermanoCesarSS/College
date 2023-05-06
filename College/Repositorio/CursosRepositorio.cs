using College.DAO;
using College.Models;

namespace College.Repositorio
{
    public class CursosRepositorio : ICursoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public CursosModel ListarPorId(int id) {
            return _bancoContext.Cursos.FirstOrDefault(x => x.Id == id);
        }

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

        public CursosModel Atualizar(CursosModel curso) {
            CursosModel cursoDB = ListarPorId(curso.Id);

            if (cursoDB == null)
                throw new Exception("Houve um erro na atualização do contato!");

            cursoDB.Site = curso.Site;
            cursoDB.Titulo = curso.Titulo;
            cursoDB.Link = curso.Link;
            cursoDB.Descricao = curso.Descricao;
            cursoDB.Duracao = curso.Duracao;

            _bancoContext.Cursos.Update(cursoDB);
            _bancoContext.SaveChanges();

            return cursoDB;
        }
    }
}
