using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBryce
{
    public class MessagesLogic : BaseLogic
    {
        public ContactUsMessageModel AddMessage(ContactUsMessageModel messageModel)
        {
            messageModel.dateAdded = DateTime.Now;

            ContactUsMessage contactUsMessage = new ContactUsMessage()
            {
                MessageDateAdded = messageModel.dateAdded,
                Phone = messageModel.phone,
                Email = messageModel.email,
                MessageContent = messageModel.msgContent
            };

            DB.ContactUsMessages.Add(contactUsMessage);
            DB.SaveChanges();

            messageModel.id = contactUsMessage.MessageID;
            return messageModel;
        }
    }
}
