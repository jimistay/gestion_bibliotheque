   M S B A M L   `   `   `  ����O  Kgestion_bibliotheque, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:gestion_bibliotheque.View.livres gestion_bibliotheque.View.livres  5      /    )gestion_bibliotheque.View.livres.Afficher   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:gestion_bibliotheque.View.livres     5        N� Title$  Afficher��5      .��5      � .+�5   
   �� -   5         ��Name$ 	ListLivre��5      $��0,84,0,0q�6&   $��Center=�6Z   $
��1300��6w   ���	#FF1C1C1C
����������	#001C1C1C$��14(�6�   ��6:   �� *Livres+ � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�   '��       �� 5      " ��6   .�5      ��  � �� �	#FF1C1C1C63    5      P� 5       �@J�IsMouseOver$
 True��69   . �5      ��  � �� �	#FF2C2C2C6;   5      5      5      	 �� View	 5      �� 5      .P�5      �� $��Titre��6%   
 �� Width$	
 200��6[    �� DisplayMemberBinding 64   �� *TITRE+6[   �� 5      $��Date de Publication��6%   $	
 200��6t    6B   �� *DATE_PUBLICATION+6t   �� 5      $��
Couverture��6%    �� CellTemplate 5      �� 5       .R�5!   "   �� $	��300��6K   $	��300��6W   ��6(   �� *CouvertureImage+6W   5"      5$      �� 5%      $��	Supprimer��6%    5&      �� 5'      .R�5(   "   �� -   5        $��	Supprimer��5(   )   ���	#FFE29090$	��100��6r   $��50��6~   $��Impact)�6�   $��14(�6�   5)      5+      5,      5.      �� 5/   
   -   5         ��Name$ CheckBoxDisponible��5/      $��
Disponible��6/   $
��Left=�6D   $��
219,34,0,0q�6_    d� 	IsChecked$
 TrueY�6s   $	��Top=�6�   
�������$��22(�6�   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�   (  "System.Windows.Controls.DatePicker  50   
   -   5          Name$ DatePickerDate��50      $
��Left=�6-   $��
383,37,0,0q�6H   $	��Top=�6\   �� 51   
   -   5         ��Name$ TextBoxTitre��51      $
��Left=�6(   $��	73,41,0,0q�6C    �� TextWrapping$
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��120��6�   �� 52   
   -   5         ��Name$ ComboBoxGenre��52      $
��Left=�6*   $��
637,39,0,0q�6E   $	��Top=�6Y   $	��120��6q   �� 53   
   -   5        $ ComboBoxAuteur��53      $
��Left=�6+   $��
863,39,0,0q�6F   $	��Top=�6Z   $	��120��6r   �� 54   
   -   5        $ ComboBoxEdition��54      $
��Left=�6,   $��1118,36,0,0q�6G   $	��Top=�6\   $	��120��6t   �� 55   
   $��Genre��6   $
��Left=�6    $��
565,28,0,0q�6;   $	��Top=�6O   
�������$��22(�6{   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�   �� 56   
   $��Auteur��6   $
��Left=�6!   $��
784,27,0,0q�6<   $	��Top=�6P   
�������$��22(�6{   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�   $��94��6�    J� RenderTransformOrigin$ 0.312,0.493&�6�   �� 57   
   $��Edition��6   $
��Left=�6"   $��1030,28,0,0q�6=   $	��Top=�6R   
�������$��22(�6}   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�   �� 58   
   $��Titre��6   $
��Left=�6    $��	10,28,0,0q�6;   $	��Top=�6N   
�������$��22(�6y   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�   59      5:      