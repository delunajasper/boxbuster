namespace BoxBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubscriptionToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Subscription", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Subscription");
        }
    }
}
