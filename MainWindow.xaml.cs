using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4Contact
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Contact> Contacts { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Contacts = new ObservableCollection<Contact>
            {
                new Contact { FirstName = "Мария", LastName = "Дмитрук", PhoneNumber = "+38097777777", Email = "dmitruk@ukr.net" },
                new Contact { FirstName = "Петро", LastName = "Миньков", PhoneNumber = "+38098888888", Email = "minkov@ukr.net" },
                 new Contact { FirstName = "Михаил", LastName = "Бойко", PhoneNumber = "+38099999999", Email = "bmror@ukr.net" },
                new Contact { FirstName = "Дарья", LastName = "Кравчук", PhoneNumber = "+38096666666", Email = "krava@ukr.net" }
            };

            contactListView.ItemsSource = Contacts;
        }

        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            AddContactWindow addContactWindow = new AddContactWindow();
            if (addContactWindow.ShowDialog() == true)
            {
                Contacts.Add(addContactWindow.NewContact);
            }
        }

        private void EditContactButton_Click(object sender, RoutedEventArgs e)
        {
            if (contactListView.SelectedItem is Contact selectedContact)
            {
                EditContactWindow editContactWindow = new EditContactWindow(selectedContact);
                if (editContactWindow.ShowDialog() == true)
                {
                    // Обновление контакта после редактирования
                    selectedContact.FirstName = editContactWindow.NewContact.FirstName;
                    selectedContact.LastName = editContactWindow.NewContact.LastName;
                    selectedContact.PhoneNumber = editContactWindow.NewContact.PhoneNumber;
                    selectedContact.Email = editContactWindow.NewContact.Email;
                }
            }
        }

        private void DeleteContactButton_Click(object sender, RoutedEventArgs e)
        {
            if (contactListView.SelectedItem is Contact selectedContact)
            {
                Contacts.Remove(selectedContact);
            }
        }
        private void ContactsListBox_SelectedItemChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (contactListView.SelectedItem is Contact selectedContact)
            {
                // Вызываем окно редактирования контакта
                var editContactWindow = new EditContactWindow(selectedContact);
                if (editContactWindow.ShowDialog() == true)
                {
                    // Обновляем информацию о контакте
                    selectedContact.FirstName = editContactWindow.NewContact.FirstName;
                    selectedContact.LastName = editContactWindow.NewContact.LastName;
                    selectedContact.PhoneNumber = editContactWindow.NewContact.PhoneNumber;
                    selectedContact.Email = editContactWindow.NewContact.Email;
                }
            }
        }
    }
}

