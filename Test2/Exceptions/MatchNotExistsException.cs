namespace Test2.Exceptions;

public class MatchNotExistsException : Exception
{
    public MatchNotExistsException() : base("Match not exists") { }
}