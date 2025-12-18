using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIOS

    /*EJERCICIO #1*/

{
    //class Ejercicio1
    //{
    //    class Prestamo
    //    {
    //        double Monto { get; set; }
    //        double TasaInteresAnual { get; set; }
    //        int PlazoAnios { get; set; }

    //        public Prestamo(double monto, double tasa, int plazo)
    //        {
    //            Monto = monto;
    //            TasaInteresAnual = tasa;
    //            PlazoAnios = plazo;
    //        }

    //        double InteresAnual() => Monto * (TasaInteresAnual / 100);
    //        double InteresTrimestre() => InteresAnual() / 4;
    //        double InteresMensual() => InteresAnual() / 12;
    //        double TotalAPagar() => Monto + (InteresAnual() * PlazoAnios);

    //        public void MostrarResultados()
    //        {
    //            Console.WriteLine($"\nInterés anual: ${InteresAnual():N2}");
    //            Console.WriteLine($"Interés tercer trimestre: ${InteresTrimestre():N2}");
    //            Console.WriteLine($"Interés primer mes: ${InteresMensual():N2}");
    //            Console.WriteLine($"Total a pagar: ${TotalAPagar():N2}");
    //        }
    //    }


    //    static void Main()
    //    {
    //        Console.Write("Ingrese el monto del préstamo: ");
    //        double monto = Convert.ToDouble(Console.ReadLine());
    //        Prestamo p = new Prestamo(monto, 5, 5);
    //        p.MostrarResultados();
    //    }

    //}

    /* EJERCICIO 2: Colilla de pago */

    //class Ejercicio2
    //{
    //    class Empleado
    //    {
    //        double Salario { get; set; }
    //        double AhorroMensual { get; set; }

    //        public Empleado(double salario, double ahorro)
    //        {
    //            Salario = salario;
    //            AhorroMensual = ahorro;
    //        }

    //        double DescuentoSalud() => Salario * 0.125;
    //        double DescuentoPension() => Salario * 0.16;
    //        double TotalRecibir() => Salario - (DescuentoSalud() + DescuentoPension() + AhorroMensual);

    //        public void MostrarColilla()
    //        {
    //            Console.WriteLine($"\nSalario: ${Salario:N2}");
    //            Console.WriteLine($"Ahorro: ${AhorroMensual:N2}");
    //            Console.WriteLine($"Descuento salud: ${DescuentoSalud():N2}");
    //            Console.WriteLine($"Descuento pensión: ${DescuentoPension():N2}");
    //            Console.WriteLine($"Total a recibir: ${TotalRecibir():N2}");
    //        }
    //    }


    //    static void Main()
    //    {
    //        Console.Write("Salario del empleado: ");
    //        double s = double.Parse(Console.ReadLine());
    //        Console.Write("Ahorro mensual: ");
    //        double a = double.Parse(Console.ReadLine());
    //        Empleado e = new Empleado(s, a);
    //        e.MostrarColilla();
    //    }

    //}

    /*EJERCICIO #3*/

    //class Ejercicio3
    //{
    //    class Persona
    //    {
    //        string Nombre { get; set; }
    //        int Edad { get; set; }
    //        string Genero { get; set; }
    //        string Telefono { get; set; }

    //        public Persona(string n, int e, string g, string t)
    //        {
    //            Nombre = n;
    //            Edad = e;
    //            Genero = g;
    //            Telefono = t;
    //        }

    //        void ImprimirDetalles()
    //        {
    //            Console.WriteLine($"\nNombre: {Nombre}\nEdad: {Edad}\nGénero: {Genero}\nTeléfono: {Telefono}");
    //        }

    //        void CalcularEdadEnDias()
    //        {
    //            Console.WriteLine($"Edad en días: {Edad * 365} días");
    //        }

    //        public void Menu()
    //        {
    //            Console.WriteLine("\n1. Imprimir detalles\n2. Calcular edad en días");
    //            int op = int.Parse(Console.ReadLine());
    //            if (op == 1) ImprimirDetalles();
    //            else if (op == 2) CalcularEdadEnDias();
    //        }
    //    }


    //    static void Main()
    //    {
    //        Console.Write("Nombre: ");
    //        string n = Console.ReadLine();
    //        Console.Write("Edad: ");
    //        int e = int.Parse(Console.ReadLine());
    //        Console.Write("Género (M/F): ");
    //        string g = Console.ReadLine();
    //        Console.Write("Teléfono: ");
    //        string t = Console.ReadLine();

    //        Persona p = new Persona(n, e, g, t);
    //        p.Menu();
    //    }

    //}

    /*EJERCICIO #4*/

    //class Ejercicio4
    //{
    //    class Libro
    //    {
    //        string Titulo { get; set; }
    //        string Autor { get; set; }
    //        string Editorial { get; set; }
    //        int Anio { get; set; }

    //        public Libro(string t, string a, string e, int an)
    //        {
    //            Titulo = t; Autor = a; Editorial = e; Anio = an;
    //        }

    //        public string Info() => $"{Titulo} - {Autor} ({Anio})";
    //    }

    //    class Biblioteca
    //    {
    //        List<Libro> Libros = new List<Libro>();

    //        public void Agregar(Libro l) => Libros.Add(l);

    //        public void Listar()
    //        {
    //            Console.WriteLine("\nLibros en biblioteca:");
    //            foreach (var l in Libros) Console.WriteLine(l.Info());
    //        }

    //        public void Buscar(string titulo)
    //        {
    //            var libro = Libros.Find(x => x.Info().ToLower().Contains(titulo.ToLower()));
    //            Console.WriteLine(libro != null ? "Encontrado: " + libro.Info() : "No encontrado");
    //        }
    //    }


    //    static void Main()
    //    {
    //        Biblioteca b = new Biblioteca();
    //        b.Agregar(new Libro("Cien Años de Soledad", "García Márquez", "Sudamericana", 1967));
    //        b.Agregar(new Libro("El Quijote", "Cervantes", "Espasa", 1605));

    //        b.Listar();
    //        Console.Write("\nBuscar libro: ");
    //        string t = Console.ReadLine();
    //        b.Buscar(t);
    //    }

    //}

    /*EJERCICIO #5*/

    //class Programa
    //{
    //    string Nombre { get; set; }
    //    int Creditos { get; set; }
    //    double Descuento { get; set; }

    //    public Programa(string nombre, int creditos, double descuento)
    //    {
    //        Nombre = nombre;
    //        Creditos = creditos;
    //        Descuento = descuento;
    //    }

    //    public int ObtenerCreditos() => Creditos;
    //    public double ObtenerDescuento() => Descuento;
    //    public string ObtenerNombre() => Nombre;
    //}

    //class Ejercicio5
    //{
    //    const double ValorCredito = 200000;

    //    static void Main()
    //    {
    //        // Crear los programas académicos
    //        var programas = new Dictionary<string, Programa>()
    //        {
    //            {"Ingeniería de sistemas", new Programa("Ingeniería de sistemas", 20, 0.18)},
    //            {"Psicología", new Programa("Psicología", 16, 0.12)},
    //            {"Economía", new Programa("Economía", 18, 0.10)},
    //            {"Comunicación Social", new Programa("Comunicación Social", 18, 0.05)},
    //            {"Administración de Empresas", new Programa("Administración de Empresas", 20, 0.15)}
    //        };

    //        // Contadores
    //        var conteoEstudiantes = new Dictionary<string, int>();
    //        foreach (var key in programas.Keys)
    //            conteoEstudiantes[key] = 0;

    //        int totalCreditos = 0;
    //        double totalSinDescuento = 0, totalDescuentos = 0;

    //        Console.Write("Ingrese la cantidad de estudiantes a matricular: ");
    //        int cantidad = int.Parse(Console.ReadLine());

    //        for (int i = 0; i < cantidad; i++)
    //        {
    //            Console.WriteLine("\nSeleccione el programa académico:");
    //            int index = 1;
    //            foreach (var p in programas)
    //                Console.WriteLine($"{index++}. {p.Key}");

    //            Console.Write("Opción: ");
    //            int opcion = int.Parse(Console.ReadLine());
    //            string programaSeleccionado = new List<string>(programas.Keys)[opcion - 1];
    //            var programa = programas[programaSeleccionado];

    //            Console.Write("Forma de pago (1-Efectivo, 2-En línea): ");
    //            int formaPago = int.Parse(Console.ReadLine());

    //            // Cálculos
    //            double valorPrograma = programa.ObtenerCreditos() * ValorCredito;
    //            double descuento = (formaPago == 1) ? valorPrograma * programa.ObtenerDescuento() : 0;

    //            totalCreditos += programa.ObtenerCreditos();
    //            totalSinDescuento += valorPrograma;
    //            totalDescuentos += descuento;
    //            conteoEstudiantes[programa.ObtenerNombre()]++;

    //            Console.WriteLine($"\nEstudiante matriculado en {programa.ObtenerNombre()}");
    //            Console.WriteLine($"Valor del programa: ${valorPrograma:N2}");
    //            if (descuento > 0)
    //                Console.WriteLine($"Descuento aplicado: ${descuento:N2}");
    //            Console.WriteLine($"Valor neto: ${(valorPrograma - descuento):N2}");
    //        }

    //        // Resultados finales
    //        Console.WriteLine("\n========== RESULTADOS ==========");
    //        Console.WriteLine("\na) Estudiantes por programa:");
    //        foreach (var p in conteoEstudiantes)
    //            Console.WriteLine($"   {p.Key}: {p.Value}");

    //        Console.WriteLine($"\nb) Total de créditos inscritos: {totalCreditos}");
    //        Console.WriteLine($"c) Valor total sin descuentos: ${totalSinDescuento:N2}");
    //        Console.WriteLine($"d) Valor total de descuentos: ${totalDescuentos:N2}");
    //        Console.WriteLine($"e) Valor neto total: ${(totalSinDescuento - totalDescuentos):N2}");
    //    }
    //}

    /*EJERCICIO #6*/

    //class Empleado
    //{
    //    string Nombre { get; set; }
    //    List<double> Ventas { get; set; }
    //    const double PagoBase = 500000;

    //    public Empleado(string nombre)
    //    {
    //        Nombre = nombre;
    //        Ventas = new List<double>();
    //    }

    //    public void AgregarVenta(double valor)
    //    {
    //        if (valor > 0)
    //            Ventas.Add(valor);
    //        else
    //            Console.WriteLine("⚠️ El valor de la venta debe ser positivo.");
    //    }

    //    double TotalVentas()
    //    {
    //        double total = 0;
    //        foreach (var v in Ventas) total += v;
    //        return total;
    //    }

    //    double CalcularBonificacion()
    //    {
    //        double total = TotalVentas();

    //        if (total >= 800000)
    //            return total * 0.10;
    //        else if (total >= 400001 && total <= 800000)
    //            return total * 0.05;
    //        else if (total >= 400000)
    //            return total * 0.03;
    //        else
    //            return 0;
    //    }

    //    void ClasificarVentas(out int bajas, out int medias, out int altas)
    //    {
    //        bajas = medias = altas = 0;
    //        foreach (var v in Ventas)
    //        {
    //            if (v <= 300000) bajas++;
    //            else if (v < 800000) medias++;
    //            else altas++;
    //        }
    //    }

    //    public void MostrarResumen()
    //    {
    //        ClasificarVentas(out int bajas, out int medias, out int altas);
    //        double totalVentas = TotalVentas();
    //        double bono = CalcularBonificacion();
    //        double totalPagar = PagoBase + bono;

    //        Console.WriteLine($"\n=== Empleado: {Nombre} ===");
    //        Console.WriteLine($"Ventas menores o iguales a $300.000: {bajas}");
    //        Console.WriteLine($"Ventas entre $300.001 y $799.999: {medias}");
    //        Console.WriteLine($"Ventas mayores o iguales a $800.000: {altas}");
    //        Console.WriteLine($"Total vendido: ${totalVentas:N2}");
    //        Console.WriteLine($"Bonificación: ${bono:N2}");
    //        Console.WriteLine($"Pago base: ${PagoBase:N2}");
    //        Console.WriteLine($"💰 Total a pagar: ${totalPagar:N2}");
    //    }
    //}

    //class Ejercicio6
    //{
    //    static void Main()
    //    {
    //        Console.Write("Ingrese la cantidad de empleados: ");
    //        int cantidad = int.Parse(Console.ReadLine());

    //        List<Empleado> empleados = new List<Empleado>();

    //        for (int i = 0; i < cantidad; i++)
    //        {
    //            Console.Write($"\nNombre del empleado {i + 1}: ");
    //            string nombre = Console.ReadLine();
    //            Empleado e = new Empleado(nombre);

    //            Console.Write($"Cantidad de ventas realizadas por {nombre}: ");
    //            int nVentas = int.Parse(Console.ReadLine());

    //            for (int j = 0; j < nVentas; j++)
    //            {
    //                Console.Write($"Valor de la venta {j + 1}: $");
    //                double valor = double.Parse(Console.ReadLine());
    //                e.AgregarVenta(valor);
    //            }

    //            empleados.Add(e);
    //        }

    //        Console.WriteLine("\n========== RESUMEN DEL DÍA ==========");
    //        foreach (var emp in empleados)
    //            emp.MostrarResumen();
    //    }
    //}

    /*EJERCICIO #7*/

    //class Conductor
    //{
    //    int AnioNacimiento { get; set; }
    //    int Sexo { get; set; }        // 1: Femenino, 2: Masculino
    //    int Registro { get; set; }    // 1: Bogotá, 2: Otras ciudades

    //    public Conductor(int anio, int sexo, int registro)
    //    {
    //        AnioNacimiento = anio;
    //        Sexo = sexo;
    //        Registro = registro;
    //    }

    //    int CalcularEdad()
    //    {
    //        int anioActual = DateTime.Now.Year;
    //        return anioActual - AnioNacimiento;
    //    }

    //    public bool EsMenorDe30() => CalcularEdad() < 30;
    //    public bool EsMasculino() => Sexo == 2;
    //    public bool EsFemenino() => Sexo == 1;
    //    public bool EsMasculinoEntre12y30()
    //    {
    //        int edad = CalcularEdad();
    //        return EsMasculino() && edad >= 12 && edad <= 30;
    //    }
    //    public bool CarroFueraDeBogota() => Registro == 2;
    //}

    //class Ejercicio7
    //{
    //    static void Main()
    //    {
    //        Console.Write("Ingrese el número de conductores: ");
    //        int cantidad = int.Parse(Console.ReadLine());

    //        List<Conductor> conductores = new List<Conductor>();

    //        for (int i = 0; i < cantidad; i++)
    //        {
    //            Console.WriteLine($"\n--- Conductor {i + 1} ---");
    //            Console.Write("Año de nacimiento: ");
    //            int anio = int.Parse(Console.ReadLine());

    //            Console.Write("Sexo (1-Femenino, 2-Masculino): ");
    //            int sexo = int.Parse(Console.ReadLine());

    //            Console.Write("Registro del carro (1-Bogotá, 2-Otras ciudades): ");
    //            int registro = int.Parse(Console.ReadLine());

    //            conductores.Add(new Conductor(anio, sexo, registro));
    //        }

    //        // Cálculos
    //        int total = conductores.Count;
    //        int menores30 = 0, hombres = 0, mujeres = 0, hombresJovenes = 0, fueraBogota = 0;

    //        foreach (var c in conductores)
    //        {
    //            if (c.EsMenorDe30()) menores30++;
    //            if (c.EsMasculino()) hombres++;
    //            if (c.EsFemenino()) mujeres++;
    //            if (c.EsMasculinoEntre12y30()) hombresJovenes++;
    //            if (c.CarroFueraDeBogota()) fueraBogota++;
    //        }

    //        // Resultados (en porcentaje)
    //        Console.WriteLine("\n========== RESULTADOS ==========");
    //        Console.WriteLine($"• Conductores menores de 30 años: {(double)menores30 / total * 100:N2}%");
    //        Console.WriteLine($"• Conductores masculinos: {(double)hombres / total * 100:N2}%");
    //        Console.WriteLine($"• Conductores femeninos: {(double)mujeres / total * 100:N2}%");
    //        Console.WriteLine($"• Conductores masculinos entre 12 y 30 años: {(double)hombresJovenes / total * 100:N2}%");
    //        Console.WriteLine($"• Conductores con carros registrados fuera de Bogotá: {(double)fueraBogota / total * 100:N2}%");
    //    }
    //}

    /*EJERCICIO #8*/

    //class Empleado
    //{
    //    string Nombre { get; set; }
    //    DateTime FechaNacimiento { get; set; }

    //    public Empleado(string nombre, DateTime fechaNacimiento)
    //    {
    //        Nombre = nombre;
    //        FechaNacimiento = fechaNacimiento;
    //    }

    //    public int Edad()
    //    {
    //        int edad = DateTime.Now.Year - FechaNacimiento.Year;
    //        if (DateTime.Now < FechaNacimiento.AddYears(edad)) edad--;
    //        return edad;
    //    }

    //    public int MesCumple()
    //    {
    //        return FechaNacimiento.Month;
    //    }
    //}

    //class Ejercicio8
    //{
    //    static void Main()
    //    {
    //        const double Bono = 150000;
    //        Console.Write("Ingrese la cantidad de empleados: ");
    //        int n = int.Parse(Console.ReadLine());

    //        List<Empleado> empleados = new List<Empleado>();

    //        for (int i = 0; i < n; i++)
    //        {
    //            Console.WriteLine($"\n--- Empleado {i + 1} ---");
    //            Console.Write("Nombre: ");
    //            string nombre = Console.ReadLine();

    //            Console.Write("Fecha de nacimiento (yyyy-mm-dd): ");
    //            DateTime fecha = DateTime.Parse(Console.ReadLine());

    //            empleados.Add(new Empleado(nombre, fecha));
    //        }

    //        // Cálculo de edades y meses
    //        double sumaEdades = 0;
    //        int[] cumplePorMes = new int[12];

    //        foreach (var e in empleados)
    //        {
    //            int edad = e.Edad();
    //            sumaEdades += edad;

    //            if (edad >= 18 && edad <= 50)
    //                cumplePorMes[e.MesCumple() - 1]++;
    //        }

    //        double promedioEdad = sumaEdades / n;

    //        // Mostrar resultados
    //        Console.WriteLine("\n========== RESULTADOS ==========");
    //        Console.WriteLine($"Promedio de edades: {promedioEdad:N2} años");

    //        double totalBonos = 0;
    //        Console.WriteLine("\nMes\t\tEmpleados\tDinero en Bonos");

    //        for (int i = 0; i < 12; i++)
    //        {
    //            double dineroMes = cumplePorMes[i] * Bono;
    //            totalBonos += dineroMes;

    //            string mes = new DateTime(1, i + 1, 1).ToString("MMMM");
    //            Console.WriteLine($"{mes,-12}\t{cumplePorMes[i]} empleados\t${dineroMes:N0}");
    //        }

    //        Console.WriteLine($"\nTotal a pagar en bonificaciones: ${totalBonos:N0}");
    //    }
    //}

    /*EJERCICIO #9*/

    class Camion
    {
        double CapacidadMaxima { get; set; }
        double CargaActual { get; set; }

        public Camion(double capacidad)
        {
            CapacidadMaxima = capacidad;
            CargaActual = 0;
        }

        public bool Cargar(double peso)
        {
            if (CargaActual + peso <= CapacidadMaxima)
            {
                CargaActual += peso;
                Console.WriteLine($"✔️ Tanque cargado. Carga actual: {CargaActual:N0} L");
                return true;
            }
            else
            {
                Console.WriteLine($"❌ Capacidad excedida con {peso:N0} L. Despachando camión...");
                return false;
            }
        }

        public void Despachar()
        {
            Console.WriteLine($"🚚 Camión despachado con {CargaActual:N0} litros.\n");
        }
    }

    class Ejercicio9
    {
        static void Main()
        {
            Console.WriteLine("=== CONTROL DE CARGA DE CAMIONES (20 diarios) ===");

            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine($"\n--- CAMIÓN #{i} ---");
                Console.Write("Ingrese la capacidad del camión (18000 - 28000 L): ");
                double capacidad = double.Parse(Console.ReadLine());

                while (capacidad < 18000 || capacidad > 28000)
                {
                    Console.Write("⚠️ Capacidad fuera del rango. Ingrese nuevamente: ");
                    capacidad = double.Parse(Console.ReadLine());
                }

                Camion camion = new Camion(capacidad);

                while (true)
                {
                    Console.Write("Ingrese el peso del tanque de alcohol (3000-9000 L) o 0 para terminar: ");
                    double peso = double.Parse(Console.ReadLine());

                    if (peso == 0)
                    {
                        camion.Despachar();
                        break;
                    }

                    if (peso < 3000 || peso > 9000)
                    {
                        Console.WriteLine("⚠️ El valor debe estar entre 3000 y 9000 litros.");
                        continue;
                    }

                    bool cargado = camion.Cargar(peso);
                    if (!cargado)
                    {
                        camion.Despachar();
                        break;
                    }
                }
            }

            Console.WriteLine("\n Se han despachado los 20 camiones del día.");
        }
    }

}
