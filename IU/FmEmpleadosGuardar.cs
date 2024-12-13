using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Security;
namespace Integrador_2
{
    public partial class FmEmpleadosGuardar : Form
    {
        BEEmpleado Usu;
        BLLEmpleado bLLEmpleado;
        BEDomicilio bEDomicilio;
        BEPerfil bEPerfil;
        BEEmpleado bEEmpleado;
        BLLPerfil bllPerfil;
        public FmEmpleadosGuardar()
        {
            InitializeComponent();
            bEEmpleado = new BEEmpleado();
            Usu = new BEEmpleado();
            bLLEmpleado = new BLLEmpleado();
            bEPerfil = new BEPerfil();
            bEDomicilio = new BEDomicilio();
            bllPerfil = new BLLPerfil();
        }
        public FmEmpleadosGuardar(BEEmpleado Usuario ,BEEmpleado obEEmpleado = null )
        {
            InitializeComponent();
            bEEmpleado = new BEEmpleado();
            Usu = new BEEmpleado();
            bLLEmpleado = new BLLEmpleado();
            bEDomicilio = new BEDomicilio();
            bEPerfil = new BEPerfil();
            Usu = Usuario;
            if(obEEmpleado != null)
            {
                bEEmpleado = obEEmpleado;
            }           
        }

        private void FmEmpleadosGuardar_Load(object sender, EventArgs e)
        {
            Limpiar();
            cargarDatos();       
            if(bEEmpleado.Id != 0)
            {
                bEEmpleado = bLLEmpleado.ListarUno(bEEmpleado);
                Asignar();
            }        
        }
        private void btn_GuardarEmp_Click(object sender, EventArgs e)
        {
            try
            {
                if (CapturarDatos())
                {
                    if (bLLEmpleado.Guardar(bEEmpleado, Usu))
                    {
                        MessageBox.Show("Se guardo con exito");
                        FmEmpleado fmEmpleado = new FmEmpleado(Usu);
                        fmEmpleado.Show();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Error al guardar");
                    }
                   
                }       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Limpiar()
        {
            txt_NombreEmp.Text = null;
            txt_ApellidoEmp.Text= null;
            soloDNI1.Text = null;
            txt_PassEmp.Text = null;
            dateTimePicker1.Value = DateTime.Today;
            txtSoloNum2.Text = null;
            txt_CalleEmp.Text = null;
        }
        void cargarDatos()
        {
            BLLPerfil p = new BLLPerfil();
            try
            {
                List<BEPerfil> listaPerfiles = p.buscarPerfiles();
                if (listaPerfiles.Count > 0)
                {
                    cb_CargoEmp.Items.Clear();
                    foreach (BEPerfil perfil in listaPerfiles)
                    {
                        KeyValuePair<int, string> item = new KeyValuePair<int, string>(perfil.Id, perfil.Tipo);
                        cb_CargoEmp.Items.Add(item);
                    }
                    cb_CargoEmp.DisplayMember = "Value";
                    cb_CargoEmp.ValueMember = "Key";
                    cb_CargoEmp.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void Asignar()
        {
            try
            {
                txt_NombreEmp.Text = bEEmpleado.Nombre;
                txt_ApellidoEmp.Text = bEEmpleado.Apellido;
                soloDNI1.Text = bEEmpleado.DNI.ToString();
                txt_PassEmp.Text = bEEmpleado.Pass;
                cb_CargoEmp.Text = bEEmpleado.Perfil.Tipo;
                dateTimePicker1.Value = bEEmpleado.FechaNac;
                txtSoloNum2.Text = bEEmpleado.oDom.Numero.ToString();
                txt_CalleEmp.Text = bEEmpleado.oDom.Calle;
                txtLocalidad.Text = bEEmpleado.oDom.Localidad;
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
        bool CapturarDatos()
        {
            bool res = false;
            try
            {
                if (soloDNI1.Validar() && txtSoloNum2.Validar())
                {
                
                    bEEmpleado.FechaNac = dateTimePicker1.Value;
                    bEEmpleado.Edad = bEEmpleado.Calcular_Edad(bEEmpleado.FechaNac);
                    if(bEEmpleado.Edad >= 18)
                    {
                        bEEmpleado.Nombre = txt_NombreEmp.Text;
                        bEEmpleado.Apellido = txt_ApellidoEmp.Text;
                        bEEmpleado.DNI = Convert.ToInt32(soloDNI1.Text);
                        bEEmpleado.Pass = txt_PassEmp.Text;
                        KeyValuePair<int, string> perfilSeleccionado = (KeyValuePair<int, string>)cb_CargoEmp.SelectedItem;
                        bEPerfil.Id = perfilSeleccionado.Key;
                        bEPerfil.Tipo = perfilSeleccionado.Value;
                        bEEmpleado.Perfil = bEPerfil;

                        bEDomicilio.Numero = Convert.ToInt32(txtSoloNum2.Text);
                        bEDomicilio.Calle = txt_CalleEmp.Text;
                        bEDomicilio.Localidad = txtLocalidad.Text;

                        if (bEEmpleado.Id != 0)
                        {

                            bEEmpleado.oDom.Calle = bEDomicilio.Calle;
                            bEEmpleado.oDom.Numero = bEDomicilio.Numero;
                            bEEmpleado.oDom.Localidad = bEDomicilio.Localidad;
                        }
                        else
                        {

                            bEEmpleado.oDom = bEDomicilio;
                        }
                        res = true;
                    }      
                }
                else
                {
                    res = false;
                    MessageBox.Show("Error en los campos");
                }
                

            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message);
            }
            return res;

        }

        private void btn_SalirEmp_Click(object sender, EventArgs e)
        {
            FmEmpleado fmEmpleado = new FmEmpleado(Usu);
            fmEmpleado.Show();
            this.Hide();
        }

    }
}
