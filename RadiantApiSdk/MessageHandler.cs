using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.RadiantApiSdk
{
   public class MessageHandler
   {
      private readonly MainWindow m_window;
      public  MessageHandler(MainWindow window)
      {
         m_window = window;
      }
      public void Error(string errorMessage)
      {
         m_window.Title = "!!!ERROR!!!  " + errorMessage;
      }

      public void Info (string message)
      {
         m_window.Title = message;
      }
   }
}
