   M S B A M L   `   `   `  ����G  CFrontEndMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FrontEndMainFrontEndMain  5   	   (    "FrontEndMain.CreateQuote_Cartridge   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FrontEndMain     5   	   -   5          � Title$  Create Quote - Cartridge��5   	   $	��600��6*   $	��950��67    � WindowStartupLocation$ Manual=�5	   	    � Left$	 165��5
   	   
 � Top$ 55��6    � 
ResizeMode$ CanMinimize=�5   	   ���	#FFE5E6E4.��5      � .+�5   
   �� $
��Left=�6   $��81��6/   $	��Top=�6;   $	��944��6S   ���	#FFEAD0BF$��0��6p   �� 5   
   $
��Left=�6   $
��Wrap=�6/   $��Generate��6C   $	��Top=�6S   $��36(�6k   $��Century Gothic)�6y   $
��Bold"�6�   $��Italic$�6�   $	��178��6�   $��11,0,0,0q�6�   �� 5   
   $
��Left=�6   $��	12,31,0,0q�6/   $
��Wrap=�6B   $��	New Quote��6V   $	��Top=�6g   $��28(�6   $��Century Gothic)�6�   $
��Bold"�6�   $��Italic$�6�   $	��178��6�   �� 5   
   $
��Left=�6   $
��Wrap=�6/   $��	Cartridge��6C   $	��Top=�6T   $��48(�6l   $��Century Gothic)�6z   $
��Bold"�6�   $��Italic$�6�   $	��350��6�   $��
584,12,0,0q�6�    �� TextAlignment$ Right=�6�   �� 5   
   $
��Left=�6   $��	10,96,0,0q�6/   $
��Wrap=�6B   $��	Customer:��6V   $	��Top=�6g   $��18(�6   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 5   
   $
��Left=�6   $��-25,189,0,0q�6/   $
��Wrap=�6D   $��
Quantities��6X   $	��Top=�6j   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $��91��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$	 -90Q�6&   T� 5      5      5      �� 5   
   -   5         ��Name$ 
myComboBox��5   8   $
��Left=�6L   $��	8,119,0,0q�6g   $	��Top=�6z   $	��193��6�   $��23��6�   $��0q�6�   $��14(�6�   6�   �� 5   
   -   5        	 ��Name$	 tbQty1��5   7   $
��Left=�6G   $��23��6b   $��
41,147,0,0q�6n   
 �� TextWrapping$

 Wrap=�6�   $	��Top=�6�   $��85��6�   
�������$��14(�6�   6�   �� 5   
   -   5        $	 tbQty2��5   7   $
��Left=�6G   $��23��6b   $��
41,175,0,0q�6n   $

 Wrap=�6�   $	��Top=�6�   $��85��6�   
�������$��14(�6�   6�   �� 5   
   -   5        $	 tbQty3��5   7   $
��Left=�6G   $��23��6b   $��
41,203,0,0q�6n   $

 Wrap=�6�   $	��Top=�6�   $��85��6�   
�������$��14(�6�   6�   �� 5    
   -   5        $	 tbQty4��5    7   $
��Left=�6G   $��23��6b   $��
41,231,0,0q�6n   $

 Wrap=�6�   $	��Top=�6�   $��85��6�   
�������$��14(�6�   6�   �� 5!   
   -   5         ��Name$	 lq1��5!      $
��Left=�6!   $��126,151,0,0q�6<   $
��Wrap=�6Q   $	��Top=�6�   $��14(�6�   $��Century Gothic)�6�   $��75��6�   $��Italic$�6�   $ Right=�6�   ��6e   �� *lq1+ �� Mode$ TwoWay=�6�   �� 5"   
   -   5        $	 lq2��5"      $
��Left=�6!   $��126,179,0,0q�6<   $
��Wrap=�6Q   $	��Top=�6�   $��14(�6�   $��Century Gothic)�6�   $��75��6�   $��Italic$�6�   $ Right=�6�   ��6e   �� *lq2+$ TwoWay=�6�   �� 5#   
   -	   5        $	 lq3��5#      $
��Left=�6!   $��126,207,0,0q�6<   $
��Wrap=�6Q   $	��Top=�6�   $��14(�6�   $��Century Gothic)�6�   $��75��6�   $��Italic$�6�   $ Right=�6�   ��6e   �� *lq3+$ TwoWay=�6�   �� 5$   
   -
   5        $	 lq4��5$      $
��Left=�6!   $��126,235,0,0q�6<   $
��Wrap=�6Q   $	��Top=�6�   $��14(�6�   $��Century Gothic)�6�   $��75��6�   $��Italic$�6�   $ Right=�6�   ��6e   �� *lq4+$ TwoWay=�6�   �� 5%   
   -   5        $ lMulti��5%      $
��Left=�6$   $��126,101,0,0q�6?   $
��Wrap=�6T   $	��Top=�6�   $��14(�6�   $��Century Gothic)�6�   $��75��6�   $��Italic$�6�   $ Right=�6�   ��6h   �� *lMulti+$ TwoWay=�6�   �� 5&   
   -   5        $ cmbDiameter��5&   8   $
��Left=�6M   $��232,119,0,0q�6h   $	��Top=�6}   $	��193��6�   $��23��6�   $��0q�6�   $��14(�6�   �� 5'   
   $
��Left=�6   $��
232,96,0,0q�6/   $
��Wrap=�6C   $��	Diameter:��6W   $	��Top=�6h   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 5(   
   $
��Left=�6   $��232,148,0,0q�6/   $
��Wrap=�6D   $��Length:��6X   $	��Top=�6g   $��18(�6   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 5)   
   -   5        $	 tbLength��5)   7   $
��Left=�6I   $��23��6d   $��232,170,0,0q�6p   $

 Wrap=�6�   $	��Top=�6�   $	��193��6�   
�������$��14(�6�   6�   �� 5*   
   -   5        $ cmbTermStyle��5*   8   $
��Left=�6N   $��232,219,0,0q�6i   $	��Top=�6~   $	��193��6�   $��23��6�   $��0q�6�   $��14(�6�   �� 5+   
   $
��Left=�6   $��232,196,0,0q�6/   $
��Wrap=�6D   $��Termination Style:��6X   $	��Top=�6r   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 5,   
   -   5        $	 tbLeads��5,   7   $
��Left=�6H   $��23��6c   $��232,269,0,0q�6o   $

 Wrap=�6�   $	��Top=�6�   $��92��6�   
�������$��14(�6�   6�   �� 5-   
   $
��Left=�6   $��232,247,0,0q�6/   $
��Wrap=�6D   $��Leads:��6X   $	��Top=�6f   $��18(�6~   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 5.   
   -   5        $	 	tbLeadCov��5.   7   $
��Left=�6J   $��23��6e   $��333,269,0,0q�6q   $

 Wrap=�6�   $	��Top=�6�   $��92��6�   
�������$��14(�6�   6�   �� 5/   
   $
��Left=�6   $��333,247,0,0q�6/   $
��Wrap=�6D   $��	Covering:��6X   $	��Top=�6i   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $��87��6�   �� 50   
   $
��Left=�6   $��
460,97,0,0q�6/   $
��Wrap=�6C   $��Labor Multiplier:��6W   $	��Top=�6p   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 51   
   $
��Left=�6   $��232,300,0,0q�6/   $
��Wrap=�6D   $��Watts:��6X   $	��Top=�6f   $��18(�6~   $��Century Gothic)�6�   $
��Bold"�6�   $��92��6�   �� 52   
   $
��Left=�6   $��333,300,0,0q�6/   $
��Wrap=�6D   $��Volts:��6X   $	��Top=�6f   $��18(�6~   $��Century Gothic)�6�   $
��Bold"�6�   $��92��6�   �� 53   
   $
��Left=�6   $��460,196,0,0q�6/   $
��Wrap=�6D   $��Special Notes:��6X   $	��Top=�6n   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 54   
   -   5        $	 tbWatts��54   7   $
��Left=�6H   $��23��6c   $��232,322,0,0q�6o   $

 Wrap=�6�   $	��Top=�6�   $��92��6�   
�������$��14(�6�   6�   �� 55   
   -   5        $	 tbVolts��55   7   $
��Left=�6H   $��23��6c   $��333,322,0,0q�6o   $

 Wrap=�6�   $	��Top=�6�   $��92��6�   
�������$��14(�6�   6�   �� 56   
   -   5        $	 tbLabor��56   7   $
��Left=�6H   $��23��6c   $��460,119,0,0q�6o   $

 Wrap=�6�   $	��Top=�6�   $	��193��6�   
�������$��14(�6�   6�   �� 57   
   -   5        $	 tbManualAdder��57   7   $
��Left=�6N   $��23��6i   $��460,170,0,0q�6u   $

 Wrap=�6�   $	��Top=�6�   $	��193��6�   
�������$��14(�6�   6�   �� 58   
   -   5        $	 
tbSpecials��58   7   $
��Left=�6K   $	��126��6f   $��460,219,0,0q�6s   $

 Wrap=�6�   $	��Top=�6�   $	��331��6�   
�������$��14(�6�   6�   	� 5;   
   -   5         	�Name$ rdoSMT��5;      $��SMT Pricing��6&   $
��Left=�6<   $��
41,269,0,0q�6W   $	��Top=�6k   $��14(�6�    d� 	IsChecked$
 TrueY�6�   6�   	� 5<   
   -   5        $ rdo5DAY��5<      $��5-DAY Pricing��6'   $
��Left=�6?   $��
41,286,0,0q�6Z   $	��Top=�6n   $��14(�6�   6�   	� 5=   
   -   5        $ rdoHOT��5=      $��HOT Pricing��6&   $
��Left=�6<   $��
41,303,0,0q�6W   $	��Top=�6k   $��14(�6�   6�   �� 5>   
   -   5         ��Name$ btnPrecalculate��5>      $��Precalculate��6*   $
��Left=�6A   $��653,523,0,0q�6\   $	��Top=�6q   $	��143��6�   $��41��6�   $��18(�6�   $
��Bold"�6�   ���	#FF6A8195$��0q�6�   $ -0.437,-0.929&�6  ���	#FFE5E6E4��6�   Z� 6G  �� 5?   
   -   5        $ btnSaveQuote��5?      $��
Save Quote��6'   $
��Left=�6<   $��793,523,0,0q�6W   $	��Top=�6l   $	��144��6�   $��41��6�   $��18(�6�   $
��Bold"�6�   ���	#FF689564$��0q�6�   $ -0.437,-0.929&�6�   ���	#FFE5E6E4��6�   Z� 6?  �� 5@   
   -   5        $ btnClearForm��5@      $��
Clear Form��6'   $
��Left=�6<   $��148,524,0,0q�6W   $	��Top=�6l   $	��143��6�   $��41��6�   $��18(�6�   $
��Bold"�6�   ���	#FF9C5151$��0q�6�   $ -0.437,-0.929&�6�   ���	#FFE5E6E4��6�   Z� 6?  �� 5A   
   -   5        $ btnClose��5A      $��Close��6#   $
��Left=�63   $��
10,524,0,0q�6N   $	��Top=�6b   $	��141��6z   $��41��6�   $��18(�6�   $
��Bold"�6�   ���	#FFCFCCC7$��0q�6�   $ -0.437,-0.929&�6�   
���   ���6�   Z� 61  �� 5B   
   $
��Left=�6   $��460,148,0,0q�6/   $
��Wrap=�6D   $��Manual Adder:��6X   $	��Top=�6m   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 5C   
   $
��Left=�6   $��796,473,0,0q�6/   $
��Wrap=�6D   $
��SMT:��6X   $	��Top=�6d   $��18(�6|   $��Century Gothic)�6�   $
��Bold"�6�   $	��148��6�   �� 5D   
   -   5        $	 tbSMT��5D      $
��Left=�6!   $��23��6<   $��796,495,0,0q�6H   $

 Wrap=�6]   $	��Top=�6q   $	��138��6�   
�������$��14(�6�   6�   �� 5E   
   -   5         ��Name$ lbAdders��5E      $
��Left=�6$   $��76��6?   $��460,370,0,0q�6K   $	��Top=�6`   $	��331��6x   
���������5F      �� 5G      .R�5H      � .+�5I      �� $��14(�6?   $��0,0,0,0q�6M   ��6$   �� *	AdderName+6M   5J      5K      5M      �� 5N   
   $
��Left=�6   $��460,348,0,0q�6/   $
��Wrap=�6D   $��Adders:��6X   $	��Top=�6g   $��18(�6   $��Century Gothic)�6�   $
��Bold"�6�   $��94��6�   �� 5O   
   -   5        $ btnAdd��5O      $��+��6!   $
��Left=�6-   $��768,350,0,0q�6H   $	��Top=�6]   $��23��6u   $��20��6�   $��12(�6�   ���	#FFCFCCC7���	#FFCFCCC7$��0q�6�   $ -0.437,-0.929&�6�   $
��Bold"�6  6  �� 5P   
   -    5        $	 lPN��5P      $
��Left=�6!   $��
242,31,0,0q�6<   $
��Wrap=�6P   $	��Top=�6�   $��28(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $��Italic$�6�   $	��337��6�   ��6d   �� *lPN+$ TwoWay=�6�   �� 5Q   
   -!   5        $ 	btnDelAdd��5Q       � ToolTip$ Clear All Adders!��6$   $��x��6@   $
��Left=�6L   $��742,347,0,0q�6g   $	��Top=�6|   $��29��6�   $��26��6�   $��12(�6�   ���	#FF9C5151$��0q�6�   $ -0.437,-0.929&�6�   ���	#FFE5E6E4��6�   Z� 69  5S      5T      