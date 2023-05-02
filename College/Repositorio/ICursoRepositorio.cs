using College.Models;

namespace College.Repositorio
{
    public interface ICursoRepositorio
    {
        List<CursosModel> BuscarTodos();

        CursosModel Adicionar(CursosModel curso);
    }
}
