   M S B A M L   `   `   `  ����@  <MVVM3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MVVM3.ViewsMVVM3.Views  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      1clr-namespace:MVVM3.ViewModelMVVM3.ViewModel  5
      %    MVVM3.Views.GetExtentValuesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:MVVM3.Views     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5      -	viewModelclr-namespace:MVVM3.ViewModel  5
        � DataContext  5      .   (MVVM3.ViewModel.GetExtentValuesViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� 
�����F�$��1q�6)    �� CornerRadius$ 10��6=   $��	10,0,30,0q�6P   ._�5      �� $��0��6   $��	10,0,10,0q�6*   .+�5      �� $��Get Extent Values��6   $��22(�64   $��SemiBold"�6B   $��Center=�6X   �� 5      $�� ��6   $��6(�6#   $��SemiBold"�60   $
��Left=�6F   �� 5      $��DMS Type��6   $��14(�6+   $��SemiBold"�69   $��Center=�6O   �� 5      $��0,5,0,10q�6_   $��14(�6q   $��Regular"�6   ��6   �� *Types+ �� SelectedItem 69   �� *SelectedType+6   �� 5      $��
Properties��6   $��14(�6-   $��SemiBold"�6;   $��Center=�6Q   �� 5      -   5        $��property��5   4    �� SelectionMode$ Extended=�6   $��14(�5      $��Regular"�5       ��5      �� *
Properties+.  (System.Windows.Interactivity.Interaction   Triggers 5!      /  )System.Windows.Interactivity.EventTrigger  5"         	EventName$ SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5#      B  <Microsoft.Expression.Interactivity.Core.ChangePropertyAction     PropertyName$ SelectedItems��6[   8  2System.Windows.Interactivity.TargetedTriggerAction	   TargetObject	 66   �� 
 �� Mode$
 OneWay=�   Value 6x   ��  �� Path$ SelectedItems� �� ElementName$ property��5$      5&      �� 5(       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��Center=�6S   .+�5)      �� $"��   Clear Selected Props     ��6   
����=H�
����=H�$��2q�6�   $��14(�6�   $��SemiBold"�6�   $��0, 10, 0, 0q�6�   ��6D   �� *ClearProperties+6�   �� 5*      
���""��
���""��$��2q�6L   $��    Reset All    ��6`   $��14(�6�   $��SemiBold"�6�   $��10, 10, 0, 0q�6�   ��6|   �� *
ResetAll+6�   5+      �� 5-      
��� d �
��� d �$��2q�6H   $!��Get Values ~ Apply Criteria��6\   $��14(�6�   $��SemiBold"�6�   $��0, 10, 0, 0q�6�   ��6�   �� *GetExtentValuesCriteria+6�   5.      5/      � 52   
   $��1��6   .+�53      �� 
�����F�$��1q�6-   $ 10��6A   $��
-15,0,10,0q�6T   ._�54      �� $��0��6   $��	10,0,10,0q�6.   .+�55      �� $7��1Listing of available values for selected criteria��6   $��22(�6X   $��SemiBold"�6f   $��Center=�6|   �� 56      $�� ��6   $��6(�6'   $��SemiBold"�64   $
��Left=�6J   �� 59      
�����F�$	��0.5q�65   $ 5��6K   ._�5:      �� $
��Auto=�6'   $
��Auto=�6J   $	��550��5;      .��5<      R� $��14(�6N   $��Regular"�6\   ��6'   �� *ListedEntities+��5=   "   �� 5>   &    �� ItemsSource 6?   �� *
Properties+.R�5?   *   �� 
�����F�
�������$��SemiBold"�6�   ��64   �� *ParentElementName+6�    �� ItemTemplate 5@   *   �� 5A   .   .R�5B   2   �� $ 
Horizontal=�6=   .+�5C   6   �� ��6@   �� *	ModelCode+�� 5D   6   $	�� - ��6@   �� 5E   6   $��SemiBold"�6W   ��6@   �� *Value+6W   5F   3   5G   /   5I   '   5K      5L      5M      5O      5P      5Q      5R      5S      