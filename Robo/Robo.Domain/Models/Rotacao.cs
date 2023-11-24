using System.ComponentModel;

namespace Robo.Domain.Models;

public enum Rotacao
{
    [Description("-90°")]
    RotacaoMenos90 = 1,
    [Description("-45°")]
    RotacaoMenos45 = 2,
    [Description("Em repouso")]
    EmRepouso = 3,
    [Description("45°")]
    Rotacao45 = 4,
    [Description("90°")]
    Rotacao90 = 5
}