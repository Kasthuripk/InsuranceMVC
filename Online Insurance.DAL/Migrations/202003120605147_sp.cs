namespace Online_Insurance.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        insuranceId = c.Int(nullable: false, identity: true),
                        insuranceNumber = c.String(),
                        insuranceType = c.String(),
                        GST = c.String(),
                    })
                .PrimaryKey(t => t.insuranceId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        mailId = c.String(nullable: false, maxLength: 128),
                        customerId = c.Int(nullable: false, identity: true),
                        customerName = c.String(),
                        gender = c.String(),
                        age = c.String(),
                        Address = c.String(),
                        phoneNumber = c.Long(nullable: false),
                        dateOfBirth = c.DateTime(nullable: false),
                        password = c.String(),
                        annualIncome = c.String(),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.mailId);
            
            CreateStoredProcedure(
                "dbo.Admin_Insert",
                p => new
                    {
                        insuranceNumber = p.String(),
                        insuranceType = p.String(),
                        GST = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Admins]([insuranceNumber], [insuranceType], [GST])
                      VALUES (@insuranceNumber, @insuranceType, @GST)
                      
                      DECLARE @insuranceId int
                      SELECT @insuranceId = [insuranceId]
                      FROM [dbo].[Admins]
                      WHERE @@ROWCOUNT > 0 AND [insuranceId] = scope_identity()
                      
                      SELECT t0.[insuranceId]
                      FROM [dbo].[Admins] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[insuranceId] = @insuranceId"
            );
            
            CreateStoredProcedure(
                "dbo.Admin_Update",
                p => new
                    {
                        insuranceId = p.Int(),
                        insuranceNumber = p.String(),
                        insuranceType = p.String(),
                        GST = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Admins]
                      SET [insuranceNumber] = @insuranceNumber, [insuranceType] = @insuranceType, [GST] = @GST
                      WHERE ([insuranceId] = @insuranceId)"
            );
            
            CreateStoredProcedure(
                "dbo.Admin_Delete",
                p => new
                    {
                        insuranceId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Admins]
                      WHERE ([insuranceId] = @insuranceId)"
            );
            
            CreateStoredProcedure(
                "dbo.User_Insert",
                p => new
                    {
                        mailId = p.String(maxLength: 128),
                        customerName = p.String(),
                        gender = p.String(),
                        age = p.String(),
                        Address = p.String(),
                        phoneNumber = p.Long(),
                        dateOfBirth = p.DateTime(),
                        password = p.String(),
                        annualIncome = p.String(),
                        role = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Users]([mailId], [customerName], [gender], [age], [Address], [phoneNumber], [dateOfBirth], [password], [annualIncome], [role])
                      VALUES (@mailId, @customerName, @gender, @age, @Address, @phoneNumber, @dateOfBirth, @password, @annualIncome, @role)
                      
                      SELECT t0.[customerId]
                      FROM [dbo].[Users] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[mailId] = @mailId"
            );
            
            CreateStoredProcedure(
                "dbo.User_Update",
                p => new
                    {
                        mailId = p.String(maxLength: 128),
                        customerId = p.Int(),
                        customerName = p.String(),
                        gender = p.String(),
                        age = p.String(),
                        Address = p.String(),
                        phoneNumber = p.Long(),
                        dateOfBirth = p.DateTime(),
                        password = p.String(),
                        annualIncome = p.String(),
                        role = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Users]
                      SET [customerName] = @customerName, [gender] = @gender, [age] = @age, [Address] = @Address, [phoneNumber] = @phoneNumber, [dateOfBirth] = @dateOfBirth, [password] = @password, [annualIncome] = @annualIncome, [role] = @role
                      WHERE ([mailId] = @mailId)"
            );
            
            CreateStoredProcedure(
                "dbo.User_Delete",
                p => new
                    {
                        mailId = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[Users]
                      WHERE ([mailId] = @mailId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.User_Delete");
            DropStoredProcedure("dbo.User_Update");
            DropStoredProcedure("dbo.User_Insert");
            DropStoredProcedure("dbo.Admin_Delete");
            DropStoredProcedure("dbo.Admin_Update");
            DropStoredProcedure("dbo.Admin_Insert");
            DropTable("dbo.Users");
            DropTable("dbo.Admins");
        }
    }
}
