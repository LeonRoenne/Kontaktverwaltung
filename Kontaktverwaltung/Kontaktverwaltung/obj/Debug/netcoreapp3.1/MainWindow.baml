   M S B A M L   `   `   `  ����L  HKontaktverwaltung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:KontaktverwaltungKontaktverwaltung  5   	   "    Kontaktverwaltung.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Kontaktverwaltung     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	      %   Kontaktverwaltung.MainViewmodel   MainViewModel��%   &	          5
   
   6   5      .��5      �  � DataContext# [  6   .+�5   
   �� .+�5      A� $��50��6   $	��Top=�6&    A� Rows$ 1��6>   .+�5      �� -   5         ��Name$ btAdd��5   S   $��Hinzufügen��6   $��50��6b   ��6.   �� *OpenCreateDialog+6b   �� 5      -   5        $ btEdit��5   Q   $��
Bearbeiten��6   $��50��6a   ��6.   �� *OpenEditDialog+6a   �� 5      -   5        $ btCopy��5   O   $��Kopieren��6   $��50��6_   ��6,   �� *OpenCopyDialog+6_   �� 5      -   5        $ btDelete��5   P   $��Löschen��6   $��50��6b   ��6+   �� *OpenDeleteDialog+6b   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ MainWindowDataGrid��5   a   $	��350��6      AutoGenerateColumns$ False��6E   $
��True��6�   $
��Auto=�6�   $
��Auto=�6�   ��6$   �� *
Kontakte+ �� SelectedItem 6}   �� *SelectedKontakt+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Anzeigename��6)   -   5        
DGName��1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5   N   �� *DisplayName+  5      $	 Nachname��6)   
 6;   �� *	Surname+  5      $	 Vorname��6)   
 6:   �� *Name+  5      $	 Anrede��6)   
 69   �� *Title+  5      $	 
Geschlecht��6)   
 6=   �� *Sex+   RowDetailsTemplate 5      �� 5      .R�5      �� $��0q�6!   
������� �� Padding$ 10q�6H   ._�5      ��  �� Orientation$ 
Horizontal=�6)   .+�5    "   �� $ Vertical=�6-   $��5q�6D   .+�5!   &   �� $��	Adresse 1��60   $
��Bold"�6A   �� 5"   &   $ 
Horizontal=�61   .+�5#   *   �� $��	Straße: ��64   $��12(�6D   $��Center=�6R   �� 5$   *   $��14(�6T   $��Center=�6b   ��64   �� *Address.Street+6b   5%   '   �� 5&   &   $ 
Horizontal=�61   .+�5'   *   �� $��Hausnummer: ��64   $��12(�6H   $��Center=�6V   �� 5(   *   $��14(�6Z   $��Center=�6h   ��64   �� *Address.HouseNoumber+6h   5)   '   �� 5*   &   $ 
Horizontal=�61   .+�5+   *   �� $��PLZ: ��64   $��12(�6A   $��Center=�6O   �� 5,   *   $��14(�6X   $��Center=�6f   ��64   �� *Address.PostalCode+6f   5-   '   �� 5.   &   $ 
Horizontal=�61   .+�5/   *   �� $��Ort: ��64   $��12(�6A   $��Center=�6O   �� 50   *   $��14(�6R   $��Center=�6`   ��64   �� *Address.City+6`   51   '   �� 52   &   $ 
Horizontal=�61   .+�53   *   �� $��E-Mail: ��64   $��12(�6D   $��Center=�6R   �� 54   *   $��14(�6S   $��Center=�6a   ��64   �� *Address.EMail+6a   55   '   �� 56   &   $ 
Horizontal=�61   .+�57   *   �� $��Mobiltelfonnummer: ��64   $��12(�6O   $��Center=�6]   �� 58   *   $��14(�6V   $��Center=�6d   ��64   �� *Address.MobileNr+6d   59   '   �� 5:   &   $ 
Horizontal=�61   .+�5;   *   �� $��Telefonnummer: ��64   $��12(�6K   $��Center=�6Y   �� 5<   *   $��14(�6U   $��Center=�6c   ��64   �� *Address.PhoneNr+6c   5=   '   �� 5>   &   $ 
Horizontal=�61   .+�5?   *   �� $��Faxnummer: ��64   $��12(�6G   $��Center=�6U   �� 5@   *   $��14(�6S   $��Center=�6a   ��64   �� *Address.FaxNr+6a   5A   '   5B   #   �� 5C   "   $ Vertical=�6-   $��5q�6D   .+�5D   &   �� $��	Adresse 2��60   $
��Bold"�6A   �� 5E   &   $ 
Horizontal=�61   .+�5F   *   �� $��	Straße: ��64   $��12(�6D   $��Center=�6R   �� 5G   *   $��14(�6U   $��Center=�6c   ��64   �� *Address1.Street+6c   5H   '   �� 5I   &   $ 
Horizontal=�61   .+�5J   *   �� $��Hausnummer: ��64   $��12(�6H   $��Center=�6V   �� 5K   *   $��14(�6[   $��Center=�6i   ��64   �� *Address1.HouseNoumber+6i   5L   '   �� 5M   &   $ 
Horizontal=�61   .+�5N   *   �� $��PLZ: ��64   $��12(�6A   $��Center=�6O   �� 5O   *   $��14(�6Y   $��Center=�6g   ��64   �� *Address1.PostalCode+6g   5P   '   �� 5Q   &   $ 
Horizontal=�61   .+�5R   *   �� $��Ort: ��64   $��12(�6A   $��Center=�6O   �� 5S   *   $��14(�6R   $��Center=�6`   ��64   �� *Address.City+6`   5T   '   �� 5U   &   $ 
Horizontal=�61   .+�5V   *   �� $��E-Mail: ��64   $��12(�6D   $��Center=�6R   �� 5W   *   $��14(�6T   $��Center=�6b   ��64   �� *Address1.EMail+6b   5X   '   �� 5Y   &   $ 
Horizontal=�61   .+�5Z   *   �� $��Mobiltelfonnummer: ��64   $��12(�6O   $��Center=�6]   �� 5[   *   $��14(�6W   $��Center=�6e   ��64   �� *Address1.MobileNr+6e   5\   '   �� 5]   &   $ 
Horizontal=�61   .+�5^   *   �� $��Telefonnummer: ��64   $��12(�6K   $��Center=�6Y   �� 5_   *   $��14(�6V   $��Center=�6d   ��64   �� *Address1.PhoneNr+6d   5`   '   �� 5a   &   $ 
Horizontal=�61   .+�5b   *   �� $��Faxnummer: ��64   $��12(�6G   $��Center=�6U   �� 5c   *   $��14(�6T   $��Center=�6b   ��64   �� *Address1.FaxNr+6b   5d   '   5e   #   �� 5f   "   $ Vertical=�6-   $��5q�6D   .+�5g   &   �� $��	Adresse 3��60   $
��Bold"�6A   �� 5h   &   $ 
Horizontal=�61   .+�5i   *   �� $��	Straße: ��64   $��12(�6D   $��Center=�6R   �� 5j   *   $��14(�6U   $��Center=�6c   ��64   �� *Address2.Street+6c   5k   '   �� 5l   &   $ 
Horizontal=�61   .+�5m   *   �� $��Hausnummer: ��64   $��12(�6H   $��Center=�6V   �� 5n   *   $��14(�6[   $��Center=�6i   ��64   �� *Address2.HouseNoumber+6i   5o   '   �� 5p   &   $ 
Horizontal=�61   .+�5q   *   �� $��PLZ: ��64   $��12(�6A   $��Center=�6O   �� 5r   *   $��14(�6Y   $��Center=�6g   ��64   �� *Address2.PostalCode+6g   5s   '   �� 5t   &   $ 
Horizontal=�61   .+�5u   *   �� $��Ort: ��64   $��12(�6A   $��Center=�6O   �� 5v   *   $��14(�6S   $��Center=�6a   ��64   �� *Address2.City+6a   5w   '   �� 5x   &   $ 
Horizontal=�61   .+�5y   *   �� $��E-Mail: ��64   $��12(�6D   $��Center=�6R   �� 5z   *   $��14(�6T   $��Center=�6b   ��64   �� *Address2.EMail+6b   5{   '   �� 5|   &   $ 
Horizontal=�61   .+�5}   *   �� $��Mobiltelfonnummer: ��64   $��12(�6O   $��Center=�6]   �� 5~   *   $��14(�6W   $��Center=�6e   ��64   �� *Address2.MobileNr+6e   5   '   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� $��Telefonnummer: ��64   $��12(�6K   $��Center=�6Y   �� 5�   *   $��14(�6V   $��Center=�6d   ��64   �� *Address2.PhoneNr+6d   5�   '   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� $��Faxnummer: ��64   $��12(�6G   $��Center=�6U   �� 5�   *   $��14(�6T   $��Center=�6b   ��64   �� *Address2.FaxNr+6b   5�   '   5�   #   5�      5�      5�      5�      5�      A� 5�   
   $��Bottom=�6   $ 1��61   .+�5�      �� $��	Speichern��6   $��Bottom=�6K   ��6)   �� *Save_Contacts+6K   5�      5�      5�      