using Site_SmartComfort.Models;

namespace Site_SmartComfort.Repository.Contract
{
    public interface IPFRepository
    {
        Task CadastrarPF(PF pf, Usuario usuario);  // Criar PF e Usuario
        Task AtualizarPF(PF pf, Usuario usuario);  // Atualizar PF e Usuario
        Task ExcluirPF(int IdUsu);  // Excluir PF e Usuario
        Task<PF?> ObterPF(int IdUsu);  // Obter PF com base no Usuario 
        // o ? permitindo que o retorno seja null caso o PF não seja encontrado para aquele Usuario
    }
}
