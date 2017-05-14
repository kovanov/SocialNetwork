using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DAL
{
    public class Message
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        [Required]
        public DateTime SendDate { get; set; }

        [Required]
        public string Body { get; set; }

        public User Sender { get; set; }

        public User Receiver { get; set; }
    }

    public class User
    {
        public int Id { get; set; }

        [Required]
        public string AppAuthId { get; set; }

        public int? ProfileId { get; set; }

        public UserProfile Profile { get; set; }
    }

    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string About { get; set; }

        public byte[] Photo { get; set; }
    }

    public class UserRelation
    {
        public int Id { get; set; }

        public int WhoId { get; set; }

        public int WhomId { get; set; }
        
        public User Whom { get; set; }

        public User Who { get; set; }

        [Required]
        public UserRelationType RelationType { get; set; }
    }

    public enum UserRelationType
    {
        FriendRequestSend, Friend, BlackList
    }
}
