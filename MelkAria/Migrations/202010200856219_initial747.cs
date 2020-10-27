namespace MelkAria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial747 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.melk", "IsElevator", c => c.Boolean(nullable: false));
            AddColumn("dbo.melk", "IsParking", c => c.Boolean(nullable: false));
            AddColumn("dbo.melk", "CoolKind", c => c.String());
            AddColumn("dbo.melk", "Isswimmingpool", c => c.Boolean(nullable: false));
            AddColumn("dbo.melk", "IsJacuzzi", c => c.Boolean(nullable: false));
            AddColumn("dbo.melk", "Skeletontype", c => c.String());
            AddColumn("dbo.melk", "Pricepersquaremeter", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.melk", "Pricepersquaremeter");
            DropColumn("dbo.melk", "Skeletontype");
            DropColumn("dbo.melk", "IsJacuzzi");
            DropColumn("dbo.melk", "Isswimmingpool");
            DropColumn("dbo.melk", "CoolKind");
            DropColumn("dbo.melk", "IsParking");
            DropColumn("dbo.melk", "IsElevator");
        }
    }
}
