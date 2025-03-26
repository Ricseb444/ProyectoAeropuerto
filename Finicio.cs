using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DEL;
using BLL;
using System.Diagnostics;

namespace ProyectoAeropuerto
{
    public partial class INICIO : Form
    {
        //Objeto que invoca a MetodoAsientos A-B-C
        //para usar todos sus métodos en esta ventana
        readonly MetodoAsientosA callerA = new MetodoAsientosA();
        readonly MetodoAsientosB callerB = new MetodoAsientosB();
        readonly MetodoAsientosC callerC = new MetodoAsientosC();
        public INICIO()
        {
            InitializeComponent();
        }

        private void reservar_Click(object sender, EventArgs e)
        {            
            Registro ventanaRegis = new Registro();
            ventanaRegis.ShowDialog();
            //hace la consulta de los asientos libres
            //para que el panel con los asientos libres
            //se mantenga con la información actualizada
            Consult();
        }

        private void INICIO_Load(object sender, EventArgs e)
        {
            //Rellena el arraylist de cada uno de los métodos
            //Asientos con null (esto evita errores en la lista)
            ImportarLista();            
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            Buscarf ventanaCancel = new Buscarf();
            //Envía información sobre el botón que se 
            //presionó para acceder al FORMS Buscarf
            //pues esta cumple 2 funciones (Buscar/Cancelar)
            ventanaCancel.BotonPresionado = "Cancelar";
            ventanaCancel.ShowDialog();
            //hace la consulta de los asientos libres
            //para que el panel con los asientos libres
            //se mantenga con la información actualizada
            Consult();
        }

        private void asNombres_Click(object sender, EventArgs e)
        {
            Buscarf ventanaBuscar = new Buscarf();
            //Envía información sobre el botón que se 
            //presionó para acceder al FORMS Buscarf
            //pues esta cumple 2 funciones (Buscar/Cancelar)
            ventanaBuscar.BotonPresionado = "Buscar";
            ventanaBuscar.ShowDialog();
        }
        /*===========Invocador del Metodo consultar asientos libres============*/
        private void Consult()
        {
            //trae los asientos libres desde los 3 MetodoAsientos
            ImportarLista();
            AC1.Text = $"{callerA.ConsultarAsLibres()}";
            AC2.Text = $"{callerB.ConsultarAsLibres()}";
            AC3.Text = $"{callerC.ConsultarAsLibres()}";
        }
        private void asLibres_Click(object sender, EventArgs e)
        {
            //Al hacer clic en el botón asLibres este Consulta 
            //la info de los asientos libres y despues muestra
            //el panel.También si este es vuelto a presionar 
            //oculta el panel.
            Consult();
            asLibresPan.Visible = !asLibresPan.Visible;
            panelInfo.Visible = false;
            panelPrincipal.Visible = true;
        }
        
        /*=====================================================================*/
        private void ImportarLista()
        {
            List<Pasajero> listaPasajerosA = callerA.ListarPasajeros();
            dataGridView1.DataSource = listaPasajerosA;
            List<Pasajero> listaPasajerosB = callerB.ListarPasajeros();
            dataGridView2.DataSource = listaPasajerosB;
            List<Pasajero> listaPasajerosC = callerC.ListarPasajeros();
            dataGridView3.DataSource = listaPasajerosC;
        }

        /*==================Método para controlar el slidebar==================*/
        bool slidebarExpand;        
        private void slidebarTimer_Tick(object sender, EventArgs e)
        {
            if (slidebarExpand)
            {
                //Entre mayor sea el numero, más rapido se cerrará
                slidebar.Width -= 50;
                if (slidebar.Width == slidebar.MinimumSize.Width)
                {
                    slidebarExpand = false;
                    slidebarTimer.Stop();
                }                
            }
            else
            {
                //Entre mayor sea el numero, más rapido se abrirá
                slidebar.Width += 10;
                if (slidebar.Width == slidebar.MaximumSize.Width)
                {
                    slidebarExpand = true;
                    slidebarTimer.Stop();
                }
            }
            slidebar.Refresh();
        }
        
        private void Menubtn_Click(object sender, EventArgs e)
        {
            slidebarTimer.Start();
        }
        /*====================================================================*/
        private void apagar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /*========================Eventos Hover y Leave=======================*/
                            //Hover = pasar el mouse por encima
                            //Leave = quitar el mouse de encima
                    //los eventos mouse Hover/Leave son para cambiar el
                    //color del contenido de los botones pues al pasar
                    //el mouse por encima de estos el boton se resalta 
                    //en color blanco provocando que sea imposible de 
                    //leer el contenido de estos. Por lo que al pasar 
                    //el mouse por encima su contenido cambia de color 
                    //a negro y al quitar el mouse se activa el método 
                    //mouse leave que hace que vuelvan a ser de color
                    //blanco.
        private void Menubtn_MouseHover(object sender, EventArgs e)
        {
            Menubtn.Image = Properties.Resources.Menu_2;
        }

        private void Menubtn_MouseLeave(object sender, EventArgs e)
        {
            Menubtn.Image = Properties.Resources.Menu_1;
        }

        private void asNombres_MouseHover(object sender, EventArgs e)
        {
            asNombres.Image = Properties.Resources.Search_2;
            asNombres.ForeColor = System.Drawing.Color.Black;
        }

        private void asNombres_MouseLeave(object sender, EventArgs e)
        {
            asNombres.Image = Properties.Resources.Search_1;
            asNombres.ForeColor = System.Drawing.Color.White;
        }

        private void reservar_MouseHover(object sender, EventArgs e)
        {
            reservar.Image = Properties.Resources.Add_2;
            reservar.ForeColor = System.Drawing.Color.Black;
        }

        private void reservar_MouseLeave(object sender, EventArgs e)
        {
            reservar.Image = Properties.Resources.Add_1;
            reservar.ForeColor = System.Drawing.Color.White;
        }

        private void cancelar_MouseHover(object sender, EventArgs e)
        {
            cancelar.Image = Properties.Resources.Cancel_2;
            cancelar.ForeColor = System.Drawing.Color.Black;
        }

        private void cancelar_MouseLeave(object sender, EventArgs e)
        {
            cancelar.Image = Properties.Resources.Cancel_1;
            cancelar.ForeColor = System.Drawing.Color.White;
        }

        private void asLibres_MouseHover(object sender, EventArgs e)
        {
            asLibres.Image = Properties.Resources.Ok_2;
            asLibres.ForeColor = System.Drawing.Color.Black;
        }

        private void asLibres_MouseLeave(object sender, EventArgs e)
        {
            asLibres.Image = Properties.Resources.Ok_1;
            asLibres.ForeColor = System.Drawing.Color.White;
        }

        private void apagar_MouseHover(object sender, EventArgs e)
        {
            apagar.Image = Properties.Resources.Power_Off_Button_2;
            apagar.ForeColor = System.Drawing.Color.Black;
        }

        private void apagar_MouseLeave(object sender, EventArgs e)
        {
            apagar.Image = Properties.Resources.Power_Off_Button_1;
            apagar.ForeColor = System.Drawing.Color.White;
        }
        /*====================================================================*/

        /*================Botón para mostrar info del Dev=====================*/
        private void btnInfo_Click(object sender, EventArgs e)
        {
            //Oculta o muestra el panel pricipal si el botón se vuelve a presionar
            panelPrincipal.Visible = !panelPrincipal.Visible;
            //Intercambia sobre cual panel se muestra (info/principal)
            //Cerrando uno y abriendo el otro 
            panelInfo.Visible = !panelInfo.Visible;
            //Oculta el panel de asientos libres por si esta abierto
            asLibresPan.Visible = false;
        }
        /*====================================================================*/

        /*==================Cerrar panel informacion=========================*/        
        private void Closei_Click(object sender, EventArgs e)
        {
            //Cerrar panel informacion 
            //Vuelve a abrir el panel principal
            //pues hay que recordar que este se
            //cierra al abrir el panel info
            panelPrincipal.Visible = true; 
            panelInfo.Visible = false; 
        }
        /*====================================================================*/

        /*===============Cerrar panel asientos libres=========================*/
        private void Closea_Click(object sender, EventArgs e)
        {
            //Cerrar panel asientos libres
            asLibresPan.Visible = false; 
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirPaginaWeb("https://campus.uam.ac.cr");
        }
        /*====================================================================*/
        private void AbrirPaginaWeb(string url)
        {
            try
            {
                // Utiliza Process.Start para abrir la URL en el navegador predeterminado del sistema
                Process.Start(url);
            }
            catch (Exception ex)
            {
                // Manejo de errores si la apertura de la página web falla
                MessageBox.Show($"Error al abrir la página web: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AbrirPaginaWeb("https://www.instagram.com");
        }
    }
}
