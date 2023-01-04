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
    public partial class Edit : ContentPage
    {
        public ObservableCollection<Contact> contacts = App.ContactRepository.Contacts;
        private Contact thisContact = null;

        public Edit(Contact contact)
        {
            InitializeComponent();
            thisContact = contact;
            name.Text = contact.Name;
            firstName.Text = contact.Firtsname;
            phone.Text = contact.Phone;
            email.Text = contact.Email;
            comment.Text = contact.Comment;
        }

        private async void editContactButton_Clicked(object sender, EventArgs e)
        {
            thisContact.Name = name.Text;
            thisContact.Firtsname= firstName.Text;
            thisContact.Phone = phone.Text;
            thisContact.Email = email.Text;
            thisContact.Comment = comment.Text;
            await App.ContactRepository.EditContactAsync(thisContact);
            App.ContactRepository.ResetContactList();
            await Navigation.PopToRootAsync();
        }

        private async void deleteContactButton_Clicked(object sender, EventArgs e)
        {
            await App.ContactRepository.DeleteContactAsync(thisContact);
            App.ContactRepository.ResetContactList();
            await Navigation.PopToRootAsync();
        }
    }
}