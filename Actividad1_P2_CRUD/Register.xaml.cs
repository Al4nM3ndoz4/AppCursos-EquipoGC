using Actividad1_P2_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Actividad1_P2_CRUD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void btn_Registro_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                await DisplayAlert("AVISO", "Favor de ingresar su nombre", "OK");
                return;
            }
            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                await DisplayAlert("AVISO", "Favor de ingresar un correo valido", "OK");
                return;
            }
            if (string.IsNullOrEmpty(txtEdad.Text))
            {
                await DisplayAlert("AVISO", "Favor de ingresar su edad", "OK");
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                await DisplayAlert("AVISO", "Favor de ingresar su contraseña", "OK");
                return;
            }

            Users users = new Users()
            {
                NombreCompleto = txtNombre.Text, 
                Email = txtCorreo.Text, 
                Edad = int.Parse(txtEdad.Text), 
                Emailpassword = txtPassword.Text, 
                FechaCreacion = DateTime.Now
            };

            await App.SQLiteDB.SaveUserModelAsync(users);

            await DisplayAlert("AVISO", "Tu registro fue exitoso", "OK");


            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtEdad.Text = "";
            txtPassword.Text = "";

            await Navigation.PopAsync();
        }
    }
}