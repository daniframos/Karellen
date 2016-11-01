namespace Karellen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoSolucao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBOcorrencia", "Resolucao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBOcorrencia", "Resolucao");
        }
    }
}
