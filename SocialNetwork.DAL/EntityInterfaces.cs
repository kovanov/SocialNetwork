using System;
using System.Collections.Generic;

namespace SocialNetwork.DAL
{
    public interface IMessage
    {
        int Id { get; set; }
        int SenderId { get; set; }
        int ReceiverId { get; set; }
        DateTime SendDate { get; set; }
        string Body { get; set; }
    }

    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        int Age { get; set; }
        string About { get; set; }
        byte[] Photo { get; set; }
        ICollection<User> Friends { get; set; }
    }

    public interface IUserRelation
    {
        int Id { get; set; }
        int Who { get; set; }
        int Whom { get; set; }
        UserRelationType RelationType { get; set; }
    }
}
