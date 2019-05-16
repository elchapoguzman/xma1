using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class login : ContentPage
	{
        public login()
        {
            InitializeComponent();
            loginButton.Clicked += LoginButton_Clicked;
        }

        async void LoginButton_Clicked(object sender, EventArgs e)
        {
            string nombre = userEntry.Text;
            string pass = passEntry.Text;
            if (string.IsNullOrEmpty(nombre))
            {
                await DisplayAlert("Error", "Ingrese usuario", "Aceptar");
                userEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(pass))
            {
                await DisplayAlert("Error", "Debe ingresar Password", "Aceptar");
                passEntry.Focus();
                return;
            }
        }
    }
}