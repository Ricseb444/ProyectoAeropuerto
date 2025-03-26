using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DEL;
using BLL;

namespace ProyectoAeropuerto
{
    public partial class Buscarf : Form
    {
        private static readonly MetodoAsientosA manejadorA = new MetodoAsientosA();
        private static readonly MetodoAsientosB manejadorB = new MetodoAsientosB();
        private static readonly MetodoAsientosC manejadorC = new MetodoAsientosC();

        public class PasajeroPanel : Panel
        {
            private readonly Button btnCancelarReserva;
            private readonly Buscarf FBuscar;
            private string Nom { get; set; }
            private int Num { get; set; }
            private string Clase { get; set; }
            //private Pasajero pasajeroborrar { get; set; }

            public PasajeroPanel(Buscarf Fuscar, string informacion, string nomP, int numA, string clas)
            {
                FBuscar = Fuscar;
                Nom = nomP;
                Num = numA;
                Clase = clas;
                RichTextBox labelInformacion = new RichTextBox();
                ToolTip toolTip = new ToolTip();

                labelInformacion.Text = informacion;
                labelInformacion.SelectionStart = 0;
                labelInformacion.SelectionLength = informacion.IndexOf("\n") + 1;
                labelInformacion.SelectionFont = new Font("Segoe UI", 12f, FontStyle.Bold);
                labelInformacion.SelectionColor = Color.Black;
                labelInformacion.SelectionIndent = 30;

                labelInformacion.SelectionStart = informacion.IndexOf("\n") + 1;
                labelInformacion.SelectionLength = informacion.Length - (informacion.IndexOf("\n") + 1);
                labelInformacion.SelectionFont = new Font("Segoe UI", 9f, FontStyle.Regular);
                labelInformacion.SelectionColor = Color.Black;
                labelInformacion.SelectionIndent = 80;
                labelInformacion.SelectionStart = 0;
                labelInformacion.SelectionLength = 0;

                labelInformacion.ReadOnly = true;
                labelInformacion.Size = new Size(250, 120);
                labelInformacion.BackColor = Color.LightGray;

                BackColor = Color.SteelBlue;
                this.Size = new Size(295, 145);

                labelInformacion.Location = new Point((this.Width - labelInformacion.Width) / 2, (this.Height - labelInformacion.Height) / 2);

                btnCancelarReserva = new Button();
                btnCancelarReserva.TextAlign = ContentAlignment.MiddleLeft;
                btnCancelarReserva.Size = new Size(23, 23);
                btnCancelarReserva.FlatStyle = FlatStyle.Flat;
                btnCancelarReserva.FlatAppearance.BorderSize = 0;
                btnCancelarReserva.BackColor = Color.Transparent;
                btnCancelarReserva.ForeColor = Color.White;
                btnCancelarReserva.Click += BtnCancelarReserva_Click;
                btnCancelarReserva.Font = new Font("Arial", 7f, FontStyle.Bold);
                btnCancelarReserva.Cursor = Cursors.Hand;
                btnCancelarReserva.Location = new Point(this.Width - btnCancelarReserva.Width - 0, this.Height - btnCancelarReserva.Height - 122);

                Image image = Properties.Resources.Delete;
                btnCancelarReserva.BackgroundImage = image;
                btnCancelarReserva.BackgroundImageLayout = ImageLayout.Zoom;
                btnCancelarReserva.Padding = new Padding(5, 0, 0, 0);
                toolTip.SetToolTip(btnCancelarReserva, "Cancelar esta reserva");

                Controls.Add(btnCancelarReserva);
                Controls.Add(labelInformacion);
            }

            public void Alert(string msg, FAlert.enmType type)
            {
                FAlert frm = new FAlert();
                frm.showAlert(msg, type);
            }
            
            private void BtnCancelarReserva_Click(object sender, EventArgs e)
            {                
                Alert("¿Está seguro?", FAlert.enmType.Warning);                
                DialogResult respuesta = MessageBox.Show($"¿Está seguro de que desea cancelar la reserva a nombre de {Nom} asiento numero {Num}?",
                "Cancelar reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);                
                if (respuesta == DialogResult.Yes)
                {
                    MessageBox.Show($"La reserva del asiento numero {Num} fue cancelada");
                    manejadorA.CancelarReserva(Nom, Num, Clase);
                    manejadorB.CancelarReserva(Nom, Num, Clase);
                    manejadorC.CancelarReserva(Nom, Num, Clase);
                }                            
                FBuscar.RealizarBusqueda();
            }
            public void DesactivarBotonCancelarReserva()
            {
                btnCancelarReserva.Visible = false;
            }
        }
        
        private string ObtenerInfoPasajero(Pasajero pasajero)
        {
            StringBuilder output = new StringBuilder("Información del pasajero:\n\n");
            output.Append("Nombre: ").AppendLine(pasajero.Nombre)
            .Append("Cedula: ").AppendLine($"{pasajero.Cedula}")
            .Append("Telefono: ").AppendLine(pasajero.Telefono)
            .Append("Asiento: ").AppendLine($"{pasajero.Asiento}")
            .Append("Clase: ").Append(pasajero.Clase);
            return output.ToString();
        }

        public Buscarf()
        {
            InitializeComponent();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string botonPresionado;

        public string BotonPresionado
        {
            get { return botonPresionado; }
            set { botonPresionado = value; }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RealizarBusqueda();
        }

        private void RealizarBusqueda()
        {
            flowLayoutPanel1.Controls.Clear();
            List<Pasajero> pasajerosEncontradosA = manejadorA.BuscarXNom(NombreBuscado.Text);

            if (pasajerosEncontradosA.Count > 0)
            {
                foreach (Pasajero pasajero in pasajerosEncontradosA)
                {
                    PasajeroPanel panelPasajero = new PasajeroPanel(this, ObtenerInfoPasajero(pasajero), pasajero.Nombre, pasajero.Asiento, pasajero.Clase)
                    {
                        BackColor = Color.FromArgb(63, 107, 145)

                    };
                    if (BotonPresionado == "Buscar")
                    {
                        panelPasajero.DesactivarBotonCancelarReserva();
                    }
                    flowLayoutPanel1.Controls.Add(panelPasajero);
                }
            }
            else
            {
                PasajeroPanel panelPasajero = new PasajeroPanel(this, "No hay coincidencias\n\nNo se encontraron reservaciones con\nese nombre en la\nPrimera Clase.", "", 0, "")
                {
                    BackColor = Color.FromArgb(63, 107, 145)
                };
                flowLayoutPanel1.Controls.Add(panelPasajero);

                panelPasajero.DesactivarBotonCancelarReserva();

            }

            List<Pasajero> pasajerosEncontradosB = manejadorB.BuscarXNom(NombreBuscado.Text);

            if (pasajerosEncontradosB.Count > 0)
            {
                foreach (Pasajero pasajero in pasajerosEncontradosB)
                {
                    PasajeroPanel panelPasajero = new PasajeroPanel(this, ObtenerInfoPasajero(pasajero), pasajero.Nombre, pasajero.Asiento, pasajero.Clase)
                    {
                        BackColor = Color.FromArgb(145, 63, 107)
                    };
                    if (BotonPresionado == "Buscar")
                    {
                        panelPasajero.DesactivarBotonCancelarReserva();
                    }
                    flowLayoutPanel1.Controls.Add(panelPasajero);
                }
            }
            else
            {
                PasajeroPanel panelPasajero = new PasajeroPanel(this, "No hay coincidencias\n\nNo se encontraron reservaciones con\nese nombre en la\nSegunda Clase.", "", 0, "")
                {
                    BackColor = Color.FromArgb(145, 63, 107)
                };
                flowLayoutPanel1.Controls.Add(panelPasajero);

                panelPasajero.DesactivarBotonCancelarReserva();

            }

            List<Pasajero> pasajerosEncontradosC = manejadorC.BuscarXNom(NombreBuscado.Text);

            if (pasajerosEncontradosC.Count > 0)
            {
                foreach (Pasajero pasajero in pasajerosEncontradosC)
                {
                    PasajeroPanel panelPasajero = new PasajeroPanel(this, ObtenerInfoPasajero(pasajero), pasajero.Nombre, pasajero.Asiento, pasajero.Clase)
                    {
                        BackColor = Color.FromArgb(107, 145, 63)
                    };
                    if (BotonPresionado == "Buscar")
                    {
                        panelPasajero.DesactivarBotonCancelarReserva();
                        panelCancel.BackColor = Color.FromArgb(27, 28, 49);
                    }
                    flowLayoutPanel1.Controls.Add(panelPasajero);
                }
            }
            else
            {
                PasajeroPanel panelPasajero = new PasajeroPanel(this, "No hay coincidencias\n\nNo se encontraron reservaciones con\nese nombre en la\nTercera Clase.", "", 0, "")
                {
                    BackColor = Color.FromArgb(107, 145, 63)
                };
                flowLayoutPanel1.Controls.Add(panelPasajero);

                panelPasajero.DesactivarBotonCancelarReserva();

            }
        }

        private void btnBuscar_MouseHover(object sender, EventArgs e)
        {
            btnBuscar.BackgroundImage = Properties.Resources.Search2;
        }

        private void btnBuscar_MouseLeave(object sender, EventArgs e)
        {
            btnBuscar.BackgroundImage = Properties.Resources.Search1;
        }

        private void btnVolver_MouseHover(object sender, EventArgs e)
        {
            btnVolver.BackgroundImage = Properties.Resources.Home2;
        }

        private void btnVolver_MouseLeave(object sender, EventArgs e)
        {
            btnVolver.BackgroundImage = Properties.Resources.Home1;
        }

        private void Buscarf_Load(object sender, EventArgs e)
        {
            //BackCol();
            if (BotonPresionado == "Buscar")
            {
                panelCancel.BackColor = Color.FromArgb(27, 28, 49);
            }
        }
    }
}
