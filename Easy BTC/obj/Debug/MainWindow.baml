   M S B A M L   `   `   `  ����C  ?Easy BTC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Easy_BTCEasy_BTC  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5   	       Easy_BTC.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Easy_BTC     5   	   Bcol2clr-namespace:System.Collections;assembly=mscorlib     5   	   -   5          � Title$  Easy BTC��5	   	   $��2254.831��6   $��3205.344��6,    � WindowState$ 	Maximized=�6T   .��5
      ]� $��0,0,0.2,-0.4q�6   .+�5   
   � $��Stretch=�6   $��-9,0,0,-19.4q�6-   $
��3220��6C    � ColumnDefinitions 5      �� 5      $	��17* �6#   �� 5      $
��622* �6#   �� 5      $��2581* �6#   .+�5      �� -   5         ��Name$ txtFilterPoloniex��5      $
��Left=�61   $��19��6L   $��42.2,11,0,0q�6X    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $��82��6�   $��1��6�   �� 5      $��FIlter:��6   $
��Left=�6&   $��10,7,0,0q�6A   $	��Top=�6S   $��23��6k   $��56��6w   $��2��6�   	� 5      -   5        $
��5min��5      $��1��6)   $
��Left=�69   $��226.2,14,0,0q�6T   $	��Top=�6j    	� 	GroupName$ radiobtnSort��6�    d� 	IsChecked$
 TrueY�6�   $��14��6�   $��46��6�   	� 5      -   5        $��15min��5      $��1��6*   $
��Left=�6:   $��276.2,15,0,0q�6U   $	��Top=�6k   $ radiobtnSort��6�   $��15��6�   $��52��6�   	� 5      -   5        $��30min��5      $��1��6*   $
��Left=�6:   $��335.2,16,0,0q�6U   $	��Top=�6k   $ radiobtnSort��6�   $��15��6�   $��52��6�   �� 5      $��Visible=�6   ��. 
���  ��$��0,33,129.2,49q�6w   $��2��6�   .��5      &   System.Windows.Controls.DataGrid  -   5        $��commonPoloniexDataGrid��5   7      AutoGenerateColumns .  $
��Left=�6U   $
��2164��6p   $	��Top=�6~   $	��491��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Coin��6-   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6;   �� *Name+6V     5      $	 Price��6-   
 6<   �� *CurrentPrice+6_     5      $	 Low 24hr��6-   
 6?   �� *	Low24hr+6]     5      $	 %(Poloniex)��6-   
 6B   ��  �� Path$ PercentChangePoloniex� �� StringFormat$
 #.##��6�     5      $	 % 5min��6-   
 6=   �� $ PercentChange5min�$ ###.##��   	CellStyle 5      �� 5    "    �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6(    �� Triggers 5!   &   �� 5"   *    �� Binding 66   �� *TriggerColor5min+ �� Value Red6[   .a�5#   .   ��  �� Property � �� �� Value
 �����6K   5$   +   �� 5%   *    66   �� *TriggerColor5min+
 Orange6[   .a�5&   .   ��  � ��
 ��� �6K   5'   +   �� 5(   *    66   �� *TriggerColor5min+	 Green6[   .a�5)   .   ��  � ��
 ����6K   5*   +   5,   #      ElementStyle 5.      �� 5/   "   " ��6(   .�50   &   ��  � ��$ Right=�6L   51   #   53        54      $	 % 15min��6-   
 6>   �� $ PercentChange15min�$ ###.##�� 55      �� 56   "   "  6(    57   &   �� 58   *    66   �� *TriggerColor15min+ Red6\   .a�59   .   ��  � ��
 �����6K   5:   +   �� 5;   *    66   �� *TriggerColor15min+
 Orange6\   .a�5<   .   ��  � ��
 ��� �6K   5=   +   �� 5>   *    66   �� *TriggerColor15min+	 Green6\   .a�5?   .   ��  � ��
 ����6K   5@   +   5B   #    5D      �� 5E   "   " ��6(   .�5F   &   ��  � ��$ Right=�6L   5G   #   5I        5J      $	 % 30min��6-   
 6>   �� $ PercentChange30min�$ ###.##�� 5K      �� 5L   "   "  6(    5M   &   �� 5N   *    66   �� *TriggerColor30min+ Red6\   .a�5O   .   ��  � ��
 �����6K   5P   +   �� 5Q   *    66   �� *TriggerColor30min+
 Orange6\   .a�5R   .   ��  � ��
 ��� �6K   5S   +   �� 5T   *    66   �� *TriggerColor30min+	 Green6\   .a�5U   .   ��  � ��
 ����6K   5V   +   5X   #    5Z      �� 5[   "   " ��6(   .�5\   &   ��  � ��$ Right=�6L   5]   #   5_      5a      5b      �� 5c      $��Sorting by:��6   $��1��6*   $
��Left=�6:   $��159.2,7,0,0q�6U   $	��Top=�6j   $��26��6�   $��67��6�     5f      -   5        $��commonBittrexDataGrid��5f       .  $��2��6P   $
��Left=�6`   $
��2159��6{   $	��Top=�6�   $	��436��6�   $��128.8,37,0,0q�6�    5g        5h      $
	 Coin��6)   
 67   �� *Name+6R     5i      $	 Price��6)   
 68   �� *CurrentPrice+6[     5j      $	 Low 24hr��6)   
 6;   �� *	Low24hr+6Y     5k      $	 % 5min��6)   
 69   �� $ PercentChange5min�$ ###.##�� 5l      �� 5m      "  6$    5n   "   �� 5o   &    62   �� *TriggerColor5min+ Red6W   .a�5p   *   ��  � ��
 �����6G   5q   '   �� 5r   &    62   �� *TriggerColor5min+
 Orange6W   .a�5s   *   ��  � ��
 ��� �6G   5t   '   �� 5u   &    62   �� *TriggerColor5min+	 Green6W   .a�5v   *   ��  � ��
 ����6G   5w   '   5y       5{      �� 5|      " ��6$   .�5}   "   ��  � ��$ Right=�6H   5~      5�        5�      $	 % 15min��6)   
 6:   �� $ PercentChange15min�$ ###.##�� 5�      �� 5�      "  6$    5�   "   �� 5�   &    62   �� *TriggerColor15min+ Red6X   .a�5�   *   ��  � ��
 �����6G   5�   '   �� 5�   &    62   �� *TriggerColor15min+
 Orange6X   .a�5�   *   ��  � ��
 ��� �6G   5�   '   �� 5�   &    62   �� *TriggerColor15min+	 Green6X   .a�5�   *   ��  � ��
 ����6G   5�   '   5�       5�      �� 5�      " ��6$   .�5�   "   ��  � ��$ Right=�6H   5�      5�        5�      $	 % 30min��6)   
 6:   �� $ PercentChange30min�$ ###.##�� 5�      �� 5�      "  6$    5�   "   �� 5�   &    62   �� *TriggerColor30min+ Red6X   .a�5�   *   ��  � ��
 �����6G   5�   '   �� 5�   &    62   �� *TriggerColor30min+
 Orange6X   .a�5�   *   ��  � ��
 ��� �6G   5�   '   �� 5�   &    62   �� *TriggerColor30min+	 Green6X   .a�5�   *   ��  � ��
 ����6G   5�   '   5�       5�      �� 5�      " ��6$   .�5�   "   ��  � ��$ Right=�6H   5�      5�      5�      �� 5�      -   5        $ txtFilterBittrex��5�      $��2��61   $
��Left=�6A   $��23��6\   $��201.8,7,0,0q�6h   $
 Wrap=�6}   $	��Top=�6�   $��72��6�   6�   �� 5�      $��Filter:��6   $��2��6&   $
��Left=�66   $��158.8,6,0,0q�6Q   $	��Top=�6f   $��26��6~   $��38��6�   �� 5�      $��Sorting by:��6   $��2��6*   $
��Left=�6:   $��294.8,5,0,0q�6U   $	��Top=�6j   $��26��6�   $��67��6�   	� 5�      -	   5        $
��5min��5�      $��2��6)   $
��Left=�69   $��361.8,11,0,0q�6T   $	��Top=�6j   $ radiobtnSort2��6�   $
 TrueY�6�   $��15��6�   $��46��6�   	� 5�      -
   5        $��15min��5�      $��2��6*   $
��Left=�6:   $��411.8,12,0,0q�6U   $	��Top=�6k   $ radiobtnSort2��6�   $��15��6�   $��52��6�   	� 5�      -   5        $��30min��5�      $��2��6*   $
��Left=�6:   $��470.8,13,0,0q�6U   $	��Top=�6k   $ radiobtnSort2��6�   $��15��6�   $��52��6�   �� 5�      $��Visible=�6   ��. $��1��6f   $��507.2,33,2476,-20q�6v   $��2��6�   .��5�        -   5        $��successPoloniexDataGrid��5�       .  $��Disabled=�6V   $��1��6�   $
��Left=�6�   $
��2170��6�   $	��Top=�6�   $	��210��6�   $��2��6�    5�        5�      $
	 Coin��6-   
 6;   �� *Name+6V     5�      $	 %��6-   
 68   �� *	Percent+$ ###.##��6k     5�      $
	 Time��6-   
 6;   �� *DateTimeCell+6^   5�      5�      �� 5�      $��Visible=�6   ��. $��579.8,37,1758,0q�6f   $��2��6   .��5�        -   5        $��successBittrexDataGrid��5�       .  $��Disabled=�6U   $��2��6�   $
��Left=�6�   $
��2163��6�   $	��Top=�6�   $	��233��6�    5�        5�      $
	 Coin��6-   
 6;   �� *Name+6V     5�      $	 %��6-   
 68   �� *	Percent+$ ###.##��6k     5�      $
	 Time��6-   
 6;   �� *DateTimeCell+6^   5�      5�      5�      5�      5�      