namespace NoteApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditNoteTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notes", "UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Notes", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notes", "CreationDate", c => c.String());
            AlterColumn("dbo.Notes", "UpdateDate", c => c.String());
        }
    }
}
