   M S B A M L   `   `   `  ���� G  CFrontEndMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FrontEndMainFrontEndMain      FrontEndMain.RecallQuote   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:FrontEndMain       � Title$  Recall an Existing Quote��$	��850��$
��1200�����	#FFCBD6C7 � WindowStartupLocation$ Manual=� � Left$	 120��
 � Top$ 50�� � 
ResizeMode$ NoResize=�.��� .+��� ���	#FFD7E2D3$
��Left=�$	��385��$��391,429,0,0q�$	��Top=�$	��793���� $
��Left=�$��	10,72,0,0q�$
��Wrap=�$��	Customer:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��188���� $
��Left=�$��
221,10,0,0q�$
��Wrap=�$��Date Range:��$	��Top=�$��18(�$��Century Gothic)�$
��Bold"�$	��173���� $
��Left=�$��
257,28,0,0q�$
��Wrap=�$��between:��$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$��64��$��Italic$� �� TextAlignment$ Center=��� $
��Left=�$��
257,68,0,0q�$
��Wrap=�$
��and:��$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$��64��$��Italic$�$ Center=��� -    ��Name$ lbCust��$
��Left=�$	��637��$��
10,138,0,0q�$	��Top=�$	��188�����	#FFF5F1F5���	#FFF1F5F1���� .R�� .+��� $��10(����� *
CustName+(  "System.Windows.Controls.DatePicker  -     Name$ dpStart��$
��Left=�$��
221,44,0,0q�$	��Top=�$	��151��$��0q����	#FFF5F1F5$��14(�$��Century Gothic)����	#FFF5F1F5$��24��  -   $ dpEnd��$
��Left=�$��
221,83,0,0q�$	��Top=�$	��151��$��0q����	#FFF5F1F5$��14(�$��Century Gothic)����	#FFF5F1F5$��24���� -   $ lbQuotes��$
��Left=�$	��377��$��
391,44,0,0q�$	��Top=�$	��793�����	#FFF5F1F5���	#FFF1F5F1���� .R�� .+��� $��10(����� *ID+�� $��12(�$��35,0,0,0q����� *Cust+�� $��12(�$��	250,0,0,0q����� *dte+�� $��12(�$��	400,0,0,0q����� *pn+�� $��12(�$��
1110,0,0,0q����� *
filename+�� -    ��Name$ btnEditQuote��$��
Edit Quote��$
��Left=�$��800,774,0,0q�$	��Top=�$	��187��$��35��$��18(�$
��Bold"����	#FFB8D8E4���	#FFB8D8E4$��0q�	 J� RenderTransformOrigin$	 -0.437,-0.929&��� -   $ btnClose��$��deselect customer��$
��Left=�$��
10,780,0,0q�$	��Top=�$	��187��$��34��$��18(����	#FFF0BDB8���	#FFF0BDB8$��0q�$	 -0.437,-0.929&��� $
��Left=�$��	10,10,0,0q�$
��Wrap=�$��Department:��$	��Top=�$��18(�$��Century Gothic)�$	��146��$
��Bold"��� -   
 ��Name$
 cmbDep��$
��Left=�$��9,44,0,0q�$	��Top=�$	��189��$��23��$��0q�$��14(��� -    ��Name$ tbCustSearch��$
��Left=�$��23��$��
10,110,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��188��
�������$��14(��� $
��Left=�$��	10,94,0,0q�$
��Wrap=�$��search:��$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��188��$��Italic$�$ Center=��� -	   $ tbParam1��$
��Left=�$��23��$��221,170,0,0q�$
 Wrap=�$	��Top=�$	��149��
�������$��14(��� -
    ��Name$ lParam1��$
��Left=�$��221,155,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��146��$��Italic$�$ Center=����� *	lParam1+ �� Mode$ TwoWay=��� -   $ tbParam2��$
��Left=�$��23��$��221,213,0,0q�$
 Wrap=�$	��Top=�$	��149��
�������$��14(��� -   $ lParam2��$
��Left=�$��221,198,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��146��$��Italic$�$ Center=����� *	lParam2+$ TwoWay=��� -   $ tbParam3��$
��Left=�$��23��$��221,256,0,0q�$
 Wrap=�$	��Top=�$	��149��
�������$��14(��� -   $ lParam3��$
��Left=�$��221,241,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��146��$��Italic$�$ Center=����� *	lParam3+$ TwoWay=��� -   $ tbParam4��$
��Left=�$��23��$��221,299,0,0q�$
 Wrap=�$	��Top=�$	��149��
�������$��14(��� -   $ lParam4��$
��Left=�$��221,284,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��146��$��Italic$�$ Center=����� *	lParam4+$ TwoWay=��� -   $ tbParam5��$
��Left=�$��23��$��221,342,0,0q�$
 Wrap=�$	��Top=�$	��149��
�������$��14(��� -   $ lParam5��$
��Left=�$��221,327,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��146��$��Italic$�$ Center=����� *	lParam5+$ TwoWay=��� -   $ tbParam6��$
��Left=�$��23��$��221,385,0,0q�$
 Wrap=�$	��Top=�$	��149��
�������$��14(��� -   $ lParam6��$
��Left=�$��221,370,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��146��$��Italic$�$ Center=����� *	lParam6+$ TwoWay=��� -   $ tbParam7��$
��Left=�$��23��$��221,429,0,0q�$
 Wrap=�$	��Top=�$	��149��
�������$��14(��� -   $ lParam7��$
��Left=�$��221,414,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��146��$��Italic$�$ Center=����� *	lParam7+$ TwoWay=��� -   $ tbParam8��$
��Left=�$��23��$��221,472,0,0q�$
 Wrap=�$	��Top=�$	��149��
�������$��14(��� -   $ lParam8��$
��Left=�$��221,457,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��146��$��Italic$�$ Center=����� *	lParam8+$ TwoWay=��� -   $ tbParam9��$
��Left=�$��23��$��221,515,0,0q�$
 Wrap=�$	��Top=�$	��149��
�������$��14(��� -   $ lParam9��$
��Left=�$��221,500,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��146��$��Italic$�$ Center=����� *	lParam9+$ TwoWay=��� -   $ 	tbParam10��$
��Left=�$��23��$��221,558,0,0q�$
 Wrap=�$	��Top=�$	��149��
�������$��14(��� -   $ lParam10��$
��Left=�$��221,543,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��146��$��Italic$�$ Center=����� *
lParam10+$ TwoWay=��� $
��Left=�$��9,28,0,0q�$
��Wrap=�$��select:��$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��188��$��Italic$�$ Center=��� -   $ tbCustSearch_Copy��$
��Left=�$��23��$��221,127,0,0q�$
 Wrap=�$	��Top=�$	��149��
�������$��14(��� -   $ lParam1_Copy��$
��Left=�$��221,112,0,0q�$
��Wrap=�$��part number:��$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��146��$��Italic$�$ Center=��� -   $ btnDesQuote��$��deselect quote��$
��Left=�$��992,433,0,0q�$	��Top=�$	��187��$��34��$��18(����	#FFF0BDB8���	#FFF0BDB8$��0q�$	 -0.437,-0.929&��� -    $	 lPN��$
��Left=�$��401,436,0,0q�$
��Wrap=�$��part number:��$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��175��$��Italic$��� -!   $ 	lPartNumb��$
��Left=�$��401,455,0,0q�$
��Wrap=�$	��Top=�$��22(�$��Century Gothic)�$	��225������ *	lPartNumb+$ TwoWay=��� -"   $ lS��$
��Left=�$��401,532,0,0q�$
��Wrap=�$��spec:��$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��175��$��Italic$��� -#   $	 lP1��$
��Left=�$��487,552,0,0q�$
��Wrap=�$	��Top=�$��16(�$��Century Gothic)�$��89������ *lp1+$ TwoWay=��� -$   $ lPLab1��$
��Left=�$��401,556,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$��81��$��Italic$�$ Right=����� *lPlab1+$ TwoWay=��� -%   $	 lP2��$
��Left=�$��487,576,0,0q�$
��Wrap=�$	��Top=�$��16(�$��Century Gothic)�$��89������ *lp2+$ TwoWay=��� -&   $ lPLab2��$
��Left=�$��401,580,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$��81��$��Italic$�$ Right=����� *lPlab2+$ TwoWay=��� -'   $	 lP3��$
��Left=�$��487,601,0,0q�$
��Wrap=�$	��Top=�$��16(�$��Century Gothic)�$��89������ *lp3+$ TwoWay=��� -(   $ lPLab3��$
��Left=�$��401,605,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$��81��$��Italic$�$ Right=����� *lPlab3+$ TwoWay=��� -)   $	 lP4��$
��Left=�$��487,626,0,0q�$
��Wrap=�$	��Top=�$��16(�$��Century Gothic)�$��89������ *lp4+$ TwoWay=��� -*   $ lPLab4��$
��Left=�$��401,630,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$��81��$��Italic$�$ Right=����� *lPlab4+$ TwoWay=��� -+   $ lWatts��$
��Left=�$��694,553,0,0q�$
��Wrap=�$	��Top=�$��16(�$��Century Gothic)�$��89������ *lWatts+$ TwoWay=��� -,   $ labWatts��$
��Left=�$��608,557,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$��81��$��Italic$�$ Right=����� *
labWatts+$ TwoWay=��� --   $ lVolts��$
��Left=�$��694,577,0,0q�$
��Wrap=�$	��Top=�$��16(�$��Century Gothic)�$��89������ *lVolts+$ TwoWay=��� -.   $ labVolts��$
��Left=�$��608,581,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$��81��$��Italic$�$ Right=����� *
labVolts+$ TwoWay=��� -/   $ lTerm��$
��Left=�$��694,601,0,0q�$
��Wrap=�$	��Top=�$��16(�$��Century Gothic)�$	��101������ *lTerm+$ TwoWay=��� -0   $ labTerm��$
��Left=�$��608,605,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$��81��$��Italic$�$ Right=����� *	labTerm+$ TwoWay=��� -1   $ lParam1_Copy18��$
��Left=�$��401,762,0,0q�$
��Wrap=�$��filename��$	��Top=�$��10(�$��Century Gothic)�$
��Bold"�$	��793��$��Italic$��� -2   $ lC��$
��Left=�$��704,436,0,0q�$
��Wrap=�$��	customer:��$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��175��$��Italic$��� -3   $ lCust��$
��Left=�$��704,455,0,0q�$
��Wrap=�$	��Top=�$��22(�$��Century Gothic)�$	��298������ *lCust+$ TwoWay=��� -4   $ lD��$
��Left=�$��401,484,0,0q�$
��Wrap=�$��date quoted:��$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$	��175��$��Italic$��� -5   $ lDate��$
��Left=�$��401,503,0,0q�$
��Wrap=�$	��Top=�$��14(�$��Century Gothic)�$	��225������ *lDate+$ TwoWay=��� -6   $ lNotes��$
��Left=�$��843,572,0,0q�$
��Wrap=�$	��Top=�$��16(�$��Century Gothic)�$	��341��$��88������ *lNotes+$ TwoWay=��� -7   $	 lSN��$
��Left=�$��843,557,0,0q�$
��Wrap=�$��special notes:��$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$��81��$��Italic$�$ Right=��� -8   $
 lPr1��$
��Left=�$��694,662,0,0q�$
��Wrap=�$	��Top=�$��16(�$��Century Gothic)�$��89������ *lPr1+$ TwoWay=� �� StringFormat$ {0:c}���� -9   $	 lQ1��$
��Left=�$��608,666,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$��81��$��Italic$�$ Right=����� *lQ1+$ TwoWay=��� -:   $
 lPr2��$
��Left=�$��694,682,0,0q�$
��Wrap=�$	��Top=�$��16(�$��Century Gothic)�$��89������ *lPr2+$ TwoWay=�$ {0:c}���� -;   $	 lQ2��$
��Left=�$��608,686,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$��81��$��Italic$�$ Right=����� *lQ2+$ TwoWay=��� -<   $
 lPr3��$
��Left=�$��694,702,0,0q�$
��Wrap=�$	��Top=�$��16(�$��Century Gothic)�$��89������ *lPr3+$ TwoWay=�$ {0:c}���� -=   $	 lQ3��$
��Left=�$��608,706,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$��81��$��Italic$�$ Right=����� *lQ3+$ TwoWay=��� ->   $
 lPr4��$
��Left=�$��694,722,0,0q�$
��Wrap=�$	��Top=�$��16(�$��Century Gothic)�$��89������ *lPr4+$ TwoWay=�$ {0:c}���� -?   $	 lQ4��$
��Left=�$��608,726,0,0q�$
��Wrap=�$	��Top=�$��12(�$��Century Gothic)�$
��Bold"�$��81��$��Italic$�$ Right=����� *lQ4+$ TwoWay=��� -@   $ btnCreatePN��$��Create Part��$
��Left=�$��992,774,0,0q�$	��Top=�$	��187��$��35��$��18(�$
��Bold"����	#FFBDE4B8���	#FFBDE4B8$��0q�$	 -0.437,-0.929&�