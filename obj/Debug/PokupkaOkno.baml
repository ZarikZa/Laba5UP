   M S B A M L   `   `   `  ����@  <Laba5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Laba5Laba5  5   	       Laba5.PokupkaOkno   5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:mt1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Laba5     5   	     � Title$  PokupkaOkno��5	   	   $	��450��6   $	��800��6*   $��300px��5
   	   $��300px��6   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $
��0.2* �6   �� 5       � RowDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $��0.14* �6   �� 5      �� 5      $��0.15* �6   �� 5      $��0.15* �6   �� 5      $��0.19* �6   .+�5   
   �� $��/pixil-frame-0 (1).png��6   $��Uniform=�60   �� 5   
   $��3��6   $��Покупка��6(    �� TextAlignment$ Center=�67   $
��30px(�6N   �� 5   
   -   5         ��Name$ VihodBtm��5      $��
Выйти��6#   $��2��63   $��Right=�6C   $	��Top=�6_   6w   �� 5   
   $��1��6   $��Все товары��6!   $ Center=�63   $
��20px(�6J   � 5   
   $��2��6   $��1��6    5      �� 5      �� 5       .+�5"      �� $��Полная цена:��6   $ Right=�6,   $
��20px(�6B   �� 5#      -   5         ��Name$ PriceTblock��5#      $��1��6-   $
 Left=�6=   $
��20px(�6R   5$      &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ TovariDG��5%      $��2��6%      AutoGenerateColumns .     
IsReadOnly . 	   Columns	 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Название��6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
UnitazName+6D     5(      $
 Цена��6E    6%   �� *UnitazPrice+6E   5*        5+   
   -   5        $ 	PokupkiDG��5+       .   . $��2��6T   $��2��6d   	 5,        5-      $
 Название��6I    6%   �� *unit.UnitazName+6I     5.      $
 Цена��6J    6%   �� *unit.UnitazPrice+6J     5/      $
 Количество��6?    6%   �� *kolvo+6?   51      � 52   
   $��1��6   $��2��6    53      �� 54      �� 55      �� 56      �� 57      �� 58      .+�5:      �� -   5        $ DobavBtm��5:      $��1��6'   .��5;      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
ArrowRight=�6   5<      �� 5=      -   5        $ UbratBtm��5=      $��3��6'   .��5>        $ 	ArrowBack=�6   5?      5@      �� 5A   
   -   5         ��Name$ TypeOplatiCBox��5A      $
��15px(�6+   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Тип оплаты��6;   $��3��6[   6h   �� 5B   
   -   5        $ TypeDostavkiCBox��5B      $
��15px(�6-   $ Тип доставки��6=   $��2��6_   $��3��6o   6|   �� 5C   
   -	   5         ��Name$ 
ColvoDTbox��5C      $
��15px(�6&   $��3��66   {�.  $��4��6\   $% Количество денег��6i   �� 5D   
   -
   5        $ KupitBtm��5D      $��3��6#   $��5��67   $'��!Завершить покупку��6D   6`   5E      5F      