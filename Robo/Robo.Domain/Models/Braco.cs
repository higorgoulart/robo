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
        switch (EnumUtils.DifferenceBetween(Cotovelo, cotovelo))
        {
            case > 1:
                throw new MovimentacaoException();
            case 0:
                return;
        }
        
        Cotovelo = cotovelo;
        
        if (Cotovelo != Cotovelo.FortementeContraido)
            Pulso = Pulso.EmRepouso;
    }

    public void MovimentarPulso(Pulso pulso)
    {
        switch (EnumUtils.DifferenceBetween(Pulso, pulso))
        {
            case > 1:
                throw new MovimentacaoException();
            case 0:
                return;
        }

        if (Cotovelo != Cotovelo.FortementeContraido)
            throw new BusinessException("Pulso não pode ser modificada enquanto cotovelo não estiver fortemente contraído");

        Pulso = pulso;
    }
}