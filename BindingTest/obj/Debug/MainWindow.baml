   M S B A M L   `   `   `  ����F  BBindingTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BindingTestBindingTest  5   	       BindingTest.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   +localclr-namespace:BindingTest     5   	     � Title$  
MainWindow��5   	    � SizeToContent$ WidthAndHeight=�5   	    � 	Resources 5       �� 
TargetType   Style_Checkbox �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader  	Style_DGH   BindingTest.B2VConv  B2VC   BindingTest.V2BConv  V2BC   BindingTest.B2MVConv 	 B2MVC��%Q  &	        &	 �     &	 �     &	 �     &	     �� 5   
   " ��6   .�5	      ��  � ��$ Center=�6;   �� 5
       � ��$ Center=�69   �� 5       � ��$ 6,6,0,6q�6'   5      �� 5   
   "  6   .�5      ��  � ��$	 125��6&   5        5   
   6     5   
   6     5   
   6   5      .��5      �� .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DG_Test��5      $	��500��5         ColumnHeaderHeight$ 25Q�5         AutoGenerateColumns .  	   CanUserAddRows	 .  
   CanUserResizeRows
 .  ��5      ��  �� Path$ 
lstPersons�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Vorname��6%      HeaderStyle# [ 66   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      �� 5       $ Vorname�6"    �� UpdateSourceTrigger$ 	LostFocus=�61    �� ValidationRules 5!      "	   BindingTest.InputValidations	  5"   "   ,
  &System.Windows.Controls.ValidationRule 
  ValidatesOnTargetUpdated .   
  ValidationStep$ CommittedValue=�6Z   5$      5&        5'      $
 Name��6%   # [ 63    6h   �� $
 Name�  5(      $ 	Mobil-Nr.��6%   # [ 68    6m   �� $ MobilNr�4  .System.Windows.Controls.DataGridComboBoxColumn  5)      -   5        DGCB_Location��$	 Ort��5)   @   # [ 6M      DisplayMemberPath$
 City��6�      SelectedItemBinding 6�   �� $ Location�6�     5*      -   5        DGCB_Climate��$ Klima��5+   )   # [ 5,   )    5-   )   �� $ Klima�  5.      -   5        DGCB_LVTest��$ Test-CB��5/   )   # [ 50   )     LVS   ItemsSource# [ 51   )   53      �� 54   
   -   5         ��Name$ SP_UserControl��54       �� Orientation$ 
Horizontal=�6-   .+�55      �� -   5         ��Name$ Btn_Add��55      $��Hinzufügen��6&   $	��100��6;   $��6,6,0,6q�6G   $
��Left=�6X   6s   �� 56      -   5        $��CBox_DayOfWeek��56      $	��100��6-   $��6,6,0,6q�69    �� DisplayMemberPath$	 Day��6�   ��6J   �� $ lstDaysOfWeek� �� SelectedItem 6u   �� $	 DOW�6�   �� 57      -   5        $��CB_ShowClimate��57      $��Zeige Klima��58      $
��Left=�59      $	��100��5:      #��[  5;       d� IsThreeState .   d� 	IsChecked 5=      ��  �� ElementName$ DGCB_Climate��$ 
Visibility� �� 	Converter# [ 5>      �� 5?      -	   5        $��CB_ShowColumns��5?      $��Mehrfach��5@      $
��Left=�5A      $	��100��5B      #��[  5C       5D      `� 5E        `� 	Converter#  [ 6#   .1�5F      �� $ DGCB_Climate��6"   $ 
Visibility�6=   �� 5G      $ DGCB_Location��6"   $ 
Visibility�6>   5H      5J      5K      5L      5M      