﻿using System;
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
    /// Interaction logic for EditContactWindow.xaml
    /// </summary>
    public partial class EditContactWindow : Window
    {
        public Contact NewContact { get; set; }

        public EditContactWindow(Contact existingContact)
        {
            InitializeComponent();
            NewContact = new Contact
            {
                FirstName = existingContact.FirstName,
                LastName = existingContact.LastName,
                PhoneNumber = existingContact.PhoneNumber,
                Email = existingContact.Email
            };

            DataContext = NewContact;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}