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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btn_Login_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                await DisplayAlert("AVISO", "Debe ingresar el email", "OK");
                return;
            }
            if (string.IsNullOrEmpty(txtPasswordLog.Text)){
                await DisplayAlert("AVISO", "La contraseña no puede ir vacia", "OK");
                return;
            }
            
            var resultado = await App.SQLiteDB.GetUsersValidate(txtEmail.Text, txtPasswordLog.Text);

            if (resultado.Count > 0)
            {
                txtEmail.Text = "";
                txtPasswordLog.Text = "";

                await Navigation.PushAsync(new MenuLateral());
            }
            else
            {
                txtEmail.Text = "";
                txtPasswordLog.Text = "";
                await DisplayAlert("AVISO", "El email o contraseña son incorrectos", "OK");
                return;
            }
        }

        private async void btn_registro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
    }
}