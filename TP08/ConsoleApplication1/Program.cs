using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static string[] estado = new string[]{ "casado", "soltero" };
        public static string[] genero = new string[]{ "masculino", "femenino" };
        public static string[] nombre = new string[] { "Juan", "Nacho", "Roberto", "Eustaquio", "Luna", "Angel", "Martin", "Javier" };
        public static string[] apellido = new string[] { "Naval", "Castelli", "Villafañe", "Perdigon", "Perez", "Arcucci", "Lauriano", "Paz" };
       
        static DateTime RandomBirthDay()
        {
            Random gen = new Random();
            DateTime start = new DateTime(1963, 1, 1);
            DateTime EndDay = new DateTime(1970, 1, 1);
            int rango = (EndDay - start).Days;
            return start.AddDays(gen.Next(rango));
        }
        static DateTime RandomIngressDay()
        {
            Random gen = new Random();
            DateTime start = new DateTime(1990, 1, 1);
            int rango = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(rango));
        }

         static void Main(string[] args)
        {
            List<Empleado> empleados = new List<Empleado>();
            Random gen = new Random();
            DateTime Fechanac = new DateTime();
            Fechanac = RandomBirthDay();
            DateTime Fechaing = new DateTime();
            Fechaing = RandomIngressDay();
            Empleado Nuevo;
            for(int k = 0; k < 20; k++)
            {
                Nuevo = new Empleado(nombre[gen.Next() % 8], apellido[gen.Next() % 8], Fechanac, estado[gen.Next() % 2], genero[gen.Next() % 2], Fechaing, (Cargo)gen.Next(0, 4));
                empleados.Add(Nuevo);
            }
            double SueldoTot = 0;
            int i = 0;
            foreach (Empleado emple in empleados){
                Console.Write("\n\nEmpleado {0}", i+1);
                emple.MostrarEmpleado();
                SueldoTot = SueldoTot + emple.Salario();
                i++;
            }
            Console.Write("\n\n\nCantidad de empleados en la empresa{0}", i);
            Console.Write("\n\n\nMonto de Sueldos Total: ${0}", SueldoTot);
            Console.Write("\n\nDe que empleado desea ver los datos?:");
            i = int.Parse(Console.ReadLine());
            empleados[i-1].MostrarEmpleado();
            Console.ReadKey();

        }
        
    }
}
