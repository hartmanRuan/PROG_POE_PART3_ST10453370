   M S B A M L   `   `   `  ����F  BChatbotGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ChatbotGameChatbotGame  5   	   "    ChatbotGame.ChatbotInterface   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ChatbotGame     5   	     � Title$  ChatbotInterface��5   	   $	��450��6"   $	��800��6/   .��5	      � ���	#FFE3E3E3.+�5
   
   �� $��Center=�6   $	��100��61   
���   �$	��Top=�6M   $	��800��6e   ���	#FFBB14146q   �� 5   
   -   5        $��
rctSideBar��5      $
��Left=�6&   $	��334��6A   $��	0,100,0,0q�6N   ���	#FFC50F0F$	��Top=�6t   $	��139��6�   
�������6�   �� 5   
   -   5        $��
lblHeading��5      $��Chatbot��6"   $��Center=�64   $��0,13,0,0q�6Q   $	��Top=�6c   $
��Bold"�6{   $��48(�6�   
�������6�   �� 5   
   $
��Left=�6   $��77��6+   $��	48,11,0,0q�67   $	��Top=�6J   $��91��6b   $'��!/Screenshot 2025-06-05 131251.png��6m   $
��Fill=�6�    J� OpacityMask 5      �� 5       �� ImageSource$' !/Screenshot 2025-06-05 131251.png��6    j� Stretch$
 Fill=�6M   5      �� 5   
   -   5        $��lblLoginHeading��5      $��Login:��6'   $��Center=�68   $��	0,145,0,0q�6U   $	��Top=�6h   $
��Bold"�6�   $��18(�6�   �� 5   
   -   5        $��btnEnterLogin��5      $��Enter��6&   $��Center=�66   $��	0,339,0,0q�6S   $	��Top=�6f   $��40��6~   $	��104��6�   $
��Bold"�6�   $��16(�6�   6�   �� 5   
   -   5        $��lblNameLogin��5      $��Name: ��6$   $
��Left=�65   $��224,206,0,0q�6P   $	��Top=�6e   $
��Bold"�6}   $��16(�6�   �� 5   
   -   5        $��lblSurnameLogin��5      $��Surname:��6'   $
��Left=�6:   $��224,274,0,0q�6U   $	��Top=�6j   $
��Bold"�6�   $��16(�6�   �� 5   
   -   5        $��txbName��5      $��Center=�6!   $��	0,217,0,0q�6>    �� TextWrapping$
 Wrap=�6Q   $�� ��6e   $	��Top=�6m   $	��120��6�   $
��Bold"�6�   $��16(�6�   �� 5   
   -   5        $��
txbSurname��5      $��Center=�6$   $��	0,278,0,0q�6A   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��120��6�   $
��Bold"�6�   $��16(�6�   �� 5   
   -	   5         ��Name$ lbxChatbotResponses��5      $��162,114,35,100q�6/   $��0q�6H   $
��Bold"�6\   $y�	Collapsed=�6o   �� 5   
   -
   5        $��btnSendQuestion��5      $y�	Collapsed=�6(   $
��Send��6?   $
��Left=�6N   $��161,339,0,0q�6i   $	��Top=�6~   $��66��6�   $��76��6�   $
��Bold"�6�   $��16(�6�   6�   �� 5   
   -   5        $��lblQuestionAsk��5      $y�	Collapsed=�6&   $��Ask me a question:��6=   $��Center=�6Z   $��	0,321,0,0q�6w   $	��Top=�6�   $
��Bold"�6�   $��16(�6�   �� 5   
   -   5        $��txbQuestionReciever��5      $y�	Collapsed=�6-   $
��Left=�6D   $��280,360,0,0q�6_   $
 Wrap=�6t   $��
Enter here��6�   $	��Top=�6�   $	��434��6�   $
��Bold"�6�   $��16(�6�   $��45��6�   ���	#FFC60E0E6�   �� 5   
   -   5        $��lblWelcomeMessage��5      $y�	Collapsed=�6)   $4��.Welcome to the CyberSecurity Awareness Chatbot��6@   $
��Left=�6y   $��187,236,0,0q�6�   $	��Top=�6�   ���	#FFCF0C0C$
��Bold"�6�   $��24(�6�   
�������6�   �� 5   
   -   5        $��btnWelcomeSidebar��5      $��Home Screen��6*   $
��Left=�6@   $��
20,183,0,0q�6[   $	��Top=�6o   $
��Bold"�6�   $��16(�6�   $��39��6�   6�   �� 5   
   -   5        $��btnChatbotSidebar��5      $��Chatbot��6*   $
��Left=�6<   $��
18,252,0,0q�6W   $	��Top=�6k   $
��Bold"�6�   $��16(�6�   $��38��6�   $	��104��6�   6�   �� 5   
   -   5        $!��lblNavigationHeadingSidebar��5      $��Navigation:��63   $
��Left=�6I   $��
23,123,0,0q�6d   $	��Top=�6x   $
��Bold"�6�   $��16(�6�   �� 5    
   -   5         ��Name$ btnQuizNavigation_Copy��5       $�� ��61   $
��Left=�6<   $��
19,304,0,0q�6W   $	��Top=�6k   $	��100��6�   $	��102��6�   ���	#FFB41111��5!      �� 5"      $ 	/test.png��6   5$      �� 5%   
   -   5        $��lblSecretMemory��5%      $y�	Collapsed=�6'   $�� ��6>   $
��Left=�6I   $��644,278,0,0q�6d   $	��Top=�6y   5(      5)      