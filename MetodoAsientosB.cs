using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using DEL;


namespace ProyectoAeropuerto
{
    //class MetodoAsientosB
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

    //                    MessageBox.Show($"{pasajero.Nombre} ha sido asignado/a al asiento numero {pasajero.Asiento} de la Segunda clase",
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
    //        //MessageBox.Show("Method workin'");
    //        for (int i = 0; i < Campos.Count; i++)
    //        {
    //            if (Campos[i] != null && Campos[i] is Pasajero)
    //            {
    //                Pasajero pasajero = (Pasajero)Campos[i];
    //                if (string.Equals(pasajero.Clase, clase, StringComparison.OrdinalIgnoreCase))
    //                {
    //                    if (int.Equals(pasajero.Asiento, asiento))
    //                    {
    //                        if (string.Equals(pasajero.Nombre, nombre, StringComparison.OrdinalIgnoreCase))
    //                        {
    //                            DialogResult respuesta1 = MessageBox.Show($"¿Está seguro de que desea cancelar la reserva a nombre de {nombre} asiento numero {asiento}?",
    //                            "Cancelar reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

    //                            if (respuesta1 == DialogResult.Yes)
    //                            {
    //                                Campos[i] = null;
    //                                this.Alert($"Reserva {asiento} eliminada", FAlert.enmType.info);
    //                                break;
    //                            }
    //                            else
    //                            {
    //                                break;
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    public List<Pasajero> BuscarXNom(string nombreBuscado)
    //    {
    //        List<Pasajero> coincidencias = new List<Pasajero>();

    //        for (int i = 0; i < Campos.Count; i++)
    //        {
    //            if (Campos[i] != null && Campos[i] is Pasajero)
    //            {
    //                Pasajero pasajero = (Pasajero)Campos[i];

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

    //        for (int i = 0; i < Campos.Count; i++)
    //        {
    //            if (Campos[i] != null && Campos[i] is Pasajero)
    //            {
    //                Pasajero pasajero = (Pasajero)Campos[i];
    //                ListaPasajeros.Add(pasajero);

    //            }
    //        }
    //        return ListaPasajeros;
    //    }
    //}
}
