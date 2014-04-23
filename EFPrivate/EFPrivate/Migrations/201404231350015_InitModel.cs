namespace EFPrivate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        TicketStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId);
            
            CreateTable(
                "dbo.TicketNotes",
                c => new
                    {
                        TicketNoteId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Created = c.DateTime(nullable: false),
                        TicketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketNoteId)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketNotes", "TicketId", "dbo.Tickets");
            DropIndex("dbo.TicketNotes", new[] { "TicketId" });
            DropTable("dbo.TicketNotes");
            DropTable("dbo.Tickets");
        }
    }
}
