namespace OOD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Birds",
                c => new
                    {
                        speciesCode = c.String(nullable: false, maxLength: 128),
                        comName = c.String(),
                        sciName = c.String(),
                        locId = c.String(),
                        locName = c.String(),
                        obsDt = c.String(),
                        howMany = c.Int(nullable: false),
                        lat = c.Double(nullable: false),
                        lng = c.Double(nullable: false),
                        obsValid = c.Boolean(nullable: false),
                        obsReviewed = c.Boolean(nullable: false),
                        locationPrivate = c.Boolean(nullable: false),
                        subId = c.String(),
                        userBird = c.Boolean(nullable: false),
                        birdImage = c.String(),
                    })
                .PrimaryKey(t => t.speciesCode);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Birds");
        }
    }
}
