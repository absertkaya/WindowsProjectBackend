using FlightAppAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.DTOs
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public FriendDTO Sender { get; set; }
        public FriendDTO Receiver { get; set; }
        public DateTime TimeStamp { get; set; }

        public static MessageDTO FromMessage(Message message)
        {
            return new MessageDTO
            {
                Id = message.Id,
                Content = message.Content,
                TimeStamp = message.Timestamp,
                Sender = FriendDTO.FromPassenger(message.Sender),
                Receiver = FriendDTO.FromPassenger(message.Receiver)
            };
        }
    }
}
