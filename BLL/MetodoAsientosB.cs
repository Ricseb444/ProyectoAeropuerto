using DAL;
using DEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MetodoAsientosB
    {
        public readonly StringBuilder stringBuilder = new StringBuilder();
        private readonly PasajeroDAL PDAL;

        public MetodoAsientosB()
        {
            PDAL = new PasajeroDAL();
        }

        public List<Pasajero> ListarPasajeros()
        {
            List<Pasajero> ListaPasajeros = PDAL.GetAll("pasajeros2");
            return ListaPasajeros;
        }

        public int ConsultarAsLibres()
        {
            int asientosLibres = 50;
            List<Pasajero> newList = ListarPasajeros();
            for (int i = 0; i < newList.Count; i++)
            {
                if (newList[i] != null)
                {
                    asientosLibres--;
                }
            }
            return asientosLibres;
        }

        public int AgregarPasagero(int numA, Pasajero pasajero)
        {
            int asientosLibres = ConsultarAsLibres();

            List<Pasajero> lista = ListarPasajeros();

            if (asientosLibres > 0)
            {
                foreach (Pasajero item in lista)
                {
                    if (PDAL.GetByid(pasajero.Cedula, "pasajeros2") == null)
                    {
                        if (item.Asiento == numA)
                        {
                            stringBuilder.Clear();
                            stringBuilder.Append($"El asiento numero {pasajero.Asiento} no esta disponible");
                            return 1;
                        }
                    }
                    else
                    {
                        stringBuilder.Clear();
                        stringBuilder.Append($"Ya existe una reservación al número de cédula{pasajero.Cedula}");
                        return 3;
                    }
                }
                stringBuilder.Clear();
                PDAL.Insert(pasajero, "pasajeros2");
                stringBuilder.Append($"{pasajero.Nombre} ha sido asignado/a al asiento numero {pasajero.Asiento} de la primera clase");
                return 0;
            }
            else
            {
                stringBuilder.Clear();
                stringBuilder.Append("No quedan más asientos disponibles en esta clase");
                return 2;
            }
        }

        public void CancelarReserva(string nombre, int asiento, string clase)
        {
            List<Pasajero> newList = ListarPasajeros();
            stringBuilder.Clear();
            foreach (object item in newList)
            {
                if (item is Pasajero pasajero)
                {
                    if (string.Equals(pasajero.Clase, clase, StringComparison.OrdinalIgnoreCase))
                    {
                        if (int.Equals(pasajero.Asiento, asiento))
                        {
                            if (string.Equals(pasajero.Nombre, nombre, StringComparison.OrdinalIgnoreCase))
                            {
                                PDAL.Delete(pasajero.Cedula,"pasajeros2");
                                stringBuilder.Append($"La reserva del asiento numero {asiento} fue cancelada");
                            }
                        }
                    }
                }
            }
        }

        public List<Pasajero> BuscarXNom(string nombreBuscado)
        {
            List<Pasajero> lista = ListarPasajeros();
            List<Pasajero> coincidencias = new List<Pasajero>();
            foreach (object item in lista)//<--Esto era campos
            {
                if (item is Pasajero pasajero)
                {
                    if (string.Equals(pasajero.Nombre, nombreBuscado, StringComparison.OrdinalIgnoreCase))
                    {
                        coincidencias.Add(pasajero);
                    }
                }
            }

            return coincidencias;
        }
    }
}
