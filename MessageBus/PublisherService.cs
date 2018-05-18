using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageBus.Interfaces;
using Common.Model;
using System.ServiceModel;
using Common;

namespace MessageBus
{
    public class PublisherService : IPublisherService
    {
        public void Publish(Message pMessage)
        {
            Console.WriteLine("Publish queue-------- Topic: " + pMessage.Topic);
            String topic = pMessage.Topic;
            String forwardAddress = "";
            if(topic == "bank")
            {
                forwardAddress = "bank";
            }
            if(topic == "transfer")
            {
                TransferMessage transferMessage = pMessage as TransferMessage;
                bool bTransferResult = transferMessage.BTransfer;
                if (bTransferResult)
                {
                    forwardAddress = "delivery";

                }else
                {
                    forwardAddress = "email";
                }
                
            }
            if(topic == "delivery")
            {
                forwardAddress = "email";
            }
            if(topic == "videostore")
            {

            }

            foreach (String lHandlerAddress in SubscriptionRegistry.Instance.GetTopicSubscribers(forwardAddress))
            {
                ISubscriberService lSubServ = ServiceFactory.GetService<ISubscriberService>(lHandlerAddress);
                Console.WriteLine("Handler Address:" + lHandlerAddress);
                lSubServ.PublishToSubscriber(pMessage);
            }
        }

    }
}
