namespace Lab02Lenguajes_AFND;

public class AutomataDePila
{
    private Stack<char> stack;
    private string currentState;
    
    private int contadorA = 0;
    private int contadorB = 0;

    public AutomataDePila()
    {
        stack = new Stack<char>();
        currentState = "q0";
        stack.Push('Z'); // Símbolo de fondo en la pila
    }

    public bool ProcessInput(string input)
    {
        
        // Verificar que la cadena sea de la forma a^n b^n
        foreach (char symbol in input)
        {
            if (symbol == 'a')
            {
                contadorA++;
            }
            else if (symbol == 'b')
            {
                contadorB++;
            }
        }

        if (contadorA != contadorB || contadorA == 0 || contadorA >= 10)
        {
            return false;
        }
        else
        {
            foreach (char symbol in input)
            {
                if (currentState == "q0" && symbol == 'a')
                {
                    stack.Push('X'); // Apilar 'X' por cada 'a'
                }
                else if (currentState == "q0" && symbol == 'b' && stack.Count > 0 && stack.Peek() == 'X')
                {
                    stack.Pop(); // Desapilar 'X' por cada 'b'
                    currentState = "q1"; // Cambiar a estado q1 cuando se empieza a leer 'b'
                }
                else if (currentState == "q1" && symbol == 'b' && stack.Count > 0 && stack.Peek() == 'X')
                {
                    stack.Pop(); // Continuar desapilando 'X' en estado q1
                }
                else
                {
                    return false; // Si algo no coincide, rechazar
                }
            }

            // Si la pila queda vacía excepto por el símbolo de fondo, aceptar
            if (currentState == "q1" && stack.Count == 1 && stack.Peek() == 'Z')
            {
                return true;
            }

            return false;
        }
    }
}