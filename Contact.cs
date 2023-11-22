using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfApp4Contact
{
    public class Contact : INotifyPropertyChanged, IDataErrorInfo
    {
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string email;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(PhoneNumber):
                        if (!IsValidPhoneNumber(PhoneNumber))
                            return "Неверный формат номера телефона";
                        break;
                    case nameof(Email):
                        if (!IsValidEmail(Email))
                            return "Неверный формат электронной почты";
                        break;
                    case nameof(FirstName):
                        if (string.IsNullOrWhiteSpace(FirstName))
                            return "Имя не может быть пустым";
                        break;
                    case nameof(LastName):
                        if (string.IsNullOrWhiteSpace(LastName))
                            return "Фамилия не может быть пустой";
                        break;
                }

                return null;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length >= 12;
        }

        private bool IsValidEmail(string email)
        {

            return !string.IsNullOrEmpty(email) && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

