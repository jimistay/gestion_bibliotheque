   M S B A M L   `   `   `  ����O  Kgestion_bibliotheque, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:gestion_bibliotheque.View.location"gestion_bibliotheque.View.location  5      0    *gestion_bibliotheque.View.location.Ajouter   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:gestion_bibliotheque.View.location     5        N� Title$  Ajouter��5	      .��5      � .+�5   
   �� $��Date de location :��6   $
��Left=�6-   $��
361,58,0,0q�6H   $	��Top=�6\   
�������$��22(�6�   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DateLocationTextBox��5      $��Center=�62   $��0,62,0,0q�6O   $	��Top=�6a   �� 5   
   $#��Date attendue (2 semaines) : ��6   $
��Left=�68   $��262,113,0,0q�6S   $	��Top=�6h   
�������$��22(�6�   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�     5   
   -   5        $! DateLocationAttendueTextBox��5      $��Center=�6:   $��	0,121,0,0q�6W   $	��Top=�6j    J� RenderTransformOrigin$ 0.529,-0.003&�6�   �� 5   
   $��Livre :��6   $
��Left=�6"   $��472,174,0,0q�6=   $	��Top=�6R   
�������$��22(�6}   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�   �� 5   
   -   5         ��Name$ LivreComboBox��5       �� DisplayMemberPath$ TITRE��6*    �� SelectedValuePath$ LIVRE_ID��6D   $
��Left=�6a   $��575,183,0,0q�6|   $	��Top=�6�   $	��120��6�   �� 5   
   $��Utilisateur :��6   $
��Left=�6(   $��415,225,0,0q�6C   $	��Top=�6X   
�������$��22(�6�   $��Palatino Linotype)�6�   $
��Bold"�6�   $��Italic$�6�   �� 5   
   -   5        $ UtilisateurComboBox��5      $ NOMCPTE��60   $
 USER��6L   $
��Left=�6e   $��575,240,0,0q�6�   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $��Ajouter��5      $	��Top=�6#   $��53��6;   $��567,323,575,0q�6G   $��20(�6_   $ 0.5,0.5&�6m   
������� K� ZIndex$ 1��6�   
���   ���5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � ��	 �� Value	 5      �� 5       
 �� 
TargetType"
 ��6.   .R�5!   "   ��  �� CornerRadius$ 30��6)   #��z��6;   ._�5"   &   �� $��Center=�67   $��Center=�6T   5#   #   5$      5&      5'      5)      5*      5+      