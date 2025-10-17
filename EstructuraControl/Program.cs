using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraControl
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // EJERCICIO 1

            //Console.Write("Ingrese el monto del préstamo: ");
            //float monto = float.Parse(Console.ReadLine());

            //float tasaAnual = 0.05f;
            //int plazoAnios = 5;

            //float interesAnual = monto * tasaAnual;
            //float interesTrimestre3 = interesAnual * (3f / 12f);
            //float interesPrimerMes = interesAnual / 12f;
            //float totalAPagar = monto + (interesAnual * plazoAnios);

            //// Resultados
            //Console.WriteLine("\n--- RESULTADOS ---");
            //Console.WriteLine($"Interés pagado en un año: ${interesAnual:F2}");
            //Console.WriteLine($"Interés pagado en el tercer trimestre: ${interesTrimestre3:F2}");
            //Console.WriteLine($"Interés pagado en el primer mes: ${interesPrimerMes:F2}");
            //Console.WriteLine($"Total a pagar incluyendo intereses: ${totalAPagar:F2}");

            //Console.WriteLine("\nPresione una tecla para salir...");
            //Console.ReadKey();



            //EJERCICIO 2

            //Console.Write("Ingrese el salario del empleado: ");
            //float salario = float.Parse(Console.ReadLine());

            //Console.WriteLine("Ingrese el valor de ahorro mensual programado: ");
            //float ahorroMensual = float.Parse(Console.ReadLine());

            //float deduccionSalud = salario * 12.5f / 100f;
            //float deduccionPension = salario * 16f / 100f;
            //float totalRecibir = salario - (deduccionPension + deduccionSalud);

            //Console.WriteLine("\n----- COLILLA DE PAGO -----");
            //Console.WriteLine("Salario del Empleado: " + salario);
            //Console.WriteLine("Ahorro Mensual Programado: " + ahorroMensual);
            //Console.WriteLine("Deducción por Salud (12.5%): " + deduccionSalud);
            //Console.WriteLine("Deducción por Pensión (16%): " + deduccionPension);
            //Console.WriteLine("Total a Recibir: " + totalRecibir);


            //EJERCICIO 3

            //Console.Write("Ingrese el valor total de la matrícula: ");
            //int matricula = int.Parse(Console.ReadLine());

            //int cuota1 = matricula * 40 / 100;
            //int cuota2 = matricula * 25 / 100;
            //int cuota3 = matricula * 20 / 100;
            //int cuota4 = matricula * 15 / 100;

            //Console.WriteLine("\n----- PLAN DE PAGOS -----");
            //Console.WriteLine("Primera cuota (40%): " + cuota1);
            //Console.WriteLine("Segunda cuota (25%): " + cuota2);
            //Console.WriteLine("Tercera cuota (20%): " + cuota3);
            //Console.WriteLine("Cuarta cuota (15%): " + cuota4);


            //EJERCICIO 4

            //Console.Write("Ingrese el nombre: ");
            //string nombre = Console.ReadLine();

            //Console.Write("Ingrese la dirección: ");
            //string direccion = Console.ReadLine();

            //Console.Write("Ingrese el año de nacimiento: ");
            //int anioNacimiento = int.Parse(Console.ReadLine());

            //int edad = DateTime.Now.Year - anioNacimiento;

            //Console.WriteLine($"\nNombre: {nombre}");
            //Console.WriteLine($"Dirección: {direccion}");
            //Console.WriteLine($"Edad: {edad} años");


            //EJERCICIO 5

            //Console.WriteLine("=== Cálculo de tiempo para llenar baldes ===");

            //float tiempo1Litro = 90f; 

            //float tiempo3Litros = tiempo1Litro * 3;
            //float tiempo5Litros = tiempo1Litro * 5;

            //Console.WriteLine("\n--- Baldes conocidos (1L, 3L, 5L) ---");
            //Console.WriteLine($"Tiempo para llenar 1 litro: {tiempo1Litro} minutos");
            //Console.WriteLine($"Tiempo para llenar 3 litros: {tiempo3Litros} minutos");
            //Console.WriteLine($"Tiempo para llenar 5 litros: {tiempo5Litros} minutos");

            //Console.WriteLine("\n--- Baldes de tamaño ingresado por el usuario ---");
            //Console.Write("Ingrese la cantidad de litros de un balde desconocido: ");
            //float litros = float.Parse(Console.ReadLine());

            //float tiempoDesconocido = tiempo1Litro * litros;

            //Console.WriteLine($"Tiempo estimado para llenar {litros} litros: {tiempoDesconocido} minutos");


            //EJERCICIO 6
            float tiempo7m = 5f; // horas

            Console.Write("Ingrese la altura que desea subir (en metros): ");
            float altura = float.Parse(Console.ReadLine());

            float tiempoEstimado = (tiempo7m / 7f) * altura;

            Console.WriteLine($"Tiempo estimado: {tiempoEstimado} horas");

        }
    }
}
