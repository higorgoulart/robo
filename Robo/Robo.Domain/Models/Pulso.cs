using System.ComponentModel;

namespace Robo.Domain.Models;

public enum Pulso
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
    Rotacao90 = 5,
    [Description("135°")]
    Rotacao135 = 6,
    [Description("180°")]
    Rotacao180 = 7
}