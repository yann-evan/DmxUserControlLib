   M S B A M L   `   `   `  ����L  HDmxUserControlLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DmxUserControlLibDmxUserControlLib  5      )    #DmxUserControlLib.ChannelController   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:DmxUserControlLib     5      
�������.��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� -   5         ��Name$ channelNumberLB��5      $��0��6)   $��0��66   $��Center=�6B   $��Center=�6]   $��5q�6z   �� 5   
   -   5         ��Name$ valueTB��5      $��1��6#   $��50��60   $��10q�6;   $��0��6G   6P   �� 5   
   -   5         ��Name$ DimmerSB��5      $��2��6&   $��Center=�63   $	��200��6P   $��10q�6]    � Minimum$ 0Q�6i    � Maximum$	 255Q�6u    � Value$	 255Q�6�    � SmallChange$ 1Q�6�    � LargeChange$ 10Q�6�   5      5      