namespace Test2.Exceptions;

public class MatchNotExists : Exception
{
    public MatchNotExists() : base("Match not exists") { }
}