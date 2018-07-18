namespace SFI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingRequiredMinAndMaxIntoMovieModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "Type", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Type", c => c.String());
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}
