namespace Robo.Domain.Exceptions;

public class MovimentacaoException : BusinessException
{
    public MovimentacaoException() : base("Movimentação muito longa!")
    {
        
    }
}