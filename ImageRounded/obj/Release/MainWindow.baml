   M S B A M L   `   `   `  ���� G  CImageRounded, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null+clr-namespace:ImageRoundedImageRounded      ImageRounded.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:ImageRounded       � 
ResizeMode$  NoResize=� � WindowStartupLocation$ CenterScreen=� � Title$ 图像圆角工具 v0.0.2��$	��492��$	��750��.��� .+��� $��参数设置��$��0,5,5,35q�$��Right=�$	��240��.��� .+��� $��10,2,2,2q�$��圆角大小(像素)：���� -   $��RoundCornerSize��$�� ��$
��Auto��$	��200��$��3,7,0,0q�$��14,29,13.2,340q�$��Stretch=��� $��10,67,4.2,-63q�$��圆角背景：���� -    ��Name$ comboBox��$��14,94,14,276q�$��6,6,0,0q�$��30��$	��200��.@���  �� 
IsSelected . .��透明�� .��白色�� $��10,137,-1.8,-133q�$��导出文件名：���� -   $��
OutPutName��$�� ��$
��Auto��$	��200��$��3,7,0,0q�$��14,163,13.2,206q�$��Stretch=��� $��10,201,1.2,-197q�$$��导出路径 (双击选择)：���� -   $��
OutPutPath��$�� ��$
��Auto��$	��200��$��3,7,0,0q�$��14,229,13.2,140q�$��Stretch=��� -   $��OperationBtn��$��30��$��执 行(Opertion)��$	��0,5q�$
��Bold"����	#B2FFFFFF$��5,332,4.2,38q��� -   $��	OutPutBtn��$��导 出(OutPut)��$	��0,5q�$
��Bold"����	#B2FFFFFF$��Bottom=�$��5q��� -   $��	settinggb��$��图像预览��$
��Left=�$��5,5,0,35q�$	��480��.���  � RowDefinitions �� $��30 ��� $��* �.+�� $��0��.+��� -    ��Name$ SelectImageBtn��$�� 选择图像 ��$
��Left=�$��24��$��5,0,0,0q�$��Center=��� -	   $��FilePath��$�� �� �� Padding$ 6,9,0,0q�$��
73,0,5,0.4q��� -
    ��Name$ sp��$��10q�$��1��.+��� -   $��ImagePreview��$��Uniform=�$	��340��$
��Auto��$��5,5,5,5q��� -   $��	TheAuthor��$,��&Code By：呆头作家，on 2018-07-27��	 K� ZIndex$	 1��
 �� TextAlignment$
 Center=�$	 0,1q�$��
ExtraLight"����	#B2FFFFFF$��Bottom=�$��5q�