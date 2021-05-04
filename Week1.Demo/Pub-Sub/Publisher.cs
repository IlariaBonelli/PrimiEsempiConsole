using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Demo.Pub_Sub
{
    public class Publisher
    {
        //campi
        public string PublisherName { get; set; }

        //costruttore

        public Publisher(string publisherName)
        {
            PublisherName = publisherName;
        }

        //delegate
        public delegate void Notify(Publisher p, Notification n);

        //evento
        public event Notify OnPublish;

        //metodo che pubblica l'evento
        public void Publish()
        {
            if(OnPublish != null)
            {
                Notification notification = new Notification("New notification from " + PublisherName, DateTime.Now);
                OnPublish(this, notification);
            }
        }

    }
}
