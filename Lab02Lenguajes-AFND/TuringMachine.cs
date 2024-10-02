namespace Lab02Lenguajes_AFND;

public class TuringMachine
{
    public void ComputeComplement(string input)
    {
        
        char[] tape = input.ToCharArray();

        // Estado inicial
        int currentState = 0;
        int headPosition = 0;

        // Ejecutar la Máquina de Turing
        while (currentState != 1) // Estado 1 es el estado de aceptación
        {
            if (headPosition < tape.Length)
            {
                // Leer el símbolo en la cinta
                char currentSymbol = tape[headPosition];

                switch (currentState)
                {
                    case 0:
                        if (currentSymbol == '0')
                        {
                            tape[headPosition] = '1'; // Cambiar 0 por 1
                            headPosition++;           // Mover cabezal a la derecha
                        }
                        else if (currentSymbol == '1')
                        {
                            tape[headPosition] = '0'; // Cambiar 1 por 0
                            headPosition++;           // Mover cabezal a la derecha
                        }
                        else
                        {
                            currentState = 1; // Si encuentra un espacio en blanco, acepta
                        }
                        break;

                    default:
                        currentState = 1; // Estado de aceptación
                        break;
                }
            }
            else
            {
                currentState = 1; // Al llegar al final de la cinta, aceptar
            }
        }

        // Mostrar el resultado
        Console.WriteLine("Complemento a 1:");
        Console.WriteLine(new string(tape));
    }
}