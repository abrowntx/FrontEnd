   M S B A M L   `   `   `  ���� G  CFrontEndMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FrontEndMainFrontEndMain  (    "FrontEndMain.CreateQuote_Cartridge   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:FrontEndMain     -     � Title$  Create Quote - Cartridge��$	��600��$	��950�� � WindowStartupLocation$ Manual=� � Left$	 165��
 � Top$ 55�� � 
ResizeMode$ CanMinimize=����	#FFE5E6E4.��� .+��� $
��Left=�$��81��$	��Top=�$	��944�����	#FFEAD0BF$��0���� $
��Left=�$
��Wrap=�$��Generate��$	��Top=�$��36(�$��Century Gothic)�$
��Bold"�$��Italic$�$	��178��$��11,0,0,0q��� $
��Left=�$��	12,31,0,0q�$
��Wrap=�$��	New Quote��$	��Top=�$��28(�$��Century Gothic)�$
��Bold"�$��Italic$�$	��178���� $
��Left=�$
��Wrap=�$��	Cartridge��$	��Top=�$��48(�$��Century Gothic)�$
��Bold"�$��Italic$�$	��350��$��
584,12,0,0q� �� TextAlignment$ Right=��� $
��Left=�$��	10,96,0,0q�$
��Wrap=�$��	Customer:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� $
��Left=�$��-25,189,0,0q�$
��Wrap=�$��
Quantities��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$��91�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$	 -90Q�T� �� -    ��Name$ 
myComboBox��$
��Left=�$��	8,119,0,0q�$	��Top=�$	��193��$��23��$��0q�$��14(��� -   	 ��Name$	 tbQty1��$
��Left=�$��23��$��
41,147,0,0q�
 �� TextWrapping$

 Wrap=�$	��Top=�$��85��
�������$��14(��� -   $	 tbQty2��$
��Left=�$��23��$��
41,175,0,0q�$

 Wrap=�$	��Top=�$��85��
�������$��14(��� -   $	 tbQty3��$
��Left=�$��23��$��
41,203,0,0q�$

 Wrap=�$	��Top=�$��85��
�������$��14(��� -   $	 tbQty4��$
��Left=�$��23��$��
41,231,0,0q�$

 Wrap=�$	��Top=�$��85��
�������$��14(��� -    ��Name$	 lq1��$
��Left=�$��126,151,0,0q�$
��Wrap=�$	��Top=�$��14(�$��Century Gothic)�$��75��$��Italic$�$ Right=����� *lq1+ �� Mode$ TwoWay=��� -   $	 lq2��$
��Left=�$��126,179,0,0q�$
��Wrap=�$	��Top=�$��14(�$��Century Gothic)�$��75��$��Italic$�$ Right=����� *lq2+$ TwoWay=��� -	   $	 lq3��$
��Left=�$��126,207,0,0q�$
��Wrap=�$	��Top=�$��14(�$��Century Gothic)�$��75��$��Italic$�$ Right=����� *lq3+$ TwoWay=��� -
   $	 lq4��$
��Left=�$��126,235,0,0q�$
��Wrap=�$	��Top=�$��14(�$��Century Gothic)�$��75��$��Italic$�$ Right=����� *lq4+$ TwoWay=��� -   $ lMulti��$
��Left=�$��126,101,0,0q�$
��Wrap=�$	��Top=�$��14(�$��Century Gothic)�$��75��$��Italic$�$ Right=����� *lMulti+$ TwoWay=��� -   $ cmbDiameter��$
��Left=�$��232,119,0,0q�$	��Top=�$	��193��$��23��$��0q�$��14(��� $
��Left=�$��
232,96,0,0q�$
��Wrap=�$��	Diameter:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� $
��Left=�$��232,148,0,0q�$
��Wrap=�$��Length:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� -   $	 tbLength��$
��Left=�$��23��$��232,170,0,0q�$

 Wrap=�$	��Top=�$	��193��
�������$��14(��� -   $ cmbTermStyle��$
��Left=�$��232,219,0,0q�$	��Top=�$	��193��$��23��$��0q�$��14(��� $
��Left=�$��232,196,0,0q�$
��Wrap=�$��Termination Style:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� -   $	 tbLeads��$
��Left=�$��23��$��232,269,0,0q�$

 Wrap=�$	��Top=�$��92��
�������$��14(��� $
��Left=�$��232,247,0,0q�$
��Wrap=�$��Leads:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� -   $	 	tbLeadCov��$
��Left=�$��23��$��333,269,0,0q�$

 Wrap=�$	��Top=�$��92��
�������$��14(��� $
��Left=�$��333,247,0,0q�$
��Wrap=�$��	Covering:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$��87���� $
��Left=�$��
460,97,0,0q�$
��Wrap=�$��Labor Multiplier:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� $
��Left=�$��232,300,0,0q�$
��Wrap=�$��Watts:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$��92���� $
��Left=�$��333,300,0,0q�$
��Wrap=�$��Volts:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$��92���� $
��Left=�$��460,196,0,0q�$
��Wrap=�$��Special Notes:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� -   $	 tbWatts��$
��Left=�$��23��$��232,322,0,0q�$

 Wrap=�$	��Top=�$��92��
�������$��14(��� -   $	 tbVolts��$
��Left=�$��23��$��333,322,0,0q�$

 Wrap=�$	��Top=�$��92��
�������$��14(��� -   $	 tbLabor��$
��Left=�$��23��$��460,119,0,0q�$

 Wrap=�$	��Top=�$	��193��
�������$��14(��� -   $	 tbManualAdder��$
��Left=�$��23��$��460,170,0,0q�$

 Wrap=�$	��Top=�$	��193��
�������$��14(��� -   $	 
tbSpecials��$
��Left=�$	��126��$��460,219,0,0q�$

 Wrap=�$	��Top=�$	��331��
�������$��14(�	� -    	�Name$ rdoSMT��$��SMT Pricing��$
��Left=�$��
41,269,0,0q�$	��Top=�$��14(� d� 	IsChecked$
 TrueY�	� -   $ rdo5DAY��$��5-DAY Pricing��$
��Left=�$��
41,286,0,0q�$	��Top=�$��14(�	� -   $ rdoHOT��$��HOT Pricing��$
��Left=�$��
41,303,0,0q�$	��Top=�$��14(��� -    ��Name$ btnPrecalculate��$��Precalculate��$
��Left=�$��653,523,0,0q�$	��Top=�$	��143��$��41��$��18(�$
��Bold"����	#FF6A8195$��0q�$ -0.437,-0.929&����	#FFE5E6E4��Z� �� -   $ btnSaveQuote��$��
Save Quote��$
��Left=�$��793,523,0,0q�$	��Top=�$	��144��$��41��$��18(�$
��Bold"����	#FF689564$��0q�$ -0.437,-0.929&����	#FFE5E6E4��Z� �� -   $ btnClearForm��$��
Clear Form��$
��Left=�$��148,524,0,0q�$	��Top=�$	��143��$��41��$��18(�$
��Bold"����	#FF9C5151$��0q�$ -0.437,-0.929&����	#FFE5E6E4��Z� �� -   $ btnClose��$��Close��$
��Left=�$��
10,524,0,0q�$	��Top=�$	��141��$��41��$��18(�$
��Bold"����	#FFCFCCC7$��0q�$ -0.437,-0.929&�
���   ���Z� �� $
��Left=�$��460,148,0,0q�$
��Wrap=�$��Manual Adder:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� $
��Left=�$��796,473,0,0q�$
��Wrap=�$
��SMT:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��148���� -   $	 tbSMT��$
��Left=�$��23��$��796,495,0,0q�$

 Wrap=�$	��Top=�$	��138��
�������$��14(��� -    ��Name$ lbAdders��$
��Left=�$��76��$��460,370,0,0q�$	��Top=�$	��331��
����������� .R�� .+��� $��14(�$��0,0,0,0q����� *	AdderName+�� $
��Left=�$��460,348,0,0q�$
��Wrap=�$��Adders:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$��94���� -   $ btnAdd��$��+��$
��Left=�$��768,350,0,0q�$	��Top=�$��23��$��20��$��12(����	#FFCFCCC7���	#FFCFCCC7$��0q�$ -0.437,-0.929&�$
��Bold"��� -    $	 lPN��$
��Left=�$��
242,31,0,0q�$
��Wrap=�$	��Top=�$��28(�$��Century Gothic)�$
��Bold"�$��Italic$�$	��337������ *lPN+$ TwoWay=��� -!   $ 	btnDelAdd�� � ToolTip$ Clear All Adders!��$��x��$
��Left=�$��742,347,0,0q�$	��Top=�$��29��$��26��$��12(����	#FF9C5151$��0q�$ -0.437,-0.929&����	#FFE5E6E4��Z� 