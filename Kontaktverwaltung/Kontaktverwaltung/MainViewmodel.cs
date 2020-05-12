using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Collections;
using System.Windows;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Windows.Controls;
using System.Collections.Specialized;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Security.Cryptography.X509Certificates;

namespace Kontaktverwaltung
{
    public class MainViewmodel : INotifyPropertyChanged
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Kontakt> Kontakte { get; set; }


        public List<Kontakt> ModifiedKontakte { get; set; }
        private Kontakt _selectedKontakt;
        public MainViewmodel()
        {

            if (File.Exists(path + "\\KontaktverwaltungData.xml"))
            {


                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Kontakt>));
                using (StreamReader rd = new StreamReader(path + "\\KontaktverwaltungData.xml"))
                {
                    Kontakte = xs.Deserialize(rd) as ObservableCollection<Kontakt>;
                }
            }

            else
            {

                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Kontakt>));
                using (StreamWriter wr = new StreamWriter(path + "\\KontaktverwaltungData.xml"))
                {
                    xs.Serialize(wr, Kontakte);
                }

                XmlSerializer xs1 = new XmlSerializer(typeof(ObservableCollection<Kontakt>));
                using (StreamReader rd = new StreamReader(path + "\\KontaktverwaltungData.xml"))
                {
                    Kontakte = xs1.Deserialize(rd) as ObservableCollection<Kontakt>;
                }
            }

            this.ModifiedKontakte = new List<Kontakt>();

            this.Kontakte.CollectionChanged += this.OnCollectionChanged;

            OpenCreateDialog = new DelegateCommand(() => openCreateDialog());
            OpenCopyDialog = new DelegateCommand(() => openCopyDialog());
            OpenEditDialog = new DelegateCommand(() => openEditDialog());
            OpenDeleteDialog = new DelegateCommand(() => openDeleteDialog());
            Save_Contacts = new DelegateCommand(() => saveContacts());

        }

        public DelegateCommand OpenCopyDialog { get; set; }
        public DelegateCommand OpenEditDialog { get; set; }
        public DelegateCommand OpenDeleteDialog { get; set; }
        public DelegateCommand OpenCreateDialog { get; set; }
        public DelegateCommand Save_Contacts { get; set; }


        public Kontakt SelectedKontakt
        {
            get { return _selectedKontakt; }
            set { _selectedKontakt = value; NotifyPropertyChanged("SelectedKontakt"); }
        }

        public void saveContacts()
        {
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Kontakt>));
            using (StreamWriter wr = new StreamWriter(path + "\\KontaktverwaltungData.xml"))
            {
                xs.Serialize(wr, Kontakte);
            }
        }

        public void openCreateDialog()
        {
            EditCreateWindow editCreateWindow = new EditCreateWindow("Hinzufügen eines Kontaktes");
            if (editCreateWindow.ShowDialog() == true)
            {
                var check = Kontakte.SingleOrDefault(i => i.DisplayName == editCreateWindow.tbDisplayName.Text);
                if (check == null)
                    Kontakte.Add(new Kontakt() { Sex = (Sex)Enum.Parse(typeof(Sex), editCreateWindow.CBSex.Text), DisplayName = editCreateWindow.tbDisplayName.Text, Surname = editCreateWindow.tbSurName.Text, Name = editCreateWindow.tbName.Text, Title = editCreateWindow.tbTitle.Text, Address = new Address { City = editCreateWindow.tbCity.Text, HouseNoumber = editCreateWindow.tbHouseNumber.Text, PostalCode = editCreateWindow.tbPostalCode.Text, Street = editCreateWindow.tbStreet.Text, EMail = editCreateWindow.tbEmail.Text, MobileNr = editCreateWindow.tbMobileNr.Text, PhoneNr = editCreateWindow.tbPhoneNr.Text, FaxNr = editCreateWindow.tbFaxNr.Text }, Address1 = new Address { City = editCreateWindow.tbCity1.Text, HouseNoumber = editCreateWindow.tbHouseNumber1.Text, PostalCode = editCreateWindow.tbPostalCode1.Text, Street = editCreateWindow.tbStreet1.Text, EMail = editCreateWindow.tbEmail1.Text, MobileNr = editCreateWindow.tbMobileNr1.Text, PhoneNr = editCreateWindow.tbPhoneNr1.Text, FaxNr = editCreateWindow.tbFaxNr1.Text }, Address2 = new Address { City = editCreateWindow.tbCity2.Text, HouseNoumber = editCreateWindow.tbHouseNumber2.Text, PostalCode = editCreateWindow.tbPostalCode2.Text, Street = editCreateWindow.tbStreet2.Text, EMail = editCreateWindow.tbEmail2.Text, MobileNr = editCreateWindow.tbMobileNr2.Text, PhoneNr = editCreateWindow.tbPhoneNr2.Text, FaxNr = editCreateWindow.tbFaxNr2.Text } });
                else
                    MessageBox.Show("Es dürfen keine zwei Kontakte mit dem Gleichen Anzeigenamen existieren");
            }
        }

        public void openCopyDialog()
        {
            if (SelectedKontakt != null)
            {
                int eValue = (int)SelectedKontakt.Sex;
                EditCreateWindow editCreateWindow = new EditCreateWindow("Kopieren eines Kontaktes", SelectedKontakt.DisplayName, SelectedKontakt.Surname, SelectedKontakt.Name, SelectedKontakt.Title, SelectedKontakt.Address.Street, SelectedKontakt.Address.HouseNoumber, SelectedKontakt.Address.PostalCode, SelectedKontakt.Address.City, SelectedKontakt.Address.EMail, SelectedKontakt.Address.MobileNr, SelectedKontakt.Address.PhoneNr, SelectedKontakt.Address.FaxNr, SelectedKontakt.Address1.Street, SelectedKontakt.Address1.HouseNoumber, SelectedKontakt.Address1.PostalCode, SelectedKontakt.Address1.City, SelectedKontakt.Address1.EMail, SelectedKontakt.Address1.MobileNr, SelectedKontakt.Address1.PhoneNr, SelectedKontakt.Address1.FaxNr, SelectedKontakt.Address2.Street, SelectedKontakt.Address2.HouseNoumber, SelectedKontakt.Address2.PostalCode, SelectedKontakt.Address2.City, SelectedKontakt.Address2.EMail, SelectedKontakt.Address2.MobileNr, SelectedKontakt.Address2.PhoneNr, SelectedKontakt.Address2.FaxNr);
                editCreateWindow.CBSex.SelectedIndex = eValue;

                if (editCreateWindow.ShowDialog() == true)
                {
                    var check = Kontakte.SingleOrDefault(i => i.DisplayName == editCreateWindow.tbDisplayName.Text);
                    if (check == null)
                        Kontakte.Add(new Kontakt() { Sex = (Sex)Enum.Parse(typeof(Sex), editCreateWindow.CBSex.Text), DisplayName = editCreateWindow.tbDisplayName.Text, Surname = editCreateWindow.tbSurName.Text, Name = editCreateWindow.tbName.Text, Title = editCreateWindow.tbTitle.Text, Address = new Address { City = editCreateWindow.tbCity.Text, HouseNoumber = editCreateWindow.tbHouseNumber.Text, PostalCode = editCreateWindow.tbPostalCode.Text, Street = editCreateWindow.tbStreet.Text, EMail = editCreateWindow.tbEmail.Text, MobileNr = editCreateWindow.tbMobileNr.Text, PhoneNr = editCreateWindow.tbPhoneNr.Text, FaxNr = editCreateWindow.tbFaxNr.Text }, Address1 = new Address { City = editCreateWindow.tbCity1.Text, HouseNoumber = editCreateWindow.tbHouseNumber1.Text, PostalCode = editCreateWindow.tbPostalCode1.Text, Street = editCreateWindow.tbStreet1.Text, EMail = editCreateWindow.tbEmail1.Text, MobileNr = editCreateWindow.tbMobileNr1.Text, PhoneNr = editCreateWindow.tbPhoneNr1.Text, FaxNr = editCreateWindow.tbFaxNr1.Text }, Address2 = new Address { City = editCreateWindow.tbCity2.Text, HouseNoumber = editCreateWindow.tbHouseNumber2.Text, PostalCode = editCreateWindow.tbPostalCode2.Text, Street = editCreateWindow.tbStreet2.Text, EMail = editCreateWindow.tbEmail2.Text, MobileNr = editCreateWindow.tbMobileNr2.Text, PhoneNr = editCreateWindow.tbPhoneNr2.Text, FaxNr = editCreateWindow.tbFaxNr2.Text } });
                    else
                        MessageBox.Show("Es dürfen keine zwei Kontakte mit dem Gleichen Anzeigenamen existieren");
                }
            }
            else
            {
                MessageBox.Show("Wählen sie einen Kontakt aus");
            }
        }

        public void openEditDialog()
        {
            if (SelectedKontakt != null)
            {
                int eValue = (int)SelectedKontakt.Sex;
                EditCreateWindow editCreateWindow = new EditCreateWindow("Bearbeiten eines Kontaktes", SelectedKontakt.DisplayName, SelectedKontakt.Surname, SelectedKontakt.Name, SelectedKontakt.Title, SelectedKontakt.Address.Street, SelectedKontakt.Address.HouseNoumber, SelectedKontakt.Address.PostalCode, SelectedKontakt.Address.City, SelectedKontakt.Address.EMail, SelectedKontakt.Address.MobileNr, SelectedKontakt.Address.PhoneNr, SelectedKontakt.Address.FaxNr, SelectedKontakt.Address1.Street, SelectedKontakt.Address1.HouseNoumber, SelectedKontakt.Address1.PostalCode, SelectedKontakt.Address1.City, SelectedKontakt.Address1.EMail, SelectedKontakt.Address1.MobileNr, SelectedKontakt.Address1.PhoneNr, SelectedKontakt.Address1.FaxNr, SelectedKontakt.Address2.Street, SelectedKontakt.Address2.HouseNoumber, SelectedKontakt.Address2.PostalCode, SelectedKontakt.Address2.City, SelectedKontakt.Address2.EMail, SelectedKontakt.Address2.MobileNr, SelectedKontakt.Address2.PhoneNr, SelectedKontakt.Address2.FaxNr);
                editCreateWindow.CBSex.SelectedIndex = eValue;
                if (editCreateWindow.ShowDialog() == true)
                {
                    var check = Kontakte.SingleOrDefault(i => i.DisplayName == editCreateWindow.tbDisplayName.Text && i.DisplayName != SelectedKontakt.DisplayName);
                    if (check == null)
                    {
                        var item = Kontakte.FirstOrDefault(i => i.DisplayName == SelectedKontakt.DisplayName);
                        if (item != null)
                        {
                            item.DisplayName = editCreateWindow.tbDisplayName.Text;
                            item.Surname = editCreateWindow.tbSurName.Text;
                            item.Name = editCreateWindow.tbName.Text;
                            item.Title = editCreateWindow.tbTitle.Text;
                            item.Address.Street = editCreateWindow.tbStreet.Text;
                            item.Address.HouseNoumber = editCreateWindow.tbHouseNumber.Text;
                            item.Address.PostalCode = editCreateWindow.tbPostalCode.Text;
                            item.Address.City = editCreateWindow.tbCity.Text;
                            item.Address.EMail = editCreateWindow.tbEmail.Text;
                            item.Address.MobileNr = editCreateWindow.tbMobileNr.Text;
                            item.Address.PhoneNr = editCreateWindow.tbPhoneNr.Text;
                            item.Address.FaxNr = editCreateWindow.tbFaxNr.Text;

                            item.Address1.Street = editCreateWindow.tbStreet1.Text;
                            item.Address1.HouseNoumber = editCreateWindow.tbHouseNumber1.Text;
                            item.Address1.PostalCode = editCreateWindow.tbPostalCode1.Text;
                            item.Address1.City = editCreateWindow.tbCity1.Text;
                            item.Address1.EMail = editCreateWindow.tbEmail1.Text;
                            item.Address1.MobileNr = editCreateWindow.tbMobileNr1.Text;
                            item.Address1.PhoneNr = editCreateWindow.tbPhoneNr1.Text;
                            item.Address1.FaxNr = editCreateWindow.tbFaxNr1.Text;

                            item.Address2.Street = editCreateWindow.tbStreet2.Text;
                            item.Address2.HouseNoumber = editCreateWindow.tbHouseNumber2.Text;
                            item.Address2.PostalCode = editCreateWindow.tbPostalCode2.Text;
                            item.Address2.City = editCreateWindow.tbCity2.Text;
                            item.Address2.EMail = editCreateWindow.tbEmail2.Text;
                            item.Address2.MobileNr = editCreateWindow.tbMobileNr2.Text;
                            item.Address2.PhoneNr = editCreateWindow.tbPhoneNr2.Text;
                            item.Address2.FaxNr = editCreateWindow.tbFaxNr2.Text;
                            item.Sex = (Sex)Enum.Parse(typeof(Sex), editCreateWindow.CBSex.Text);
                        }
                    }
                    else
                        MessageBox.Show("Es dürfen keine zwei Kontakte mit dem Gleichen Anzeigenamen existieren");
                }
            }
            else
            {
                MessageBox.Show("Wählen sie einen Kontakt aus");
            }
        }

        public void openDeleteDialog()
        {
            if (SelectedKontakt != null)
            {
                DeleteDialog deleteDialog = new DeleteDialog(SelectedKontakt.DisplayName);
                if (deleteDialog.ShowDialog() == true)
                    Kontakte.Remove(Kontakte.SingleOrDefault(i => i.DisplayName == SelectedKontakt.DisplayName));
            }
            else
            {
                MessageBox.Show("Wählen sie einen Kontakt aus");
            }
        }




        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Kontakt newItem in e.NewItems)
                {
                    ModifiedKontakte.Add(newItem);

                  
                    newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
            }

            if (e.OldItems != null)
            {
                foreach (Kontakt oldItem in e.OldItems)
                {
                    ModifiedKontakte.Add(oldItem);

                    oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
        }

        void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Kontakt kontakt = sender as Kontakt;
            if (kontakt != null)
                ModifiedKontakte.Add(kontakt);
        }

        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }

}