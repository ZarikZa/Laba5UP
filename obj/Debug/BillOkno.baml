   M S B A M L   `   `   `  ����@  <Laba5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Laba5Laba5  5   	       Laba5.BillOkno   5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:mt1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Laba5     5   	     � Title$  BillOkno��5	   	   $	��450��6   $	��800��6'   $��300px��5
   	   $��300px��6   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      $��0.07* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ BillDG��5         AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер заказа��6A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	FK_Bill+6A     5      $# Фамилия клиента��6U    6%   �� *Bills.Clients.ClientSurname+6U     5      $ Имя клиента��6R    6%   �� *Bills.Clients.ClientName+6R     5      $% Название унитаза��6L    6%   �� *Unitazs.UnitazName+6L     5      $ Количество��6E    6%   �� *KolvoUnitaz+6E     5      $ Цена заказа��6C    6%   �� *	PriceBill+6C     5      $ Тип оплаты��6V    6%   �� *Bills.TypeOplatis.TypeOplati+6V     5      $ Тип доставки��6Z    6%   �� *" Bills.TypeDostavkis.TypeDostavki+6Z     5      $ Дата��6H    6%   �� *Bills.DateBill+6H   5       � 5!   
   $��1��6    5"      �� 5#      �� 5$      �� 5%       5'      �� 5(      $
��0.5* �6    �� 5)      $
��0.3* �6    �� 5*      $
��0.3* �6    �� 5+      $
��0.3* �6    �� 5,      $
��0.3* �6    �� 5-      $
��0.3* �6    �� 5.      $
��0.3* �6    .+�50      �� -   5        	 ��Name$	 BackBtm��50      $
��99px��6&   $	��Top=�63   $��Right=�6K   $��Вернуться��6g   $��2��6{   6�   �� 51      -   5        $	 AddBtm��51      $��Добавить��6%   $��7��68   $��1��6E   6U   �� 52      -   5        $	 EditBtm��52      $��Изменить��6&   $��7��69   6F   �� 53      -   5        $	 	DeleteBtm��53      $��Удалить��6(   $��7��6:   $��2��6G   6W   �� 54      -   5        $	 UnitazOknoBtm��54      $!��Добавить новый��6,   $��12.5px(�6E   $��2��6W   $��2��6g   6t   �� 55      -   5        $	 ZakazOknoBtm��55      $!��Добавить новый��6+   $��12.5px(�6D   $��2��6V   $��3��6f   6s   �� 56      $��1��6   $��/pixil-frame-0 (1).png��6$   $��Uniform=�6D   �� 57      $.��(Данные для заполнения��6   $��Center=�65   $��Center=�6P   $
��20px(�6m   $��1��6}   $��3��6�   �� 58      -   5        
 ��Name$
 
UnitazCBox��58      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Унитаз��6+   $
��20px(�6G   $��2��6W   $��2��6d   �� 59      -	   5        $
 	ZakazCBox��59      $ Номер заказа��6*   $
��20px(�6L   $��3��6\   $��2��6i   �� 5:      -
   5         ��Name$ KolvoUniTBox��5:      $+ %Количество унитазов��6,   $
��20px(�6U   $��4��6e   $��3��6r   �� 5;      -   5         ��Name$ OshibkaTBlock��5;      $��Center=�6/   $��Center=�6J   $
��20px(�6g   $��5��6w   $��3��6�   5<      �� 5=   
   -   5        $	 VigruzkaBtm��5=      $��1��6&   $��2��63   $-��'Выгрузить чеки в файл��6G   6g   5>      5?      