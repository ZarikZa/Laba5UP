   M S B A M L   `   `   `  ����@  <Laba5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Laba5Laba5  5   	       Laba5.UnitazTypeOkno   5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:mt1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Laba5     5   	     � Title$  UnitazTypeOkno��5	   	   $	��450��6    $	��800��6-   $��300px��5
   	   $��300px��6   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ typeUnitazDG��5         AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Тип унитаза��6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
UnitazType+6D   5      � 5   
   $��1��6    5      �� 5      �� 5      �� 5       � RowDefinitions 5      �� 5      $
��0.5* �6    �� 5      $
��0.3* �6    �� 5      �� 5      $
��0.3* �6    �� 5       $
��0.3* �6    �� 5!      $
��0.2* �6    .+�5#      �� -   5        	 ��Name$	 BackBtm��5#      $
��99px��6&   $	��Top=�63   $��Right=�6K   $��Вернуться��6g   $��2��6{   6�   �� 5$      -   5        $	 AddBtm��5$      $��Добавить��6%   $��4��68   $��1��6E   6U   �� 5%      -   5        $	 EditBtm��5%      $��Изменить��6&   $��4��69   6F   �� 5&      -   5        $	 	DeleteBtm��5&      $��Удалить��6(   $��4��6:   $��2��6G   6W   �� 5'      $��1��6   $��/pixil-frame-0 (1).png��6$   $��Uniform=�6D   �� 5(      $.��(Данные для заполнения��6   $��Center=�65   $��Center=�6P   $
��20px(�6m   $��1��6}   $��3��6�   �� 5)      -   5        
 ��Name$
 TypeUniTbox��5)      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Тип унитаза��6+   $
��20px(�6L   $��2��6\   $	��Top=�6i   $��3��6�   �� 5*      -   5         ��Name$ OshibkaTBlock��5*      $��Center=�6/   $��Center=�6J   $
��20px(�6g   $��3��6w   $��3��6�   �� 5+      -   5        $	 VigruzkaBtm��5+      $��5��6*   $��3��67   $5��/Выгрузить данные из файла��6K   6o   5,      5-      5.      