   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      @ <MVVM3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MVVM3.ViewsMVVM3.Views 5      1clr-namespace:MVVM3.ViewModelMVVM3.ViewModel 5	      &    MVVM3.Views.GetRelatedValuesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5      %localclr-namespace:MVVM3.Views  5      -	viewModelclr-namespace:MVVM3.ViewModel  5	        � DataContext  5      /  )MVVM3.ViewModel.GetRelatedValuesViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� 
�����F�$��1q�6)    �� CornerRadius$ 10��6=   $��	10,0,30,0q�6P   ._�5      �� $��0��6   $��	10,0,10,0q�6*   .+�5      �� $��Get Related Values��6   $��22(�65   $��SemiBold"�6C   $��Center=�6Y   �� 5      $�� ��6   $��2(�6#   $��SemiBold"�60   $
��Left=�6F   �� 5      $��DMS Type��6   $��14(�6+   $��SemiBold"�69   $��Center=�6O   �� 5      $��0,2,0,0q�6_   $��14(�6p   $��Regular"�6~   ��6   �� *Types+ �� SelectedItem 69   �� *SelectedType+6~   �� 5      $��
Global IDs��6   $��14(�6-   $��SemiBold"�6;   $��Center=�6Q   �� 5      $��0,2,0,0q�6]   $��14(�6n   $��Regular"�6|   ��6   �� *Gids+ 68   �� *SelectedGid+6|   �� 5      $��	Reference��6   $��14(�6,   $��SemiBold"�6:   $��Center=�6P   �� 5      $��0,5,0,10q�6r   $��14(�6�   $��Regular"�6�   ��6   �� *
References+ 6>   �� *SelectedReferenceModelCode+6�   �� 5!      $��
Properties��6   $��14(�6-   $��SemiBold"�6;   $��Center=�6Q   �� 5"      -   5        $��property��5"   4    �� SelectionMode$ Extended=�6   $��14(�5$      $��Regular"�5%      ��5#      �� *
Properties+.   (System.Windows.Interactivity.Interaction   Triggers 5&      /   )System.Windows.Interactivity.EventTrigger  5'         	EventName$ SelectionChanged��6)   .   (System.Windows.Interactivity.TriggerBase   Actions. 5(      B  <Microsoft.Expression.Interactivity.Core.ChangePropertyAction     PropertyName$ SelectedItems��6[   8   2System.Windows.Interactivity.TargetedTriggerAction	   TargetObject	 66   �� 
 �� Mode$
 OneWay=�   Value 6x   ��  �� Path$ SelectedItems� �� ElementName$ property��5)      5+      �� 50       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��Center=�6S   .+�51      �� $"��   Clear Selected Props     ��6   
������
������$��2q�6�   $��14(�6�   $��SemiBold"�6�   $��0, 10, 0, 0q�6�   ��6D   �� *ClearProperties+6�   �� 52      
���""��
���""��$��2q�6L   $��    Reset All    ��6`   $��14(�6�   $��SemiBold"�6�   $��10, 10, 0, 0q�6�   ��6|   �� *
ResetAll+6�   53      �� 55      
�����F�
�����F�$��2q�6H   $!��Get Values ~ Apply Criteria��6\   $��14(�6�   $��SemiBold"�6�   $��0, 10, 0, 0q�6�   ��6�   �� *GetRelatedValuesCriteria+6�   56      57      � 5:   
   $��1��6   .+�5;      �� 
�����F�$��1q�6-   $ 10��6A   $��
-15,0,10,0q�6T   ._�5<      �� $��0��6   $��	10,0,10,0q�6.   .+�5=      �� $7��1Listing of available values for selected criteria��6   $��22(�6X   $��SemiBold"�6f   $��Center=�6|   �� 5>      $�� ��6   $��6(�6'   $��SemiBold"�64   $
��Left=�6J   �� 5A      
�����F�$	��0.5q�65   $ 5��6K   ._�5B      �� $
��Auto=�6'   $
��Auto=�6J   $	��550��5C      .��5D      R� $��14(�6P   $��Regular"�6^   ��6'   �� *ListedProperties+��5E   "   �� 5F   &    �� ItemsSource 6?   �� *
Properties+.R�5G   *   �� 
�����F�
�������$��SemiBold"�6�   ��64   �� *ParentElementName+6�    �� ItemTemplate 5H   *   �� 5I   .   .R�5J   2   �� $ 
Horizontal=�6=   .+�5K   6   �� ��6@   �� *	ModelCode+�� 5L   6   $	�� - ��6@   �� 5M   6   $��SemiBold"�6W   ��6@   �� *Value+6W   5N   3   5O   /   5Q   '   5S      5T      5U      5W      5X      5Y      5Z      5[      