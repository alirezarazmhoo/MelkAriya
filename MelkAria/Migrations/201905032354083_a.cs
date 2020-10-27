namespace MelkAria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.aboutUs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(maxLength: 50),
                        androidVersion = c.String(maxLength: 20),
                        author = c.String(maxLength: 20),
                        description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.city",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50),
                        nameEnglish = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.contactUs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        phone = c.String(maxLength: 50),
                        pageTelegramUrl = c.String(maxLength: 200),
                        pageInstagramUrl = c.String(maxLength: 200),
                        pageTwitterUrl = c.String(maxLength: 200),
                        siteName = c.String(maxLength: 100),
                        email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.melk",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cityId = c.Int(nullable: false),
                        createDate = c.DateTime(nullable: false),
                        pCreateDate = c.String(maxLength: 20),
                        isYard = c.Boolean(nullable: false),
                        kind = c.Int(nullable: false),
                        statusKind = c.Int(nullable: false),
                        price = c.Long(),
                        metraj = c.Double(nullable: false),
                        roomCount = c.Int(nullable: false),
                        floorCount = c.Int(nullable: false),
                        parkingKind = c.String(maxLength: 200),
                        cellingKind = c.String(maxLength: 200),
                        floorKind = c.String(maxLength: 200),
                        heatingKind = c.String(maxLength: 200),
                        status = c.Int(nullable: false),
                        description = c.String(maxLength: 1000),
                        lon = c.Double(nullable: false),
                        lat = c.Double(nullable: false),
                        tell = c.String(maxLength: 11),
                        title = c.String(maxLength: 200),
                        address = c.String(maxLength: 500),
                        imageUrl = c.String(maxLength: 70),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.city", t => t.cityId, cascadeDelete: true)
                .Index(t => t.cityId);
            
            CreateTable(
                "dbo.photo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        file = c.String(),
                        jobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.melk", t => t.jobId, cascadeDelete: true)
                .Index(t => t.jobId);
            
            CreateTable(
                "dbo.role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleNameFa = c.String(nullable: false),
                        RoleNameEn = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50),
                        family = c.String(maxLength: 200),
                        mobile = c.String(maxLength: 11),
                        userNamee = c.String(maxLength: 20),
                        email = c.String(maxLength: 100),
                        password = c.String(maxLength: 1000),
                        passwordShow = c.String(maxLength: 20),
                        apiToken = c.String(maxLength: 100),
                        isNew = c.Boolean(nullable: false),
                        score = c.Int(nullable: false),
                        image = c.String(maxLength: 70),
                        role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.role", t => t.role_Id)
                .Index(t => t.role_Id);
            
            CreateTable(
                "dbo.rule",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(maxLength: 50),
                        description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.userFavorite",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        jobId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.melk", t => t.jobId, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.userId, cascadeDelete: true)
                .Index(t => t.jobId)
                .Index(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.userFavorite", "userId", "dbo.user");
            DropForeignKey("dbo.userFavorite", "melkId", "dbo.melk");
            DropForeignKey("dbo.user", "role_Id", "dbo.role");
            DropForeignKey("dbo.photo", "jobId", "dbo.melk");
            DropForeignKey("dbo.melk", "cityId", "dbo.city");
            DropIndex("dbo.userFavorite", new[] { "userId" });
            DropIndex("dbo.userFavorite", new[] { "melkId" });
            DropIndex("dbo.user", new[] { "role_Id" });
            DropIndex("dbo.photo", new[] { "melkId" });
            DropIndex("dbo.melk", new[] { "cityId" });
            DropTable("dbo.userFavorite");
            DropTable("dbo.rule");
            DropTable("dbo.user");
            DropTable("dbo.role");
            DropTable("dbo.photo");
            DropTable("dbo.melk");
            DropTable("dbo.contactUs");
            DropTable("dbo.city");
            DropTable("dbo.aboutUs");
        }
    }
}
