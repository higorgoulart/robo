using Robo.Domain.Utils;

namespace Robo.Domain.Models;

public class Robo
{
    public Cabeca Cabeca { get; }
    public Braco BracoEsquerdo { get; }
    public Braco BracoDireito { get; }

    public Robo()
    {
        Cabeca = new Cabeca();
        BracoEsquerdo = new Braco();
        BracoDireito = new Braco();
    }

    public void Movimentar(Movimento movimento, string valor)
    {
        switch (movimento)
        {
            case Movimento.Rotacao:
                Cabeca.MovimentarRotacao(valor.ToEnum<Rotacao>());
                break;
            case Movimento.Inclinacao:
                Cabeca.MovimentarInclinacao(valor.ToEnum<Inclinacao>());
                break;
            case Movimento.CotoveloEsquerdo:
                BracoEsquerdo.MovimentarCotovelo(valor.ToEnum<Cotovelo>());
                break;
            case Movimento.PulsoEsquerdo:
                BracoEsquerdo.MovimentarPulso(valor.ToEnum<Pulso>());
                break;
            case Movimento.CotoveloDireito:
                BracoDireito.MovimentarCotovelo(valor.ToEnum<Cotovelo>());
                break;
            case Movimento.PulsoDireito:
                BracoDireito.MovimentarPulso(valor.ToEnum<Pulso>());
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(movimento), movimento, null);
        }
    }
}