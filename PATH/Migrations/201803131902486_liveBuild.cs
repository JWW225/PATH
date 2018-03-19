namespace ProvalusApplicantTrackingHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class liveBuild : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Line1 = c.String(nullable: false),
                        Line2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.Int(nullable: false),
                        ZIP = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        JobApp_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobApps", t => t.JobApp_Id)
                .Index(t => t.JobApp_Id);
            
            CreateTable(
                "dbo.JobApps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        FName = c.String(nullable: false),
                        LName = c.String(nullable: false),
                        MName = c.String(),
                        Email = c.String(nullable: false),
                        PrimaryPhone = c.String(nullable: false),
                        PPhoneIsMobile = c.Boolean(nullable: false),
                        SecondaryPhone = c.String(),
                        SPhoneIsMobile = c.Boolean(nullable: false),
                        CanRelocate = c.Boolean(nullable: false),
                        DateAvailable = c.DateTime(nullable: false),
                        DateEntered = c.DateTime(nullable: false),
                        AuthorizedToWork = c.Boolean(nullable: false),
                        DrugScreen = c.Boolean(nullable: false),
                        Military = c.Boolean(nullable: false),
                        MilBranch = c.Int(nullable: false),
                        Conviction = c.Boolean(nullable: false),
                        Explanation = c.String(),
                        Signature = c.Binary(),
                        About = c.String(),
                        Resume = c.String(),
                        CPABScore = c.Int(nullable: false),
                        PTScore = c.Int(nullable: false),
                        Assignment = c.String(),
                        Status = c.Int(nullable: false),
                        Source = c.Int(nullable: false),
                        EmployeeType = c.Int(nullable: false),
                        LastEdit = c.DateTime(nullable: false),
                        Branch = c.Int(nullable: false),
                        Applicant_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Applicant_Id)
                .Index(t => t.Applicant_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Branch = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        Author_Id = c.String(nullable: false, maxLength: 128),
                        JobApp_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id, cascadeDelete: true)
                .ForeignKey("dbo.JobApps", t => t.JobApp_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.JobApp_Id);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        School = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Major = c.String(),
                        Degree = c.String(),
                        JobApp_Id = c.Int(),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobApps", t => t.JobApp_Id)
                .ForeignKey("dbo.Addresses", t => t.Location_Id)
                .Index(t => t.JobApp_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Employments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Current = c.Boolean(nullable: false),
                        Employer = c.String(nullable: false),
                        JobTitle = c.String(nullable: false),
                        EmployerPhone = c.String(),
                        StartPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EndPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayRate = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Address_Id = c.Int(),
                        JobApp_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.JobApps", t => t.JobApp_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.JobApp_Id);
            
            CreateTable(
                "dbo.References",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Title = c.String(),
                        Company = c.String(),
                        Phone = c.String(nullable: false),
                        JobApp_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobApps", t => t.JobApp_Id)
                .Index(t => t.JobApp_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Explanation = c.String(),
                        Proficiency = c.Int(nullable: false),
                        JobApp_Id = c.Int(),
                        Technology_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobApps", t => t.JobApp_Id)
                .ForeignKey("dbo.Technologies", t => t.Technology_Id)
                .Index(t => t.JobApp_Id)
                .Index(t => t.Technology_Id);
            
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "Technology_Id", "dbo.Technologies");
            DropForeignKey("dbo.Skills", "JobApp_Id", "dbo.JobApps");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.References", "JobApp_Id", "dbo.JobApps");
            DropForeignKey("dbo.Employments", "JobApp_Id", "dbo.JobApps");
            DropForeignKey("dbo.Employments", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Educations", "Location_Id", "dbo.Addresses");
            DropForeignKey("dbo.Educations", "JobApp_Id", "dbo.JobApps");
            DropForeignKey("dbo.Comments", "JobApp_Id", "dbo.JobApps");
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Addresses", "JobApp_Id", "dbo.JobApps");
            DropForeignKey("dbo.JobApps", "Applicant_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Skills", new[] { "Technology_Id" });
            DropIndex("dbo.Skills", new[] { "JobApp_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.References", new[] { "JobApp_Id" });
            DropIndex("dbo.Employments", new[] { "JobApp_Id" });
            DropIndex("dbo.Employments", new[] { "Address_Id" });
            DropIndex("dbo.Educations", new[] { "Location_Id" });
            DropIndex("dbo.Educations", new[] { "JobApp_Id" });
            DropIndex("dbo.Comments", new[] { "JobApp_Id" });
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.JobApps", new[] { "Applicant_Id" });
            DropIndex("dbo.Addresses", new[] { "JobApp_Id" });
            DropTable("dbo.Technologies");
            DropTable("dbo.Skills");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.References");
            DropTable("dbo.Employments");
            DropTable("dbo.Educations");
            DropTable("dbo.Comments");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.JobApps");
            DropTable("dbo.Addresses");
        }
    }
}
