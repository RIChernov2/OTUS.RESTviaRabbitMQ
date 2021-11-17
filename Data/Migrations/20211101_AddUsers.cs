using FluentMigrator;

namespace Data.Migrations
{
    [Migration(202111010729)]
    public class AddUsers : Migration
    {
        public override void Up()
        {
            Create.Table("users")
                .WithColumn("user_id").AsInt64().PrimaryKey().Identity()
                .WithColumn("name").AsString(50).NotNullable()
                .WithColumn("surname").AsString(50).Nullable()
                .WithColumn("age").AsByte().Nullable();

            Create.Index("ix_users_surname")
                .OnTable("users")
                .OnColumn("surname");
        }

        public override void Down()
        {
            Delete.Table("users");
        }
    }
}