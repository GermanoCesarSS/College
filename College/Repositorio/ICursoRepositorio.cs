using College.Models;

namespace College.Repositorio
{
    public interface ICursoRepositorio
    {
        CursosModel ListarPorId(int id);

        List<CursosModel> BuscarTodos();

        CursosModel Adicionar(CursosModel curso);

        CursosModel Atualizar(CursosModel curso);

        
    }
}
