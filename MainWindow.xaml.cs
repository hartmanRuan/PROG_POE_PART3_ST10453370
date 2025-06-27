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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[,] quizQuestions = {{ "Safe passwords should contain letters and numbers and nothing more", "True or False:"},
                                            { "What do we call it when a person ask for a payment in advance without getting the product?","Answer the question:" },
                                            { "Which of the following options is the best option for having the safest password?" ,"Multiple Choice:"},
                                            {"Its safe to enter your personal data on random websites","True or False:" },
                                            {"What do we call a person trying to malicious harm to an online platform?","Answer the question:" },
                                            {"What the best way to prevent online threats:","Multiple Choice:" },
                                            {"There arent many online threats in the world, some people just have bad luck","True or False:" },
                                            {"What is the best question to ask yourself if you think you are being scammed?","Answer the question:" },
                                            {"What is the reason for cyber-attacks?","Multiple Choice:" },
                                            {"Just because a website has a logo of a company, doesnt mean that they are legit","True or False:"} };

        
        int count = 0;
        int marks = 0;
        string answer;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void scrChangeQuestion_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Hide
            lblResults.Visibility = Visibility.Collapsed;
            lblMark.Visibility = Visibility.Collapsed;
            //SHOW
            btnSubmit.Visibility = Visibility.Visible;
            lblquestionHeading.Visibility = Visibility.Visible;
            questionTypelbl.Visibility = Visibility.Visible;
            lblQuestionNo.Content = (scrChangeQuestion.Value).ToString();
            pgbProgress.Value = scrChangeQuestion.Value;
            count = (int)scrChangeQuestion.Value;
            bool endLoopResults = false;

            for (int i = 0; i<= 10; i++)
            {
                if (i == scrChangeQuestion.Value)
                {
                    questionTypelbl.Content= quizQuestions[i-1,1];
                    if (quizQuestions[i - 1, 1].Equals("True or False:"))
                    {
                        
                        //Show
                        btnFalse.Visibility = Visibility.Visible;
                        btnTrue.Visibility = Visibility.Visible;
                        lblToFAnswer.Content = "Your Answer: ";
                        lblToFAnswer.Visibility = Visibility.Visible;
                        //Hide
                        cbx1.Visibility = Visibility.Collapsed;
                        cbx2.Visibility = Visibility.Collapsed;
                        cbx3.Visibility = Visibility.Collapsed;
                        cbx4.Visibility = Visibility.Collapsed;
                        cbx5.Visibility = Visibility.Collapsed;

                        txbAnswer.Visibility = Visibility.Collapsed;
                        
                    }
                    else if (quizQuestions[i - 1,1].Equals("Answer the question:"))
                    {

                        //Show
                        txbAnswer.Text = "";
                        txbAnswer.Visibility= Visibility.Visible;
                        //Hide
                        cbx1.Visibility = Visibility.Collapsed;
                        cbx2.Visibility = Visibility.Collapsed;
                        cbx3.Visibility = Visibility.Collapsed;
                        cbx4.Visibility = Visibility.Collapsed;
                        cbx5.Visibility = Visibility.Collapsed;

                        btnTrue.Visibility= Visibility.Collapsed;
                        btnFalse.Visibility= Visibility.Collapsed;
                        lblToFAnswer.Visibility= Visibility.Collapsed;
                    }
                    else if (quizQuestions[i - 1, 1].Equals("Multiple Choice:"))
                    {
                        //Question3
                        if (count == 3)
                        {
                            cbx1.Content = "Numbers";
                            cbx2.Content = "Letters";
                            cbx4.Content = "Numbers, and Letters";
                            cbx3.Content = "Numbers, Letters, and Symbols";
                            cbx5.Content = "None of the above";
                        }

                        if (count == 6)
                        {
                            cbx1.Content = "Stay away from going online";
                            cbx2.Content = "Educate yourself of potential threats and how to deal with them";
                            cbx4.Content = "Just set stronger passwords";
                            cbx3.Content = "Buy the most expensive security package";
                            cbx5.Content = "None of the above";
                        }

                        if (count == 9)
                        {
                            cbx1.Content = "Capital Gain";
                            cbx2.Content = "Cause Reputational Harm";
                            cbx4.Content = "Protest";
                            cbx3.Content = "For Fun";
                            cbx5.Content = "All of the above";
                        }

                        

                        //Show
                        cbx1.IsChecked = false;
                        cbx2.IsChecked = false;
                        cbx3.IsChecked = false;
                        cbx4.IsChecked = false;
                        cbx5.IsChecked = false;

                        cbx1.Visibility = Visibility.Visible;
                        cbx2.Visibility = Visibility.Visible;
                        cbx3.Visibility = Visibility.Visible;
                        cbx4.Visibility = Visibility.Visible;
                        cbx5.Visibility = Visibility.Visible;
                        //Hide
                        btnTrue.Visibility = Visibility.Collapsed;
                        btnFalse.Visibility = Visibility.Collapsed;
                        lblToFAnswer.Visibility = Visibility.Collapsed;

                        txbAnswer.Visibility = Visibility.Collapsed;
                    }
                    

                    lblquestionHeading.Content = quizQuestions[i - 1, 0];
                    //Find the end of the quiz
                    
                }
                
            }
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Hide
            btnSubmit.Visibility = Visibility.Collapsed;
            btnTrue.Visibility = Visibility.Collapsed;
            btnFalse.Visibility = Visibility.Collapsed;
            lblToFAnswer.Visibility = Visibility.Collapsed;
            txbAnswer.Visibility = Visibility.Collapsed;
            cbx1.Visibility = Visibility.Collapsed;
            cbx2.Visibility = Visibility.Collapsed;
            cbx3.Visibility = Visibility.Collapsed;
            cbx4.Visibility = Visibility.Collapsed;
            cbx5.Visibility = Visibility.Collapsed;
            //Show
            lblMark.Visibility = Visibility.Visible;
            switch (count)
            {
                case 1:
                    if (lblToFAnswer.Content.Equals("Your Answer: False"))
                    {
                        lblMark.Content = "Your Answer was correct!";
                        
                        marks++;
                    }
                    else { lblMark.Content = "INCORRECT. MAYBE NEXT TIME"; }

                        break;
                case 2:
                    if (txbAnswer.Text.Equals("Scam"))
                    {
                        lblMark.Content = "Your Answer was correct!";
                        
                        marks++;
                    }
                    else { lblMark.Content = "INCORRECT. MAYBE NEXT TIME"; }
                    break;
                case 3:
                    if (cbx3.IsChecked == true)
                    {
                        lblMark.Content = "Your Answer was correct!";
                        
                        marks++;
                    }
                    else { lblMark.Content = "INCORRECT. MAYBE NEXT TIME"; }
                    break;
                case 4:
                    if (lblToFAnswer.Content.Equals("Your Answer: False"))
                    {
                        lblMark.Content = "Your Answer was correct!";

                        marks++;
                    }
                    else { lblMark.Content = "INCORRECT. MAYBE NEXT TIME"; }
                    break;
                case 5:
                    if (txbAnswer.Text.Equals("Hacker"))
                    {
                        lblMark.Content = "Your Answer was correct!";

                        marks++;
                    }
                    else { lblMark.Content = "INCORRECT. MAYBE NEXT TIME"; }
                    break;
                case 6:
                    if (cbx2.IsChecked == true)
                    {
                        lblMark.Content = "Your Answer was correct!";

                        marks++;
                    }
                    else { lblMark.Content = "INCORRECT. MAYBE NEXT TIME"; }
                    break;
                case 7:
                    if (lblToFAnswer.Content.Equals("Your Answer: False"))
                    {
                        lblMark.Content = "Your Answer was correct!";

                        marks++;
                    }
                    else { lblMark.Content = "INCORRECT. MAYBE NEXT TIME"; }
                    break;
                case 8:
                    if (txbAnswer.Text.Equals("Is it too good to be true?"))
                    {
                        lblMark.Content = "Your Answer was correct!";

                        marks++;
                    }
                    else { lblMark.Content = "INCORRECT. MAYBE NEXT TIME"; }
                    break;
                case 9:
                    if (cbx5.IsChecked == true)
                    {
                        lblMark.Content = "Your Answer was correct!";

                        marks++;
                    }
                    else { lblMark.Content = "INCORRECT. MAYBE NEXT TIME"; }
                    break;
                case 10:
                    if (lblToFAnswer.Content.Equals("Your Answer: True"))
                    {
                        lblMark.Content = "Your Answer was correct!";
                        marks++;

                        //Show Results
                        //HIDE
                        cbx1.Visibility = Visibility.Collapsed;
                        cbx2.Visibility = Visibility.Collapsed;
                        cbx3.Visibility = Visibility.Collapsed;
                        cbx4.Visibility = Visibility.Collapsed;
                        cbx5.Visibility = Visibility.Collapsed;

                        btnTrue.Visibility = Visibility.Collapsed;
                        btnFalse.Visibility = Visibility.Collapsed;
                        lblToFAnswer.Visibility = Visibility.Collapsed;

                        txbAnswer.Visibility = Visibility.Collapsed;
                        lblquestionHeading.Visibility = Visibility.Collapsed;
                        questionTypelbl.Visibility = Visibility.Collapsed;

                        btnSubmit.Visibility = Visibility.Collapsed;
                        scrChangeQuestion.Visibility = Visibility.Collapsed;
                        lblMark.Visibility = Visibility.Collapsed;

                        //SHOW

                        if (marks < 5)
                        {
                            lblResults.Content = "You got " + marks + "/10. You failed! Better luck next time.";
                        }
                        else if (marks >= 5 && marks <= 7)
                        {
                            lblResults.Content = "You got " + marks + "/10. You passed! Lets see if you can improve.";
                        }
                        else if (marks > 7)
                        {
                            lblResults.Content = "You got " + marks + "/10. You passed with distinction! Keep up the good work";
                        }

                        lblResults.Visibility = Visibility.Visible;
                        scrChangeQuestion.Visibility=Visibility.Collapsed;
                    }
                    else 
                    {
                        lblMark.Content = "INCORRECT. MAYBE NEXT TIME";
                        //HIDE
                        cbx1.Visibility = Visibility.Collapsed;
                        cbx2.Visibility = Visibility.Collapsed;
                        cbx3.Visibility = Visibility.Collapsed;
                        cbx4.Visibility = Visibility.Collapsed;
                        cbx5.Visibility = Visibility.Collapsed;

                        btnTrue.Visibility = Visibility.Collapsed;
                        btnFalse.Visibility = Visibility.Collapsed;
                        lblToFAnswer.Visibility = Visibility.Collapsed;

                        txbAnswer.Visibility = Visibility.Collapsed;
                        lblquestionHeading.Visibility = Visibility.Collapsed;
                        questionTypelbl.Visibility = Visibility.Collapsed;

                        btnSubmit.Visibility = Visibility.Collapsed;
                        scrChangeQuestion.Visibility = Visibility.Collapsed;
                        lblMark.Visibility = Visibility.Collapsed;

                        //SHOW

                        if (marks < 5)
                        {
                            lblResults.Content = "You got " + marks + "/10. You failed! Better luck next time.";
                        }
                        else if (marks >= 5 && marks <= 7)
                        {
                            lblResults.Content = "You got " + marks + "/10. You passed! Lets see if you can improve and get a distinction.";
                        }
                        else if (marks > 7)
                        {
                            lblResults.Content = "You got " + marks + "/10. You passed with distinction! Keep up the good work";
                        }

                        lblResults.Visibility = Visibility.Visible;
                        scrChangeQuestion.Visibility = Visibility.Collapsed;
                    }
                    break;
                
            }


                scrChangeQuestion.Visibility = Visibility.Visible;
        }

        private void btnTrue_Click(object sender, RoutedEventArgs e)
        {
            lblToFAnswer.Content = "Your Answer: True";
        }

        private void btnFalse_Click(object sender, RoutedEventArgs e)
        {
            lblToFAnswer.Content = "Your Answer: False";
        }

        private void mainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ChatbotInterface chatbotWindow = new ChatbotInterface();
            chatbotWindow.Show();  
            this.Hide();
        }
    }
}
