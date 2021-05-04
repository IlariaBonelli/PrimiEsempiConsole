using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Demo.Pub_Sub
{
    public class Subscriber
    {
        public string SubscriberName { get; set; }

        public Subscriber(string subscriberName)
        {
            SubscriberName = subscriberName;
        }

        //Metodi subscribe/unsubscribe

        public void Subscribe(Publisher p)
        {
            //mi registro alla notifica dell'evento
            p.OnPublish += OnNotificationReceived; 
        }

        public void Unsubscribe(Publisher p)
        {
            p.OnPublish -= OnNotificationReceived;
        }

        public void OnNotificationReceived(Publisher p, Notification n)
        {
            Console.WriteLine("Ciao, " + SubscriberName + " notifica ricevuta da "
                + p.PublisherName + " il giorno " + n.NotificationDate + " : " + n.NotificationMessage);
        }
    }
}
