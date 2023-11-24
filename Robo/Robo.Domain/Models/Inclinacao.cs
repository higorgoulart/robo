using System.ComponentModel;

namespace Robo.Domain.Models;

public enum Inclinacao
{
    [Description("Para cima")]
    ParaCima = 1,
    [Description("Em repouso")]
    EmRepouso = 2,
    [Description("Para baixo")]
    ParaBaixo = 3
}