using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatbotGame
{
    /// <summary>
    /// Interaction logic for ChatbotInterface.xaml
    /// </summary>
    public partial class ChatbotInterface : Window
    {
        
        private string favourite;
        private Responses chatbot;
        private string userName;
        public ChatbotInterface()
        {
            InitializeComponent();
            rctSideBar.Visibility = Visibility.Collapsed;
            lblWelcomeMessage.Visibility = Visibility.Collapsed;
            btnChatbotSidebar.Visibility = Visibility.Collapsed;
            btnWelcomeSidebar.Visibility = Visibility.Collapsed;
            lblNavigationHeadingSidebar.Visibility = Visibility.Collapsed;
            btnQuizNavigation_Copy.Visibility = Visibility.Collapsed;

            
            
        }

        private void btnQuizNavigation_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();         // show main window again
            this.Hide();
        }

        private void mainChatbotFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            
        }

        private void lbxChatbotResponses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEnterLogin_Click(object sender, RoutedEventArgs e)
        {
            userName = txbName.Text;
            chatbot = new Responses(userName);
            //HIDE
            lbxChatbotResponses.Visibility = Visibility.Collapsed;
            lblLoginHeading.Visibility = Visibility.Collapsed;
            lblNameLogin.Visibility = Visibility.Collapsed;
            lblSurnameLogin.Visibility = Visibility.Collapsed;
            btnEnterLogin.Visibility = Visibility.Collapsed;
            txbName.Visibility = Visibility.Collapsed;
            txbSurname.Visibility = Visibility.Collapsed;

            //SHOW
            rctSideBar.Visibility = Visibility.Visible;
            lblWelcomeMessage.Visibility= Visibility.Visible;
            btnChatbotSidebar.Visibility = Visibility.Visible;
            btnWelcomeSidebar.Visibility = Visibility.Visible;
            lblNavigationHeadingSidebar.Visibility = Visibility.Visible;
            btnQuizNavigation_Copy.Visibility = Visibility.Visible;

        }

        private void btnChatbotSidebar_Click(object sender, RoutedEventArgs e)
        {
            //SHOW
            lbxChatbotResponses.Visibility = Visibility.Visible;
            rctSideBar.Visibility = Visibility.Visible;
            lblQuestionAsk.Visibility = Visibility.Visible;
            txbQuestionReciever.Visibility = Visibility.Visible;
            btnSendQuestion.Visibility = Visibility.Visible;
            //HIDE
            lblLoginHeading.Visibility = Visibility.Collapsed;
            lblNameLogin.Visibility = Visibility.Collapsed;
            lblSurnameLogin.Visibility = Visibility.Collapsed;
            btnEnterLogin.Visibility = Visibility.Collapsed;
            txbName.Visibility = Visibility.Collapsed;
            txbSurname.Visibility = Visibility.Collapsed;
            lblLoginHeading.Visibility= Visibility.Collapsed;
            lblWelcomeMessage.Visibility = Visibility.Collapsed;
        }

        private void btnWelcomeSidebar_Click(object sender, RoutedEventArgs e)
        {
            //HIDE
            lbxChatbotResponses.Visibility = Visibility.Collapsed;
            rctSideBar.Visibility = Visibility.Visible;
            lblQuestionAsk.Visibility = Visibility.Collapsed;
            txbQuestionReciever.Visibility = Visibility.Collapsed;
            btnSendQuestion.Visibility = Visibility.Collapsed;
            
            lblLoginHeading.Visibility = Visibility.Collapsed;
            lblNameLogin.Visibility = Visibility.Collapsed;
            lblSurnameLogin.Visibility = Visibility.Collapsed;
            btnEnterLogin.Visibility = Visibility.Collapsed;
            txbName.Visibility = Visibility.Collapsed;
            txbSurname.Visibility = Visibility.Collapsed;
            //SHOW
            lblWelcomeMessage.Visibility = Visibility.Visible;
        }

        private void btnSendQuestion_Click(object sender, RoutedEventArgs e)
        {
            //User enters question in text box and clicks button to recieve response
            string userInput;
            
            userInput = txbQuestionReciever.Text;
            
            lbxChatbotResponses.Items.Add(userName + ": "+userInput);

            if (!userInput.ToLower().Contains("bye") )
            {
                
                lbxChatbotResponses.Items.Add("_____________________________________________________________________________________---" );
                lbxChatbotResponses.Items.Add("Chatbot: "+chatbot.Response(userInput));
                lbxChatbotResponses.Items.Add("---------------------------------------------------------------------------------------- ");

            }
            else
            {
                lbxChatbotResponses.Items.Add("---------------------------------------------------------------------------------------- ");
                lbxChatbotResponses.Items.Add("Goodbye " + userName);
                lbxChatbotResponses.Items.Add("---------------------------------------------------------------------------------------- ");
            }



        }
    }
}
