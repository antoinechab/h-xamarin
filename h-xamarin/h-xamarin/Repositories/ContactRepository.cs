using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using h_xamarin.Models;
using SQLite;

namespace h_xamarin.Repositories
{
    public class ContactRepository
    {
        private SQLiteAsyncConnection connection;
        public string StatusMessage { get; set; }

        public ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();
        public ObservableCollection<Contact> Contacts { get { return contacts; } }
        public ContactRepository(string dbPath)
        {
            connection= new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<Contact>();
        }

        public async Task AddNewContactAsync(string name, string firstName, string phone, string email, string comment)
        {
            int result = 0;

            try
            {
                result = await connection.InsertAsync(new Contact { Name = name, Firtsname = firstName, Phone = phone, Email = email, Comment = comment });
                StatusMessage = $"{result} contact ajouté";
            }
            catch(Exception ex)
            {
                StatusMessage = $"impossible d'ajouter le contact. \n Erreur: {ex.Message}";
            }
        }

        public async Task EditContactAsync(Contact contact)
        {
            int result = 0;

            try
            {
                result = await connection.UpdateAsync(contact);
                StatusMessage = $"{result} contact modifié";
            }
            catch (Exception ex)
            {
                StatusMessage = $"impossible de modifier le contact. \n Erreur: {ex.Message}";
            }

        }

        public async Task DeleteContactAsync(Contact contact)
        {
            int result = 0;

            try
            {
                result = await connection.DeleteAsync(contact);
                StatusMessage = $"{result} contact supprimé";
            }
            catch (Exception ex)
            {
                StatusMessage = $"impossible de supprimer le contact. \n Erreur: {ex.Message}";
            }
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            try
            {
                return await connection.Table<Contact>().ToListAsync();
            }
            catch(Exception ex)
            {
                StatusMessage = $"impossible de récupérer la liste des contacts. \n Erreur: {ex.Message}";
            }

            return new List<Contact>();
        }

        public async void ResetContactList()
        {
            Contacts.Clear();
            List<Contact> contactsList = await GetContactsAsync();

            foreach (Contact contact in contactsList)
            {
                contacts.Add(new Contact { DisplayName = $"{contact.Name} {contact.Firtsname}" });
            }
        }
    }
}
