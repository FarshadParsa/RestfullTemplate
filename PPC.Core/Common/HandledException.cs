using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Exception
{
    public class HandledException:System.Exception   
    {
        private string _message;

        public new  string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private int code;

        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        
        private string messageTitle;

        public string MessageTitle
        {
            get { return messageTitle; }
            set { messageTitle = value; }
        }

        private string messageDetail;

        public string MessageDetail
        {
            get { return messageDetail; }
            set { messageDetail = value; }
        }

        public HandledException()
        {
            this.Message = "";
            this.MessageTitle = "";
            this.MessageDetail = "";
        }
        public HandledException(string Message)
        {
            this.Message = Message;
            this.MessageTitle = "";
            this.MessageDetail = "";
        }
        public HandledException(int Code)
        {
            this.code = code;
        }
        public HandledException(string Message, string MessageTitle)
        {
            this.Message = Message;
            this.MessageTitle = MessageTitle;
            //this.MessageDetail = "";
        }
        public HandledException(string Message, string MessageTitle, string MessageDetail)
        {
            this.Message = Message;
            this.MessageTitle = MessageTitle;
            this.MessageDetail = MessageDetail;
        }
	    
    }
}
