   M S B A M L   `   `   `  ����@  <MVVM3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MVVM3.ViewsMVVM3.Views  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      1clr-namespace:MVVM3.ViewModelMVVM3.ViewModel  5
          MVVM3.Views.GetValuesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:MVVM3.Views     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5      -	viewModelclr-namespace:MVVM3.ViewModel  5
        � DataContext  5      (   "MVVM3.ViewModel.GetValuesViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� 
�����F�$��1q�6)    �� CornerRadius$ 10��6=   $��	10,0,30,0q�6P   ._�5      �� $��0��6   $��	10,0,10,0q�6*   .+�5      �� $��
Get Values��6   $��22(�6-   $��SemiBold"�6;   $��Center=�6Q   �� 5      $�� ��6   $��6(�6#   $��SemiBold"�60   $
��Left=�6F   �� 5      $��DMS Type��6   $��14(�6+   $��SemiBold"�69   $��Center=�6O   �� 5      $��0,5,0,10q�6_   $��14(�6q   $��Regular"�6   ��6   �� *Types+ �� SelectedItem 69   �� *SelectedType+6   �� 5      $��
Global IDs��6   $��14(�6-   $��SemiBold"�6;   $��Center=�6Q   �� 5      $��0,5,0,10q�6]   $��14(�6o   $��Regular"�6}   ��6   �� *Gids+ 68   �� *SelectedGid+6}   �� 5      $��
Properties��6   $��14(�6-   $��SemiBold"�6;   $��Center=�6Q   �� 5      -   5        $��property��5   4    �� SelectionMode$ Extended=�6   $��14(�5!      $��Regular"�5"      ��5       �� *
Properties+.  (System.Windows.Interactivity.Interaction   Triggers 5#      /  )System.Windows.Interactivity.EventTrigger  5$         	EventName$ SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5%      B  <Microsoft.Expression.Interactivity.Core.ChangePropertyAction     PropertyName$ SelectedItems��6[   8  2System.Windows.Interactivity.TargetedTriggerAction	   TargetObject	 66   �� 
 �� Mode$
 OneWay=�   Value 6x   ��  �� Path$ SelectedItems� �� ElementName$ property��5&      5(      �� 5*       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��Center=�6S   .+�5+      �� $"��   Clear Selected Props     ��6   
������
������$��2q�6�   $��14(�6�   $��SemiBold"�6�   $��0, 10, 0, 0q�6�   ��6D   �� *ClearProperties+6�   �� 5,      
���""��
���""��$��2q�6L   $��    Reset All    ��6`   $��14(�6�   $��SemiBold"�6�   $��10, 10, 0, 0q�6�   ��6|   �� *
ResetAll+6�   5-      �� 5/      
�����F�
�����F�$��2q�6H   $!��Get Values ~ Apply Criteria��6\   $��14(�6�   $��SemiBold"�6�   $��0, 10, 0, 0q�6�   ��6�   �� *GetValuesCriteria+6�   50      51      � 54   
   $��1��6   .+�55      �� 
�����F�$��1q�6-   $ 10��6A   $��
-15,0,10,0q�6T   ._�56      �� $��0��6   $��	10,0,10,0q�6.   .+�57      �� $7��1Listing of available values for selected criteria��6   $��22(�6X   $��SemiBold"�6f   $��Center=�6|   �� 58      $�� ��6   $��6(�6'   $��SemiBold"�64   $
��Left=�6J   &   System.Windows.Controls.DataGrid  5;         AutoGenerateColumns .     CanUserSortColumns .     CanUserAddRows .     CanUserResizeColumns .     CustomDataGridStyle#��[  6�   ��6   �� *ListedProperties+   Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ 
Model Code��61    	  
IsReadOnly .  	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	 250
 6u   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *	ModelCode+6u     5>      $ Value��61    . $ *
 6m    6@   �� *Value+6m   5@      5A      5B      5C      5D      5E      