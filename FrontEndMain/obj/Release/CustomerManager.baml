   M S B A M L   `   `   `  ���� G  CFrontEndMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FrontEndMainFrontEndMain  "    FrontEndMain.CustomerManager   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:FrontEndMain     -     � Title$  Customer Manager��$	��650��$
��1200�� � WindowStartupLocation$ Manual=� � Left$ 40��
 � Top$ 10�� � 
ResizeMode$ 	CanResize=����	#FFEAE7E2.��� .+��� $
��Left=�$
��Wrap=�$��Customer��$	��Top=�$��36(�$��Century Gothic)�$
��Bold"�$��Italic$�$	��178��$��11,0,0,0q��� $
��Left=�$��8��$��	10,64,0,0q�$	��Top=�$
��1174�����	#FFC3B7AF$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 0Q�   	Direction$	 270Q�   ShadowDepth$ 0Q�	   Color$	 	#7F000000���� -   
 ��Name$
 lbCust��$
��Left=�$	��514��$��
12,100,0,0q�$	��Top=�$	��507��
����������� .R�� .+��� $��16(����� *
CustName+�� $��16(�$��	300,0,0,0q����� *
CustType+�� $��16(�$��	425,0,0,0q����� *Multi+�� $
��Left=�$��	11,81,0,0q�$
��Wrap=�$��Customer Name��$	��Top=�$��14(�$
��Bold"��� $
��Left=�$��
316,81,0,0q�$
��Wrap=�$
��Type��$	��Top=�$��14(�$
��Bold"��� $
��Left=�$��
439,81,0,0q�$
��Wrap=�$��
Multiplier��$	��Top=�$��14(�$
��Bold"��� $
��Left=�$��	12,31,0,0q�$
��Wrap=�$��Manager��$	��Top=�$��30(�$��Century Gothic)�$
��Bold"�$��Italic$�$	��178���� -   $
 lbCustDetails��$
��Left=�$	��514��$��524,100,0,0q�$	��Top=�$	��660�����	#FFEAE7E2���	#FFEAE7E2���� .R�� .+��� $��28(�$
��Bold"�$��0,0,0,0q����� *
CustName+�� $��Customer Type: ��$
��Bold"�$��13(�$��0,35,0,0q��� $��13(�$��
112,35,0,0q����� *
CustType+�� $��Multiplier: ��$
��Bold"�$��13(�$��
250,35,0,0q��� $��13(�$��
330,35,0,0q����� *Multi+�� $
��Left=�$��6��$��0,55,0,0q�$	��Top=�$	��620�� �� Stretch$ UniformToFill=����	#FFC3B7AF$��0���� $��Phone: ��$
��Bold"�$��13(�$��	50,75,0,0q��� $��13(�$��
100,75,0,0q����� *Phone+�� $��Fax: ��$
��Bold"�$��13(�$��
250,75,0,0q��� $��13(�$��
300,75,0,0q����� *Fax+�� $��Stamp Info: ��$
��Bold"�$��13(�$��
50,120,0,0q��� $��13(�$��133,120,0,0q����� *Stamp+�� $��	Address: ��$
��Bold"�$��13(�$��
70,150,0,0q��� $��13(�$��
85,168,0,0q����� *Add1+�� $��13(�$��
85,186,0,0q����� *Add2+�� $��13(�$��
85,204,0,0q����� *Add3+�� $��13(�$��
85,222,0,0q����� *Add4+�� $��13(�$��
85,240,0,0q����� *Add5+�� -    ��Name$ btnModifyCust��$��Modify Existing
Customer��$
��Left=�$��	874,4,0,0q�$	��Top=�$	��152��$��55��$��18(�$
��Bold"����	#FFAFD4E2���	#FFAFD4E2$��0q� J� RenderTransformOrigin$ -0.437,-0.929&��� -   $ btnNewCustomer��$��Create New
Customer��$
��Left=�$��	717,4,0,0q�$	��Top=�$	��152��$��55��$��18(�$
��Bold"����	#FFBDE4B8���	#FFBDE4B8$��0q�$ -0.437,-0.929&��� -   $ 	btnDelete��$��Delete
Customer��$
��Left=�$��
1032,4,0,0q�$	��Top=�$	��152��$��55��$��18(�$
��Bold"����	#FFF0BDB8���	#FFF0BDB8$��0q�$ -0.437,-0.929&�