using Robo.Domain.Exceptions;
using Robo.Domain.Models;

namespace Robo.Tests;

public class CabecaTest
{
    [Fact(DisplayName = "Cabeça - Construtor")]
    public void Cabeca_DeveRetornarEmRepouso()
    {
        var cabeca = new Cabeca();
        
        Assert.Equal(Inclinacao.EmRepouso, cabeca.Inclinacao);
        Assert.Equal(Rotacao.EmRepouso, cabeca.Rotacao);
    }
    
    [Fact(DisplayName = "Cabeça - Movimentar Inclinação")]
    public void MovimentarInclinacao_DeveMovimentar()
    {
        var cabeca = new Cabeca();
        
        cabeca.MovimentarInclinacao(Inclinacao.ParaBaixo);
        
        Assert.Equal(Inclinacao.ParaBaixo, cabeca.Inclinacao);
    }
    
    [Fact(DisplayName = "Cabeça - Movimentar Inclinação")]
    public void MovimentarInclinacao_NaoDeveMovimentar()
    {
        var cabeca = new Cabeca();
        
        cabeca.MovimentarInclinacao(Inclinacao.EmRepouso);
        
        Assert.Equal(Inclinacao.EmRepouso, cabeca.Inclinacao);
    }
    
    [Fact(DisplayName = "Cabeça - Movimentar Inclinação")]
    public void MovimentarInclinacao_DeveLancarMovimentacaoException()
    {
        var cabeca = new Cabeca();
        
        cabeca.MovimentarInclinacao(Inclinacao.ParaBaixo);
        
        Assert.Throws<MovimentacaoException>(() => cabeca.MovimentarInclinacao(Inclinacao.ParaCima));
    }
    
    [Fact(DisplayName = "Cabeça - Movimentar Rotação")]
    public void MovimentarRotacao_DeveMovimentar()
    {
        var cabeca = new Cabeca();
        
        cabeca.MovimentarRotacao(Rotacao.Rotacao45);
        
        Assert.Equal(Rotacao.Rotacao45, cabeca.Rotacao);
    }
    
    [Fact(DisplayName = "Cabeça - Movimentar Rotação")]
    public void MovimentarRotacao_NaoDeveMovimentar()
    {
        var cabeca = new Cabeca();
        
        cabeca.MovimentarRotacao(Rotacao.EmRepouso);
        
        Assert.Equal(Rotacao.EmRepouso, cabeca.Rotacao);
    }
    
    [Fact(DisplayName = "Cabeça - Movimentar Rotação")]
    public void MovimentarRotacao_DeveLancarMovimentacaoException()
    {
        var cabeca = new Cabeca();
        
        Assert.Throws<MovimentacaoException>(() => cabeca.MovimentarRotacao(Rotacao.Rotacao90));
    }
    
    [Fact(DisplayName = "Cabeça - Movimentar Rotação")]
    public void MovimentarRotacao_DeveLancarBusinessException()
    {
        var cabeca = new Cabeca();
        
        cabeca.MovimentarInclinacao(Inclinacao.ParaBaixo);
        
        Assert.Throws<BusinessException>(() => cabeca.MovimentarRotacao(Rotacao.Rotacao45));
    }
}