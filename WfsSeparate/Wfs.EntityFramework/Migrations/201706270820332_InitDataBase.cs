namespace Wfs.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysAction",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ControllerName = c.String(nullable: false, maxLength: 50),
                        ActionName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 50),
                        NamedDescription = c.String(maxLength: 50),
                        IsActive = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        UpdationTime = c.DateTime(),
                        CreateOne = c.Guid(nullable: false),
                        UpdateOne = c.Guid(),
                    })
                .PrimaryKey(t => new { t.Id, t.ControllerName, t.ActionName });
            
            CreateTable(
                "dbo.SysMenu",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Icon = c.String(maxLength: 50),
                        MenuName = c.String(nullable: false, maxLength: 50),
                        ControllerName = c.String(nullable: false, maxLength: 50),
                        ActionName = c.String(nullable: false, maxLength: 50),
                        MenuUrl = c.String(maxLength: 50),
                        MenuPId = c.Guid(),
                        Order = c.Int(),
                        Description = c.String(maxLength: 100),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysRole",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        RoleDescription = c.String(maxLength: 100),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysRoleAction",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        ActionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysUser",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SysUserName = c.String(nullable: false, maxLength: 50),
                        SysUserPwd = c.String(nullable: false, maxLength: 50),
                        SysUserRandomCode = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        UpdationTime = c.DateTime(),
                        IsDelete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysUserInfo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        RealName = c.String(maxLength: 50),
                        MobilePhone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Sex = c.Int(nullable: false),
                        HeaderImg = c.String(maxLength: 100),
                        IsDelete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysUserRole",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ThirdClient",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ThirdClientName = c.String(nullable: false, maxLength: 100),
                        ThirdClientCode = c.String(maxLength: 50),
                        ThirdClientSecret = c.String(nullable: false, maxLength: 50),
                        ThirdClientUrl = c.String(maxLength: 100),
                        ThirdDescription = c.String(maxLength: 512),
                        IsActive = c.Int(nullable: false),
                        ExpireTime = c.DateTime(),
                        CreationTime = c.DateTime(nullable: false),
                        UpdationTime = c.DateTime(),
                        CreateOne = c.Guid(nullable: false),
                        UpdateOne = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ThirdClientAction",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ActionId = c.String(nullable: false, maxLength: 50),
                        ThirdClientId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ThirdClientAction");
            DropTable("dbo.ThirdClient");
            DropTable("dbo.SysUserRole");
            DropTable("dbo.SysUserInfo");
            DropTable("dbo.SysUser");
            DropTable("dbo.SysRoleAction");
            DropTable("dbo.SysRole");
            DropTable("dbo.SysMenu");
            DropTable("dbo.SysAction");
        }
    }
}
