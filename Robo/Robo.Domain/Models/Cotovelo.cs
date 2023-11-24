using System.ComponentModel;

namespace Robo.Domain.Models;

public enum Cotovelo
{
    [Description("Em repouso")]
    EmRepouso = 1,
    [Description("Levemente contraído")]
    LevementeContraido = 2,
    [Description("Contraído")]
    Contraido = 3,
    [Description("Fortemente contraído")]
    FortementeContraido = 4
}