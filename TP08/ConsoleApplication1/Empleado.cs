using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public enum Cargo { Auxiliar, Administrativo, Ingeniero, Especialista, Investigador };
    class Empleado
    {
        public string nombre;
        public string apellido;
        public DateTime fechanac;
        public string estadocivil;
        public string genero;
        public DateTime fechaingreso;
        public Cargo cargo;
        public Empleado(string _nombre, string _apellido, DateTime _fechanac, string _estadocivil, string _genero, DateTime _fechaingreso, Cargo _cargo)
        {
            this.nombre = _nombre;
            this.apellido = _apellido;
            this.fechanac = _fechanac;
            this.estadocivil = _estadocivil;
            this.genero = _genero;
            this.fechaingreso = _fechaingreso;
            this.cargo = _cargo;
        }
        public void AgregarAArchiv(StreamWriter write)
        {
            try
            {
                write.Write("\n{0};{1};{2};{3};{4};{5};{6}", nombre, apellido, fechanac.ToShortDateString(), estadocivil, genero, fechaingreso.ToShortDateString(), cargo);
            }
            catch (Exception x)
            {
                string hola = x.ToString();

            } 
        }
        public void MostrarEmpleado()
        {
            Console.Write("\n{0}", this.nombre);
            Console.Write("\n{0}", this.apellido);
            Console.Write("\n{0}", this.fechanac.Date.ToShortDateString());
            Console.Write("\n{0}", this.estadocivil);
            Console.Write("\n{0}", this.genero);
            Console.Write("\n{0}", this.fechaingreso.Date.ToShortDateString());
            Console.Write("\n{0}", this.cargo);
            Console.Write("\nLa antiguedad del empleado es de {0} años", Antiguedad());
            Console.Write("\nLa Edad del empleado es de {0} años", Edad());
            Console.Write("\nPara jubilarse le faltan {0} años", Jubila());
            Console.Write("\nSalario: ${0}", Salario());
        }
        public double Salario()
        {
            double Adicional, basico = 15000, Sueldo;
            Random gen = new Random();
            int hijos = gen.Next(0, 11);
            if (Antiguedad() < 25)
            {
                Adicional = basico * (0.2 * Antiguedad());
            }
            else
            {
                Adicional = basico * 0.25;
            }
            if ((cargo == (Cargo)2) || (cargo == (Cargo)3))
            {
                Adicional = Adicional * 1.50;
            }
            if (estadocivil == "casado")
            {
                if (hijos > 2)
                {
                    Adicional = Adicional + 5000;
                }
            }
            Sueldo = basico + Adicional;
            return Sueldo;
        }
        public int Antiguedad()
        {
            int Antig;
            Antig = (DateTime.Today - fechaingreso).Days / 365;
            return Antig;
        }
        public int Edad()
        {
            int Antig;
            Antig = (DateTime.Today - fechanac).Days / 365;
            return Antig;
        }
        public int Jubila()
        {
            int Antig;

            if (genero == "masculino")
            {
                Antig = 65 - Edad();
            }
            else
            {
                Antig = 60 - Edad();
            }
            return Antig;
        }
    }
}
