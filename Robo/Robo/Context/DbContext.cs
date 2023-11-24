namespace Robo.Context;

public class DbContext : IDbContext
{
    private Domain.Models.Robo _robo;

    public DbContext()
    {
        _robo ??= new Domain.Models.Robo();
    }

    public Domain.Models.Robo GetRobo()
    {
        return _robo;
    }

    public void SaveRobo(Domain.Models.Robo robo)
    {
        _robo = robo;
    }
}