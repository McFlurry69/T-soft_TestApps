   M S B A M L   `   `   `  ����H  DTestSolution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TestSolution1.ViewsTestSolution1.Views  5   	   #    TestSolution1.Views.ShellView   5   	   ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   3local!clr-namespace:TestSolution1.Views     5   	     � Title$  T-Soft test application��5   	   $	��800��6)   $	��800��66   $	��500��6B   $	��800��6Q   $��Colibri)�5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��Auto �6   �� 5      $��40 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   
����ح�.+�5   
   �� $��2��6   $��1��6!   $	��123��61   $��25(�6G    �� TextAlignment$ Center=�6U   86Параметры объекта управления6�   �� 5   
   $��3��6   $��1��6!   $ Center=�61   ��6H   ��  �� Path$ ClientsInfo� �� Mode$ OneWay=�6{   �� 5   
   $��3��6   $��3��6!   $ Center=�61   ��6H   �� $ 
ParamsInfo�$ OneWay=�6z   �� 5    
   $��4��6   $��1��6!   $ Center=�61   $��15(�6H   Параметры из БД6g   �� 5!   
   $��5��6   $��1��6   ��6/   �� $ 	AllParams���5"      �� 5#      .R�5$      �� $��5q�6!   .+�5%      �� $��20(�6$   ��62   �� $ 	ParamName�$ OneWay=��� 5&      $��15(�6$   ��62   �� $ 
ClientName�$ OneWay=�5'      5(      5*      �� 5,   
   $��4��6   $��2��6!   $ Center=�61   $��15(�6H   '%Отправленные данные6k   �� 5/   
   $��5��6   $��2��6   $��20 0 0 0q�6/   ��6C   �� $ ReadedFromServer���50      �� 51      .R�52      �� $��5q�6!   .+�53      �� $��15(�6$   ��62   �� $ 	ParamName�$ OneWay=��� 54      $��10(�6$   ��62   �� $ 
ClientName�$ OneWay=��� 55      $��10(�6$   ��62   �� $ Value�$ OneWay=�56      57      59      �� 5;   
   $��4��6   $��3��6!   $ Center=�61   $��15(�6H   Принятые данные6g   �� 5=   
   $��5��6   $��3��6   $��20 0 0 0q�6/   ��6C   �� $ ReadedFromClient���5>      �� 5?      .R�5@      �� $��5q�6!   .+�5A      �� $��15(�6$   ��62   �� $ 	ParamName�$ OneWay=��� 5B      $��10(�6$   ��62   �� $ 
ClientName�$ OneWay=��� 5C      $��10(�6$   ��62   �� $ Value�$ OneWay=�5D      5E      5G      5H      5I      