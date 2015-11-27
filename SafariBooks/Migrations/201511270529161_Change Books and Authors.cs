namespace SafariBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBooksandAuthors : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "FName", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Title", c => c.String());
            AlterColumn("dbo.Authors", "FName", c => c.String());
        }
    }
}
