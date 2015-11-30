namespace SafariBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Books");
            AddColumn("dbo.Books", "BookID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Books", "BookID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Books");
            DropColumn("dbo.Books", "BookID");
            AddPrimaryKey("dbo.Books", "UniqueNumber");
        }
    }
}
