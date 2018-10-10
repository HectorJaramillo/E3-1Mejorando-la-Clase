using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Sistema_de_Calificaciones_2._0
{
    public class Alumnos
    {
        public void Proceso(string Materia)
        {
            int Contador = 0;// variable tipo int
            string nombre;// variable tipo string
            int Materia1;// variable tipo int
            string[] GuardadoTemporal;//Arreglo unidimensional
            List<string[]> Alumno2 = new List<string[]>(); //Lista de arreglos que guarda 2 posiciones(Calificacion y nombre)
            int Opcion = 0;// variable tipo int
            while (Opcion != 3)//Ciclo while si la opcion es diferente de 3 se mantendra corriendo
            {
                Console.WriteLine("Bienvenido a la clase de "+Materia+" \nQue accion desea realizar"); //despliega un menu
                Console.WriteLine("1.-Agregar Alumno \n2.-Ver Alumnos  \n3.-Salir");
                string OpcionTemporal = Console.ReadLine();// variable tipo string
                if (int.TryParse(OpcionTemporal, out int x))//prueba si es posible el Parseo de opciontemporal saca el valor x
                {
                    GuardadoTemporal = new string[2];//Arreglo unidimensional que guarda temporalmente 2 campos antes de mandarlos a la lista
                    Opcion = int.Parse(OpcionTemporal);//Conversion de dato en variable Opcion
                    switch (Opcion)//Estructura selectiva switch
                    {
                        case 1:
                            Marca://Punto de referencia para usar la instruccion goto
                            try
                            {
                                MarcaDos://Punto de referencia para usar la instruccion goto
                                Console.Write("Ingrese el nombre del Alumno: ");
                                nombre = Console.ReadLine();//Lectura de variable nombre
                                GuardadoTemporal[0] = nombre;//Guardado de la variable nombre en la posicion 0 del arreglo
                                if (nombre == string.Empty)//Estructura if, si la variable nombre esta vacia pide volver a ingresarla
                                {
                                    Console.WriteLine("No ingrese espacios en blanco");
                                    goto MarcaDos;//instruccion que envia al usuario al punto de referencia MarcaDos
                                } 
                                Console.Write("Ingrese la calificacion del Alumno : ");
                                Materia1 = int.Parse(Console.ReadLine());//Lectura de variable Materia1
                                GuardadoTemporal[1] = Materia1.ToString(); //Guardado de la variable nombre en la posicion 1 del arreglo y conversion de dato con la extension ToString                
                                Alumno2.Add(GuardadoTemporal);//Guardado del arreglo temporal en la posicion x de la lista
                            }
                            catch (Exception Error) { Console.WriteLine("Ingrese solo numeros \nVuelva a Captura la informacion del Alumno de nuevo desde el nombre"); goto Marca; }//Excepcion  si ingresan un formato incorrecto
                            Console.WriteLine("Alumno Agregado al sistema \nPresione enter para continuar...");
                            break;
                        case 2:
                            Console.WriteLine("---------------------------Lista Calificaciones de Alumnos Registrados-----------------------------");
                            Console.WriteLine("Nombre                       Calificacion ");
                            foreach (string[] Ver in Alumno2)//Por cada Arreglo Ver en la Lista(Alumno2)
                            {
                                Console.Write(Ver[0]);//Impresion de la primera posicion del arreglo ver
                                Console.SetCursorPosition(29, 8 + Contador);//cambia las coordenadas de escritura en la pantalla
                                Console.WriteLine(Ver[1]);//Impresion de la primera posicion del arreglo ver                          
                                Contador++;//Variable contador +1
                            }
                            Contador = 0;//igualacion de contador a 0
                            break;//termina proceso
                        case 3://Caso vacio para terminar con el proceso
                            break;//termina proceso
                        default://Si la opcion es distinta de las anteriores envia mensaje de error
                            Console.WriteLine("La opcion seleccionada no existe favor de volver a ingresar la opcion");
                            break;//termina proceso
                    }
                }
                else// de otra forma
                {
                    Opcion = 0;//igualacion de opcion a 0
                    Console.WriteLine("El valor ingresado no es correcto");
                }
                if (Opcion != 3)//Si opcion es diferente de 3
                {
                    Console.ReadLine();//Lectura de consola
                }
                Console.Clear();//Limpieza de consola
            }           
        }
        public void Inicio()
        {
            Alumnos Alumno = new Alumnos();//Instancia de objeto Alumnos
            int CantidadDeClases, OpcionMenu;//Declaracion de variables de tipo int
            string Clase;//Declaracion de variable de tipo string
            Console.WriteLine("Cuantas clases desea agregar");
            CantidadDeClases = int.Parse(Console.ReadLine());//Inicializacion por el usuario
            string[] Clases = new string[CantidadDeClases];//Arreglo de tamaño definido por el usuario
            for (int Indice = 0; Indice < Clases.Length; Indice++)//ciclo for, desde 0 hasta tamaño del arreglo con paso +1
            {
                Console.WriteLine("Ingrese el nombre de la materia");
                Clase = Console.ReadLine();//Asignacion valor/cadena a variable clase
                Clases[Indice] = Clase;//Asignacion de variable clase a la posicion x del arreglo
            }
            Marca2://Punto de referencia para usar la instruccion goto
            Console.WriteLine("Que clase desea alterar");
            for (int Indice = 0; Indice < Clases.Length; Indice++)//ciclo for, desde 0 hasta tamaño del arreglo con paso +1
            {
                Console.WriteLine(Indice + 1 + ".-" + Clases[Indice]);//Escribe en pantalla numero x.- Clase segun la posicion del arreglo
            }
            OpcionMenu = int.Parse(Console.ReadLine());//Conversion de opcionmenu de int a string
            if (OpcionMenu > CantidadDeClases)//si opcionmenu en mayor a la cantidad de clases
            {
                Console.WriteLine("Ingrese una clase existente");
                goto Marca2;//instruccion que envia al usuario al punto de referencia Marca2
            }
            switch (OpcionMenu)//Estructura selectiva switch
            {
                default:
                    Alumno.Proceso(Clases[OpcionMenu - 1]);//Llamando el metodo Proceso con el objeto Alumno y enviando un valor de la posicion del arreglo
                    break;
            }
            Console.WriteLine("1.-Modificar otras clases \n2.-Salir");
            int OpcionFinal = int.Parse(Console.ReadLine());//Lectura y conversion de string a int de la variable OpcionFinal
            switch (OpcionFinal)//Estructura selectiva switch
            {
                case 1:
                    goto Marca2;//instruccion que envia al usuario al punto de referencia Marca2
                case 2://Caso vacio para poder terminar el proceso
                    break;
                default:
                    Console.WriteLine("La opcion selesccionada no se encuentra en el menu");
                    Console.ReadKey(true);//Para la pantalla en tiempo de ejecucion
                    Console.Clear();//Limpia la ventana de la consola
                    goto Marca2;//instruccion que envia al usuario al punto de referencia Marca2
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Alumnos Alumno = new Alumnos();//Instancia de objeto Alumnos
            Alumno.Inicio();//Llamado de la puncion Inicio de la Clase Alumnos(a la vez este proceso manda a llamar al proceso Proceso)
            Console.ReadKey(true);//Para la pantalla en tiempo de ejecucion
        }
    }
}
