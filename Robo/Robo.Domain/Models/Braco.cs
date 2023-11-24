using Robo.Domain.Exceptions;
using Robo.Domain.Utils;

namespace Robo.Domain.Models;

public class Braco
{
    public Cotovelo Cotovelo { get; set; }
    public Pulso Pulso { get; set; }

    public Braco()
    {
        Cotovelo = Cotovelo.EmRepouso;
        Pulso = Pulso.EmRepouso;
    }
    
    public void MovimentarCotovelo(Cotovelo cotovelo)
    {
        if (EnumUtils.DifferenceBetween(Cotovelo, cotovelo) > 1)
            throw new MovimentacaoException();
        
        Cotovelo = cotovelo;
        
        if (Cotovelo != Cotovelo.FortementeContraido)
            Pulso = Pulso.EmRepouso;
    }

    public void MovimentarPulso(Pulso pulso)
    {
        if (EnumUtils.DifferenceBetween(Pulso, pulso) > 1)
            throw new MovimentacaoException();
        
        if (Cotovelo != Cotovelo.FortementeContraido)
            throw new BusinessException("Pulso não pode ser modificada enquanto cotovelo não estiver fortemente contraído");

        Pulso = pulso;
    }
}