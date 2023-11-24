namespace Robo.Context;

public interface IDbContext
{
    Domain.Models.Robo GetRobo();
    void SaveRobo(Domain.Models.Robo robo);
}