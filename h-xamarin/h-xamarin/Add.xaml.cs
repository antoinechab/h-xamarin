using h_xamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace h_xamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : ContentPage
    {
        public ObservableCollection<Contact> contacts = App.ContactRepository.Contacts;
        public Add()
        {
            InitializeComponent();
        }

        private async void addContactButton_Clicked(object sender, EventArgs e)
        {
            await App.ContactRepository.AddNewContactAsync(name.Text, firstName.Text, phone.Text, email.Text, comment.Text);
            App.ContactRepository.ResetContactList();
            await Navigation.PopToRootAsync();
        }
    }
}