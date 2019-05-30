using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            //activo la espera
            waitActivityIndicator.IsRunning = true;
            //bloqueo el boton
            loginButton.IsEnabled = false;
            HttpClient client = new HttpClient();
            //direccion base raiz
            client.BaseAddress = new Uri("http://service.twk.cl");

            // método asincrono await espera la respuesta
            string jsonData = "{'nombre' :'" + nombre + "', 'pass' :'" + pass + "' }";

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/alumno/201033292", content);

            //leer la respuesta como strin y devuelva el resultado
            string result = await response.Content.ReadAsStringAsync();

            loginButton.IsEnabled = true;
            waitActivityIndicator.IsRunning = true;

            //se valida el resultado 
            if (string.IsNullOrEmpty(result) || result == "null")
            {
                await DisplayAlert("Error", "Usuario o Clave erronea", "Aceptar");
                userEntry.Text = string.Empty;
                passEntry.Text = string.Empty;
                userEntry.Focus();
                return;
            }
        }
    }
}