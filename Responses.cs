using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ChatbotGame
{
    internal class Responses : ChatbotResponse
    {
        //Array for all the questions
        private string[] questionInput =  { "How are you",
                                                    "What is your purpose",
                                                    "What can i ask you about",
                                                    "Who created you",
                                                    "Emergency",
                                                    "Password",
                                                    "Phishing",
                                                    "Browsing",
                                                    "Downloads",
                                                    "Scam",
                                                    "Privacy",
                                                    "Thank you",
                                                    "Bye",
                                                    "Confused",
                                                    "Tell me more",
                                                    "Detail",
                                                    "Explain",
                                                    "Im interested in"

                                                    };

        //Array for all the responses
        private string[,] responseOutput1 =  { {"I am always well as i am robotic. I was hardcoded by my creator to always be well and positive", "I am doing good, thanks for asking. ", "A Chatbot like me... IM ALWAYS doing good. Thank you for asking" },
                                                    { "I am a Cybersecurity awareness bot that was built with the purpose of enlighting my users of the dangers around cybersecurity. I dont want my users to fall in the traps of threats!", "My purpose is to enlighten my users of the dangers and threats of the Cybersecurity world that are out there!", "My developers made me to try and raise awareness of cybersecurity by spreading facts about it." },
                                                    { "Ask me about anything cybersecurity related and i will do my best to answer your questions.", "I specialize in everything Cybersecurity related. Ask away!", "I was made to answer Cybersecurity related questions" },
                                                    { "I was created by a programmer, Ruan Hartman on 17 April 2025.", "Ruan Hartman created me as a solution for a task in 2025","I was made by a Computer and Information Science Student by the name of Ruan Hartman" },
                                                    { "Contact the following number for immediate support from a cybersecurity hotline: 011-202-3500", "Call our Hotline NOW: 011-241-3500", "Dont waste time! Call -> 011-410-3006" },
                                                    { "To ensure your password is up to standard, see that it complies with the following: \n\t\t -Minimum of 8 characters\n\t\t -Make use of both numbers and symbols\n\t\t -Use capital and lowercase letters\n\t\t -Make your password unrelated to you\nThe above criterea will give you a strong password.", "Your password should contain the following for it to be robust: \n\t-Numbers \n\t-Characters \n\t-Be longer than 8 spaces \n\t-Have no alignment with you as a person", "Your password should follow simple rules like having numbers, letter and symbols, it must also contain upper and lowercase letters."},
                                                    { "Phishing consits of you being under attack through emails or messages that pretend to be from big, legit companies...THEY ARE NOT! They use this to retrieve your personal data like passwords or credit card info. Do not fall for a trap like this. A reputable company will never ask for your password or banking info.", "Phishing is when a user is attacked with emails, that pretend to be big companies. They make users think they are from that company and use that to leverage their way with a user.", "Phishing summed up is a long stream of messages of people pretending to be a reputable source, trying to reach your sensitive data by you having to trust this 'BIG' company with your data" },
                                                    { "These are practices that protect you,as a user, from online threats. This can be anything from malware, to phishing. Safe browsing can be achieved by securing your browser, being educated of risks and using other security measures.", "When browsing, to remain safe, only download files from trusted sources, dont go on random websites. They can do you harm.", "Be careful of clicking on random websites and entering info into them."},
                                                    { "DO NOT DOWNLOAD FILES FROM RANDOM SITES!!! This is a way which malware can make it on your computer. Websites can disguise these files and when you download them, the malware gets on your computer without you noticing.", "Always be careful when downloading files. It is the easiest way your computer can become infected. Make sure you are downloading from trusted sources.", "Try to avoid opening and downloading of files from untrusted sources. They can do you and your computer harm"},
                                                    { "Always be aware of scammers. The best way of identifying one is to ask yourself if the offer they try and give you seems to good to be true. If it seems to good to be true, it likely is too good to be true.", "Scammers try to take advantage of a person by asking money for a product or service that doesnt exist. If they receive the payment, they dissappear with your money." , "A Scam is a person trying to get you to pay them for their services or products, but they never intend on actually giving you the service or product."},
                                                    { "Be aware of what data you enter and what you post and publish on certain social media apps, websites and register pages. Some companies use your data by selling it to other merketing companies.", "Try to not enter data on random websites. When they are asking for sensitive data, make sure that the website is secured and consider trying another way.", "Keep away from untrusted sites and be careful where you post, publish or enter your data on the internet. All that information can be used to do you harm"},
                                                    { "Not a problem. Feel free to ask me more questions", "Cool, im always here to answer more questions.", "Right-on! Keep the questions rolling if you have more."},
                                                    { "Goodbye", "Bye-Bye", "See you later"},
                                                    { "Invalid question detected. Please ask another question", "Invalid question detected. Please ask another question" ,"Damn, i could not understand your question... Please try again"} };

        int previousQuestion = 0;
        private string topic = " ";
        public string favourite;
        private bool fav = false;
        private List<Task> taskList = new List<Task>();
        private Task pendingReminderTask = null;
        private Task pendingDescriptionTask = null;
        private List<string> activityLog = new List<string>();


        public Responses(string userName) : base(userName)
        {

        }

        public override string Response(string questionRecieved)
        {
            //MessageBox.Show(favourite);
            //Get random number for random response
            Random rnd = new Random();
            int random = 0;
            for (int j = 0; j < 4; j++)
            {
                random = (rnd.Next(0, 3));
            }

            int count = 0;

            //Start loop
            for (count = 0; count < 17;)
            {
                questionRecieved = questionRecieved.ToLower();
                //TASK MANAGER
                if (questionRecieved.Contains("show activity log") || questionRecieved.Contains("what have you done for me"))
                {
                    if (activityLog.Count == 0)
                        return " No activities has been recorded recorded .";

                    return "Activity Log (most recent 5 activities):\n" + string.Join("\n", activityLog);
                }

                if (pendingReminderTask != null && questionRecieved.Contains("remind"))
                {
                    DateTime reminderTime;
                    if (TryParseRelativeReminder(questionRecieved, out reminderTime))
                    {
                        pendingReminderTask.Reminder = reminderTime;
                        var title = pendingReminderTask.Title;
                        pendingReminderTask = null;
                        LogAction($"Set reminder for task: {title} at {reminderTime:g}");

                        return $" Reminder was set for '{title}' on {reminderTime:g}.";
                    }
                    else
                    {
                        return " I couldn't understand the reminder you want to set. Try something like 'Remind me on 25 June at 5pm'";
                    }
                }
                if (pendingDescriptionTask != null && !questionRecieved.StartsWith("remind"))
                {
                    pendingDescriptionTask.Description = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(questionRecieved.Trim());
                    var title = pendingDescriptionTask.Title;
                    pendingDescriptionTask = null;
                    LogAction($"Added description to task: {title}");


                    return $" Description added for '{title}'.\nWould you want to set a reminder for it?";
                }

                if (questionRecieved.StartsWith("set up") || questionRecieved.StartsWith("add task") )
                    return HandleTaskCreation(questionRecieved);

                if (questionRecieved.Contains("show tasks") || questionRecieved.Contains("my tasks"))
                    return HandleTaskListing();

                if (questionRecieved.StartsWith("delete task"))
                    return HandleTaskDeletion(questionRecieved);

                if (questionRecieved.Equals(" "))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    return ("I didnt understand. Please try again " + userName);
                }
                else
                {
                    if (questionRecieved.ToLower().Contains(questionInput[count].ToLower()))
                    {
                        
                        

                        if (questionRecieved.ToLower().Contains("explain") || questionRecieved.ToLower().Contains("tell me more") || questionRecieved.ToLower().Contains("confused") || questionRecieved.ToLower().Contains("detail"))
                        {

                            return Confusion(random, previousQuestion);
                        }
                        if (questionRecieved.ToLower().Contains("im interested in"))
                        {
                            fav = true;
                            favourite = questionRecieved.Remove(0, 17);
                            //MessageBox.Show(favourite);
                           
                            return Memory(questionRecieved, favourite);
                        }

                        else
                        {
                            topic = questionInput[count ];
                            previousQuestion = count;
                            if (fav == true)
                            {
                                if (questionRecieved.ToLower().Contains(favourite))
                                {

                                    return "As you are interested in " + favourite + " ." + responseOutput1[count , random];
                                }
                                else
                                {
                                    if (questionRecieved.ToLower().Contains("worried") || questionRecieved.ToLower().Contains("scared") || questionRecieved.ToLower().Contains("concerned"))
                                    {

                                        return Sentiment(questionRecieved, topic) + userName + ", " + responseOutput1[count , random];
                                    }
                                    else
                            if (questionInput[count].ToLower().Contains("curious") || questionRecieved.ToLower().Contains("wonder") || questionRecieved.ToLower().Contains("interested"))
                                    {

                                        return Sentiment(questionRecieved, topic) + userName + ", " + responseOutput1[count , random];
                                    }
                                    else
                            if (questionRecieved.ToLower().Contains("frustrated") || questionRecieved.ToLower().Contains("angry") || questionRecieved.ToLower().Contains("upset"))
                                    {

                                        return Sentiment(questionRecieved, topic) + userName + ", " + responseOutput1[count , random];
                                    }
                                    else
                                    {
                                        return userName + ",that is a great question, " + responseOutput1[count , random];
                                    }
                                }
                            }
                            else
                            if (questionRecieved.ToLower().Contains("worried") || questionRecieved.ToLower().Contains("scared") || questionRecieved.ToLower().Contains("concerned"))
                            {

                                return Sentiment(questionRecieved, topic) + userName + ", " + responseOutput1[count, random];
                            }
                            else
                            if (questionInput[count].ToLower().Contains("curious") || questionRecieved.ToLower().Contains("wonder") || questionRecieved.ToLower().Contains("interested"))
                            {

                                return Sentiment(questionRecieved, topic) + userName + ", " + responseOutput1[count , random];
                            }
                            else
                            if (questionRecieved.ToLower().Contains("frustrated") || questionRecieved.ToLower().Contains("angry") || questionRecieved.ToLower().Contains("upset"))
                            {

                                return Sentiment(questionRecieved, topic) + userName + ", " + responseOutput1[count , random];
                            }
                            else
                            {
                                return userName + ",that is a great question, " + responseOutput1[count , random];
                            }

                        }
                    }
                    else
                    {
                        
                        count++;

                    }
                }
            }

            return "Sorry " + userName + " " + responseOutput1[14, random];

        }

        public string Confusion(int randomm, int prevCountt)
        {
            if (randomm == 0)
            {
                
                return "Sorry " + userName + " . Let me clarify for you: \n " + responseOutput1[prevCountt , randomm ];
            }
            else
            if (randomm == 1)
            {
                
                return "Sorry " + userName + " . Let me explain more: \n " + responseOutput1[prevCountt , randomm ];
            }
            else
            if (randomm == 2)                       
            {
                
                return "Sorry " + userName + " . Let me adjust my answer: \n " + responseOutput1[prevCountt , randomm ];
            }
            else
            {
                return "I could not understand please try again.";
            }



        }

        public string Memory(string qReceived, string favour)
        {
            int count = 0;
            fav = true;


            while (count < questionInput.Length)
            {
                if (questionInput[count].ToLower().Contains(favour))
                {
                    return "Good to know " + userName + " . Ill keep the topic of " + favour + " in mind for our future conversations.";
                }
                count++;
            }

            return "Good to know " + userName + " . Ill keep the topic of " + favour + " in mind for future conversations.";
        }

        public string Sentiment(string QReceived, string topic)
        {
            int count = 0;
            

            //Loop through question Input array
            while (count < questionInput.Length)
            {
                if (QReceived.ToLower().Contains("worried") || QReceived.ToLower().Contains("scared") || QReceived.ToLower().Contains("concerned"))
                {
                    return "No need to worry about " + topic + "... It can be intimidating but here is more info regarding it: ";
                }
                if (QReceived.ToLower().Contains("curious") || QReceived.ToLower().Contains("wonder") || QReceived.ToLower().Contains("interested"))
                {
                    return "I love the curiosity, here more information about " + topic + " : ";
                }
                if (QReceived.ToLower().Contains("frustrated") || QReceived.ToLower().Contains("angry") || QReceived.ToLower().Contains("upset"))
                {
                    return topic + " can be very frustrating. It important to be informed about " + topic + " so that you dont end up as a victim. Here is more info: ";
                }
                else
                {
                    count++;

                }

            }
            return "Not found";


        }
        

        private string HandleTaskCreation(string input) //USE TO CREATE A NEW TASK
        {
            var task = new Task
            {
                Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.Trim()),
                Description = "", 
                Reminder = null
            };

            taskList.Add(task);
            pendingDescriptionTask = task;
            pendingReminderTask = task;
            LogAction($"Added task: {task.Title}");
            return $" Task added: {task.Title}\nWould you want to create a description for this task?";
        }

        private string HandleTaskListing() //USE TO WORK WITH A TASK
        {
            if (taskList.Count == 0)
                return " You do not have any tasks.";
            return string.Join("\n\n", taskList.Select(t => t.ToString()));
        }

        private string HandleTaskDeletion(string input) //USE THIS WHEN TRYING TO DELETE A TASK
        {
            var title = input.Replace("delete task", "").Trim();
            var taskToRemove = taskList.FirstOrDefault(t => t.Title.ToLower().Contains(title));
            if (taskToRemove != null)
            {
                taskList.Remove(taskToRemove);
                return $"Delete Task '{taskToRemove.Title}' deleted.";
            }
            return $" Couldn't find a task with title containing '{title}'.";
        }

        private bool TryParseRelativeReminder(string input, out DateTime reminder) //USE THIS TO CONVERT FROM A USERS WORDS INTO A TIMEFRAME
        {
            reminder = DateTime.MinValue;

            var match = Regex.Match(input, @"in (\d+) (day|days|hour|hours|minute|minutes)");
            if (match.Success)
            {
                int value = int.Parse(match.Groups[1].Value);
                string unit = match.Groups[2].Value;

                switch (unit)
                {
                    case "day": //if day then ...
                    case "days":
                        reminder = DateTime.Now.AddDays(value);
                        break;
                    case "hour":
                    case "hours":
                        reminder = DateTime.Now.AddHours(value);
                        break;
                    case "minute":
                    case "minutes":
                        reminder = DateTime.Now.AddMinutes(value);
                        break;
                    default:
                        return false;
                }

                return true;
            }

            return false;
        }

        private void LogAction(string action)// Detecxt an action and add to the list of actions
        {
            activityLog.Add($"[{DateTime.Now:t}] {action}");

            // only last 5 entries
            if (activityLog.Count > 5)
            {
                activityLog = activityLog.Skip(activityLog.Count - 5).ToList();
            }
        }

        //GeeksForGeeks.2025. C# Program to display date in string, 27 December 2021. [Online]. Available at:
        //https://www.geeksforgeeks.org/c-sharp/c-sharp-program-to-display-date-in-string/
        //[Accessed 26/06/2025]



    }
}
