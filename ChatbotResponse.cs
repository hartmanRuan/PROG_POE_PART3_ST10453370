using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotGame
{
    internal abstract class ChatbotResponse
    {
        protected string userName;

        //CONSTRUCTOR
        public ChatbotResponse()
        {
            userName = "";
        }

        public ChatbotResponse(string user)
        {
            this.userName = user;
        }

        public abstract string Response(string question);
    }
}
