   M S B A M L   `   `   `  ����N  JFootballMenagerMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FootballMenagerMVVM.ViewFootballMenagerMVVM.View  5   	   M+clr-namespace:FootballMenagerMVVM.ViewModelFootballMenagerMVVM.ViewModel  5   	   )    #FootballMenagerMVVM.View.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   2local&clr-namespace:FootballMenagerMVVM.View  5   	   4vm+clr-namespace:FootballMenagerMVVM.ViewModel  5   	     � Title$           MenagerMVVM��5   	   $	��450��5      $��850         ��6#    � 	Resources 5      <  6FootballMenagerMVVM.ViewModel.FootballMenagerViewModel   footballmenagerviewmodel��%   &	          5   
   6&   5       � DataContext 5      �� 5   
    �� ResourceKey$ footballmenagerviewmodel��6   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     PassEventArgsToCommand .    Command 6$   �� 	 �� Path$	 LoadDataCommand�
 �� Source#
 [  6   5        5   
   $ 	LostFocus��6   . 5         .  6$   �� $	 SaveDataCommand�#
 [  6~   5      .��5      � # [  6    � RowDefinitions 5      �� 5      $��0.10* �6    �� 5       $��0.15* �6    �� 5!      $��0.15* �6    �� 5"      $��0.15* �6    �� 5#      $��0.15* �6    �� 5$      $��0.15* �6    �� 5%      $��0.15* �6     � ColumnDefinitions 5)      �� 5*      $��0.25* �6#   �� 5+      $��0.25* �6#   �� 5,      $
��0.5* �6#   .+�50      �� $��0��6   $��0��6(   $��Name: ��65   $��15(�6C    �� Padding$ 	30 10 0 0q�6Q   0   *FootballMenagerMVVM.View.TextBoxForLetters  51      -   5          Name$ textBoxForename��51   C   $��1��6&   $��0��66   $��10q�6\   $��15(�6h   
�������$��Center=�53   &   $��Stretch=�6A      Text 52   &   �� $	 Forename� �� Mode$ TwoWay=�53   A   �� 56      $��0��6   $��1��6(   $��
LastName: ��65   $��15(�6G   $ 	30 10 0 0q�6U     57      -   5        $ textBoxSurname��57   E   $��1��6&   $��1��66   $��10q�6]   $��15(�6i   
�������$��Center=�59   "   $��Stretch=�6=    58   "   �� $	 Surname�$ TwoWay=�59   =   � 5<      $��0q�6    � Orientation$ 
Horizontal=�6$   $��2��6=   $��0��6J   $��2��6Z   $��2��6k   .+�5@      �� $��Age: ��6   $��15(�6(   $��50��66   $
��Left=�6A   �� 5A      $��15(�6P   $
��Left=�6^   ��6   �� $	 Value� �� ElementName$ 	sliderAge��6^   �� 5B      -   5         ��Name$ 	sliderAge��5B      $	��300��6-   $��5q�69   
���  ��$��Center=�6W    � SmallChange$ 1Q�5C       �� TickPlacement$ BottomRight=�6)    � Maximum$ 50Q�6E    � Minimum$ 0Q�6R    �� IsSnapToTickEnabled . $��0q�5D   ]    � Value 6   �� $		 Age�$ TwoWay=�6]   �� 5G      $��Weight: ��6   $��15(�6+   $��50��69   $
��Left=�6D   �� 5H      $��12(�6S   $
��Left=�6a   ��6   �� $	 Value�$ sliderWeight��6a   �� 5I      -   5        $ sliderWeight��5I      $	��300��60   $��5q�6<   
���  ��$��Center=�6Z   $ 1Q�5J      $ BottomRight=�6)   $	 100Q�5K      $ 0Q�6'    . $��0q�5L       5K   3   �� $	 Weight�$ TwoWay=�5L      5M      �� 5O      $��0��6B   $��4��6S   
������$	��Add��6x   $��
10 10 10 0q�6�   $��2��6�   $��15(�6�   ��6   �� *
AddCommand+$ OneWay=�6�   �� 5R   
   $��0��6A   $��5��6R   
�������$��Delete��6w   $��
10 10 10 0q�6�   $��2��6�   $��15(�6�   ��6   �� *DeleteCommand+$ OneWay=�6�   �� 5U      $��0��6B   $��6��6S   
���z���$��Modify��6y   $��10 10 10 17q�6�   $��2��6�   $��15(�6�   ��6   �� *EditCommand+$ OneWay=�6�   �� 5Y   
   $��2��6   $��0��6"   $��10��6/   $��15(�6A   ��6O   �� $	 StoredPlayers� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5Z      �� $	 SelectedPlayer�$ TwoWay=� 5\        5]      $ SelectionChanged��6!   . 5^         6,   �� $	 CopyCommand�5_      5a      5b      5c      