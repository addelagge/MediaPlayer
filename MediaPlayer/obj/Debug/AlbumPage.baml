   M S B A M L   `   `   `  ����F  BMediaPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MediaPlayerAppMediaPlayerApp  5          MediaPlayerApp.AlbumPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MediaPlayerApp     5        N� Title$  	New album��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      $��20 �6   6*   �� 5      6   �� 5      6   �� 5      6   .+�5   
   o� $��4��6   .@�5      m� $
��Menu��6   .@�5      m� -   5        $��
mnuAddFile��5      $��Add media file��6-   6`   m� 5      -   5        $��	mnuChange��5      $��Change album name��6,   6a   m� 5      -   5        $��mnuSave��5      $��
Save album��6*   6V   5      5      �� 5!   
   $��1��6   $��2��6"   $��5,0,0,0q�63   .+�5"      �� $��Folders��6   6)   R� 5#      -   5        $
��tree��5#       
  mapper � DataContext# [  6#   $	��181��6l   ��6I   �� *
Tree.Items+��5$      �� 5%       �� DataType$ 
local:Node��6/    �� ItemsSource 6E   �� *Items+.R�5&      ��  �� Orientation$ 
Horizontal=�6%   .+�5'      �� $��8��6k   $��8��6u   ��6$   �� *Icon+  nullImageConverter �� 	Converter# [ 6�   �� 5(      ��6(   ��  �� Path$ Header�6G   5)      5*      5,      5-      �� 5/   
   $��1��6   $��1��6"   $��2��62   $��5,0,0,0q�6C   .+�50      �� $��Media files��6   6-   �� 52      -   5        $��	picsPanel��52      $	��195��6�   ��6U   �� 	 �� ElementName$
	 tree��$ SelectedItem.ImagePaths���53      �� 54      .R�55      �� ��6$   �� *
FileName+6@   56      58      5:      �� 5=   
   $��2��6   $��1��6&   $��2��63   $��2��6D   $��5,0,5,0q�6X   .+�5>      �� -   5        $��
imgPreview��5>      $
��Fill=�6&   $	��187��65   $	��195��6B   $
��Left=�6N   $��0,0,-5,0q�6i   �� 5?      -   5        
 ��Name$
 btnAdd��5?      $��Add image above to album��6%   $��0,3,0,0q�6�   {�6H   �� *SelectedIndex+  selectedConverter# [ $	 	picsPanel��6�   5@      �� 5C   
   $��3��6   $��2��6"    
 player# [ 67   $��5,0,0,0q�6^   .+�5D      �� $��Italic$�64   $
��Left=�6G   ��6   �� *
Album.Name+6G   �� 5E      .��5F      �� -   5        $��lbxAlbum��5F      $��65��6S   ��6*   �� *Album.MediaFiles+��5G      �� 5H      .R�5I      �� ��6(   �� *
FileName+6D   5J      5L      5M      �� 5N      -	   5        $
 	btnRemove��5N      $��Remove image from album��6(   $��0,3,17,0q�5O   -   {�5N   J   �� *SelectedIndex+# [ $	 lbxAlbum��5O   -   5P      �� 5S   
   $��2��6   $��3��6%   $��2��62   $��5,0,5,0q�6F   .+�5T      �� -
   5        $��txtDescription��5T      
����ح� � ToolTip$# Description of the media file��6C    �� 
IsReadOnly . $��40��6}   $	��0,2q�5U   [   ��6   �� $	 lbxAlbum��$ SelectedItem.Description�6[   �� 5W      -   5        $
 btnAddDescription��5W      $,��&Add description of selected album file��6P   {�5X      �� $	 lbxAlbum��$ SelectedIndex�# [ �� 5Z      -   5        $
 btnViewAlbum��5Z      # [ 6+   $��30��6Q   $��0,10,0,0q�6|   $��
View album��6�   $��Bottom=�5[      {�5Z   ]   �� *
HasMedia+5[      5\      5_      5`      