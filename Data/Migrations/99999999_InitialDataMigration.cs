using FluentMigrator;


namespace Data.Migrations
{
    [Profile("FirstStart")]
    public class InitialDataMigration : Migration {
        public override void Up()
        {
            Insert.IntoTable("users")
                .Row(new { name = "Super", surname = "Admin", age = 30 })
                .Row(new { name = "Loren", surname = "Wash", age = 17 })
                .Row(new { name = "Alysha", surname = "Holland", age = 38 })
                .Row(new { name = "Michelle", surname = "Young", age = 55 })
                .Row(new { name = "Harriett", surname = "Fosse", age = 32 })
                .Row(new { name = "Jade", surname = "Christopherson", age = 27 });
        }

        public override void Down()
        {
        }
    }
}
