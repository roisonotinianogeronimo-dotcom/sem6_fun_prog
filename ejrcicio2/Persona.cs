namespace Ejercicio1
{
    public class Persona
    {
        public int dni;
        public string nombre;
        public string telefono;

        public override string ToString()
        {
            return $"DNI: {dni}, Nombre: {nombre}, Telefono: {telefono}";
        }
    }
}