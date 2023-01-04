using h_xamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace h_xamarin
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Contact> contacts = App.ContactRepository.Contacts;
        public MainPage()
        {
            InitializeComponent();
            loadPage();
        }

        private async void loadPage()
        {
            ContactView.ItemsSource = contacts;
            List<Contact> contactsList = await App.ContactRepository.GetContactsAsync();

            foreach (Contact contact in contactsList)
            {
                contacts.Add(new Contact { DisplayName = $"{contact.Name} {contact.Firtsname}" });
            }
        }

        private async void addContact(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Add());
        }

        private async void onContactClicked(object sender, ItemTappedEventArgs e)
        {
            List<Contact> contactsList = await App.ContactRepository.GetContactsAsync();
            var currentContact = contactsList[e.ItemIndex];

            await Navigation.PushAsync(new Edit(currentContact));
        }
    }
}
