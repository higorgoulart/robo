using Robo.Domain.Exceptions;
using Robo.Domain.Models;

namespace Robo.Tests;

public class BracoTest
{
    [Fact(DisplayName = "Braço - Construtor")]
    public void Braco_DeveRetornarEmRepouso()
    {
        var braco = new Braco();
        
        Assert.Equal(Cotovelo.EmRepouso, braco.Cotovelo);
        Assert.Equal(Pulso.EmRepouso, braco.Pulso);
    }
    
    [Fact(DisplayName = "Braço - Movimentar Cotovelo")]
    public void MovimentarCotovelo_DeveMovimentar()
    {
        var braco = new Braco();
        
        braco.MovimentarCotovelo(Cotovelo.LevementeContraido);
        
        Assert.Equal(Cotovelo.LevementeContraido, braco.Cotovelo);
    }
    
    [Fact(DisplayName = "Braço - Movimentar Cotovelo")]
    public void MovimentarCotovelo_DeveLancarMovimentacaoException()
    {
        var braco = new Braco();

        Assert.Throws<MovimentacaoException>(() => braco.MovimentarCotovelo(Cotovelo.Contraido));
    }
    
    [Fact(DisplayName = "Braço - Movimentar Pulso")]
    public void MovimentarPulso_DeveMovimentar()
    {
        var braco = new Braco();
        
        braco.MovimentarCotovelo(Cotovelo.LevementeContraido);
        braco.MovimentarCotovelo(Cotovelo.Contraido);
        braco.MovimentarCotovelo(Cotovelo.FortementeContraido);
        
        braco.MovimentarPulso(Pulso.Rotacao45);
        
        Assert.Equal(Pulso.Rotacao45, braco.Pulso);
    }
    
    [Fact(DisplayName = "Braço - Movimentar Pulso")]
    public void MovimentarPulso_DeveLancarMovimentacaoException()
    {
        var braco = new Braco();
        
        Assert.Throws<MovimentacaoException>(() => braco.MovimentarPulso(Pulso.Rotacao90));
    }
    
    [Fact(DisplayName = "Braço - Movimentar Pulso")]
    public void MovimentarPulso_DeveLancarBusinessException()
    {
        var braco = new Braco();

        Assert.Throws<BusinessException>(() => braco.MovimentarPulso(Pulso.Rotacao45));
    }
}