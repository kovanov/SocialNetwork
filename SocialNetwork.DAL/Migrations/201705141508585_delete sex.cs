namespace SocialNetwork.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletesex : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProfiles", "Sex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "Sex", c => c.Int());
        }
    }
}
