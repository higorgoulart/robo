using Robo.Domain.Models;

namespace Robo.Tests;

public class RoboTest
{
    [Fact(DisplayName = "R.O.B.O. - Construtor")]
    public void Robo_DeveRetornarEmRepouso()
    {
        var robo = new Domain.Models.Robo();
        
        Assert.Equal(
            new List<Enum>
            {
                Rotacao.EmRepouso,
                Inclinacao.EmRepouso,
                Cotovelo.EmRepouso,
                Pulso.EmRepouso,
                Cotovelo.EmRepouso,
                Pulso.EmRepouso,
            }, 
            new List<Enum>
            {
                robo.Cabeca.Rotacao,
                robo.Cabeca.Inclinacao,
                robo.BracoEsquerdo.Cotovelo,
                robo.BracoEsquerdo.Pulso,
                robo.BracoDireito.Cotovelo,
                robo.BracoDireito.Pulso,
            });
    }
    
    [Theory(DisplayName = "R.O.B.O. - Movimentar")]
    [InlineData(Movimento.Rotacao, Rotacao.RotacaoMenos45, "Rotacao")]
    [InlineData(Movimento.Inclinacao, Inclinacao.ParaBaixo, "Inclinacao")]
    public void Movimentar_DeveMovimentarCabeca(Movimento movimento, Enum @enum, string field)
    {
        var robo = new Domain.Models.Robo();
        
        robo.Movimentar(movimento, @enum.ToString("G"));
        
        Assert.Equal(@enum, typeof(Cabeca).GetProperty(field)?.GetValue(robo.Cabeca));
    }
    
    [Theory(DisplayName = "R.O.B.O. - Movimentar")]
    [InlineData(Movimento.CotoveloEsquerdo, Cotovelo.LevementeContraido, "Cotovelo")]
    [InlineData(Movimento.PulsoEsquerdo, Pulso.EmRepouso, "Pulso")]
    public void Movimentar_DeveMovimentarBracoEsquerdo(Movimento movimento, Enum @enum, string field)
    {
        var robo = new Domain.Models.Robo();
        
        robo.Movimentar(movimento, @enum.ToString("G"));
        
        Assert.Equal(@enum, typeof(Braco).GetProperty(field)?.GetValue(robo.BracoEsquerdo));
    }
    
    [Theory(DisplayName = "R.O.B.O. - Movimentar")]
    [InlineData(Movimento.CotoveloDireito, Cotovelo.LevementeContraido, "Cotovelo")]
    [InlineData(Movimento.PulsoDireito, Pulso.EmRepouso, "Pulso")]
    public void Movimentar_DeveMovimentarBracoDireito(Movimento movimento, Enum @enum, string field)
    {
        var robo = new Domain.Models.Robo();
        
        robo.Movimentar(movimento, @enum.ToString("G"));
        
        Assert.Equal(@enum, typeof(Braco).GetProperty(field)?.GetValue(robo.BracoDireito));
    }
}