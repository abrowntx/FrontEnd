   M S B A M L   `   `   `  ����G  CFrontEndMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FrontEndMainFrontEndMain  5   	   (    "FrontEndMain.CreateQuote_MicaStrip   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FrontEndMain     5   	   -   5          � Title$  CreateQuote_MicaStrip��5   	   $	��600��6'   $	��950��64    � WindowStartupLocation$ Manual=�5	   	    � Left$	 165��5
   	   
 � Top$ 55��6    � 
ResizeMode$ CanMinimize=�5   	   ���	#FFE5E6E4.��5      � .+�5   
   �� $
��Left=�6   $��82��6/   $	��Top=�6;   $	��944��6S   ���	#FFC0D8C8$��0��6p    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 0Q�6#      	Direction$	 270Q�62      ShadowDepth$ 0Q�6B   	   Color$	 	#7F000000��6R   5      �� 5   
   $
��Left=�6   $
��Wrap=�6/   $��Generate��6C   $	��Top=�6S   $��36(�6k   $��Century Gothic)�6y   $
��Bold"�6�   $��Italic$�6�   $	��178��6�   $��11,0,0,0q�6�   �� 5   
   $
��Left=�6   $��	12,31,0,0q�6/   $
��Wrap=�6B   $��	New Quote��6V   $	��Top=�6g   $��28(�6   $��Century Gothic)�6�   $
��Bold"�6�   $��Italic$�6�   $	��178��6�   �� 5   
   $
��Left=�6   $
��Wrap=�6/   $��
Mica Strip��6C   $	��Top=�6U   $��48(�6m   $��Century Gothic)�6{   $
��Bold"�6�   $��Italic$�6�   $	��350��6�   $��
584,12,0,0q�6�   
 �� TextAlignment$
 Right=�6�   �� 5   
   $
��Left=�6   $��	10,96,0,0q�6/   $
��Wrap=�6B   $��	Customer:��6V   $	��Top=�6g   $��18(�6   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 5   
   $
��Left=�6   $��-25,189,0,0q�6/   $
��Wrap=�6D   $��
Quantities��6X   $	��Top=�6j   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $��91��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$	 -90Q�6&   T� 5      5      5      �� 5    
   -   5         ��Name$ 
myComboBox��5    9   $
��Left=�6M   $��	8,119,0,0q�6h   $	��Top=�6{   $	��193��6�   $��23��6�   $��0q�6�   $��14(�6�   6�   �� 5!   
   -   5         ��Name$ tbQty1��5!   8   $
��Left=�6H   $��23��6c   $��
41,147,0,0q�6o    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��85��6�   
�������$��14(�6�   6�   �� 5"   
   -   5        $ tbQty2��5"   8   $
��Left=�6H   $��23��6c   $��
41,175,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $��85��6�   
�������$��14(�6�   6�   �� 5#   
   -   5        $ tbQty3��5#   8   $
��Left=�6H   $��23��6c   $��
41,203,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $��85��6�   
�������$��14(�6�   6�   �� 5$   
   -   5        $ tbQty4��5$   8   $
��Left=�6H   $��23��6c   $��
41,231,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $��85��6�   
�������$��14(�6�   6�   �� 5%   
   -   5         ��Name$ lMulti��5%      $
��Left=�6$   $��126,101,0,0q�6?   $
��Wrap=�6T   $	��Top=�6�   $��14(�6�   $��Century Gothic)�6�   $��75��6�   $��Italic$�6�   $
 Right=�6�   ��6h   �� *lMulti+ �� Mode$ TwoWay=�6�   	� 5&   
   -   5         	�Name$ rdoSMT��5&      $��SMT Pricing��6&   $
��Left=�6<   $��
41,269,0,0q�6W   $	��Top=�6k   $��14(�6�    d� 	IsChecked$
 TrueY�6�   6�   	� 5'   
   -	   5        $ rdo5DAY��5'      $��5-DAY Pricing��6'   $
��Left=�6?   $��
41,286,0,0q�6Z   $	��Top=�6n   $��14(�6�   6�   	� 5(   
   -
   5        $ rdoHOT��5(      $��HOT Pricing��6&   $
��Left=�6<   $��
41,303,0,0q�6W   $	��Top=�6k   $��14(�6�   6�   �� 5)   
   $
��Left=�6   $��
41,341,0,0q�6/   $
��Wrap=�6C   $��Heater Info:��6W   $	��Top=�6k   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��148��6�   �� 5*   
   $
��Left=�6   $��
-8,368,0,0q�6/   $
��Wrap=�6C   $��Watt Density:��6W   $	��Top=�6l   $��14(�6�   $��Century Gothic)�6�   $	��148��6�   $
 Right=�6�   $
��Bold"�6�   �� 5+   
   $
��Left=�6   $��
-8,390,0,0q�6/   $
��Wrap=�6C   $��	Amperage:��6W   $	��Top=�6h   $��14(�6�   $��Century Gothic)�6�   $	��148��6�   $
 Right=�6�   $
��Bold"�6�   �� 5,   
   -   5        $	 lq1��5,      $
��Left=�6!   $��126,151,0,0q�6<   $
��Wrap=�6Q   $	��Top=�6�   $��14(�6�   $��Century Gothic)�6�   $��75��6�   $��Italic$�6�   $
 Right=�6�   ��6e   �� *lq1+$ TwoWay=�6�   �� 5-   
   -   5        $	 lq2��5-      $
��Left=�6!   $��126,179,0,0q�6<   $
��Wrap=�6Q   $	��Top=�6�   $��14(�6�   $��Century Gothic)�6�   $��75��6�   $��Italic$�6�   $
 Right=�6�   ��6e   �� *lq2+$ TwoWay=�6�   �� 5.   
   -   5        $	 lq3��5.      $
��Left=�6!   $��126,207,0,0q�6<   $
��Wrap=�6Q   $	��Top=�6�   $��14(�6�   $��Century Gothic)�6�   $��75��6�   $��Italic$�6�   $
 Right=�6�   ��6e   �� *lq3+$ TwoWay=�6�   �� 5/   
   -   5        $	 lq4��5/      $
��Left=�6!   $��126,235,0,0q�6<   $
��Wrap=�6Q   $	��Top=�6�   $��14(�6�   $��Century Gothic)�6�   $��75��6�   $��Italic$�6�   $
 Right=�6�   ��6e   �� *lq4+$ TwoWay=�6�   �� 50   
   -   5        $
 lWsi��50      $
��Left=�6"   $��145,368,0,0q�6=   $	��Top=�6�   $��14(�6�   $��Century Gothic)�6�   $��83��6�   ��6R   �� *lWsi+$ TwoWay=� �� StringFormat$ N2��6�   �� 51   
   -   5        $ lAmps��51      $
��Left=�6#   $��145,390,0,0q�6>   $	��Top=�6�   $��14(�6�   $��Century Gothic)�6�   $��83��6�   ��6S   �� *lAmps+$ TwoWay=�$ N2��6�   �� 52   
   $
��Left=�6   $��232,146,0,0q�6/   $
��Wrap=�6D   $��	Segments:��6X   $	��Top=�6i   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 53   
   $
��Left=�6   $��
232,92,0,0q�6/   $
��Wrap=�6C   $��Lockup Style:��6W   $	��Top=�6l   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 54   
   $
��Left=�6   $��232,197,0,0q�6/   $
��Wrap=�6D   $��Width:��6X   $	��Top=�6f   $��18(�6~   $��Century Gothic)�6�   $
��Bold"�6�   $��94��6�   �� 55   
   $
��Left=�6   $��331,197,0,0q�6/   $
��Wrap=�6D   $��Length:��6X   $	��Top=�6g   $��18(�6   $��Century Gothic)�6�   $
��Bold"�6�   $��94��6�   �� 56   
   $
��Left=�6   $��
454,96,0,0q�6/   $
��Wrap=�6C   $��Termination Style:��6W   $	��Top=�6q   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 57   
   $
��Left=�6   $��454,148,0,0q�6/   $
��Wrap=�6D   $��Lead Length:��6X   $	��Top=�6l   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 58   
   $
��Left=�6   $��454,197,0,0q�6/   $
��Wrap=�6D   $��Lead Covering Length:��6X   $	��Top=�6u   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��203��6�   �� 59   
   $
��Left=�6   $��232,247,0,0q�6/   $
��Wrap=�6D   $��Height:��6X   $	��Top=�6g   $��18(�6   $��Century Gothic)�6�   $
��Bold"�6�   $��94��6�   �� 5:   
   $
��Left=�6   $��
681,96,0,0q�6/   $
��Wrap=�6C   $��Holes:��6W   $	��Top=�6e   $��18(�6}   $��Century Gothic)�6�   $
��Bold"�6�   $��94��6�   �� 5;   
   $
��Left=�6   $��681,148,0,0q�6/   $
��Wrap=�6D   $��Manual Labor Multi:��6X   $	��Top=�6s   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 5<   
   $
��Left=�6   $��681,247,0,0q�6/   $
��Wrap=�6D   $��Special Notes:��6X   $	��Top=�6n   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 5=   
   -   5        $ 	cmbLockup��5=   9   $
��Left=�6L   $��232,119,0,0q�6g   $	��Top=�6|   $	��193��6�   $��23��6�   $��0q�6�   $��14(�6�   6�   �� 5>   
   -   5        $ tbSeg��5>   8   $
��Left=�6G   $��23��6b   $��232,169,0,0q�6n   $
 Wrap=�6�   $	��Top=�6�   $	��193��6�   
�������$��14(�6�   6�   �� 5?   
   -   5        $ tbWidth1��5?   7   $
��Left=�6I   $��23��6d   $��232,219,0,0q�6p   $
 Wrap=�6�   $	��Top=�6�   $��95��6�   
�������$��14(�6�   6  �� 5@   
   -   5        $ tbLength��5@   7   $
��Left=�6I   $��23��6d   $��330,219,0,0q�6p   $
 Wrap=�6�   $	��Top=�6�   $��95��6�   
�������$��14(�6�   6
  �� 5A   
   -   5        $ tbHeight��5A   7   $
��Left=�6I   $��23��6d   $��232,269,0,0q�6p   $
 Wrap=�6�   $	��Top=�6�   $��95��6�   
�������$��14(�6�   6
  �� 5B   
   -   5        $ tbWatts��5B   7   $
��Left=�6H   $��23��6c   $��232,322,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $��95��6�   
�������$��14(�6�   6	  �� 5C   
   -   5        $ tbVolts��5C   7   $
��Left=�6H   $��23��6c   $��330,322,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $��95��6�   
�������$��14(�6�   6	  �� 5D   
   -   5        $ cmbTermStyle��5D   8   $
��Left=�6N   $��454,119,0,0q�6i   $	��Top=�6~   $	��193��6�   $��23��6�   $��0q�6�   $��14(�6�   �� 5E   
   -   5        $ tbLeads��5E   7   $
��Left=�6H   $��23��6c   $��454,170,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $	��193��6�   
�������$��14(�6�   6�   �� 5F   
   -   5        $ 	tbLeadCov��5F   7   $
��Left=�6J   $��23��6e   $��454,219,0,0q�6q   $
 Wrap=�6�   $	��Top=�6�   $	��193��6�   
�������$��14(�6�   6�   �� 5G   
   -   5        $ tbHoles��5G   7   $
��Left=�6H   $��23��6c   $��681,118,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $��95��6�   
�������$��14(�6�   6�   �� 5H   
   -   5        $ tbMulti��5H   7   $
��Left=�6H   $��23��6c   $��681,170,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $	��193��6�   
�������$��14(�6�   6�   �� 5I   
   -   5        $ tbManualAdder��5I   7    � ToolTip$k eEnter a manual additional dollar amount to be applied per heater after quantity calculations are done��6N   $
��Left=�6�   $��23��6�   $��681,219,0,0q�6�   $
 Wrap=�6�   $	��Top=�6  $	��193��6&  
�������$��14(�6F  6T  �� 5J   
   -   5        $ 
tbSpecials��5J   7   $
��Left=�6K   $	��129��6f   $��681,269,0,0q�6s   $
 Wrap=�6�   $	��Top=�6�   $	��253��6�   
�������$��14(�6�   6�   �� 5K   
   $
��Left=�6   $��681,197,0,0q�6/   $
��Wrap=�6D   $��Additional Costs:��6X   $	��Top=�6q   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��203��6�   �� 5L   
   -   5         ��Name$ lbAdders��5L      $
��Left=�6$   $	��128��6?   $��454,270,0,0q�6L   $	��Top=�6a   $	��193��6y   
���������5M      �� 5N      .R�5O      � .+�5P      �� $��14(�6?   $��0,0,0,0q�6M   ��6$   �� *	AdderName+6M   5Q      5R      5T      �� 5U   
   $
��Left=�6   $��454,248,0,0q�6/   $
��Wrap=�6D   $��Adders:��6X   $	��Top=�6g   $��18(�6   $��Century Gothic)�6�   $
��Bold"�6�   $��94��6�   �� 5V   
   -    5         ��Name$ btnAdd��5V      $��+��6!   $
��Left=�6-   $��624,250,0,0q�6H   $	��Top=�6]   $��23��6u   $��20��6�   $��12(�6�   ���	#FFCFCCC7���	#FFCFCCC7$��0q�6�   $ -0.437,-0.929&�6�   $
��Bold"�6  �� 5W   
   -!   5        $ 	btnDelAdd��5W      $ Clear All Adders!��6$   $��x��6@   $
��Left=�6L   $��595,247,0,0q�6g   $	��Top=�6|   $��29��6�   $��26��6�   $��12(�6�   ���	#FF9C5151$��0q�6�   $ -0.437,-0.929&�6�   ���	#FFE5E6E4��6�   Z� 69  �� 5X   
   $
��Left=�6   $��232,300,0,0q�6/   $
��Wrap=�6D   $��Watts:��6X   $	��Top=�6f   $��18(�6~   $��Century Gothic)�6�   $
��Bold"�6�   $��94��6�   �� 5Y   
   $
��Left=�6   $��331,300,0,0q�6/   $
��Wrap=�6D   $��Volts:��6X   $	��Top=�6f   $��18(�6~   $��Century Gothic)�6�   $
��Bold"�6�   $��94��6�   �� 5Z   
   -"   5        $ btnPrecalculate��5Z      $��Precalculate��6*   $
��Left=�6A   $��653,523,0,0q�6\   $	��Top=�6q   $	��143��6�   $��41��6�   $��18(�6�   $
��Bold"�6�   ���	#FF6A8195$��0q�6�   $ -0.437,-0.929&�6  ���	#FFE5E6E4��6�   Z� 6G  �� 5[   
   -#   5        $ btnSaveQuote��5[      $��
Save Quote��6'   $
��Left=�6<   $��793,523,0,0q�6W   $	��Top=�6l   $	��144��6�   $��41��6�   $��18(�6�   $
��Bold"�6�   ���	#FF689564$��0q�6�   $ -0.437,-0.929&�6�   ���	#FFE5E6E4��6�   Z� 6?  �� 5\   
   -$   5        $ btnClearForm��5\      $��
Clear Form��6'   $
��Left=�6<   $��150,524,0,0q�6W   $	��Top=�6l   $	��143��6�   $��41��6�   $��18(�6�   $
��Bold"�6�   ���	#FF9C5151$��0q�6�   $ -0.437,-0.929&�6�   ���	#FFE5E6E4��6�   Z� 6?  �� 5]   
   -%   5        $ btnClose��5]      $��Close��6#   $
��Left=�63   $��
12,523,0,0q�6N   $	��Top=�6b   $	��141��6z   $��41��6�   $��18(�6�   $
��Bold"�6�   ���	#FFCFCCC7$��0q�6�   $ -0.437,-0.929&�6�   ��6�   Z� 6  �� 5^   
   $
��Left=�6   $��796,473,0,0q�6/   $
��Wrap=�6D   $
��SMT:��6X   $	��Top=�6d   $��18(�6|   $��Century Gothic)�6�   $
��Bold"�6�   $	��148��6�   �� 5_   
   -&   5        $ tbSMT��5_      $
��Left=�6!   $��23��6<   $��796,495,0,0q�6H   $
 Wrap=�6]   $	��Top=�6q   $	��138��6�   
�������$��14(�6�   6�   �� 5`   
   -'   5        $	 lPN��5`      $
��Left=�6!   $��
242,31,0,0q�6<   $
��Wrap=�6P   $	��Top=�6�   $��28(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $��Italic$�6�   $	��337��6�   ��6d   �� *lPN+$ TwoWay=�6�   5b      5c      