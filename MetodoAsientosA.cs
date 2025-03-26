using DEL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoAeropuerto
{
    //class MetodoAsientosA
    //{
    //    protected static readonly ArrayList Campos = new ArrayList(50);

    //    public static void Rellenarlista()
    //    {
    //        for (int i = 0; i < 50; i++)
    //        {
    //            Campos.Add(null);
    //        }
    //    }

    //    public int AgregarPasagero(int numA, Pasajero pasajero)
    //    {

    //        int asientosLibres = 0;

    //        for (int i = 0; i < Campos.Count; i++)
    //        {
    //            if (Campos[i] == null)
    //            {
    //                asientosLibres++;
    //            }
    //        }

    //        if (asientosLibres > 0)
    //        {
    //            for (int i = 0; i < Campos.Count;)
    //            {
    //                if (Campos[numA] == null)
    //                {
    //                    Campos[numA] = pasajero;

    //                    MessageBox.Show($"{pasajero.Nombre} ha sido asignado/a al asiento numero {pasajero.Asiento} de la primera clase",
    //                        "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

    //                    return 0;
    //                }
    //                else
    //                {
    //                    //Mensaje por si el asiento seleccionado ya esta ocupado
    //                    this.Alert("Error: Asiento no disponible", FAlert.enmType.error);
    //                    MessageBox.Show(
    //                        $"El asiento numero {pasajero.Asiento} no esta disponible",
    //                        "Lo sentimos",
    //                        MessageBoxButtons.OK,
    //                        MessageBoxIcon.Exclamation);
    //                    return 1;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            //Mensaje por si ya no quedan asientos disponibles
    //            MessageBox.Show(
    //                "No quedan más asientos disponibles en esta clase",
    //                "Lo sentimos",
    //                MessageBoxButtons.OK,
    //                MessageBoxIcon.Error);
    //            return 2;
    //        }
    //        return 3;

    //    }
    //    public int ConsultarAsLibres()
    //    {
    //        int asientosLibres = 0;

    //        for (int i = 0; i < Campos.Count; i++)
    //        {
    //            if (Campos[i] == null)
    //            {
    //                asientosLibres++;
    //            }
    //        }
    //        return asientosLibres;
    //    }

    //    public void Alert(string msg, FAlert.enmType type)
    //    {
    //        FAlert frm = new FAlert();
    //        frm.showAlert(msg, type);
    //    }

    //    public void CancelarReserva(string nombre, int asiento, string clase)
    //    {
    //        foreach (object item in Campos)
    //        {
    //            if (item is Pasajero pasajero)
    //            {
    //                Pasajero pasajeroBorrar = pasajero;
    //                if (string.Equals(pasajeroBorrar.Clase, clase, StringComparison.OrdinalIgnoreCase) && (int.Equals(pasajeroBorrar.Asiento, asiento)) && (string.Equals(pasajeroBorrar.Nombre, nombre, StringComparison.OrdinalIgnoreCase)))
    //                {
    //                    DialogResult respuesta1 = MessageBox.Show($"¿Está seguro de que desea cancelar la reserva a nombre de {nombre} asiento numero {asiento}?",
    //                    "Cancelar reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

    //                    if (respuesta1 == DialogResult.Yes)
    //                    {
    //                        int index = Campos.IndexOf(item);
    //                        if (index != -1)
    //                        {
    //                            Campos[index] = null;
    //                            this.Alert($"Reserva {asiento} eliminada", FAlert.enmType.info);
    //                        }
    //                        break;
    //                    }
    //                    else
    //                    {
    //                        break;
    //                    }

    //                }
    //            }
    //        }
    //    }

    //    public List<Pasajero> BuscarXNom(string nombreBuscado)
    //    {
    //        List<Pasajero> coincidencias = new List<Pasajero>();

    //        foreach (object item in Campos)
    //        {
    //            if (item is Pasajero pasajero)
    //            {
    //                //Pasajero newpasajero = pasajero;

    //                if (string.Equals(pasajero.Nombre, nombreBuscado, StringComparison.OrdinalIgnoreCase))
    //                {
    //                    coincidencias.Add(pasajero);
    //                }
    //            }
    //        }

    //        return coincidencias;
    //    }

    //    public List<Pasajero> ListarPasajeros()
    //    {
    //        List<Pasajero> ListaPasajeros = new List<Pasajero>();

    //        foreach (object item in Campos)
    //        {
    //            if (item is Pasajero pasajero /*&& pasajero != null*/)
    //            {
    //                ListaPasajeros.Add(pasajero);
    //            }
    //        }
    //        return ListaPasajeros;
    //    }
    //}
}
/*Mensaje de comprobación de datos
                        string mensaje = "Todo correcto!!\n"
                           + "Nombre: " + pasajero.Nombre + "\n"
                           + "cedula: " + pasajero.NumCedula + "\n"
                           + "telefono: " + pasajero.NumTelefono + "\n"
                           + "clase: " + pasajero.Clase + "\n"
                           + "asiento: " + pasajero.NumAsiento;
                        MessageBox.Show(mensaje, "Oll Korrect", MessageBoxButtons.OK);*/
/*==================================================================================================/
        public string BuscarXNom(string nombreBuscado)
        {
            List<string> coincidencias = new List<string>();

            for (int i = 0; i < Campos.Count; i++)
            {
                if (Campos[i] != null)
                {
                    if (string.Equals(((Pasajero)Campos[i]).Nombre, nombreBuscado, StringComparison.OrdinalIgnoreCase))
                    {
                        StringBuilder output = new StringBuilder("Clase #1\nInformación del pasajero:\n");
                        output.Append("Nombre: ").Append(((Pasajero)Campos[i]).Nombre).Append("\n");
                        output.Append("Cedula: ").Append(((Pasajero)Campos[i]).NumCedula).Append("\n");
                        output.Append("Telefono: ").Append(((Pasajero)Campos[i]).NumTelefono).Append("\n");
                        output.Append("Asiento: ").Append(((Pasajero)Campos[i]).NumAsiento).Append("\n");
                        output.Append("Clase: ").Append(((Pasajero)Campos[i]).Clase);
                        coincidencias.Add(output.ToString());

                    }

                }
            }

            if (coincidencias.Count > 0)
            {
                return $"para'{nombreBuscado}': {coincidencias.Count}\n\n{string.Join("\n\n", coincidencias)}";
            }

            return ":\n\nNo se encontraron coincidencias en esta clase";
        }
        /*==================================================================================================*/
