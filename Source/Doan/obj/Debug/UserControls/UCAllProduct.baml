   M S B A M L   `   `   `  ����?  ;Doan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Doan.UserControlsDoan.UserControls  5      )clr-namespace:Doan.CommonDoan.Common  5      $    Doan.UserControls.UCAllProduct   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Doan.UserControls     5      ,local1clr-namespace:Doan.Common     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignPaper#���   5        MaterialDesignBody#���  5   	     � 	Resources  5      -   'Doan.Common.RelativeToAbsoluteConverter  absoluteConverter#   Doan.Common.ImagePathToBase64  base64Converter%   Doan.Common.NumberToCurrencyVND  currencyVND  MyWaterMarkStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name ��Name
 � Tag �� Triggers	 ]� 
Conditions
 �� Property �� Value �� 
TargetName P� Property P� Value��%�  &	       &	      &	 &     &	 9       5   
   6-     5   
   6#     5   
   6%   �� 5   
   " ��6)   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� 
����������	#FF7D8683$��1q�6P   �� 5      $ PART_ContentHost��6+   $��5,0,0,0q�6E   $��Center=�6V   �� 5      $ WaterMarkLabel��65   $��5,0,0,0q�6$   #��z 6M   $��Center=�6m   $y�	Collapsed=�5       
�������$��Arial)�6I   5       5      ]� 5      	 5   "   �� 5   &   
 � ��$  ��6@   ./�5    "   �� $ WaterMarkLabel��6?    � y�$ Visible=�6[   5!      P� 5"       � {� .  . �5#   "   ��  � ��
 �iii�6?   5$      5&      5(      5)      5+      .��5,      ]� -   5        $��parrent��5,      $��10 0 0 0q�6   .+�5-   
   �� -   5        $��tbFindProduct��5-   '   $	��Top=�6   $" Tìm kiếm sản phẩm ...��6=   $��18(�6Y   #��[ 6g   $
��10 0q�6�   .��6�   5.      �� 5/   
   $	��Top=�6   $��10q�6*   .+�50      � .+�51      �� $��20(�6   Số lượng :66   �� 52      -   5        $��
tbQuantity��52      $$ Số lượng sản phẩm ...��6,   $��15(�6H   #��[ 6V   $
��10 0q�6�   $	��200��6�   6�   53      �� 54      $��DemiBold"�6   \ZGhi chú: Bạn chỉ có thể thêm sản phẩm nếu số lượng tồn kho trên 0!!6t   � 55      $��0 5 0 0q�6   .+�56      �� -   5        $��btnDone��56      .��6(   Hoàn tất62   �� 57      -   5        $��	btnCancel��57      .��6*   
Hủy bỏ62   58      59      �� 5:   
   -   5        $��
Pagination��5:   a   $��Bottom=�6    �� Orientation$ 
Horizontal=�6-   $
��Left=�6F   .+�5;      �� -   5        $��
btnPrevius��5;   ?   $��2q�6   {�6!   �� *	previus+.��6Q   
Previous6[   �� 5<      -   5        $��btnNext��5<   ;   $��2q�6   {�6    �� *next+.��6K   Next6Q   5=      �� 5>   
   -	   5         ��Name$ 	ProductLV��5>      $��Disabled=�6&   ��5?      �� 5@      .R�5A      � $��Center=�6    5B      ��5D      �� 5E      .R�5F      #  MaterialDesignThemes.Wpf.Card  $��Center=�6*   $��10q�6G   ��6U   ��  �� Path$ ActualWidth� �� ElementName$ parrent�� �� 	Converter %   Doan.Common.PercentageConverter   �� ConverterParameter$	 0.2��.��5G      �� .+�5H      ��  �� BitmapScalingMode$ HighQuality=�6o   ��6$   �� *	ImagePath+# [ 6�   �� 5I      $��
ExtraLight"�6?   $��WrapWithOverflow=�6W   $��Center=�6w   $��15(�6�   ��6)   �� *Name+6�   �� 5J      $��DemiBold"�6g   ���#bf081f��6(   �� *Price+# [ 6�   �� 5K      Số lượng còn lại: �� 6;   $��DemiBold"�6E   ��6[   �� *
Quantity+6w   6�   5L      5M      5N      5P      5Q      5R      