using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        bool status = true;       
        while (status)
        {
            Funciones func = new Funciones();

            string ninicial = Console.ReadLine().ToUpper();
            if (ninicial == "0")
            {
                return;
            }
            string Base = ninicial.Substring(ninicial.Length - 1);
            //convertir al tipo de variable adecuada dependiendo de lo necesario
            string numero = ninicial.Substring(0, ninicial.Length - 1);
            
            if (Base == "H")
            {
                System.Console.WriteLine("Hexadecimal");
            }
            else if (Base == "D")
            {
                System.Console.WriteLine("Decimal" +
                    "");
            }
            else if (Base == "O")
            {
                Console.WriteLine("Octal");
            }
            else if (Base == "B")
            {
                Console.WriteLine("Binario");
            }

            string nconversor = Console.ReadLine().ToUpper();
            if (nconversor == "H")
            {
                Console.WriteLine("Hexadecimal");
            }
            else if (nconversor == "D")
            {
                System.Console.WriteLine("Decimal");
            }
            else if (nconversor == "O")
            {
                Console.WriteLine("Octal");
            }
            else if (nconversor == "B")
            {
                Console.WriteLine("Binario");
            }

            if (Base == "D" && nconversor == "B")
            {
                func.DecBin(ninicial, Base, numero, nconversor);
            }
            if (Base == "H" && nconversor == "B")
            {
                func.HexaBin(ninicial, Base, numero, nconversor);
            }
            if (Base == "H" && nconversor == "O")
            {
                func.HexaOct(ninicial, Base, numero, nconversor);
            }
            if (Base == "B" && nconversor == "D")
            {

                func.BinDec(ninicial, Base, numero, nconversor);

            }
            if (Base == "H" && nconversor == "D")
            {
                func.HexaDec(ninicial, Base, numero, nconversor);
            }
            if (Base == "B" && nconversor == "O")
            {
                func.BinOct(ninicial, Base, numero, nconversor);
            }
            if (Base == "B" && nconversor == "H")
            {
                func.BinHexa(ninicial, Base, numero, nconversor);
            }
            if (Base == "D" && nconversor == "H")
            {
                func.DecHexa(ninicial, Base, numero, nconversor);
            }
            if (Base == "D" && nconversor == "O")
            {
                func.DecOct(ninicial, Base, numero, nconversor);
            }
            if (Base == "O" && nconversor == "B")
            {
                func.OctBin(ninicial, Base, numero, nconversor);
            }
            if (Base == "O" && nconversor == "D")
            {
                func.OctDec(ninicial, Base, numero, nconversor);
            }
            if (Base == "O" && nconversor == "H")
            {
                func.OctHexa(ninicial, Base, numero, nconversor);
            }
        }
    }
}


public class Funciones
{
    public void HexaBin(string ninicial, string Base, string numero, string nconversor)
    {

        string[,] tabla = new string[16, 2];
        tabla[0, 0] = "0"; tabla[1, 0] = "1"; tabla[2, 0] = "2"; tabla[3, 0] = "3";
        tabla[4, 0] = "4"; tabla[5, 0] = "5"; tabla[6, 0] = "6"; tabla[7, 0] = "7";
        tabla[8, 0] = "8"; tabla[9, 0] = "9"; tabla[10, 0] = "A"; tabla[11, 0] = "B";
        tabla[12, 0] = "C"; tabla[13, 0] = "D"; tabla[14, 0] = "E"; tabla[15, 0] = "F";

        tabla[0, 1] = "0000"; tabla[1, 1] = "0001"; tabla[2, 1] = "0010"; tabla[3, 1] = "0011";
        tabla[4, 1] = "0100"; tabla[5, 1] = "0101"; tabla[6, 1] = "0110"; tabla[7, 1] = "0111";
        tabla[8, 1] = "1000"; tabla[9, 1] = "1001"; tabla[10, 1] = "1010"; tabla[11, 1] = "1011";
        tabla[12, 1] = "1100"; tabla[13, 1] = "1101"; tabla[14, 1] = "1110"; tabla[15, 1] = "1111";


       
        
            string binario = "";
            for (int i = 0; i < ninicial.Length - 1; i++)
            {
                char hexChar = ninicial[i];
                int index = -1;

                // Buscando el índice del dígito hexadecimal en la matriz
                for (int j = 0; j < 16; j++)
                {
                    if (tabla[j, 0] == hexChar.ToString())
                    {
                        index = j;
                        break;
                    }
                }
                // Siempre va a ser diferente de -1
                if (index != -1)
                {
                    // Concatenar el equivalente binario a la cadena binaria
                    binario += tabla[index, 1];
                }
                else
                {
                    Console.WriteLine("Dígito hexadecimal no válido.");
                    return;
                }
            }
            Console.WriteLine(binario);
    }
    public void DecBin(string ninicial, string Base, string numero, string nconversor)
    {
        int numeroINT = Convert.ToInt32(numero);
        string binario = "";
        string modulo = "";
        for (; numeroINT >= 1;)
        {
            modulo = Convert.ToString(numeroINT % 2);

            numeroINT = numeroINT / 2;
            binario = modulo + binario;

        }
        Console.WriteLine(binario);
    }
    public void BinDec(string ninicial, string Base, string numero, string nconversor)
    {
        //estoy utilizando double porque int no soporta numeros tan grandes
        double decnum = 0;
        int n = Convert.ToInt32(numero);

        // Variable para llevar el peso del bit actual
        long bitWeight = 1;

        while (n > 0)
        {
            // Obtener el último dígito del número binario
            double d = n % 10;

            // Sumar el producto del dígito binario y el peso del bit actual al resultado
            decnum += d * bitWeight;

            // Dividir el número binario por 10 para pasar al siguiente dígito
            n /= 10;

            // Incrementar el peso del bit multiplicándolo por 2
            bitWeight *= 2;
        }

        Console.WriteLine(decnum);
    }
    public void HexaOct(string ninicial, string Base, string numero, string nconversor)
    {

        string[,] tabla = new string[16, 2];
        tabla[0, 0] = "0"; tabla[1, 0] = "1"; tabla[2, 0] = "2"; tabla[3, 0] = "3";
        tabla[4, 0] = "4"; tabla[5, 0] = "5"; tabla[6, 0] = "6"; tabla[7, 0] = "7";
        tabla[8, 0] = "8"; tabla[9, 0] = "9"; tabla[10, 0] = "A"; tabla[11, 0] = "B";
        tabla[12, 0] = "C"; tabla[13, 0] = "D"; tabla[14, 0] = "E"; tabla[15, 0] = "F";

        tabla[0, 1] = "0000"; tabla[1, 1] = "0001"; tabla[2, 1] = "0010"; tabla[3, 1] = "0011";
        tabla[4, 1] = "0100"; tabla[5, 1] = "0101"; tabla[6, 1] = "0110"; tabla[7, 1] = "0111";
        tabla[8, 1] = "1000"; tabla[9, 1] = "1001"; tabla[10, 1] = "1010"; tabla[11, 1] = "1011";
        tabla[12, 1] = "1100"; tabla[13, 1] = "1101"; tabla[14, 1] = "1110"; tabla[15, 1] = "1111";

        string binario = "";
        for (int i = 0; i < ninicial.Length - 1; i++)
        {
            char hexChar = ninicial[i];
            int index = -1;

            // Buscando el índice del dígito hexadecimal en la matriz
            for (int j = 0; j < 16; j++)
            {
                if (tabla[j, 0] == hexChar.ToString())
                {
                    index = j;
                    break;
                }
            }
            // Siempre va a ser diferente de -1
            if (index != -1)
            {
                // Concatenar el equivalente binario a la cadena binaria
                binario += tabla[index, 1];
            }
            else
            {
                Console.WriteLine("Dígito hexadecimal no válido.");
                return;
            }
        }
        //Console.WriteLine(binario);

        // Asegurarse de que la longitud del binario es un múltiplo de 3
        int length = binario.Length;
        // El '?' es lo equivalente a un if else, funciona:
        // condicion ? Si es cierto: si no es cierto
        int padding = length % 3 == 0 ? 0 : 3 - (length % 3);
        binario = new string('0', padding) + binario;

        // Crear un diccionario para mapear secuencias de 3 bits a su equivalente octal
        Dictionary<string, char> binToOctMap = new Dictionary<string, char>
    {
        {"000", '0'},
        {"001", '1'},
        {"010", '2'},
        {"011", '3'},
        {"100", '4'},
        {"101", '5'},
        {"110", '6'},
        {"111", '7'}
    };

        string octal = "";

        
        for (int i = 0; i < binario.Length; i += 3)
        {
            string tripleBit = binario.Substring(i, 3);
            // Obtener el equivalente octal y concatenarlo a la cadena resultante
            // Se concatena tripleBit a binToOctMap para buscar que cadena de bits es equivalente al diccionario
            octal += binToOctMap[tripleBit];
        }

        Console.WriteLine(octal);

    }
    public void HexaDec(string ninicial, string Base, string numero, string nconversor)
    {

        string[,] tabla = new string[16, 2];
        tabla[0, 0] = "0"; tabla[1, 0] = "1"; tabla[2, 0] = "2"; tabla[3, 0] = "3";
        tabla[4, 0] = "4"; tabla[5, 0] = "5"; tabla[6, 0] = "6"; tabla[7, 0] = "7";
        tabla[8, 0] = "8"; tabla[9, 0] = "9"; tabla[10, 0] = "A"; tabla[11, 0] = "B";
        tabla[12, 0] = "C"; tabla[13, 0] = "D"; tabla[14, 0] = "E"; tabla[15, 0] = "F";

        tabla[0, 1] = "0000"; tabla[1, 1] = "0001"; tabla[2, 1] = "0010"; tabla[3, 1] = "0011";
        tabla[4, 1] = "0100"; tabla[5, 1] = "0101"; tabla[6, 1] = "0110"; tabla[7, 1] = "0111";
        tabla[8, 1] = "1000"; tabla[9, 1] = "1001"; tabla[10, 1] = "1010"; tabla[11, 1] = "1011";
        tabla[12, 1] = "1100"; tabla[13, 1] = "1101"; tabla[14, 1] = "1110"; tabla[15, 1] = "1111";

      
        string binario = "";
        for (int i = 0; i < ninicial.Length - 1; i++)
        {
            char hexChar = ninicial[i];
            int index = -1;

            // Buscando el índice del dígito hexadecimal en la matriz
            for (int j = 0; j < 16; j++)
            {
                if (tabla[j, 0] == hexChar.ToString())
                {
                    index = j;
                    break;
                }
            }
            // Siempre va a ser diferente de -1
            if (index != -1)
            {
                // Concatenar el equivalente binario a la cadena binaria
                binario += tabla[index, 1];
            }
            else
            {
                Console.WriteLine("Dígito hexadecimal no válido.");
                return;
            }
        }
        //Console.WriteLine(binario);
        //estoy utilizando double porque int no soporta numeros tan grandes
        //regresé a usar int porque el double lo toma de manera diferente
        double decnum = 0;
        int n = Convert.ToInt32(binario);

        // Variable para llevar el peso del bit actual
        long bitWeight = 1;

        while (n > 0)
        {
            // Obtener el último dígito del número binario
            double d = n % 10;

            // Sumar el producto del dígito binario y el peso del bit actual al resultado
            decnum += d * bitWeight;

            // Dividir el número binario por 10 para pasar al siguiente dígito
            n /= 10;

            // Incrementar el peso del bit multiplicándolo por 2
            bitWeight *= 2;
        }

        Console.WriteLine(decnum);
    }
    public void BinOct(string ninicial, string Base, string numero, string nconversor)
    {
        string binario = numero;
        // Asegurarse de que la longitud del binario es un múltiplo de 3
        int length = binario.Length;
        // El '?' es lo equivalente a un if else, funciona:
        // condicion ? Si es cierto: si no es cierto
        int padding = length % 3 == 0 ? 0 : 3 - (length % 3);
        binario = new string('0', padding) + binario;

        // Crear un diccionario para mapear secuencias de 3 bits a su equivalente octal
        Dictionary<string, char> binToOctMap = new Dictionary<string, char>
    {
        {"000", '0'},
        {"001", '1'},
        {"010", '2'},
        {"011", '3'},
        {"100", '4'},
        {"101", '5'},
        {"110", '6'},
        {"111", '7'}
    };

        string octal = "";


        for (int i = 0; i < binario.Length; i += 3)
        {
            string tripleBit = binario.Substring(i, 3);
            // Obtener el equivalente octal y concatenarlo a la cadena resultante
            // Se concatena tripleBit a binToOctMap para buscar que cadena de bits es equivalente al diccionario
            octal += binToOctMap[tripleBit];
        }

        Console.WriteLine(octal);
    }
    public void BinHexa(string ninicial, string Base, string numero, string nconversor)
    {
        string binario = numero;
        // Asegurarse de que la longitud del binario es un múltiplo de 4
        int length = binario.Length;
        // El '?' es lo equivalente a un if else, funciona:
        // condicion ? Si es cierto: si no es cierto
        int padding = length % 4 == 0 ? 0 : 4 - (length % 4);
        binario = new string('0', padding) + binario;

        // Crear un diccionario para mapear secuencias de 4 bits a su equivalente octal
        Dictionary<string, char> binToHexaMap = new Dictionary<string, char>
    {
        {"0000", '0'},
        {"0001", '1'},
        {"0010", '2'},
        {"0011", '3'},
        {"0100", '4'},
        {"0101", '5'},
        {"0110", '6'},
        {"0111", '7'},
        {"1000", '8' },
        {"1001", '9' },
        {"1010", 'A' },
        {"1011", 'B' },
        {"1100", 'C' },
        {"1101", 'D' },
        {"1110", 'E' },
        {"1111", 'F' }

    };

        string hexadecimal = "";


        for (int i = 0; i < binario.Length; i += 4)
        {
            string quadBit = binario.Substring(i, 4);
            // Obtener el equivalente octal y concatenarlo a la cadena resultante
            // Se concatena tripleBit a binToOctMap para buscar que cadena de bits es equivalente al diccionario
            hexadecimal += binToHexaMap[quadBit];
        }

        Console.WriteLine(hexadecimal);
    }
    public void DecHexa(string ninicial, string Base, string numero, string nconversor)
    {
        int numeroINT = Convert.ToInt32(numero);
        string binario = "";
        string modulo = "";
        for (; numeroINT >= 1;)
        {
            modulo = Convert.ToString(numeroINT % 2);

            numeroINT = numeroINT / 2;
            binario = modulo + binario;

        }
       // Console.WriteLine(binario);

        //SEPARACION
        
        // Asegurarse de que la longitud del binario es un múltiplo de 4
        int length = binario.Length;
        // El '?' es lo equivalente a un if else, funciona:
        // condicion ? Si es cierto: si no es cierto
        int padding = length % 4 == 0 ? 0 : 4 - (length % 4);
        binario = new string('0', padding) + binario;

        // Crear un diccionario para mapear secuencias de 4 bits a su equivalente octal
        Dictionary<string, char> binToHexaMap = new Dictionary<string, char>
    {
        {"000", '0'},
        {"001", '1'},
        {"010", '2'},
        {"011", '3'},
        {"100", '4'},
        {"101", '5'},
        {"110", '6'},
        {"111", '7'},
        {"1000", '8' },
        {"1001", '9' },
        {"1010", 'A' },
        {"1011", 'B' },
        {"1100", 'C' },
        {"1101", 'D' },
        {"1110", 'E' },
        {"1111", 'F' }

    };

        string hexadecimal = "";


        for (int i = 0; i < binario.Length; i += 4)
        {
            string quadBit = binario.Substring(i, 4);
            // Obtener el equivalente octal y concatenarlo a la cadena resultante
            // Se concatena tripleBit a binToOctMap para buscar que cadena de bits es equivalente al diccionario
            hexadecimal += binToHexaMap[quadBit];
        }

        Console.WriteLine(hexadecimal);
    }
    public void DecOct(string ninicial, string Base, string numero, string nconversor)
    {
        int numeroINT = Convert.ToInt32(numero);
        string binario = "";
        string modulo = "";
        for (; numeroINT >= 1;)
        {
            modulo = Convert.ToString(numeroINT % 2);

            numeroINT = numeroINT / 2;
            binario = modulo + binario;

        }
        //Console.WriteLine(binario);

        //SEPARACION

        // Asegurarse de que la longitud del binario es un múltiplo de 3
        int length = binario.Length;
        // El '?' es lo equivalente a un if else, funciona:
        // condicion ? Si es cierto: si no es cierto
        int padding = length % 3 == 0 ? 0 : 3 - (length % 3);
        binario = new string('0', padding) + binario;

        // Crear un diccionario para mapear secuencias de 3 bits a su equivalente octal
        Dictionary<string, char> binToOctMap = new Dictionary<string, char>
    {
        {"000", '0'},
        {"001", '1'},
        {"010", '2'},
        {"011", '3'},
        {"100", '4'},
        {"101", '5'},
        {"110", '6'},
        {"111", '7'}
    };

        string octal = "";


        for (int i = 0; i < binario.Length; i += 3)
        {
            string tripleBit = binario.Substring(i, 3);
            // Obtener el equivalente octal y concatenarlo a la cadena resultante
            // Se concatena tripleBit a binToOctMap para buscar que cadena de bits es equivalente al diccionario
            octal += binToOctMap[tripleBit];
        }

        Console.WriteLine(octal);
    }
    public void OctBin(string ninicial, string Base, string numero, string nconversor)
    {
        string octal = numero;
      

        // Crear un diccionario para mapear secuencias de 3 bits a su equivalente octal
        Dictionary<string, string> OctToBinMap = new Dictionary<string, string>
    {
        {"0", "000"},
        {"1", "001"},
        {"2", "010"},
        {"3", "011"},
        {"4", "100"},
        {"5", "101"},
        {"6", "110"},
        {"7", "111"}
    };

        string binario = "";


        for(int i = 0; i < octal.Length; i++)
    {
            string sumatoria = octal.Substring(i, 1);
            // Obtener el equivalente octal y concatenarlo a la cadena resultante
            // Se concatena tripleBit a binToOctMap para buscar que cadena de bits es equivalente al diccionario
            binario += OctToBinMap[sumatoria];
        }

        Console.WriteLine(binario);
    }
    public void OctDec(string ninicial, string Base, string numero, string nconversor)
    {
        string octal = numero;


        // Crear un diccionario para mapear secuencias de 3 bits a su equivalente octal
        Dictionary<string, string> OctToBinMap = new Dictionary<string, string>
    {
        {"0", "000"},
        {"1", "001"},
        {"2", "010"},
        {"3", "011"},
        {"4", "100"},
        {"5", "101"},
        {"6", "110"},
        {"7", "111"}
    };

        string binario = "";


        for (int i = 0; i < octal.Length; i++)
        {
            string sumatoria = octal.Substring(i, 1);
            // Obtener el equivalente octal y concatenarlo a la cadena resultante
            // Se concatena tripleBit a binToOctMap para buscar que cadena de bits es equivalente al diccionario
            binario += OctToBinMap[sumatoria];
        }

       // Console.WriteLine(binario);

        //SEPARACION

        //estoy utilizando double porque int no soporta numeros tan grandes
        double decnum = 0;
        int n = Convert.ToInt32(binario);

        // Variable para llevar el peso del bit actual
        long bitWeight = 1;

        while (n > 0)
        {
            // Obtener el último dígito del número binario
            double d = n % 10;

            // Sumar el producto del dígito binario y el peso del bit actual al resultado
            decnum += d * bitWeight;

            // Dividir el número binario por 10 para pasar al siguiente dígito
            n /= 10;

            // Incrementar el peso del bit multiplicándolo por 2
            bitWeight *= 2;
        }

        Console.WriteLine(decnum);

    }
    public void OctHexa(string ninicial, string Base, string numero, string nconversor)
{
    string octal = numero;

    // Crear un diccionario para mapear secuencias de 3 bits a su equivalente octal
    Dictionary<string, string> OctToBinMap = new Dictionary<string, string>
    {
        {"0", "000"},
        {"1", "001"},
        {"2", "010"},
        {"3", "011"},
        {"4", "100"},
        {"5", "101"},
        {"6", "110"},
        {"7", "111"}
    };

    string binario = "";

    for (int i = 0; i < octal.Length; i++)
    {
        string sumatoria = octal.Substring(i, 1);
        // Obtener el equivalente binario y concatenarlo a la cadena resultante
        binario += OctToBinMap[sumatoria];
    }

   // Console.WriteLine(binario);

    // Asegurarse de que la longitud del binario es un múltiplo de 4
    int length = binario.Length;
    int padding = length % 4 == 0 ? 0 : 4 - (length % 4);
    binario = new string('0', padding) + binario;

    // Crear un diccionario para mapear secuencias de 4 bits a su equivalente hexadecimal
    Dictionary<string, char> binToHexaMap = new Dictionary<string, char>
    {
        {"0000", '0'},
        {"0001", '1'},
        {"0010", '2'},
        {"0011", '3'},
        {"0100", '4'},
        {"0101", '5'},
        {"0110", '6'},
        {"0111", '7'},
        {"1000", '8' },
        {"1001", '9' },
        {"1010", 'A' },
        {"1011", 'B' },
        {"1100", 'C' },
        {"1101", 'D' },
        {"1110", 'E' },
        {"1111", 'F' }
    };

    string hexadecimal = "";

    for (int i = 0; i < binario.Length; i += 4)
    {
        string quadBit = binario.Substring(i, 4);
        // Obtener el equivalente hexadecimal y concatenarlo a la cadena resultante
        hexadecimal += binToHexaMap[quadBit];
    }

    Console.WriteLine(hexadecimal);
}

 
}


