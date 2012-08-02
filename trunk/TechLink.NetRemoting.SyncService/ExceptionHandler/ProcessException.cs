using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
namespace ExceptionHandler
{
    public class ProcessException
    {


        public static IErrorNotify ErrorNotify = new ErrorNotify();

        public static void Handle(string str, Exception e) { }

        public static void Handle(string str){}

        public static void Handle(System.Exception exception)
        {
            WriteErrorToLog(exception.Message);

#if DEBUG && !SERVER
            System.Windows.Forms.MessageBox.Show(exception.Message + "\r\n" + exception.StackTrace, "PIS Exception Notifier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (exception.InnerException!=null)
            {
                System.Windows.Forms.MessageBox.Show(exception.Message + "\r\n" + exception.InnerException.ToString(), "PIS Exception Notifier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
#endif
          //logManager.Error(exception);
        }

        public static void Handle(System.Exception exception, string function)
        {
            function = "\r\n" + function;
            //logManager.Error(function, exception);
#if DEBUG && !SERVER
            MessageBox.Show(exception.Message + "\r\n" + exception.StackTrace, function, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
        }

        public static void Handle(System.Exception exception, string function, string note)
        {
#if DEBUG && !SERVER
            System.Windows.Forms.MessageBox.Show(exception.Message + "\r\n" + exception.StackTrace, function, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
          function = "\r\n" + function + "\r\n----> NOTE:\r\n" + note + "\r\n";
            //logManager.Error(function, exception);
        }

        public static void HandleThroughOutMail(System.Exception exception)
        {
            SendEmailUtil.Send("viajesvietluz@gmail.com", "Exception Error from PIS Server", "<b>" + exception.Message + "</b><br><hr>" + exception.StackTrace);
            throw exception;
        }

        public static void HandleThroughOutMail(System.Exception exception, string descriptionFunction)
        {
            SendEmailUtil.Send("viajesvietluz@gmail.com", "From PIS Server - " + descriptionFunction, "<b>" + exception.Message + "</b><br><hr>" + exception.StackTrace);

            System.Exception ex = new System.Exception(descriptionFunction + "\r\n" + exception.Message, exception);
            throw ex;
        }

        public static void Notify(string message)
        {
            System.Windows.Forms.MessageBox.Show(message, "PIS Exception Notifier");
        }

        public static void WriteErrorLog(string message, string fromFunction)
        {
            fromFunction = "\r\n" + fromFunction;
            //logManager.Error(fromFunction + "\r\n" + message);
        }

        public static void WriteInfoLog(string message, string fromFunction)
        {
            fromFunction = "\r\n" + fromFunction;
            //logManager.Info(fromFunction + "\r\n" + message);
        }

        private static void WriteErrorToLog(string error)
        {
            string appName = "TechLinkServiceLog";

            try
            {
                //MessageBox.Show(message, "Error - TechLink Sync", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                EventLog objEventLog = new EventLog();
                try
                {
                    if (!(EventLog.SourceExists(appName)))
                    {
                        EventLog.CreateEventSource(appName, "Error");
                    }
                    objEventLog.Source = appName;
                    objEventLog.WriteEntry("ErrorLog", EventLogEntryType.Error);
                }
                catch (Exception Ex)
                {
                }
            }
            catch
            {
            }

        }
    }

 

    public class SendEmailUtil
    {
        public static void Send(String[] to, String subject, String content, String[] attachFiles)
        {
            try
            {
                var message = new MailMessage();

                message.From = new MailAddress("viajesvietluz@gmail.com");
                foreach (var s in to)
                {
                    message.To.Add(new MailAddress(s));
                }

                message.Subject = subject;
                message.Body = content;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                if (attachFiles != null)
                    foreach (var s in attachFiles)
                    {
                        message.Attachments.Add(new Attachment(s));
                    }


                var sender = new SmtpClient("smtp.gmail.com", 587);
                sender.EnableSsl = true;
                sender.UseDefaultCredentials = false;
                sender.Credentials = new NetworkCredential("viajesvietluz@gmail.com", "addcmyk2010");

                sender.Send(message);
            }
            catch (Exception)
            {
            }

        }

        public static void Send(String[] to, String subject, String content)
        {
            Send(to, subject, content, null);
        }

        public static void Send(String to, String subject, String content)
        {
            String[] sep = { ";", ",", " " };
            String[] tos = to.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            Send(tos, subject, content, null);
        }

    }
}
