   M S B A M L   `   `   `  ����I  ETestSolution23, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TestSolution23.ViewsTestSolution23.Views  5   	   $    TestSolution23.Views.ShellView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   4local"clr-namespace:TestSolution23.Views     5   	     � Title$  	ShellView��5   	   $	��600��6   $	��800��6(   $	��800��64   $��Colibri)�5	   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��250 �6   �� 5      $	��250 �6   �� 5      $	��200 �6   �� 5      $��50 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��30 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $	��370 �6   .+�5   
   �� $��0,0,0,1q�6   
���   �$��0��6?   $
��1234��6O   $��1��6f   ._�5      �� $��20(�6    �� TextAlignment$ Center=�6&   '%Построение графиков6R   5       �� 5!   
   $��0 20 0 0q�6   $��20(�6&   $��1��64   $��2��6D   $ Center=�6Q   Выбор csv файла:6z   �� 5"   
   $��0 20 0 0q�6   $��1q�6#   
���   �$��2��6K   $	��234��6[   $��2��6q   $	��440��6~   $��20��6�   $
��Left=�6�   ._�5#      �� $	��440��6   $��20��6$   $
��Left=�60   ��6K   ��  �� Path$ FilePath�5$      �� 5%   
   -   5         ��Name$ BtnOpen��5%      $��0 20 0 0q�6"   $��4��64   $��2��6D   $��30��6Q   $��30��6\   $
��Left=�6h   .��5&      �� .+�5'      �� $��../img/folder.jpg��6   5(      5)      �� 5*   
   -   5        $ LoadChartOne��5*      $��1��6'   $��0 20 0 0q�67   $��3��6I   $	��200��6V   $��30��6b   $��Center=�6n   .��6�   +)Построить гистограмму6�   �� 5+   
   -   5        $ LoadChartTwo��5+      $��2��6'   $��	0 20 20 0q�67   $��3��6J   $	��200��6W   $��30��6c   $��Center=�6o   .��6�   '%Построить диаграмму6�   �� 5,   
   -   5        $ LoadChartThree��5,      $��3��6)   $��0 20 0 0q�69   $��3��6K   $	��200��6X   $��30��6d   $��Center=�6p   .��6�   !Построить график6�   �� 5-   
   -   5         ��Name$ 
ActiveItem��5-   \   $��0 20 0 0q�6   $��4��6+   $��1��68   $��4��6H   6\   5.      5/      