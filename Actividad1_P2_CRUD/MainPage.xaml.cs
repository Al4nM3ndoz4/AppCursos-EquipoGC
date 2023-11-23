using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Actividad1_P2_CRUD.Models;
using System.IO;

namespace Actividad1_P2_CRUD
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            llenarDatos();
        }

        public  async void Button_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Empleado emple = new Empleado()
                {
                    Nombre = txtNombre.Text,
                    ApellidoPaterno = txtApellidoP.Text,
                    ApellidoMaterno = txtApellidoM.Text,
                    Edad = int.Parse(txtEdad.Text),
                    Telefono = int.Parse(txtTelefono.Text),
                };

                await App.SQLiteDB.SaveEmpleadosAsync(emple);

                txtNombre.Text = "";
                txtApellidoP.Text = "";
                txtApellidoM.Text = "";
                txtEdad.Text = "";
                txtTelefono.Text = "";
                tomarFoto.IsVisible = false;
                Foto.IsVisible = false;

                await DisplayAlert("AVISO ", "Guardado de forma exitosa ", "OK");
                llenarDatos();
            }
            
            else
            {
                await DisplayAlert("AVISO ", "Ingrese todos los datos ", "OK");

            }

        }

        public async void llenarDatos()
        {
            var empleadoList = await App.SQLiteDB.GetEmpleadosAsync();

            if (empleadoList != null)
            {
                lsEmpleado.ItemsSource = empleadoList;
            }
        }
        public bool validarDatos()
        {
            bool respuesta;

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtApellidoP.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtApellidoM.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async void  lsEmpleado_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Empleado)e.SelectedItem;

            btnGuardar.IsVisible = false;
            tomarFoto.IsVisible = false;
            Foto.IsVisible = true;
            txtIdEmp.IsVisible = true;
            btnActualizar.IsVisible = true;
            btnEliminar.IsVisible = true;

            if (!string.IsNullOrEmpty(obj.IdEmp.ToString())){
                var emplea = await App.SQLiteDB.GetEmpleadoByIdAsync(obj.IdEmp);

                if (emplea != null)
                {
                    txtIdEmp.Text = emplea.IdEmp.ToString();
                    txtNombre.Text = emplea.Nombre;
                    txtApellidoP.Text = emplea.ApellidoPaterno;
                    txtApellidoM.Text = emplea.ApellidoMaterno;
                    txtEdad.Text = emplea.Edad.ToString();
                    txtTelefono.Text = emplea.Telefono.ToString();
                }
            }
        }

        public async void Button_Actualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdEmp.Text))
            {
                Empleado empleado = new Empleado()
                {
                    IdEmp = int.Parse(txtIdEmp.Text),
                    Nombre = txtNombre.Text,
                    ApellidoPaterno = txtApellidoP.Text,
                    ApellidoMaterno = txtApellidoM.Text,
                    Edad = int.Parse(txtEdad.Text),
                    Telefono = int.Parse(txtTelefono.Text)

                };

                await App.SQLiteDB.SaveEmpleadosAsync(empleado);
                await DisplayAlert("¡AVISO!", "Se actualizo el registro de manera exitosa", "OK");
                txtIdEmp.Text = "";
                txtNombre.Text = "";
                txtApellidoP.Text = "";
                txtApellidoM.Text = "";
                txtEdad.Text = "";
                txtTelefono.Text = "";

                txtIdEmp.IsVisible = false;
                btnGuardar.IsVisible = true;
                btnActualizar.IsVisible = false;
                tomarFoto.IsVisible = true;
                Foto.IsVisible = true;
                btnEliminar.IsVisible = false;
                llenarDatos();
            }
            
           
        }

        public async void Button_Eliminar_Clicked(object sender, EventArgs e)
        {
            var empleado = await App.SQLiteDB.GetEmpleadoByIdAsync(int.Parse(txtIdEmp.Text));

            if (empleado != null)
            {
                await App.SQLiteDB.DeleteEmpleadoAsync(empleado);
                await DisplayAlert("¡AVISO!", "Se elimino el registro de manera exitosa", "OK");

                txtIdEmp.Text = "";
                txtNombre.Text = "";
                txtApellidoP.Text = "";
                txtApellidoM.Text = "";
                txtEdad.Text = "";
                txtTelefono.Text = "";

                txtIdEmp.IsVisible = false;
                btnGuardar.IsVisible = true;
                btnActualizar.IsVisible = false;
                Foto.IsVisible = true;
                btnEliminar.IsVisible = false;
                llenarDatos();
            }
        }

        private async void tomarFoto_Clicked(object sender, EventArgs e)
        {
            var foto = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions());

            if (foto != null)
            {
                Foto.Source = ImageSource.FromStream(() =>
                {
                    return foto.GetStream();
                });
            }
        }
    }
}
