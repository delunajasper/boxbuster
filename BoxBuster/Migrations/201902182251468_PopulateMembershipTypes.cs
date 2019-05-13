namespace BoxBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, JoinFee, Duration, Discount) VALUES (1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, JoinFee, Duration, Discount) VALUES (2, 25, 1, 10)");
            Sql("INSERT INTO MembershipTypes (Id, JoinFee, Duration, Discount) VALUES (3, 75, 3, 20)");
            Sql("INSERT INTO MembershipTypes (Id, JoinFee, Duration, Discount) VALUES (4, 280, 12, 30)");

        }
        
        public override void Down()
        {
        }
    }
}
