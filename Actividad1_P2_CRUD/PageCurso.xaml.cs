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
    public partial class PageCurso : ContentPage
    {
        public PageCurso()
        {
            InitializeComponent();
        }

        private  async void btnAltaCurso_Clicked(object sender, EventArgs e)
        {
            if (validarDatosCurso())
            {
                Cursos curso = new Cursos
                {
                    NombreCurso = txtNombreCurso.Text,
                    Tipo = txtTipo.Text, 
                    Duracion = int.Parse(txtDuracion.Text)
                };

                await App.SQLiteDB.SaveCursosAsync(curso);
                txtNombreCurso.Text = "";
                txtTipo.Text = "";
                txtDuracion.Text = "";
                await DisplayAlert("Exito", "Curso guardado exitosamente", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "Ingrese todo los datos", "OK");
            }
        }
        public bool validarDatosCurso()
        {
            bool response;
            if (string.IsNullOrEmpty(txtNombreCurso.Text))
            {
                response = false;
            }
            else if (string.IsNullOrEmpty(txtTipo.Text))
            {
                response = false;
            }
            else if (string.IsNullOrEmpty(txtDuracion.Text))
            {
                response = false;
            }
            else
            {
                response = true;
            }

            return response;
         
        }
    }
}