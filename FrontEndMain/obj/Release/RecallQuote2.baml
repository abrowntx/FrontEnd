   M S B A M L   `   `   `  ���� G  CFrontEndMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FrontEndMainFrontEndMain      FrontEndMain.RecallQuote2   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:FrontEndMain       � Title$  Recall an Existing Quote��$	��850��$
��1200�����	#FFE5E6E4 � WindowStartupLocation$ Manual=� � Left$	 120��
 � Top$ 50��.���  � RowDefinitions �� $
��Auto ��� $
��auto � � ColumnDefinitions �� $��250px ��� $��* �.+��� -    ��Name$ btnMicaBand��$��	Mica Band��$��33��$��	10,10,0,0q�$	��Top=�$
��Left=�$	��126�����	#FFFBFBF2���	#FF904E55$��14(�$
��Bold"���Z� �� -   $ btnMicaStrip��$��
Mica Strip��$��33��$��
133,10,0,0q�$	��Top=�$
��Left=�$	��120�����	#FFFBFBF2���	#FF904E55$��14(�$
��Bold"�$��2����Z� �� -   $ btnMisc��$��Miscellaneous��$��33��$��
133,70,0,0q�$	��Top=�$
��Left=�$	��120�����	#FFFBFBF2���	#FF904E55$��14(�$
��Bold"�$��2����Z� �� -   $ btnCart��$��	Cartridge��$��33��$��	10,70,0,0q�$	��Top=�$
��Left=�$	��126�����	#FFFBFBF2���	#FF904E55$��14(�$
��Bold"���Z� �� -   $ btnCeramicStrip��$��Ceramic Strip��$��33��$��
133,40,0,0q�$	��Top=�$
��Left=�$	��120�����	#FFFBFBF2���	#FF904E55$��14(�$
��Bold"�$��2����Z� �� -   $ 
btnCeramic��$��Ceramic��$��33��$��	10,40,0,0q�$	��Top=�$
��Left=�$	��126�����	#FFFBFBF2���	#FF904E55$��14(�$
��Bold"���Z� �� $��Search Customers:��$��
10,102,0,0q�$
��Bold"�$	��Top=�$
��Left=�$��16��$	��104�����	#FF615757�� -    ��Name$ tbCustSearch��$
��25px��$��
12,121,0,0q�$	��Top=�$
��Left=�$	��183�����	#FF615757
�������
��������� -   $ btnClearPNSearch_Copy��$��clear��$��195,118,0,0q�$
��Left=�$��55�� J� RenderTransformOrigin$ 	-23.6,4.8&�
����������	#FF567568$
��Bold"�$��31��$	��Top=���Z� �� -	   	 ��Name$	 lbCust��$��0��$��10,154,0,-582q�$	��650��$	��Top=�$
��Left=�$	��240��
����������	#FF615757$��2����Z� ���� .R�� .+��� ���� *
CustName+
 � ContextMenu
 �� .@�m� -
    m�Name$ cmMBQ��$��Mica Band Quotes��m� -   $ cmMSQ��$��Mica Strip Quotes���� m� -   $ cmCBQ��$��Ceramic Band Quotes��m� -   $ cmCSQ��$��Ceramic Strip Quotes���� m� -   $
 cmCQ��$��Cartridge Quotes���� m� -   $
 cmMQ��$��Miscellaneous Quotes���� m� -   $ cmECD��$��Edit Customer Details���� -   $	 lbList��$��1��$
��auto��$	��724��$��10,80,10,-632q�$��2��
����������	#FF615757$	��Top=���Z� ���� .R�� .+��� $��10(����� *ID+�� $��12(�$��35,0,0,0q����� *Cust+�� $��12(�$��	230,0,0,0q����� *file+�� $��12(�$��	350,0,0,0q����� *pn+�� $��12(�$��	400,0,0,0q����� *date+�� $��12(�$��	500,0,0,0q����� *notes+
 �� .@�m� -   $ cmCreatePart��$��Create New Part��m� -   $ 
cmEditPart��$��Edit Quote Details��m� -   $ cmCreateSimilarPart��$��Create Similar Part���� m� -   $ cmDeleteQuote��$��Delete Quote Entry���� $��↑↓  Customer ��$��1��$��
0,62,823,0q�$	��Top=�$��Right=�$
��Bold"����	#FF615757�� $��↑↓  File ��$��1��$��
0,62,662,0q�$	��Top=�$��Right=�$
��Bold"����	#FF615757�� $��↑↓  Part Number��$��1��$��
0,62,493,0q�$	��Top=�$��Right=�$
��Bold"����	#FF615757�� -   $ btnMicaBand_Copy��$��Edit Quote Details��$��47��$��
462,10,0,0q�$	��Top=�$
��Left=�$	��157�����	#FFFBFBF2���	#FF6A8195$��14(�$
��Bold"�$��1����Z� �� -   $ btnMicaBand_Copy1��$��Generate New Part��$��47��$��
619,10,0,0q�$	��Top=�$
��Left=�$	��157�����	#FFFBFBF2���	#FF689564$��14(�$
��Bold"�$��1����Z� �� -   $ btnMicaBand_Copy2��$��Delete Quote Entry��$��47��$��
776,10,0,0q�$	��Top=�$
��Left=�$	��157�����	#FFFBFBF2���	#FF9C5151$��14(�$
��Bold"�$��1����Z� �� $��Description/Notes��$��1��$��
0,62,266,0q�$	��Top=�$��Right=�$
��Bold"����	#FF615757$	��165���� -    ��Name$ lPrefix��$��	15,14,0,0q�$
��Bold"�$	��Top=�$
��Left=�$��40��$	��442�����	#FF615757$��1��$��24(�