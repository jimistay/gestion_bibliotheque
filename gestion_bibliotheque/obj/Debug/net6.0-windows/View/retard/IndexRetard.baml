   M S B A M L   `   `   `  ����O  Kgestion_bibliotheque, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:gestion_bibliotheque.View.retard gestion_bibliotheque.View.retard  5   	   2    ,gestion_bibliotheque.View.retard.IndexRetard   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:gestion_bibliotheque.View.retard     5   	     � Title$  IndexRetard��5   	   $	��600��6   $
��1300��6*   .��5	      � $��	0,0,0,-43q�6   .+�5
   
   �� $��Center=�6   $	��684��61   
���   �$��Center=�6M   $
��1300��6h   ���	#FF1C1C1C6u   �� 5   
   -   5         ��Name$ ListRetards��5      $��	0,65,0,25q�6(   $
��1280��6^   ���	#FF1C1C1C
����������	#001C1C1C$��20(�6�   ��6<   �� *	Retards+ � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�   '��       �� 5      " ��6   .�5      ��  � �� �	#FF1C1C1C63    5      P� 5       �@J�IsMouseOver$
 True��69   . �5      ��  � �� �	#FF2C2C2C6;   5      5      5      	 �� View	 5      �� 5      .P�5      �� $��Date de location��6%   
 �� Width$	
 300��6n    �� DisplayMemberBinding 6?   �� *DATE_LOCATION+6n   �� 5      $ ��Date de retour obligatoire��6%   $	
 300��6z    6I   �� *DATE_R_ATTENDUE+6z   �� 5      $��Jours de retard��6%   $	
 200��6k    6>   �� *JoursRetard+6k   �� 5       $��Le référence du livre��6%   $	
 200��6n    6D   �� *
LIVRE_ID+6n   �� 5!      $	��Par��6%   $	
 200��6X    62   �� *USER+6X   5+      5-      �� 5.   
   -   5        $�� ��5.      $
��Left=�6   $��1161,10,0,0q�67   $	��Top=�6L   $��50��6d   $��33��6o    J� OpacityMask 5/      �� 50       �� ImageSource$$ ../../ressources/back_page.png��6   ��52      �� 53      $ /ressources/back_page.png��6   55      56      57      