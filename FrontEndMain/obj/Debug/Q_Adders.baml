   M S B A M L   `   `   `  ����G  CFrontEndMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FrontEndMainFrontEndMain  5   	       FrontEndMain.Q_Adders   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FrontEndMain     5   	     � Title$  Quoting Adders��5   	   $	��600��6    $	��450��6-   ���	#FFEAE7E2 � WindowStartupLocation$ Manual=�5	   	    � Left$ 40��5
   	   
 � Top$ 10��6    � 
ResizeMode$ NoResize=�5   	   .��5      � .+�5   
   �� -   5         ��Name$ lbAdders��5      $
��Left=�6$   $	��497��6?   $��	10,32,0,0q�6L   $	��Top=�6_   $	��424��6w   
������� �� SelectionMode$ Multiple=�6�   ��5      �� 5      .R�5      � .+�5      �� $��16(�6?   $��15,0,0,0q�6M   ��6$   �� *	AdderName+6a   �� 5      $��16(�6V   $��	300,0,0,0q�6d   ��6$   �� *	AdderCost+ �� StringFormat$ {0:c}��6y   5      5      5      �� 5   
   -   5         ��Name$ 	btnSubmit��5      $��Submit Adders��6$   $
��Left=�6<   $��275,534,0,0q�6W   $	��Top=�6l   $	��159��6�   $��30��6�   $��18(�6�   $
��Bold"�6�   ���	#FFBDE4B8���	#FFBDE4B8$��0q�6�   	 J� RenderTransformOrigin$	 -0.437,-0.929&�6�   6%  �� 5   
   -   5        $ btnClose��5      $��Cancel��6#   $
��Left=�64   $��
10,534,0,0q�6O   $	��Top=�6c   $	��103��6{   $��30��6�   $��18(�6�   $
��Bold"�6�   ���	#FFCFCCC7���	#FFCFCCC7$��0q�6�   $	 -0.437,-0.929&�6�   6  �� 5   
   $
��Left=�6   $��	10,13,0,0q�6/   $
��Wrap=�6B   $	��Top=�6V   $��14(�6n   $��Italic$�6|   �� 6�   $�*Select ��6�   �� 6�   $
��Bold"�6�   $�UP TO ��6�   �� 6�   $�6 Adder Options��6�   6�   5      5      