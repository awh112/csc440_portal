namespace CSC440_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNullableBLS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OccupationalGroups", "BLSCurrent", c => c.Double());
            AddColumn("dbo.OccupationalGroups", "BLSFuture", c => c.Double());
            AddColumn("dbo.OccupationalGroups", "BLSNumChange", c => c.Double());
            AddColumn("dbo.OccupationalGroups", "BLSPercentChange", c => c.Double());
            AddColumn("dbo.OccupationalGroups", "BLSMedianWage", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OccupationalGroups", "BLSMedianWage");
            DropColumn("dbo.OccupationalGroups", "BLSPercentChange");
            DropColumn("dbo.OccupationalGroups", "BLSNumChange");
            DropColumn("dbo.OccupationalGroups", "BLSFuture");
            DropColumn("dbo.OccupationalGroups", "BLSCurrent");
        }
    }
}
