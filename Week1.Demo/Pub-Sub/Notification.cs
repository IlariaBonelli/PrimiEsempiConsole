using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Demo.Pub_Sub
{
    public class Notification
    {
        public string NotificationMessage { get; set; }
        public DateTime NotificationDate { get; set; }

        //Costruttore
        public Notification( string message, DateTime dateNotification)
        {
            NotificationMessage = message;
            NotificationDate = dateNotification;
        }




    }
}
