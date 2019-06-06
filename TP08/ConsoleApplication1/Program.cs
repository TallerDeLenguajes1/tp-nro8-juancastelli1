using System;
using System.IO;
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
        public static Random gen1 = new Random();
        static DateTime RandomBirthDay()
        {
            DateTime start = new DateTime(1963, 1, 1);
            DateTime EndDay = new DateTime(1970, 1, 1);
            int rango = (EndDay - start).Days;
            double valor = gen1.Next(rango);
            start = start.AddDays(valor);
            return start;
        }
        static DateTime RandomIngressDay()
        {
            
            DateTime start = new DateTime(1990, 1, 1);
            int rango = (DateTime.Today - start).Days;
            return start.AddDays(gen1.Next(rango));
        }
       
        static void Main(string[] args)
        {
            string path = "empleados.csv";
            List<Empleado> empleados = new List<Empleado>();
            Random gen = new Random();
            DateTime Fechanac = new DateTime();
            DateTime Fechaing = new DateTime();
            Empleado Nuevo;
            for(int k = 0; k < 20; k++)
            {
                Fechanac = RandomBirthDay();
                Fechaing = RandomIngressDay();
                Nuevo = new Empleado(nombre[gen.Next() % 8], apellido[gen.Next() % 8], Fechanac, estado[gen.Next() % 2], genero[gen.Next() % 2], Fechaing, (Cargo)gen.Next(0, 4));
                empleados.Add(Nuevo); 
            }
            double SueldoTot = 0;
            int i = 0;
            StreamWriter write = new StreamWriter(File.Open(path, FileMode.Create));
            write.Write("Nombre;Apellido;Nacimiento;Estado;Genero;Fechaing;Cargo");
            foreach (Empleado emple in empleados){
                Console.Write("\n\nEmpleado {0}", i+1);
                emple.MostrarEmpleado();
                emple.AgregarAArchiv(write);
                SueldoTot = SueldoTot + emple.Salario();
                i++;
            }
            write.Close();
            Console.Write("\n\n\nCantidad de empleados en la empresa{0}", i);
            Console.Write("\n\n\nMonto de Sueldos Total: ${0}", SueldoTot);
            Console.Write("\n\nDe que empleado desea ver los datos?:");
            i = int.Parse(Console.ReadLine());
            empleados[i-1].MostrarEmpleado();
            Console.Write("\nEn que disco desea guardar su backup?:");
            foreach(string s in Directory.GetLogicalDrives()){
                Console.Write(s);
            }
            string disco = Console.ReadLine();
            string pathbackup = disco + ":\\BackUpAgenda\\";
            if (Directory.Exists(pathbackup) != true)
            {
                Directory.CreateDirectory(pathbackup);
            }
            i = 0;
            string file = pathbackup + "empleados-copia" + i + ".bk";
            while (File.Exists(file))
            {
                file = pathbackup + "empleados-copia" + i + ".bk";
                i++;
            }
            File.Copy("empleados.csv", file);
            Console.ReadKey();

        }
        
    }
}
