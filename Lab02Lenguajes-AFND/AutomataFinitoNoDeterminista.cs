namespace Lab02Lenguajes_AFND;

public class AutomataFinitoNoDeterminista
{
    public bool Accepts(string input)
    {
        bool startsWithAC = false;
        bool endsWithAB = false;
        
        if (input.StartsWith("ac"))
        {
            startsWithAC = true;
        }
        
        if (input.EndsWith("ab"))
        {
            endsWithAB = true;
        }
        
        return !startsWithAC || !endsWithAB;
    }
}