using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Actividad1_P2_CRUD.Data;
using System.IO;

namespace Actividad1_P2_CRUD
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDet { get; set; }
        static SQLiteHelper db;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new Login());
        }

        public static SQLiteHelper SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Empresa.db3"));
                }
                return db;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
