   M S B A M L   `   `   `  ����@  <MVVM3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MVVM3.ViewsMVVM3.Views  5      1clr-namespace:MVVM3.ViewModelMVVM3.ViewModel  5          MVVM3.Views.HomeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:MVVM3.Views     5      3	viewModelclr-namespace:MVVM3.ViewModel     5        � DataContext  5
      #   MVVM3.ViewModel.HomeViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��150 �6   �� 5      $	��150 �6   �� 5      $	��100 �6    � ColumnDefinitions 5   
   �� 5      $	��350 �6   �� 5      $	��450 �6   �� 5      $��50 �6   .+�5   
   �� $��1��6   $��1��5      $��66(�5      $��DemiBold"�5      $��Bottom=�5      ��5      �� *ApplicationTitle+5      �� 5   
   $��2��6   $��1��5       $��22(�5"      $��DemiBold"�5#      $	��Top=�5$      $
��Wrap=�5%      ��5!      �� *ApplicationSubtitle+5%      �� 5'   
   $��2��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $
��Left=�6K   $��Stretch=�6f   $��0, 50, 0, 50q�6�   .+�5(      �� $%��  ↹ Import & Apply Delta     ��6   
�����F�
�����F�$��2q�6�   $��16(�6�   $��SemiBold"�6�   $��0, 10, 0, 0q�6�   ��6A   �� *	ImportXml+6�   �� 5)      
���""��
���""��$��2q�6D   $��   ⟳ Fresh Start    ��6X   $��16(�6�   $��SemiBold"�6�   $��10, 10, 0, 0q�6�   ��6w   �� *
ResetAll+6�   5*      5+      5,      