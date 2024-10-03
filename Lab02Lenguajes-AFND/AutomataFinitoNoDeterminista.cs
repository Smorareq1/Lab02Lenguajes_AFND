namespace Lab02Lenguajes_AFND;
using System.Text.RegularExpressions;

public class AutomataFinitoNoDeterminista
{
    // Definimos los estados finales
    private static readonly HashSet<int> EstadosFinales = new HashSet<int> { 4 };
    // Definimos las transiciones como un diccionario de listas
    private static readonly Dictionary<(int, char), List<int>> Transiciones = new Dictionary<(int, char), List<int>>
    {
        {(0, 'a'), new List<int> { 1 }},
        {(0, 'b'), new List<int> { 5 }},
        {(0, 'c'), new List<int> { 5 }},
        {(1, 'c'), new List<int> { 2 }},
        {(2, 'a'), new List<int> { 3 }},
        {(2, 'b'), new List<int> { 2 }},
        {(2, 'c'), new List<int> { 2 }},
        {(3, 'a'), new List<int> { 3 }},
        {(3, 'b'), new List<int> { 4 }},
        {(4, 'a'), new List<int> { 3 }},
        {(5, 'a'), new List<int> { 5 }},
        {(5, 'b'), new List<int> { 5 }},
        {(5, 'c'), new List<int> { 5 }},
    };

    public static bool AceptaCadena(string cadena)
    {
        var estadosActuales = new HashSet<int> { 0 };

        foreach (var simbolo in cadena)
        {
            var nuevosEstados = new HashSet<int>();
            foreach (var estado in estadosActuales)
            {
                if (Transiciones.TryGetValue((estado, simbolo), out var siguientesEstados))
                {
                    nuevosEstados.UnionWith(siguientesEstados);
                }
            }
            estadosActuales = nuevosEstados;
        }

        // Verificamos si al menos un estado actual es final
        foreach (var estado in estadosActuales)
        {
            if (EstadosFinales.Contains(estado))
            {
                return true;
            }
        }

        return false;
    }
    public bool Accepts(string input)
    {
        // Verifica si el input solo contiene 'a', 'b' o 'c'
        if (!Regex.IsMatch(input, "^[abc]*$"))
        {
            return false; // Si hay otros caracteres, no acepta la entrada
        }

        bool startsWithAC = input.StartsWith("ac");
        bool endsWithAB = input.EndsWith("ab");

        // Acepta si no empieza con "ac" o no termina con "ab"
        return !startsWithAC || !endsWithAB;
    }
}