namespace DEL
{
    public class Pasajero
    {
        // Propiedades de la clase
        public string Nombre { get; set; }
        public long Cedula { get; set; }
        public string Telefono { get; set; }
        public string Clase { get; set; }
        public int Asiento { get; set; }

        public Pasajero()
        {
        
        }
        // Constructor
        public Pasajero(string nombre, long numCedula, string numTelefono, string clase, int numAsiento)
        {
            Nombre = nombre;
            Cedula = numCedula;
            Telefono = numTelefono;
            Clase = clase;
            Asiento = numAsiento;

        }
    }
}
