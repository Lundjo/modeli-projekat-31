   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      @ <MVVM3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MVVM3MVVM3 5      )clr-namespace:MVVM3.ViewsMVVM3.Views 5      1clr-namespace:MVVM3.ViewModelMVVM3.ViewModel 5	         MVVM3.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      %localclr-namespace:MVVM3     5      +viewsclr-namespace:MVVM3.Views     5      3	viewModelclr-namespace:MVVM3.ViewModel     5	      -   5        $��MainWindowRef��5
   	     � Title$  
GDA Client��6    � WindowStyle$
 None=�61   $	��735��6D    � 
ResizeMode$ NoResize=�5   	   
�������$
��1000��5       � WindowStartupLocation$ CenterScreen=�6)    � DataContext 5      )  #MVVM3.ViewModel.MainWindowViewModel  5   
    � 	Resources 5       �� DataType#  MVVM3.ViewModel.HomeViewModel  MVVM3.Views.HomeView(  "MVVM3.ViewModel.GetValuesViewModel  MVVM3.Views.GetValuesView/  )MVVM3.ViewModel.GetRelatedValuesViewModel&   MVVM3.Views.GetRelatedValuesView.  (MVVM3.ViewModel.GetExtentValuesViewModel%	  MVVM3.Views.GetExtentValuesView��%,  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5      	  5      5      .��5      � 
�������.+�5   
   �  � ColumnDefinitions 5       �� 5!      $��* �6#   �� 5"      $��* �6#    � RowDefinitions 5$      �� 5%      $��50 �6    �� 5&      $��12 �6    �� 5'      $��* �6    �� 5(      $��40 �6    .+�5*      �� $��2��6   $��3��6"   68   � 5,      $��0��6   $��Center=�6    $��0��6=   $��2��6M   .+�5-      �� $��170,5,200,5q�6   
�����F�$��1q�6F   	 �� CornerRadius$	 5��6Z   
�������._�5.      �  5/      �� 50      $��0 �6/   �� 51      $	��120 �6/   �� 52      $	��120 �6/   �� 53      $	��160 �6/   �� 54      $	��220 �6/   �� 55      $	��220 �6/   .+�57      �� -   5        
 ��Name$

 home��57   1   $��1��6!   
������ $��0q�6w   $
��Home��6�   $��20(�6�   $
��home��6�   ��6?   �� *
NavCommand+6�   �� 58      -   5        $
 related��58   1   $��4��6!   
������ $��0q�6[   $��Get Related Values��6o   $��20(�6�   $��related��6�   ��6�   �� *
NavCommand+6�   �� 59      -   5        $	
 get��59   1   $��2��6!   
������ $��0q�6W   $��
Get Values��6k   $��20(�6�   $	��get��6�   ��6�   �� *
NavCommand+6�   �� 5:      -   5        $
 extent��5:   1   $��3��6!   
������ $��0q�6Z   $��Get Extent Values��6n   $��20(�6�   $��extent��6�   ��6�   �� *
NavCommand+6�   5;      5<      �� 5=      -   5        $
 close��5@   	   $��	914,0,0,0q�5=      $��35��5>   	   $��76��5?   	   $��0q�5A   	   $��20(�5B   	   $��Center=�5D   	   $��Center=�5E   	   ��5C   	   �� *CloseWindowCommand+��5F   	   ��  �� ElementName$ MainWindowRef�� 5G       �� 
TargetType �� Property �� Value �� 
TargetType��%t  '��       �� 5I      " ��6    .�5J      ��  � ��
 ���� 6;   �� 5K       � ��$ 0q�6@   �� 5L       � ��$ 20(�69   �� 5N       � �� 5O   "   �� 5P   &   " ��66   .R�5Q   *   �� #��z��61   #��z��5R   !   #��z��5S   !   $	 5��5T   !   ._�5U   .   �� $��Center=�6?   $��Center=�6\   5V   +   5W   '   5Y      5Z      5[      ��5\      �� 5]      $��/assets/close.png��6    $��64��6;   $��37��6F   5_      5`      �� 5a      $��2��6   $��0��6*   $��2��6:   ��6N   �� *CurrentViewModel+5b      �� 5d   
   $��2��6   $��Stretch=�6!   $��Bottom=�6?   
�������$��14(�6�   ��6Z   ��  �� Path$ BackgroundColor�.@�5e      �� .��5f      �� $��10,0,0,0q�6   ��6.   �� $ StatusMessage�5g      5h      5i      5j      