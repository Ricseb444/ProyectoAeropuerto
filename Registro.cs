using System;
using System.Linq;
using System.Windows.Forms;
using DEL;
using BLL;

namespace ProyectoAeropuerto
{
    public partial class Registro : Form
    {
        public string Nombre { get; set; }
        public long Cedula { get; set; }
        public string Telefono { get; set; }
        public string Clase { get; set; }
        public int Asiento { get; set; }

        string[] numeros = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                        "11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
                        "21", "22", "23", "24", "25", "26", "27", "28", "29", "30",
                        "31", "32", "33", "34", "35", "36", "37", "38", "39", "40",
                        "41", "42", "43", "44", "45", "46", "47", "48", "49", "50" };

        string[] clases = { "Primera Clase", "Segunda Clase", "Tercera Clase" };

        public Registro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            RellenarAsientoCombo();
            RellenarClaseCombo();
        }

        void RellenarAsientoCombo()
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                asientocombo.Items.Add(numeros[i]);
            }
        }

        void RellenarClaseCombo()
        {
            for (int i = 0; i < clases.Length; i++)
            {
                clasecombo.Items.Add(clases[i]);
            }
        }

        int Validaciones()
        {
            if ((nombretxt.Text == ""))
            {
                return 1;
            }
            else if ((cedulatxt.Text == ""))
            {
                return 2;
            }
            else if ((telefonotxt.Text == ""))
            {
                return 3;
            }
            else if (!(nombretxt.Text.All(Char.IsLetter)))
            {
                return 4;
            }
            else if (!(cedulatxt.Text.All(Char.IsDigit)))
            {
                return 5;
            }
            else if (!(telefonotxt.Text.All(Char.IsDigit)))
            {
                return 6;
            }
            else if ((clasecombo.SelectedIndex <= -1))
            {
                return 7;
            }

            else if ((asientocombo.SelectedIndex <= -1))
            {
                return 8;
            }
            else
            {
                return 0;
            }

        }

        readonly MetodoAsientosA registrarA = new MetodoAsientosA();
        readonly MetodoAsientosB registrarB = new MetodoAsientosB();
        readonly MetodoAsientosC registrarC = new MetodoAsientosC();

        public void Alert(string msg, FAlert.enmType type)
        {
            FAlert frm = new FAlert();
            frm.showAlert(msg, type);
        }
        private void DesactivarErr()
        {
            errorProvider1.SetError(panelNCT, "");
            errorProvider1.SetError(panelCed, "");
            errorProvider1.SetError(panelTel, "");
            errorProvider1.SetError(panelCA, "");
            errorProvider1.SetError(panelAsi, "");
        }
        private void btnReservar_Click(object sender, EventArgs e)
        {
            switch (Validaciones())
            {
                case 0:
                    {
                        Nombre = nombretxt.Text;
                        Cedula = long.Parse(cedulatxt.Text);
                        Telefono = telefonotxt.Text;
                        Clase = clasecombo.Text;
                        Asiento = int.Parse(asientocombo.Text);
                        Pasajero pasajero = new Pasajero(Nombre, Cedula, Telefono, Clase, Asiento);
                        string mensaje; 
                        switch (clasecombo.Text)
                        {
                            case "Primera Clase":
                                {
                                    if (registrarA.AgregarPasagero(Asiento , pasajero) == 0)
                                    {
                                        this.Alert("Registro Exitoso", FAlert.enmType.Success);
                                        mensaje = registrarA.stringBuilder.ToString();
                                        MessageBox.Show(mensaje, "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);                                        
                                        this.Close();
                                    }
                                    else if (registrarA.AgregarPasagero(Asiento , pasajero) == 1)
                                    {
                                        this.Alert("Error:Asiento no disponible", FAlert.enmType.error);
                                        mensaje = registrarA.stringBuilder.ToString();
                                        MessageBox.Show(mensaje, "Lo sentimos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        break;
                                    }
                                    else if (registrarA.AgregarPasagero(Asiento , pasajero) == 2)
                                    {
                                        this.Alert("Error: Clase Llena", FAlert.enmType.error);
                                        mensaje = registrarA.stringBuilder.ToString();
                                        MessageBox.Show(mensaje, "Lo sentimos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                                        
                                        break;
                                    }
                                    else if (registrarA.AgregarPasagero(Asiento, pasajero) == 3)
                                    {
                                        this.Alert("Error: Ya existe reserva", FAlert.enmType.error);
                                        mensaje = registrarA.stringBuilder.ToString();
                                        MessageBox.Show(mensaje, "Lo sentimos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                                        
                                        break;
                                    }
                                    break;
                                }
                            case "Segunda Clase":
                                {
                                    if (registrarB.AgregarPasagero(Asiento, pasajero) == 0)
                                    {
                                        this.Alert("Registro Exitoso", FAlert.enmType.Success);
                                        mensaje = registrarB.stringBuilder.ToString();
                                        MessageBox.Show(mensaje, "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    else if (registrarB.AgregarPasagero(Asiento, pasajero) == 1)
                                    {
                                        this.Alert("Error:Asiento no disponible", FAlert.enmType.error);
                                        mensaje = registrarB.stringBuilder.ToString();
                                        MessageBox.Show(mensaje, "Lo sentimos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        break;
                                    }
                                    else if (registrarB.AgregarPasagero(Asiento, pasajero) == 2)
                                    {
                                        this.Alert("Error: Clase Llena", FAlert.enmType.error);
                                        mensaje = registrarB.stringBuilder.ToString();
                                        MessageBox.Show(mensaje, "Lo sentimos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        break;
                                    }
                                    else if (registrarB.AgregarPasagero(Asiento, pasajero) == 3)
                                    {
                                        this.Alert("Error: Ya existe reserva", FAlert.enmType.error);
                                        mensaje = registrarB.stringBuilder.ToString();
                                        MessageBox.Show(mensaje, "Lo sentimos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        break;
                                    }
                                    break;
                                }
                            case "Tercera Clase":
                                {
                                    if (registrarC.AgregarPasagero(Asiento, pasajero) == 0)
                                    {
                                        this.Alert("Registro Exitoso", FAlert.enmType.Success);
                                        mensaje = registrarC.stringBuilder.ToString();
                                        MessageBox.Show(mensaje, "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    else if (registrarC.AgregarPasagero(Asiento, pasajero) == 1)
                                    {
                                        this.Alert("Error:Asiento no disponible", FAlert.enmType.error);
                                        mensaje = registrarC.stringBuilder.ToString();
                                        MessageBox.Show(mensaje, "Lo sentimos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        break;
                                    }
                                    else if (registrarC.AgregarPasagero(Asiento, pasajero) == 2)
                                    {
                                        this.Alert("Error: Clase Llena", FAlert.enmType.error);
                                        mensaje = registrarC.stringBuilder.ToString();
                                        MessageBox.Show(mensaje, "Lo sentimos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        break;
                                    }
                                    else if (registrarC.AgregarPasagero(Asiento, pasajero) == 3)
                                    {
                                        this.Alert("Error: Ya existe reserva", FAlert.enmType.error);
                                        mensaje = registrarC.stringBuilder.ToString();
                                        MessageBox.Show(mensaje, "Lo sentimos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        break;
                                    }
                                    break;
                                }

                        }
                        break;
                    }
                case 1:
                    {
                        DesactivarErr();
                        errorProvider1.SetError(panelNCT, "Debe ingresar su nombre");                        
                        break;
                    }
                case 2:
                    {
                        DesactivarErr();
                        errorProvider1.SetError(panelCed, "Debe ingresar su cedula");
                        break;
                    }
                case 3:
                    {
                        DesactivarErr();
                        errorProvider1.SetError(panelTel, "Debe ingresar un teléfono");
                        break;

                    }
                case 4:
                    {
                        DesactivarErr();
                        errorProvider1.SetError(panelNCT, "Introdujo un caracter invalido en su nombre");
                    }
                    break;
                case 5:
                    {
                        DesactivarErr();
                        errorProvider1.SetError(panelCed, "Introdujo un caracter invalido");
                    }
                    break;
                case 6:
                    {
                        DesactivarErr();
                        errorProvider1.SetError(panelTel, "Introdujo un caracter invalido");
                    }
                    break;
                case 7:
                    {
                        DesactivarErr();
                        errorProvider1.SetError(panelCA, "Debe seleccionar una clase");
                    }
                    break;
                case 8:
                    {
                        DesactivarErr();
                        errorProvider1.SetError(panelAsi, "Debe seleccionar un asiento");
                    }
                    break;
            }
        }
    }
}
