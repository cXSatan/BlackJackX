   M S B A M L   `   `   `  ����D  @BlackJack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BlackJack	BlackJack  5   	       BlackJack.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BlackJack     5   	     � Title$  
MainWindow��5	   	   $��388.62��6   $��553.966��6,   .��5      � -   5         �Name$
 grid��5       � RowDefinitions 5   
   �� 5      $	��81* �6   �� 5      $
��174* �6   �� 5      $
��103* �6    � ColumnDefinitions 5   
   �� 5      $	��99* �6   �� 5      $
��350* �6   �� 5      $	��97* �6   ��5   
   �� 5       �� ImageSource$h bC:\Users\User\Desktop\Programaçao 2\Projectos\BlackJack/Images\Cards With Bg/tableBackground.jpeg��6   6�   .+�5   
   �� -   5         ��Name$ carvas��5      $��
10,10,0,24q�6!   $��3��65   $��3��6F   $
��Left=�6Z   $	��526��6u   5      �� 5   
   -   5         ��Name$ Slider��5       � Maximum$	 100Q�5       �� TickFrequency$ 10Q�5      	 �� TickPlacement$	 BottomRight=�5       
������ 
�������$��20��5#      $	��100��5$      
 �� IsSnapToTickEnabled
 . 
 �� Top$	 280��5&       �� Left$ 10��6&   $��2��67   $��19,27,330,56q�6K   $��2��6a   �� 5(   
   -   5         ��Name$ bet_txt��5(      $��75,59,335,24q�6&   $��2��6<   
�������$��2��6�   ��6I   ��  �� ElementName$ Slider�� �� Path$ Value� �� Mode$ TwoWay=�6�   �� 5)   
   -   5         ��Name$	 bet��5)      $��Apostar��6   $��1��6B   $
��Left=�6R   $��	24,22,0,0q�6m   $��2��6�   $	��Top=�6�   $��63��6�   $��57��6�   �� 5*   
   -   5        $	 hit��5*      {�.  $��Hit me��6B   $��1��6S   $
��Left=�6c   $��
112,22,0,0q�6~   $��2��6�   $	��Top=�6�   $��63��6�   $��57��6�   �� 5+   
   -   5        $ stand��5+      $��Stand��6    {�.  $��1��6W   $
��Left=�6g   $��
203,22,0,0q�6�   $��2��6�   $	��Top=�6�   $��63��6�   $��57��6�   �� 5-   
   -   5        $ pJogador��5-      $��1��6&   $��128,166,189,86q�66   $��1��6N   $��2��6[   
�������6l   �� 5:   
   -	   5        $ vitoria��5:      $y�Hidden=�6%   
�������$��1��6L   $��307,41,41,52q�6\   $��1��6r   $��2��6   6�   �� 5;   
   -
   5        $ pCasa��5;      $��1��6#   $��137,10,180,46q�63   
�������6J   5<      5>      