   M S B A M L   `   `   `  ����@  <Laba5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Laba5Laba5  5   	       Laba5.ZakaziOkno   5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:mt1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Laba5     5   	     � Title$  
ZakaziOkno��5	   	   $	��450��6   $	��800��6)   $��300px��5
   	   $��300px��6   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ZakaziDG��5         AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер заказа��6A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	Bill_ID+6A     5      $# Фамилия клиента��6O    6%   �� *Clients.ClientSurname+6O     5      $ Имя клиента��6L    6%   �� *Clients.ClientName+6L     5      $ Тип оплаты��6P    6%   �� *TypeOplatis.TypeOplati+6P     5      $ Тип доставки��6T    6%   �� *TypeDostavkis.TypeDostavki+6T     5      $ Дата��6B    6%   �� *
DateBill+6B   5      � 5   
   $��1��6    5      �� 5      �� 5      �� 5       � RowDefinitions 5       �� 5!      $
��0.5* �6    �� 5"      $
��0.3* �6    �� 5#      $
��0.3* �6    �� 5$      $
��0.3* �6    �� 5%      $
��0.3* �6    �� 5&      $
��0.3* �6    �� 5'      $
��0.3* �6    �� 5(      $
��0.3* �6    .+�5*      �� -   5        	 ��Name$	 BackBtm��5*      $
��99px��6&   $	��Top=�63   $��Right=�6K   $��Вернуться��6g   $��2��6{   6�   �� 5+      -   5        $	 AddBtm��5+      $��Добавить��6%   $��7��68   $��1��6E   6U   �� 5,      -   5        $	 EditBtm��5,      $��Изменить��6&   $��7��69   6F   �� 5-      -   5        $	 	DeleteBtm��5-      $��Удалить��6(   $��7��6:   $��2��6G   6W   �� 5.      $��1��6   $��/pixil-frame-0 (1).png��6$   $��Uniform=�6D   �� 5/      $.��(Данные для заполнения��6   $��Center=�65   $��Center=�6P   $
��20px(�6m   $��1��6}   $��3��6�   �� 50      -   5        
 ��Name$
 
ClientCBox��50      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Клиент��6+   $
��20px(�6G   $��2��6W   $��2��6d   �� 51      -   5        $	 ClientOknoBtm��51      $#��Добавить нового��6,   $��12.5px(�6F   $��2��6X   $��2��6h   6u   �� 52      -   5        $
 TypeOplatiCBox��52      $ Тип оплаты��6/   $
��20px(�6O   $��3��6_   $��2��6l   �� 53      -	   5        $	 TypeOplatiOknoBtm��53      $!��Добавить новый��60   $��12.5px(�6I   $��2��6[   $��3��6k   6x   �� 54      -
   5        $
 TypeDostavkiCBox��54      $ Тип доставки��61   $
��20px(�6S   $��4��6c   $��2��6p   �� 55      -   5        $	 TypeDostavkiOknoBtm��55      $!��Добавить новый��62   $��12.5px(�6K   $��2��6]   $��4��6m   6z   (  "System.Windows.Controls.DatePicker  56      -   5          Name$ 	DateDPick��56      $ Дата��6,   $
��20px(�6F   $��5��6V   $��3��6c   �� 57      -   5         ��Name$ OshibkaTBlock��57      $��Center=�6/   $��Center=�6J   $
��20px(�6g   $��6��6w   $��3��6�   58      59      5:      