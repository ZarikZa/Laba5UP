   M S B A M L   `   `   `  ����@  <Laba5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Laba5Laba5  5   	       Laba5.RegistraziyaOkno   5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:mt1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Laba5     5   	     � Title$  RegistraziyaOkno��5	   	   $	��450��6"   $	��800��6/   $��300px��5
   	   $��300px��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��1.2* �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �  � ColumnDefinitions 5      �� 5      $
��0.5* �6#   �� 5      �� 5      $
��0.4* �6#   .+�5      �� -   5         ��Name$ ExitBtm��5      $
��50px��6&   $
��20px(�64   $��
Выход��6D   6T   �� 5      $��1��6   $��Center=�6(   $��Center=�6C   $
��30px(�6`   $(��"Зарегестрируйтесь��6p   �� 5       $��2��6   $��/pixil-frame-0 (1).png��6$   $��Uniform=�6D   5!      �� 5"   
   -   5         ��Name$ SurnameTbox��5"      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Фамилия*��6'   $
��20px(�6E    �� TextAlignment$ Center=�6U   $��1��6l   $
��40px��6y   �� 5#   
   -   5        $ NameTbox��5#      $ Имя*��6$   $
��20px(�6>   $ Center=�6N   $��2��6e   $
��40px��6r   �� 5$   
   -   5        $ MiddleNameTbox��5$      $ Отчество��6*   $
��20px(�6H   $ Center=�6X   $��3��6o   $
��40px��6|   � 5%   
   $��4��6    5&      �� 5'      �� 5(      .+�5*      �� -   5        $ 	LoginTbox��5*      $ Логин*��6)   $
��20px(�6E   $ Center=�6U   $
��40px��6l   �� 5+      -   5        $ PassTbox��5+      $ Пароль*��6(   $
��20px(�6E   $ Center=�6U   $
��40px��6l   $��1��6z   5,      �� 5-   
   -   5        $ 	GorodTbox��5-      $ Город*��6%   $
��20px(�6A   $ Center=�6Q   $
��40px��6h   $��5��6v   �� 5.   
   -   5        $ 
StreetTbox��5.      $ Улица*��6&   $
��20px(�6B   $ Center=�6R   $
��40px��6i   $��6��6w   � 5/   
   $��7��6    50      �� 51      �� 52      .+�54      �� -	   5        $ DomTbox��54      $ Дом*��6'   $
��20px(�6A   $ Center=�6Q   $
��40px��6h   �� 55      -
   5        $ KvartiraTbox��55      $��1��6,   $ Квартира��6<   $
��20px(�6Z   $ Center=�6j   $
��40px��6�   56      �� 57   
   -   5        $ ZaregBtm��57      $*��$Зарегестрироваться��6#   $
��25px(�6@   $
��50px��6P   $��8��6^   6k   58      59      