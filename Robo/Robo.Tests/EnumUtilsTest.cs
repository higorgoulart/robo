using Robo.Domain.Models;
using Robo.Domain.Utils;

namespace Robo.Tests;

public class EnumUtilsTest
{
    [Fact(DisplayName = "Enum Utils - Para Dicionário")]
    public void ToDictionary_DeveRetornarDicionario()
    {
        var expected = new List<KeyValuePair<string, string>>
        {
            new("ParaCima", "Para cima"),
            new("EmRepouso", "Em repouso"),
            new("ParaBaixo", "Para baixo")
        };

        var result = EnumUtils.ToDictionary<Inclinacao>();
        
        Assert.Equal(expected, result);
    }
    
    [Fact(DisplayName = "Enum Utils - Obter descrição do enum")]
    public void GetEnumDescription_DeveRetornarDescricao()
    {
        var expected = Movimento.Inclinacao.ToString("G");

        var result = Movimento.Inclinacao.GetEnumDescription();
        
        Assert.Equal(expected, result);
    }
}