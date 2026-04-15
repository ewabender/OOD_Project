namespace OOD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Birds");
            AddColumn("dbo.Birds", "BirdId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Birds", "speciesCode", c => c.String());
            AddPrimaryKey("dbo.Birds", "BirdId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Birds");
            AlterColumn("dbo.Birds", "speciesCode", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Birds", "BirdId");
            AddPrimaryKey("dbo.Birds", "speciesCode");
        }
    }
}
