   M S B A M L   `   `   `  ����G  CFrontEndMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FrontEndMainFrontEndMain  5   	       FrontEndMain.NumberGen   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FrontEndMain     5   	     � Title$  File Number Generator��5   	   $	��350��6'   $	��670��64    � WindowStartupLocation$ Manual=�5	   	    � Left$	 250��5
   	   
 � Top$ 85��6    � 
ResizeMode$ CanMinimize=�5   	   ���	#FFDED9D3.��5      � .+�5   
   �� $
��Left=�6   $��8��6/   $��	10,60,0,0q�6:   $	��Top=�6M   $	��644��6e   ���	#FFB9B0A8$��0��6�   �� 5   
   $
��Left=�6   $
��Wrap=�6/   $��Generate��6C   $	��Top=�6S   $��36(�6k   $��Century Gothic)�6y   $
��Bold"�6�   $��Italic$�6�   $	��178��6�   $��11,0,0,0q�6�   �� 5   
   $
��Left=�6   $��	12,30,0,0q�6/   $
��Wrap=�6B   $��New Part File Number��6V   $	��Top=�6r   $��28(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $��Italic$�6�   $	��327��6�   �� 5   
   -   5         ��Name$ 	lbMatches��5      $
��Left=�6%   $	��176��6@   $��	10,92,0,0q�6M   $	��Top=�6`   $	��225��6x   
���������5      �� 5      .R�5      � .+�5      �� $��10(�68   ��6$   �� *ID+68   �� 5      $��12(�6:   $��35,0,0,0q�6H   ��6$   �� *file+6H   5      5      5      �� 5   
   $
��Left=�6   $��
239,75,0,0q�6/   $
��Wrap=�6C   $��file number:��6W   $	��Top=�6k   $��14(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��193��6�   $��Italic$�6�   �� 5   
   $
��Left=�6   $��	10,75,0,0q�6/   $
��Wrap=�6B   $��matching similar parts��6V   $	��Top=�6t   $��14(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��193��6�   $��Italic$�6�   �� 5   
   -   5         ��Name$ 	tbQB_Copy��5   8   $
��Left=�6K   $��34��6f   $��
240,92,0,0q�6r    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��125��6�   ���	#FFDED9D3$��22(�6�   ���	#FFDED9D36�   �� 5   
   $
��Left=�6   $��
347,75,0,0q�6/   $
��Wrap=�6C   $��prefix:��6W   $	��Top=�6f   $��14(�6~   $��Century Gothic)�6�   $
��Bold"�6�   $��85��6�   $��Italic$�6�    �� TextAlignment$ Right=�6�   �� 5   
   $
��Left=�6   $��
347,92,0,0q�6/   $
��Wrap=�6C   $��base:��6W   $	��Top=�6d   $��14(�6|   $��Century Gothic)�6�   $
��Bold"�6�   $��85��6�   $��Italic$�6�   $ Right=�6�   �� 5    
   $
��Left=�6   $��347,109,0,0q�6/   $
��Wrap=�6D   $��suffix:��6X   $	��Top=�6g   $��14(�6   $��Century Gothic)�6�   $
��Bold"�6�   $��85��6�   $��Italic$�6�   $ Right=�6�   �� 5!   
   -   5        	 ��Name$	 lPrefix��5!      $
��Left=�6%   $��
440,75,0,0q�6@   $
��Wrap=�6T   $	��Top=�6�   $��14(�6�   $��Century Gothic)�6�   $��85��6�   $��Italic$�6�   ��6h   �� *	lPrefix+
 �� Mode$
 TwoWay=�6�   �� 5"   
   -   5        $	 lBase��5"      $
��Left=�6#   $��
440,92,0,0q�6>   $
��Wrap=�6R   $	��Top=�6�   $��14(�6�   $��Century Gothic)�6�   $��85��6�   $��Italic$�6�   ��6f   �� *lBase+$
 TwoWay=�6�   �� 5#   
   -   5        $	 lSuffix��5#      $
��Left=�6%   $��440,109,0,0q�6@   $
��Wrap=�6U   $	��Top=�6�   $��14(�6�   $��Century Gothic)�6�   $��85��6�   $��Italic$�6�   ��6i   �� *	lSuffix+$
 TwoWay=�6�   �� 5$   
   -   5        $ lbExists��5$      $
��Left=�6$   $��24��6?   $��
10,290,0,0q�6K   $	��Top=�6_   $	��225��6w   
���������5%      �� 5&      .R�5'      � .+�5(      �� $��10(�68   ��6$   �� *ID+68   �� 5)      $��12(�6:   $��35,0,0,0q�6H   ��6$   �� *file+6H   5*      5+      5-      �� 5.   
   $
��Left=�6   $��
10,273,0,0q�6/   $
��Wrap=�6C   $ ��next available file number��6W   $	��Top=�6y   $��14(�6�   $��Century Gothic)�6�   $
��Bold"�6�   $	��193��6�   $��Italic$�6�   �� 5/   
   -   5         ��Name$ 	btnSelect��5/      $��select file #��6$   $
��Left=�6<   $��516,273,0,0q�6W   $	��Top=�6l   $	��138��6�   $��41��6�   $��18(�6�   $
��Bold"�6�   ���	#FFD6FDD2���	#FFD6FDD2$��0q�6�    J� RenderTransformOrigin$ -0.437,-0.929&�6�   6%  51      52      