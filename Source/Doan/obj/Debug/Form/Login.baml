   M S B A M L   `   `   `  ����?  ;Doan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Doan.Form	Doan.Form  5   	       Doan.Form.Login   5      M IFluent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546fFluenturn:fluent-ribbon  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Doan.Form     5   	     � Title$  Login��5   	   $	��350��6   $	��400��6$    � WindowStyle$
 None=�60    � 	Resources 5	         MyWaterMarkStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name ��Name
	 � Tag
 �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName P� Property P� Value��%�  &	        �� 5
   
   " ��6)   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� 
����������	#FF7D8683$��1q�6P   �� 5      $ PART_ContentHost��6+   $��5,0,0,0q�6E   $��Center=�6V   �� 5      $ WaterMarkLabel��65   $��5,0,0,0q�6$   #��z	 6M   $��Center=�6m   $y�	Collapsed=�5       
�������$��Arial)�6I   5      
 5      ]� 5       5   "   �� 5   &    � ��$  ��6@   ./�5   "   �� $ WaterMarkLabel��6?    � y�$ Visible=�6[   5      P� 5       � {� .  . �5   "   ��  � ��
 �iii�6?   5      5      5!      5"      5#      .��5$      �� $��30q�6   .+�5%   
   �� -   5        $��ParentLabel��5%      $��24(�6   $
��0 10q�61   .��6?   
UserName6I   �� 5&   
   $	 Nhập tài khoản��6   $��18(�6(   #��[  66   6b   �� 5'   
   ��6   ��  �� ElementName$ ParentLabel�� �� Path$ FontSize���6M   �� $ ParentLabel��$ Margin�.��6�   	Pasword6�   �� 5(   
   $	 Nhập mật khẩu��6   $��18(�6&   #��[  64   6`   �� 5)   
   -   5        $	��Err��5)      
���  ��$��12(�60   $��DemiBold"�6>   6V   � 5*   
   $��0 5 0 0q�6   .+�5+      �� -   5        $��btnLogin��5+      .��6%   Login6,   �� 5,      -   5        $��btnExit��5,   &   $��5 0 0 0q�6   .��65   Thoát6<   5-      5.      5/      