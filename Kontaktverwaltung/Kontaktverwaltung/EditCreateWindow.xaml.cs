using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kontaktverwaltung
{
    /// <summary>
    /// Interaktionslogik für EditCreateWindow.xaml
    /// </summary>
    public partial class EditCreateWindow : Window
    {
        public EditCreateWindow(string Mode = "", string DisplayName = "", string SurName = "", string Name = "", string Title = "", string Street = "", string HouseNumber = "", string PostalCode = "", string City = "", string Email = "", string MobilNr = "", string PhoneNr = "", string FaxNr = "", string Street1 = "", string HouseNumber1 = "", string PostalCode1 = "", string City1 = "", string Email1 = "", string MobilNr1 = "", string PhoneNr1 = "", string FaxNr1 = "", string Street2 = "", string HouseNumber2 = "", string PostalCode2 = "", string City2 = "", string Email2 = "", string MobilNr2 = "", string PhoneNr2 = "", string FaxNr2 = "")
        {
            InitializeComponent();
            SpAdress1.Visibility = Visibility.Collapsed;
            SpAdress2.Visibility = Visibility.Collapsed;

            EditCreateWindowUi.Title = Mode;

            tbDisplayName.Text = DisplayName;
            tbSurName.Text = SurName;
            tbName.Text = Name;
            tbTitle.Text = Title;
            tbStreet.Text = Street;
            tbHouseNumber.Text = HouseNumber;
            tbPostalCode.Text = PostalCode;
            tbCity.Text = City;
            tbEmail.Text = Email;
            tbMobileNr.Text = MobilNr;
            tbPhoneNr.Text = PhoneNr;
            tbFaxNr.Text = FaxNr;

            tbStreet1.Text = Street1;
            tbHouseNumber1.Text = HouseNumber1;
            tbPostalCode1.Text = PostalCode1;
            tbCity1.Text = City1;
            tbEmail1.Text = Email1;
            tbMobileNr1.Text = MobilNr1;
            tbPhoneNr1.Text = PhoneNr1;
            tbFaxNr1.Text = FaxNr1;

            tbStreet2.Text = Street2;
            tbHouseNumber2.Text = HouseNumber2;
            tbPostalCode2.Text = PostalCode2;
            tbCity2.Text = City2;
            tbEmail2.Text = Email2;
            tbMobileNr2.Text = MobilNr2;
            tbPhoneNr2.Text = PhoneNr2;
            tbFaxNr2.Text = FaxNr2;

            if (tbStreet1.Text != "" || tbHouseNumber1.Text != "" || tbPostalCode1.Text != "" || tbCity1.Text != "" || tbEmail1.Text != "" || tbMobileNr1.Text != "" || tbPhoneNr1.Text != "" || tbFaxNr1.Text != "")
                SpAdress1.Visibility = Visibility.Visible;

            if (tbStreet2.Text != "" || tbHouseNumber2.Text != "" || tbPostalCode2.Text != "" || tbCity2.Text != "" || tbEmail2.Text != "" || tbMobileNr2.Text != "" || tbPhoneNr2.Text != "" || tbFaxNr2.Text != "")
                SpAdress2.Visibility = Visibility.Visible;
        }

        private void btEditDialogOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbDisplayName.Text == "" || tbSurName.Text == "" || tbName.Text == "" || CBSex.Text == "")
                MessageBox.Show("Keines der mit einem Stern markierten Felder darf leer bleiben");
            else
                this.DialogResult = true;
        }

        private void btEditDialogAddAdress_Click(object sender, RoutedEventArgs e)
        {
            if (SpAdress1.Visibility == Visibility.Collapsed)
                SpAdress1.Visibility = Visibility.Visible;
            else
            {
                SpAdress2.Visibility = Visibility.Visible;
                btEditDialogAddAdress.IsEnabled = false;
            }
        }
    }
}
