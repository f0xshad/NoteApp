namespace NoteApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableNoteColumnId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Notes");
            AlterColumn("dbo.Notes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Notes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Notes");
            AlterColumn("dbo.Notes", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Notes", "Id");
        }
    }
}
