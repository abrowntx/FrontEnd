   M S B A M L   `   `   `  ����G  CFrontEndMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FrontEndMainFrontEndMain  5   	       FrontEndMain.ModifyAdders   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FrontEndMain     5   	     � Title$  Modify Adders��5   	   $	��600��6   $	��450��6,   ���	#FFEAE7E2 � WindowStartupLocation$ Manual=�5	   	    � Left$ 40��5
   	   
 � Top$ 10��6    � 
ResizeMode$ NoResize=�5   	   .��5      � .+�5   
   �� -   5         ��Name$ lbAdders��5      $
��Left=�6$   $	��407��6?   $��	10,10,0,0q�6L   $	��Top=�6_   $	��424��6w   
������� �� SelectionMode$ Single=�6�   ��5      �� 5      .R�5      � .+�5      �� $��10(�68   $��0,3,0,0q�6F   ��6$   �� *ID+6F   �� 5      $��16(�6?   $��50,0,0,0q�6M   ��6$   �� *	AdderName+6M   �� 5      $��16(�6V   $��	325,0,0,0q�6d   ��6$   �� *	AdderCost+ �� StringFormat$ {0:c}��6d   5      5      5      �� 5   
   -   5         ��Name$ 	btnSubmit��5      $
��Save��6$   $
��Left=�63   $��331,534,0,0q�6N   $	��Top=�6c   $	��103��6{   $��30��6�   $��18(�6�   $
��Bold"�6�   ���	#FFBDE4B8���	#FFBDE4B8$��0q�6�   	 J� RenderTransformOrigin$	 -0.437,-0.929&�6�   6  �� 5   
   -   5        $ btnNew��5      $	��New��6!   $
��Left=�6/   $��117,534,0,0q�6J   $	��Top=�6_   $	��103��6w   $��30��6�   $��18(�6�   $
��Bold"�6�   ���	#FFCFCCC7���	#FFCFCCC7$��0q�6�   $	 -0.437,-0.929&�6�   6  �� 5   
   $
��Left=�6   $��
10,422,0,0q�6/   $
��Wrap=�6C   $��Adder Name:��6W   $	��Top=�6j   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 5   
   -   5        
 ��Name$
 tbAdderName��5      $
��Left=�6'   $��23��6B   $��
10,445,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��424��6�   
�������$��14(�6�   �� 5   
   $
��Left=�6   $��
10,473,0,0q�6/   $
��Wrap=�6C   $��Adder Cost:��6W   $	��Top=�6j   $��18(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��188��6�   �� 5   
   -   5        $
 tbAdderPrice��5      $
��Left=�6(   $��23��6C   $��
10,496,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $	��123��6�   
�������$��14(�6�   �� 5   
   -   5        $ 	btnDelete��5      $��Delete��6$   $
��Left=�65   $��224,534,0,0q�6P   $	��Top=�6e   $	��103��6}   $��30��6�   $��18(�6�   $
��Bold"�6�   ���	#FFF0BDB8���	#FFF0BDB8$��0q�6�   $	 -0.437,-0.929&�6�   6  �� 5   
   -   5        $ 	btn_clear��5      $��Clear��6$   $
��Left=�64   $��
10,534,0,0q�6O   $	��Top=�6c   $	��103��6{   $��30��6�   $��18(�6�   $
��Bold"�6�   ���	#FFC1D9DC���	#FFC1D9DC$��0q�6�   $	 -0.437,-0.929&�6�   6  5!      5"      