   M S B A M L   `   `   `  ���� G  CFrontEndMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FrontEndMainFrontEndMain      FrontEndMain.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:FrontEndMain       � Title$!  EZHeat Frontend Application��$	��680��$
��1250�����	#FFFBFBF2 � WindowStartupLocation$ Manual=� � Left$ 15��
 � Top$ 0�� � 
ResizeMode$ 	CanResize=� � WindowState$ 	Maximized=�.���  � RowDefinitions �� $��* � � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+�o� ���	#FFE5E6E4$��35��$	��Top=�$��3��.@�m� $��_File��$��0q�$��50��$��14(����	#FFE5E6E4���	#FFE5E6E4.@�m� -    m�Name$ HClose��$��
_Close App��$��14(����	#FFE5E6E4���	#FFE5E6E4m� $��_Quoting��$��0q�$��75��$��14(����	#FFE5E6E4���	#FFE5E6E4.@�m� $��_Create a Quote��$��14(����	#FFE5E6E4���	#FFE5E6E4.@�m� -   $ HCreateMica��$��
_Mica Band��$	��125��$��14(����	#FFE5E6E4���	#FFE5E6E4m� -   $ HCreateStrip��$��_Mica Strip��$��14(����	#FFE5E6E4���	#FFE5E6E4m� -   $ HCreateCeramic��$��_Ceramic��$��14(����	#FFE5E6E4���	#FFE5E6E4m� -   $ HCreateCart��$��
_Cartridge��$��14(����	#FFE5E6E4���	#FFC7C7C7m� -   $ HCreateMisc��$��_Misc.��$��14(����	#FFE5E6E4���	#FFE5E6E4m� -   $ HRecallQuote��$��_Recall a Quote��$��14(����	#FFE5E6E4���	#FFC7C7C7m� $��_Configuration��$��0q�$	��110��$��14(����	#FFE5E6E4���	#FFE5E6E4.@�m� -   $ HConfig��$��_Configuration��$��14(����	#FFE5E6E4���	#FFE5E6E4m� -	   $ HManageAdders��$��_Manage Adders��$��14(����	#FFE5E6E4���	#FFE5E6E4m� $��_Customer Management��$��0q�$	��170��$��14(����	#FFE5E6E4���	#FFE5E6E4.@�m� -
   $ 
ManageCust��$��_Manage Customers��$��14(����	#FFE5E6E4���	#FFE5E6E4m� $��_Help��$��0q�$��50��$��14(����	#FFE5E6E4���	#FFE5E6E4.@�m� -   $
 hDoc��$��_Documentation��$��14(����	#FFE5E6E4���	#FFE5E6E4�� $
��Left=�$	��Top=�$��0��$��0��$��40��$��10,37,0,572q�$
��Wrap=�$
��1222��$��24(�$��Century Gothic)�$
��Bold"�$��Italic$�$��3���� $�SALES, QUOTING AND ���� $�ORDER GENERATION SYSTEM���� -   	 ��Name$	 btnCreateSO��$��2��$��0��$��	99,87,0,0q�$��Create Sales Order��$
��Left=�$	��Top=�$	��292��$��51��$��18(�$
��Bold"����	#FF4E7B90$��0q�
 J� RenderTransformOrigin$
 -0.437,-0.929&����	#FFF9F9F9��Z� �� -   $	 btnRecallQuote��$��0��$��0��$��Recall Existing Quote��$
��Left=�$��
99,380,0,0q�$	��Top=�$	��292��$��51��$��18(�$
��Bold"����	#FF904E78$��0q����	#FFF9F9F9��Z� �� -   $	 btnCustManager��$��1��$��0��$��	99,87,0,0q�$��Customer Manager��$
��Left=�$	��Top=�$	��292��$��51��$��18(�$
��Bold"����	#FF4E5790$��0q�$
 -0.437,-0.929&����	#FFF9F9F9��Z� �� -   $	 btnRecallQuote_Copy��$��0��$��0��$��Quote Manager��$
��Left=�$��	99,87,0,0q�$	��Top=�$	��292��$��51��$��18(�$
��Bold"����	#FF904E55$��0q����	#FFF9F9F9��Z� �� -   $	 btnManageSO��$��2��$��0��$��
99,192,0,0q�$��Manage Sales Orders��$
��Left=�$	��Top=�$	��292��$��51��$��18(�$
��Bold"����	#FF4E907B$��0q����	#FFF9F9F9��Z� �� -   $	 btnCreateMicaQuote��$��0��$��0��$��Create Mica Band Quote��$
��Left=�$��127,138,0,0q�$	��Top=�$	��252��$��38��$��18(����	#FFB2656D$��0q�$��Italic$����	#FFF9F9F9��Z� �� -   $	 btnCreateCartridgeQuote��$��0��$��0��$��Create Cartridge Quote��$
��Left=�$��127,214,0,0q�$	��Top=�$	��252��$��38��$��18(����	#FFB2656D$��0q�$��Italic$����	#FFF9F9F9��Z� �� -   $	 btnRecallQuote_Copy3��$��0��$��0��$��Create Ceramic Quote��$
��Left=�$��127,252,0,0q�$	��Top=�$	��252��$��38��$��18(����	#FFB2656D$��0q�$��Italic$����	#FFF9F9F9��Z� �� -   $	 btnRecallQuote_Copy4��$��0��$��0��$��Create Misc. Quote��$
��Left=�$��127,328,0,0q�$	��Top=�$	��252��$��38��$��18(����	#FFB2656D$��0q�$��Italic$����	#FFF9F9F9��Z� �� -   $	 btnCreateMicaQuote_Copy��$��0��$��0��$��Create Mica Strip Quote��$
��Left=�$��127,176,0,0q�$	��Top=�$	��252��$��38��$��18(����	#FFB2656D$��0q�$��Italic$����	#FFF9F9F9��Z� �� $��0��$��0��$��Documents.png��$
��None=�$��	43,82,0,0q�$
��Left=�$	��Top=�$��80��$��80���� $��2��$��0��$��Browsers.png��$
��None=�$��
43,182,0,0q�$
��Left=�$	��Top=�$��80��$��80���� $��1��$��0��$��User.png��$
��None=�$��	43,82,0,0q�$
��Left=�$	��Top=�$��80��$��80���� $��2��$��0��$��Network.png��$
��None=�$��	43,82,0,0q�$
��Left=�$	��Top=�$��80��$��80���� $��0��$��0��$��Note.png��$
��None=�$��
43,373,0,0q�$
��Left=�$	��Top=�$��80��$��80���� -   $��376,635,10,10q�$��More.png��$
��None=�$��2��$��Right=�$��Bottom=��� -   $	 btnModAdders��$��1��$��0��$��Modify Adders List��$
��Left=�$��119,342,0,0q�$	��Top=�$	��252��$��38��$��18(����	#FF6082AA$��0q�$��Italic$�$
 0.758,-1.97&����	#FFF9F9F9��Z� �� -   $	 btnRecallQuote_Copy1��$��1��$��0��$��Settings��$
��Left=�$��
99,294,0,0q�$	��Top=�$	��292��$��51��$��18(�$
��Bold"����	#FF4E6C90$��0q����	#FFF9F9F9��Z� �� $��1��$��0��$��
36,282,0,0q�$��4 by 4 Grid.png��$
��None=�$
��Left=�$	��Top=��� -   $	 btnSystemConfig��$��1��$��0��$��System Configuration��$
��Left=�$��119,378,0,0q�$	��Top=�$	��252��$��36��$��18(����	#FF6082AA$��0q�$��Italic$�$
 0.758,-1.97&����	#FFF9F9F9��Z� �� -   $	 btnManageSO_Copy��$��2��$��0��$��
99,287,0,0q�$��
Scheduling��$
��Left=�$	��Top=�$	��292��$��51��$��18(�$
��Bold"����	#FF4E904E$��0q����	#FFF9F9F9��Z� �� $��2��$��0��$
��None=�$��
45,282,0,0q�$��Notebook.png��$
��Left=�$	��Top=�$��80��$��80���� -   $	 
btnTCQuote��$��0��$��0��$��Create Thermocouple Quote��$
��Left=�$��127,290,0,0q�$	��Top=�$	��252��$��38��$��18(����	#FFB2656D$��0q�$��Italic$����	#FFF9F9F9��Z� �� -   $	 btnPartsList��$��0��$��0��$��Parts Lists��$
��Left=�$��
99,461,0,0q�$	��Top=�$	��292��$��51��$��18(�$
��Bold"����	#FF5D4E90$��0q����	#FFF9F9F9��Z� �� $��0��$��0��$��Note.png��$
��None=�$��
43,453,0,0q�$
��Left=�$	��Top=�$��80��$��80���� -   $	 btnMicaBand��$��0��$��0��$��BH��$
��Left=�$��127,510,0,0q�$	��Top=�$��86��$��43��$��18(����	#FF7465A8$��0q�$��Italic$����	#FFF9F9F9��Z� �� -   $	 btnMicaStrip��$��0��$��0��$��SH��$
��Left=�$��213,510,0,0q�$	��Top=�$��85��$��43��$��18(����	#FF7465A8$��0q�$��Italic$����	#FFF9F9F9��Z� �� -   $	 
btnCeramic��$��0��$��0��$��CB��$
��Left=�$��298,510,0,0q�$	��Top=�$��85��$��43��$��18(����	#FF7465A8$��0q�$��Italic$����	#FFF9F9F9��Z� �� -    $	 btnCart��$��0��$��0��$��C��$
��Left=�$��127,553,0,0q�$	��Top=�$��86��$��43��$��18(����	#FF7465A8$��0q�$��Italic$����	#FFF9F9F9��Z� �� -!   $	 btnTC��$��0��$��TC��$
��Left=�$��213,553,0,0q�$	��Top=�$��85��$��43��$��18(����	#FF7465A8$��0q�$��Italic$����	#FFF9F9F9��Z� �� -"   $	 btnMisc��$��0��$��Misc.��$
��Left=�$��298,553,0,0q�$	��Top=�$��85��$��43��$��18(����	#FF7465A8$��0q�$��Italic$����	#FFF9F9F9��Z� 