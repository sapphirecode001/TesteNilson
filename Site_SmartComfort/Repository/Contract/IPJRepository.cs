using Site_SmartComfort.Models;

namespace Site_SmartComfort.Repository.Contract
{
    public interface IPJRepository
    {
        Task CadastrarPJ(PJ pj, Usuario usuario);  // Criar PJ e Usuario
        Task AtualizarPJ(PJ pj, Usuario usuario);  // Atualizar PJ e Usuario
        Task ExcluirPJ(int idUsuario);  // Excluir PJ e Usuario
        Task<PJ?> ObterPJ(int idUsuario);  // Obter PJ com base no Usuario
    }
}
