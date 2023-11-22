using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp4Contact
{
    /// <summary>
    /// Interaction logic for AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        public Contact NewContact { get; set; }
        public AddContactWindow()
        {
            InitializeComponent();
            NewContact = new Contact();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            NewContact.FirstName = firstNameTextBox.Text;
            NewContact.LastName = lastNameTextBox.Text;
            NewContact.PhoneNumber = phoneTextBox.Text;
            NewContact.Email = emailTextBox.Text;

            DialogResult = true;
        }
    }
}
