   M S B A M L   `   `   `  ����G  CFrontEndMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FrontEndMainFrontEndMain  5   	   "    FrontEndMain.CustomerManager   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FrontEndMain     5   	   -   5          � Title$  Customer Manager��5   	   $	��650��6"   $
��1200��6/    � WindowStartupLocation$ Manual=�5	   	    � Left$ 40��5
   	   
 � Top$ 10��6    � 
ResizeMode$ 	CanResize=�5   	   ���	#FFD9DAD9.��5      � .+�5   
   �� $
��Left=�6   $��72��6/   $	��Top=�6;   $
��1192��6S   ���	#FFC5C4C1$��0��6q    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 0Q�6#      	Direction$	 270Q�62      ShadowDepth$ 0Q�6B   	   Color$	 	#7F000000��6R   5      �� 5   
   $
��Left=�6   $
��Wrap=�6/   $��Customer��6C   $	��Top=�6S   $��36(�6k   $��Century Gothic)�6y   $
��Bold"�6�   $��Italic$�6�   $	��178��6�   $��11,0,0,0q�6�   �� 5   
   -   5        
 ��Name$
 lbCust��5      $
��Left=�6"   $	��514��6=   $��
12,100,0,0q�6J   $	��Top=�6^   $	��507��6v   
���������5      �� 5      .R�5      � .+�5      �� $��14(�6>   ��6$   �� *
CustName+6>   �� 5      $��14(�6>   $��	300,0,0,0q�6L   ��6$   �� *
CustType+6L   �� 5      $��14(�6;   $��	425,0,0,0q�6I   ��6$   �� *Multi+6I   5      5      5      �� 5   
   $
��Left=�6   $��	11,81,0,0q�6/   $
��Wrap=�6B   $��Customer Name��6V   $	��Top=�6k   $��14(�6�   $
��Bold"�6�   �� 5   
   $
��Left=�6   $��
316,81,0,0q�6/   $
��Wrap=�6C   $
��Type��6W   $	��Top=�6c   $��14(�6{   $
��Bold"�6�   �� 5    
   $
��Left=�6   $��
439,81,0,0q�6/   $
��Wrap=�6C   $��
Multiplier��6W   $	��Top=�6i   $��14(�6�   $
��Bold"�6�   �� 5!   
   $
��Left=�6   $��	12,31,0,0q�6/   $
��Wrap=�6B   $��Manager��6V   $	��Top=�6e   $��30(�6}   $��Century Gothic)�6�   $
��Bold"�6�   $��Italic$�6�   $	��178��6�   �� 5"   
   -   5        $
 lbCustDetails��5"      $
��Left=�6)   $	��514��6D   $��524,100,0,0q�6Q   $	��Top=�6f   $	��660��6~   ���	#FFD9DAD9��6�   Z� ��5#      �� 5$      .R�5%      � .+�5&      �� $��28(�6>   $
��Bold"�6L   $��0,0,0,0q�6^   ��6$   �� *
CustName+6^   �� 5'      $��Customer Type: ��6$   $
��Bold"�6;   $��13(�6M   $��0,35,0,0q�6[   �� 5(      $��13(�6>   $��
112,35,0,0q�6L   ��6$   �� *
CustType+6L   �� 5)      $��Multiplier: ��6$   $
��Bold"�68   $��13(�6J   $��
250,35,0,0q�6X   �� 5*      $��13(�6;   $��
330,35,0,0q�6I   ��6$   �� *Multi+6I   �� 5+      $
��Left=�6$   $��6��6?   $��0,55,0,0q�6J   $	��Top=�6\   $	��620��6t    �� Stretch$ UniformToFill=�6�   ���	#FFC3B7AF$��0��6�   �� 5,      $��Phone: ��6$   $
��Bold"�63   $��13(�6E   $��	50,75,0,0q�6S   �� 5-      $��13(�6;   $��
100,75,0,0q�6I   ��6$   �� *Phone+6I   �� 5.      $��Fax: ��6$   $
��Bold"�61   $��13(�6C   $��
250,75,0,0q�6Q   �� 5/      $��13(�69   $��
300,75,0,0q�6G   ��6$   �� *Fax+6G   �� 50      $��Stamp Info: ��6$   $
��Bold"�68   $��13(�6J   $��
50,120,0,0q�6X   �� 51      $��13(�6;   $��133,120,0,0q�6I   ��6$   �� *Stamp+6I   �� 52      $��	Address: ��6$   $
��Bold"�65   $��13(�6G   $��
70,150,0,0q�6U   �� 53      $��13(�6:   $��
85,168,0,0q�6H   ��6$   �� *Add1+6H   �� 54      $��13(�6:   $��
85,186,0,0q�6H   ��6$   �� *Add2+6H   �� 55      $��13(�6:   $��
85,204,0,0q�6H   ��6$   �� *Add3+6H   �� 56      $��13(�6:   $��
85,222,0,0q�6H   ��6$   �� *Add4+6H   �� 57      $��13(�6:   $��
85,240,0,0q�6H   ��6$   �� *Add5+6H   59      5:      5<      �� 5=   
   -   5         ��Name$ btnModifyCust��5=      $��Modify Existing
Customer��6(   $
��Left=�6O   $��	866,7,0,0q�6j   $	��Top=�6}   $	��160��6�   $��55��6�   $��18(�6�   $
��Bold"�6�   ���	#FF6A8195$��0q�6�    J� RenderTransformOrigin$ -0.437,-0.929&�6  ���	#FFD9DAD9��6�   Z� 6Q  �� 5>   
   -   5        $ btnNewCustomer��5>      $��Create New
Customer��6)   $
��Left=�6K   $��	714,7,0,0q�6f   $	��Top=�6y   $	��155��6�   $��55��6�   $��18(�6�   $
��Bold"�6�   ���	#FF689564$��0q�6�   $ -0.437,-0.929&�6  ���	#FFD9DAD9��6�   Z� 6N  �� 5?   
   -   5        $ 	btnDelete��5?      $��Delete
Customer��6$   $
��Left=�6B   $��
1023,7,0,0q�6]   $	��Top=�6q   $	��161��6�   $��55��6�   $��18(�6�   $
��Bold"�6�   ���	#FF904E55$��0q�6�   $ -0.437,-0.929&�6  ���	#FFD9DAD9��6�   Z� 6A  5A      5B      