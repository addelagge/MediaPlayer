   M S B A M L   `   `   `  ����  MediaPlayer"    MediaPlayerApp.ViewAlbumPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  ViewAlbumPage��5      .��5
      �  � RowDefinitions 5   
   �� 5      $��20 �6   6*   �� 5      $��6* �6   6*   �� 5      $��1* �6   6*    � ColumnDefinitions 5   
   �� 5      $��2* �6   6,   �� 5      $��5* �6   6,   .+�5   
   ��  
  player � DataContext# [  6   $��Italic$�6:   $��16(�6i   $��5,0,0,0q�6w   ��6M   �� *
Album.Name+6�   �� 5   
   -   5         ��Name$ lbxAlbum��5      # [  6$   $��1��6J   $��2��6W   $��5q�6h   ��6s   �� *Album.MediaFiles+��5      �� 5       .R�5!      �� ��6    �� *
FileName+5"      5$      �� 5(   
   $��1��6   $��1��6"   $��0,0,5,0q�62   .+�5)      �� -   5        $��
imgPreview��5)      $	��234��6&   �� 5*       �� AcceptsReturn .  �� MinLines$ 2��6+   {�.  $��Bottom=�6�   $��33��6�   $��0,3,0,0q�6�   ��6J   ��  �� ElementName$ lbxAlbum�� �� Path$ SelectedItem.Description�6�   5+      �� 5-   
   $��1��6   $��2��6%   $��5,5,5,0q�62   .+�5.      �� $��Update interval��6   61   �� 5/      	 �� Orientation$	 
Horizontal=�6   .+�50      �� -   5        
 ��Name$
 txtUpdateInterval��50   @   $��60��6   $
��Left=�6%   $��3��6[   �� 51      -   5        $��btnCreateSlideShow��51      $
��Left=�63   $��96��6N   $��10,0,0,0q�52   :   $��Start slide show��6L   {�51   Y   �� $ txtUpdateInterval��$
 Text�  isIntConverter �� 	Converter# [ 52   L   54      55      58      59      