namespace EmployeeManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(nullable: false, maxLength: 50),
                        Major = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DegreeId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        GenderId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        BirthDate = c.DateTime(nullable: false, storeType: "date"),
                        PhoneNumber = c.String(nullable: false, maxLength: 25),
                        EmailAddress = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId)
                .ForeignKey("dbo.States", t => t.StateId)
                .ForeignKey("dbo.Degrees", t => t.DegreeId)
                .Index(t => t.DegreeId)
                .Index(t => t.StateId)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 6),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Abbreviation = c.String(nullable: false, maxLength: 2),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DegreeId", "dbo.Degrees");
            DropForeignKey("dbo.Employees", "StateId", "dbo.States");
            DropForeignKey("dbo.Employees", "GenderId", "dbo.Genders");
            DropIndex("dbo.Employees", new[] { "GenderId" });
            DropIndex("dbo.Employees", new[] { "StateId" });
            DropIndex("dbo.Employees", new[] { "DegreeId" });
            DropTable("dbo.States");
            DropTable("dbo.Genders");
            DropTable("dbo.Employees");
            DropTable("dbo.Degrees");
        }
    }
}
