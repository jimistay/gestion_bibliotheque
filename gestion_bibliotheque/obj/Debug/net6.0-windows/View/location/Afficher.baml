   M S B A M L   `   `   `  ����O  Kgestion_bibliotheque, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:gestion_bibliotheque.View.location"gestion_bibliotheque.View.location  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      1    +gestion_bibliotheque.View.location.Afficher   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:gestion_bibliotheque.View.location     5      6sys&clr-namespace:System;assembly=mscorlib     5        N� Title$  Afficher��5
      .��5      � .+�5   
   �� -   5         ��Name$ ListLocations��5      $��	0,65,0,25q�6*   $��Center=�6�   $
��1280��6�   ���	#FF1C1C1C
����������	#001C1C1C$��20(�6�   ��6=   �� *	Locations+ � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�   '��       �� 5      " ��6   .�5      ��  � �� �	#FF1C1C1C63    5      P� 5       �@J�IsMouseOver$
 True��69   . �5      ��  � �� �	#FF2C2C2C6;   5      5      5      	 �� View	 5      �� 5      .P�5      �� $��Date de location��6%   
 �� Width$	
 200��6n    �� DisplayMemberBinding 6?   �� *DATE_LOCATION+6n   �� 5      $��Date de retour prévue��6%   $	
 200��6u    6D   �� *DATE_R_ATTENDUE+6u   �� 5      $��Rendu le��6%   $	
 200��6f    67   �� *DATE_R_REELLE+6f   �� 5       $��
Le livre :��6%   $	
 100��6c    69   �� *
LIVRE_ID+6c   �� 5!      $��Par :��6%   $	
 100��6Z    64   �� *USER+6Z   �� 5#      $��	Supprimer��6%   $	
 200��68    �� CellTemplate 5$      �� 5%      .R�5&   "   �� -   5        $��	Supprimer��5&   )   ���	#FFE29090$	��100��6r   $��50��6~   $��Impact)�6�   $��14(�6�   ��5'   &   �� 5(   *   " ��60    5)   .   �� 5*   2    �� Binding 6>   �� *DATE_R_REELLE+ �� Value 6`   Z� .a�5+   6   ��  � y�$ 	Collapsed=�6S   5,   3   5.   +   50   #   51      53      �� 55      $��Retour��6%   $	
 200��65    56      �� 57      .R�58   "   �� -   5        $��Ajouter un retour��58   )   ���	#FFE29090$	��100��6w   $��50��6�   $��Impact)�6�   $��14(�6�   ��59   &   �� 5:   *   " ��60   .�5;   .   ��  � y�$ 	Collapsed=�6K    5<   .   �� 5=   2    6>   �� *DATE_R_REELLE+ 6`   Z� .a�5>   6   ��  � y�$ Visible=�6S   5?   3   5A   +   5C   #   5D      5F      5H      5J      �� 5L   
   -   5         ��Name$ ComboBoxUser��5L      $
��Left=�6)   $��
220,30,0,0q�6D   $	��Top=�6X   $	��120��6p   �� 5M   
   $��Utilisateur :��6   $
��Left=�6(   $��	85,21,0,0q�6C   $	��Top=�6V   
�������$��22(�6�   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�   �� 5O   
   -   5         ��Name$ RetourEffectueCheckBox��5O   -   $��Retour effectué��6   $
��Left=�6M   $��
399,30,0,0q�6h   $	��Top=�6|   
�������$��22(�6�   $��Palatino Linotype)�6�   $
��Bold"�6  $��Italic$�6!  $	��174��64  5Q      5R      