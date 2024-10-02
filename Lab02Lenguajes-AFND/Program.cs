namespace Lab02Lenguajes_AFND;

class Program
{
    public static void Main(string[] args)
    {
        // Ejercicio 1, autómata finito no determinista
        Console.WriteLine("Ejercicio 1: Autómata Finito No Determinista");
        AutomataFinitoNoDeterminista afnd = new AutomataFinitoNoDeterminista();
        Console.WriteLine("Ingresa una cadena (formada por a, b y c):");
        string input = Console.ReadLine();

        if (afnd.Accepts(input))
        {
            Console.WriteLine("Cadena aceptada.");
        }
        else
        {
            Console.WriteLine("Cadena rechazada.");
        }
        
        // Ejercicio 2, máquina de Turing
        Console.WriteLine("Ejercicio 2: Máquina de Turing");
        TuringMachine machine = new TuringMachine();
        Console.WriteLine("Ingresa un número binario:");
        string cadenaEjercicio2 = Console.ReadLine();
        machine.ComputeComplement(cadenaEjercicio2);
        
        //Ejercicio 3, automata de pila
        Console.WriteLine("Ejercicio 3: Autómata de Pila");
        AutomataDePila pila = new AutomataDePila();
        Console.WriteLine("Ingresa una cadena (a^n b^n con 1 <= n < 10):");
        string cadenaEjercicio3 = Console.ReadLine();
        if (pila.ProcessInput(cadenaEjercicio3))
        {
            Console.WriteLine("Cadena aceptada.");
        }
        else
        {
            Console.WriteLine("Cadena rechazada.");
        }
    }
}