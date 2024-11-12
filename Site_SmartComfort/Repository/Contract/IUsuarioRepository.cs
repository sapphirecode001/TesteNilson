using Site_SmartComfort.Models;

namespace Site_SmartComfort.Repository.Contract
{
    public interface IUsuarioRepository
    {
        Task<bool> UsuarioExiste(string EmailUsu); 
        IEnumerable<Usuario> ObterTodosUsuarios();
        Task<Usuario> ObterUsuario(int Id);
        Usuario LoginUsuario(string EmailUsu, string SenhaUsu);
    }
}
