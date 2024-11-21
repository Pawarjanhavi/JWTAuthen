using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate void NotificationDelegate(string message);
    public class NotificationSystem
    {
        static void SendEmailNotification(string message)
        {
            Console.WriteLine($"Email Notification : {message}");
        }

        static void SendSMSNotification(string message)
        {
            Console.WriteLine($"SMS Notification : {message}");

        }

        static void SendPushNotification(string message)
        {
            Console.WriteLine($"Push Notification : {message}");
        }

        static void Main(string[] args)
        {
            NotificationDelegate notifyuser = SendEmailNotification;
            notifyuser += SendSMSNotification;
            notifyuser += SendPushNotification;


            string newMessage = "You have a new message!";
            //Console.WriteLine("New Message Received! Notifying users through all channels...");
            notifyuser(newMessage);

        }
    }
}
