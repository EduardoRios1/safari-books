namespace SafariBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangestotheModels : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "UniqueNumber", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Books", "UniqueNumber");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "UniqueNumber", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Books", "UniqueNumber");
        }
    }
}
