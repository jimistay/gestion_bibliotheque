   M S B A M L   `   `   `  ����O  Kgestion_bibliotheque, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:gestion_bibliotheque.View.livres gestion_bibliotheque.View.livres  5      .    (gestion_bibliotheque.View.livres.Ajouter   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:gestion_bibliotheque.View.livres     5        N� Title$  Ajouter��5	      .��5      � .+�5   
   �� $��Titre :��6   $
��Left=�6"   $��
188,62,0,0q�6=   $	��Top=�6Q   
�������$��22(�6|   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�   �� 5   
   -   5         ��Name$ TitreTextBox��5      $
��Left=�6(   $��
262,72,0,0q�6C   $	��Top=�6W   $	��151��6o   $��24��6{   �� 5   
   $��Date de publication :��6   $
��Left=�60   $��
42,108,0,0q�6K   $	��Top=�6_   
�������$��22(�6�   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DatePublicationTextBox��5      $
��Left=�65   $��262,118,0,0q�6P   $	��Top=�6e   �� 5   
   $��Couverture :��6   $
��Left=�6'   $��127,219,0,0q�6B   $	��Top=�6W   
�������$��22(�6�   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�   �� 5   
   -   5        $ CouvertureTextBox��5      $
��Left=�6-   $��259,234,0,0q�6H   $	��Top=�6]    �� 
IsReadOnly$
 True��6v   $	��151��6�   $��24��6�   �� 5   
   -   5        $��Sélectionner��5      $
��Left=�6(   $	��Top=�6C   $	��120��6[   $��427,236,0,0q�6g   6|   �� 5   
   $��Genre :��6   $
��Left=�6"   $��700,230,0,0q�6=   $	��Top=�6R   
�������$��22(�6}   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�   �� 5   
   -   5         ��Name$ GenreComboBox��5       �� DisplayMemberPath$ 	NOM_GENRE��6*    �� SelectedValuePath$ 	NOM_GENRE��6H   $
��Left=�6f   $��800,236,0,0q�6�   $	��Top=�6�   $	��151��6�   $��24��6�   �� 5   
   $��Auteur :��6   $
��Left=�6#   $��692,164,0,0q�6>   $	��Top=�6S   
�������$��22(�6~   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�   �� 5   
   -   5        $ AuteurComboBox��5      $ 
NOM_AUTEUR��6+   $ 
NOM_AUTEUR��6J   $
��Left=�6i   $��800,176,0,0q�6�   $	��Top=�6�   $	��151��6�   $��24��6�   �� 5    
   $��	Edition :��6   $
��Left=�6$   $��684,102,0,0q�6?   $	��Top=�6T   
�������$��22(�6   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�   �� 5!   
   -   5        $ EditionComboBox��5!      $ NOM_EDITION��6,   $ NOM_EDITION��6L   $
��Left=�6l   $��800,114,0,0q�6�   $	��Top=�6�   $	��151��6�   $��24��6�   �� 5&   
   -   5        $��Ajouter��5&      $	��Top=�6#   $��53��6;   $��580,354,562,0q�6G   $��20(�6_    J� RenderTransformOrigin$ 0.5,0.5&�6m   
������� K� ZIndex$ 1��6�   
���   ���5'      �� 5(      	 �� 
TargetType"	 ��6   .�5)      �� 
 �� Property
 � �� �� Value 5*      �� 5+       �� 
TargetType" ��6.   .R�5,   "   ��  �� CornerRadius$ 30��6)   #��z��6;   ._�5-   &   �� $��Center=�67   $��Center=�6T   5.   #   5/      51      52      54      56      57      