   M S B A M L   `   `   `  ���� G  CFrontEndMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FrontEndMainFrontEndMain  (    "FrontEndMain.CreateQuote_MicaStrip   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:FrontEndMain     -     � Title$  CreateQuote_MicaStrip��$	��600��$	��950�� � WindowStartupLocation$ Manual=� � Left$	 165��
 � Top$ 55�� � 
ResizeMode$ CanMinimize=����	#FFE5E6E4.��� .+��� $
��Left=�$��82��$	��Top=�$	��944�����	#FFC0D8C8$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 0Q�   	Direction$	 270Q�   ShadowDepth$ 0Q�	   Color$	 	#7F000000���� $
��Left=�$
��Wrap=�$��Generate��$	��Top=�$��36(�$��Century Gothic)�$
��Bold"�$��Italic$�$	��178��$��11,0,0,0q��� $
��Left=�$��	12,31,0,0q�$
��Wrap=�$��	New Quote��$	��Top=�$��28(�$��Century Gothic)�$
��Bold"�$��Italic$�$	��178���� $
��Left=�$
��Wrap=�$��
Mica Strip��$	��Top=�$��48(�$��Century Gothic)�$
��Bold"�$��Italic$�$	��350��$��
584,12,0,0q�
 �� TextAlignment$
 Right=��� $
��Left=�$��	10,96,0,0q�$
��Wrap=�$��	Customer:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� $
��Left=�$��-25,189,0,0q�$
��Wrap=�$��
Quantities��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$��91�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$	 -90Q�T� �� -    ��Name$ 
myComboBox��$
��Left=�$��	8,119,0,0q�$	��Top=�$	��193��$��23��$��0q�$��14(��� -    ��Name$ tbQty1��$
��Left=�$��23��$��
41,147,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��85��
�������$��14(��� -   $ tbQty2��$
��Left=�$��23��$��
41,175,0,0q�$
 Wrap=�$	��Top=�$��85��
�������$��14(��� -   $ tbQty3��$
��Left=�$��23��$��
41,203,0,0q�$
 Wrap=�$	��Top=�$��85��
�������$��14(��� -   $ tbQty4��$
��Left=�$��23��$��
41,231,0,0q�$
 Wrap=�$	��Top=�$��85��
�������$��14(��� -    ��Name$ lMulti��$
��Left=�$��126,101,0,0q�$
��Wrap=�$	��Top=�$��14(�$��Century Gothic)�$��75��$��Italic$�$
 Right=����� *lMulti+ �� Mode$ TwoWay=�	� -    	�Name$ rdoSMT��$��SMT Pricing��$
��Left=�$��
41,269,0,0q�$	��Top=�$��14(� d� 	IsChecked$
 TrueY�	� -	   $ rdo5DAY��$��5-DAY Pricing��$
��Left=�$��
41,286,0,0q�$	��Top=�$��14(�	� -
   $ rdoHOT��$��HOT Pricing��$
��Left=�$��
41,303,0,0q�$	��Top=�$��14(��� $
��Left=�$��
41,341,0,0q�$
��Wrap=�$��Heater Info:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��148���� $
��Left=�$��
-8,368,0,0q�$
��Wrap=�$��Watt Density:��$	��Top=�$��14(�$��Century Gothic)�$	��148��$
 Right=�$
��Bold"��� $
��Left=�$��
-8,390,0,0q�$
��Wrap=�$��	Amperage:��$	��Top=�$��14(�$��Century Gothic)�$	��148��$
 Right=�$
��Bold"��� -   $	 lq1��$
��Left=�$��126,151,0,0q�$
��Wrap=�$	��Top=�$��14(�$��Century Gothic)�$��75��$��Italic$�$
 Right=����� *lq1+$ TwoWay=��� -   $	 lq2��$
��Left=�$��126,179,0,0q�$
��Wrap=�$	��Top=�$��14(�$��Century Gothic)�$��75��$��Italic$�$
 Right=����� *lq2+$ TwoWay=��� -   $	 lq3��$
��Left=�$��126,207,0,0q�$
��Wrap=�$	��Top=�$��14(�$��Century Gothic)�$��75��$��Italic$�$
 Right=����� *lq3+$ TwoWay=��� -   $	 lq4��$
��Left=�$��126,235,0,0q�$
��Wrap=�$	��Top=�$��14(�$��Century Gothic)�$��75��$��Italic$�$
 Right=����� *lq4+$ TwoWay=��� -   $
 lWsi��$
��Left=�$��145,368,0,0q�$	��Top=�$��14(�$��Century Gothic)�$��83������ *lWsi+$ TwoWay=� �� StringFormat$ N2���� -   $ lAmps��$
��Left=�$��145,390,0,0q�$	��Top=�$��14(�$��Century Gothic)�$��83������ *lAmps+$ TwoWay=�$ N2���� $
��Left=�$��232,146,0,0q�$
��Wrap=�$��	Segments:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� $
��Left=�$��
232,92,0,0q�$
��Wrap=�$��Lockup Style:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� $
��Left=�$��232,197,0,0q�$
��Wrap=�$��Width:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$��94���� $
��Left=�$��331,197,0,0q�$
��Wrap=�$��Length:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$��94���� $
��Left=�$��
454,96,0,0q�$
��Wrap=�$��Termination Style:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� $
��Left=�$��454,148,0,0q�$
��Wrap=�$��Lead Length:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� $
��Left=�$��454,197,0,0q�$
��Wrap=�$��Lead Covering Length:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��203���� $
��Left=�$��232,247,0,0q�$
��Wrap=�$��Height:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$��94���� $
��Left=�$��
681,96,0,0q�$
��Wrap=�$��Holes:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$��94���� $
��Left=�$��681,148,0,0q�$
��Wrap=�$��Manual Labor Multi:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� $
��Left=�$��681,247,0,0q�$
��Wrap=�$��Special Notes:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� -   $ 	cmbLockup��$
��Left=�$��232,119,0,0q�$	��Top=�$	��193��$��23��$��0q�$��14(��� -   $ tbSeg��$
��Left=�$��23��$��232,169,0,0q�$
 Wrap=�$	��Top=�$	��193��
�������$��14(��� -   $ tbWidth1��$
��Left=�$��23��$��232,219,0,0q�$
 Wrap=�$	��Top=�$��95��
�������$��14(��� -   $ tbLength��$
��Left=�$��23��$��330,219,0,0q�$
 Wrap=�$	��Top=�$��95��
�������$��14(��� -   $ tbHeight��$
��Left=�$��23��$��232,269,0,0q�$
 Wrap=�$	��Top=�$��95��
�������$��14(��� -   $ tbWatts��$
��Left=�$��23��$��232,322,0,0q�$
 Wrap=�$	��Top=�$��95��
�������$��14(��� -   $ tbVolts��$
��Left=�$��23��$��330,322,0,0q�$
 Wrap=�$	��Top=�$��95��
�������$��14(��� -   $ cmbTermStyle��$
��Left=�$��454,119,0,0q�$	��Top=�$	��193��$��23��$��0q�$��14(��� -   $ tbLeads��$
��Left=�$��23��$��454,170,0,0q�$
 Wrap=�$	��Top=�$	��193��
�������$��14(��� -   $ 	tbLeadCov��$
��Left=�$��23��$��454,219,0,0q�$
 Wrap=�$	��Top=�$	��193��
�������$��14(��� -   $ tbHoles��$
��Left=�$��23��$��681,118,0,0q�$
 Wrap=�$	��Top=�$��95��
�������$��14(��� -   $ tbMulti��$
��Left=�$��23��$��681,170,0,0q�$
 Wrap=�$	��Top=�$	��193��
�������$��14(��� -   $ tbManualAdder�� � ToolTip$k eEnter a manual additional dollar amount to be applied per heater after quantity calculations are done��$
��Left=�$��23��$��681,219,0,0q�$
 Wrap=�$	��Top=�$	��193��
�������$��14(��� -   $ 
tbSpecials��$
��Left=�$	��129��$��681,269,0,0q�$
 Wrap=�$	��Top=�$	��253��
�������$��14(��� $
��Left=�$��681,197,0,0q�$
��Wrap=�$��Additional Costs:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��203���� -    ��Name$ lbAdders��$
��Left=�$	��128��$��454,270,0,0q�$	��Top=�$	��193��
����������� .R�� .+��� $��14(�$��0,0,0,0q����� *	AdderName+�� $
��Left=�$��454,248,0,0q�$
��Wrap=�$��Adders:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$��94���� -     ��Name$ btnAdd��$��+��$
��Left=�$��624,250,0,0q�$	��Top=�$��23��$��20��$��12(����	#FFCFCCC7���	#FFCFCCC7$��0q�$ -0.437,-0.929&�$
��Bold"��� -!   $ 	btnDelAdd��$ Clear All Adders!��$��x��$
��Left=�$��595,247,0,0q�$	��Top=�$��29��$��26��$��12(����	#FF9C5151$��0q�$ -0.437,-0.929&����	#FFE5E6E4��Z� �� $
��Left=�$��232,300,0,0q�$
��Wrap=�$��Watts:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$��94���� $
��Left=�$��331,300,0,0q�$
��Wrap=�$��Volts:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$��94���� -"   $ btnPrecalculate��$��Precalculate��$
��Left=�$��653,523,0,0q�$	��Top=�$	��143��$��41��$��18(�$
��Bold"����	#FF6A8195$��0q�$ -0.437,-0.929&����	#FFE5E6E4��Z� �� -#   $ btnSaveQuote��$��
Save Quote��$
��Left=�$��793,523,0,0q�$	��Top=�$	��144��$��41��$��18(�$
��Bold"����	#FF689564$��0q�$ -0.437,-0.929&����	#FFE5E6E4��Z� �� -$   $ btnClearForm��$��
Clear Form��$
��Left=�$��150,524,0,0q�$	��Top=�$	��143��$��41��$��18(�$
��Bold"����	#FF9C5151$��0q�$ -0.437,-0.929&����	#FFE5E6E4��Z� �� -%   $ btnClose��$��Close��$
��Left=�$��
12,523,0,0q�$	��Top=�$	��141��$��41��$��18(�$
��Bold"����	#FFCFCCC7$��0q�$ -0.437,-0.929&���Z� �� $
��Left=�$��796,473,0,0q�$
��Wrap=�$
��SMT:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��148���� -&   $ tbSMT��$
��Left=�$��23��$��796,495,0,0q�$
 Wrap=�$	��Top=�$	��138��
�������$��14(��� -'   $	 lPN��$
��Left=�$��
242,31,0,0q�$
��Wrap=�$	��Top=�$��28(�$��Century Gothic)�$
��Bold"�$��Italic$�$	��337������ *lPN+$ TwoWay=�