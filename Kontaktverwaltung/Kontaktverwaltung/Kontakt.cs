using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Kontaktverwaltung
{
 

    public class Address : INotifyPropertyChanged
    {
        private string _Street;
        public string Street
        {
            get { return _Street; }
            set
            {
                _Street = value;
                OnPropertyChanged("Street");
            }
        }

        private string _HouseNoumber;
        public string HouseNoumber
        {
            get { return _HouseNoumber; }
            set
            {
                _HouseNoumber = value;
                OnPropertyChanged("Housenumber");
            }
        }

        private string _PostalCode;
        public string PostalCode
        {
            get { return _PostalCode; }
            set
            {
                _PostalCode = value;
                OnPropertyChanged("PostalCode");
            }
        }

        private string _City;
        public string City
        {
            get { return _City; }
            set
            {
                _City = value;
                OnPropertyChanged("City");
            }
        }

        private string _EMail;
        public string EMail
        {
            get { return _EMail; }
            set
            {
                _EMail = value;
                OnPropertyChanged("EMail");
            }
        }

        private string _MobileNr;
        public string MobileNr
        {
            get { return _MobileNr; }
            set
            {
                _MobileNr = value;
                OnPropertyChanged("MobileNr");
            }
        }

        private string _PhoneNr;
        public string PhoneNr
        {
            get { return _PhoneNr; }
            set
            {
                _PhoneNr = value;
                OnPropertyChanged("PhoneNr");
            }
        }

        private string _FaxNr;
        public string FaxNr
        {
            get { return _FaxNr; }
            set
            {
                _FaxNr = value;
                OnPropertyChanged("FaxNr");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public enum Sex { Männlich, Weiblich, Diverse }
    public class Kontakt : INotifyPropertyChanged
    {
        private string _DisplayName;
        public string DisplayName
        {
            get { return _DisplayName; }
            set
            {
                _DisplayName = value;
                OnPropertyChanged("DisplayName");
            }
        }

        private string _Surname;
        public string Surname
        {
            get { return _Surname; }
            set
            {
                _Surname = value;
                OnPropertyChanged("SurName");
            }
        }
       
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                OnPropertyChanged("Title");
            }
        }
        
        public Kontakt()
        {
            this.Address = new Address();
            this.Address1 = new Address();
            this.Address2 = new Address();
        }
        
        private Sex _Sex; 
        public Sex Sex
        {
            get { return _Sex; }
            set
            {
                _Sex = value;
                OnPropertyChanged("Sex");
            }
        }

        public Address Address { get; set; }
        public Address Address1 { get; set; }
        public Address Address2 { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}