using FluentMigrator;

namespace OrmBenchmarks.Dapper.Migrations;


[Migration(202106280001)]
public class TestMigrations_202106280001 : Migration
{
    public override void Down()
    {
        Delete.Table("Users");
    }
    public override void Up()
    {
        Create.Table("Users")
            .WithColumn("Id").AsInt64().NotNullable().PrimaryKey()
            .WithColumn("IsDeleted").AsBoolean().NotNullable()
            .WithColumn("DeletedDateTime").AsDateTime().Nullable()
            .WithColumn("Name").AsString(255).NotNullable()
            .WithColumn("Age").AsInt32().NotNullable();
    }
}