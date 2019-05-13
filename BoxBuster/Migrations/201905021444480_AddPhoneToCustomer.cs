namespace BoxBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Phone", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Phone");
        }
    }
}
