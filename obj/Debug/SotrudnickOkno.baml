   M S B A M L   `   `   `  ����@  <Laba5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Laba5Laba5  5   	       Laba5.SotrudnickOkno   5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:mt1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Laba5     5   	     � Title$  SotrudnickOkno��5	   	   $	��450��6    $	��800��6-   $��300px��5
   	   $��300px��6   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ SotrudDG��5         AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$! Имя сотрудника��6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *#!SNM_Sortudnicks.SortudnickSurname+6[     5      $! Имя сотрудника��6X    6%   �� * SNM_Sortudnicks.SortudnickName+6X     5      $ Должность��6Q    6%   �� *Dolznostis.DolznostName+6Q     5      $ 
Логин��6L    6%   �� *LoginPasses.Loginn+6L     5      $ Пароль��6J    6%   �� *LoginPasses.Pass+6J   5      � 5   
   $��1��6    5      �� 5      �� 5      �� 5       � RowDefinitions 5      �� 5       $
��0.5* �6    �� 5!      $
��0.3* �6    �� 5"      $
��0.3* �6    �� 5#      $
��0.3* �6    �� 5$      $
��0.3* �6    �� 5%      $
��0.3* �6    �� 5&      $
��0.3* �6    �� 5'      $
��0.3* �6    �� 5(      $
��0.3* �6    .+�5*      �� -   5        	 ��Name$	 BackBtm��5*      $
��99px��6&   $	��Top=�63   $��Right=�6K   $��Вернуться��6g   $��2��6{   6�   �� 5+      -   5        $	 AddBtm��5+      $��Добавить��6%   $��8��68   $��1��6E   6U   �� 5,      -   5        $	 EditBtm��5,      $��Изменить��6&   $��8��69   6F   �� 5-      -   5        $	 	DeleteBtm��5-      $��Удалить��6(   $��8��6:   $��2��6G   6W   �� 5.      $��1��6   $��/pixil-frame-0 (1).png��6$   $��Uniform=�6D   �� 5/      $.��(Данные для заполнения��6   $��Center=�65   $��Center=�6P   $
��20px(�6m   $��1��6}   $��3��6�   �� 50      -   5        
 ��Name$
 SotrudSurnameTbox��50      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$) #Фамилия сотрудника��61   $
��20px(�6Y   $��2��6i   $	��Top=�6v   $��3��6�   �� 51      -   5        $
 SotrudNameTbox��51      $! Имя сотрудника��6.   $
��20px(�6R   $��3��6b   $	��Top=�6o   $��3��6�   �� 52      -   5        $
 SotrudMiddleNameTbox��52      $+ %Отчество сотрудника��64   $
��20px(�6]   $��4��6m   $	��Top=�6z   $��3��6�   �� 53      -	   5         ��Name$ DolznostCBox��53      $ Должность��6-   $
��20px(�6L   $��5��6\   $	��Top=�6i   $��2��6�   �� 54      -
   5        $	 DolznostOknoBtm��54      $!��Добавить новый��6.   $��12.5px(�6G   $��2��6Y   $��5��6i   $��Right=�6v   $��0,7,0,6q�6�   $	��133��6�   6�   � 55      $��6��6   $��3��6     56      �� 57      �� 58      .+�5:      �� -   5        $
 	LoginTbox��5:      $ 
Логин��6.   $
��20px(�6I   �� 5;      -   5        $
 PassTbox��5;      $ Пароль��6-   $
��20px(�6I   $��1��6Y   5<      �� 5=      -   5         ��Name$ OshibkaTBlock��5=      $��Center=�6/   $��Center=�6J   $
��20px(�6g   $��7��6w   $��3��6�   5>      5?      5@      