using Robo.Domain.Exceptions;
using Robo.Domain.Utils;

namespace Robo.Domain.Models;

public class Cabeca
{
    public Rotacao Rotacao { get; private set; }
    public Inclinacao Inclinacao { get; private set; }

    public Cabeca()
    {
        Rotacao = Rotacao.EmRepouso;
        Inclinacao = Inclinacao.EmRepouso;
    }
    
    public void MovimentarRotacao(Rotacao rotacao)
    {
        switch (EnumUtils.DifferenceBetween(Rotacao, rotacao))
        {
            case > 1:
                throw new MovimentacaoException();
            case 0:
                return;
        }
        
        if (Inclinacao == Inclinacao.ParaBaixo)
            throw new BusinessException("Rotação não pode ser modificada enquanto inclinação estiver para baixo");
        
        Rotacao = rotacao;
    }

    public void MovimentarInclinacao(Inclinacao inclinacao)
    {
        switch (EnumUtils.DifferenceBetween(Inclinacao, inclinacao))
        {
            case > 1:
                throw new MovimentacaoException();
            case 0:
                return;
        }

        Inclinacao = inclinacao;
        
        if (Inclinacao == Inclinacao.ParaBaixo)
            Rotacao = Rotacao.EmRepouso;
    }
}