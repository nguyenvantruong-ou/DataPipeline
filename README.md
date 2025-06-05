# Database Setup & Entity Framework Core Configuration
This project is mainly to review knowledge of working with SQL Server.

---

## 🏗️ 1. Create a Migration

This is simple process so we will skip it.


## 🌱 2. Seed Initial Data


## ⚙️ 3. Fluent API Configuration for Indexes

Create a configuration class for each entity:

```csharp
public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.Email);
        builder.HasIndex(x => x.FullName);

        // Composite index (uncomment to use)
        // builder.HasIndex(x => new { x.Email, x.FullName })
        //        .HasDatabaseName("IX_User_Email_FullName");

        // Unique index (optional)
        // builder.HasIndex(u => u.Email)
        //        .IsUnique();
    }
}
```

Apply the configuration in `DbContext`:

```csharp
     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {   
         modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbAppContext).Assembly);
         base.OnModelCreating(modelBuilder);
     }
```

---

## 🧠 4. Add a Stored Procedure with Migration

Edit the `Up()` method in your migration:

```csharp
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.Sql(@"
        CREATE PROCEDURE GetUsersByCity
            @City NVARCHAR(100)
        AS
        BEGIN
            SELECT * FROM Users WHERE City = @City
        END
    ");
}
```

Call the stored procedure using EF Core:

```csharp
var users = _context.Users
    .FromSqlRaw("EXEC GetUsersByCity @City = {0}", city)
    .ToList();
```

---

## 📈 Performance Considerations

* ✅ Use indexes for frequently searched fields (like `Email`, `City`)
* ✅ Normalize or denormalize as appropriate for your use case
* ✅ Use stored procedures for repeated queries to reduce server-side parsing
* ✅ Consider SQL Triggers or Views if you're doing reporting or audit logging

---

## 🧰 Useful Features in SQL Server

### Also have:
* **Triggers** – for automating audits, logging, cascading actions
* **Views** – to simplify reporting
* **Partitioning** – for huge tables (optional)

---

## 🗂 Recommended Structure

```
/Configurations
  |- UserConfigurations.cs
/Migrations
/Models
  |- User.cs
  | - ....
/Data
  |- DbAppContext.cs
  |- UnitOfWork.cs
/Controllers
  |- UserController.cs
```

---

## ✅ Final Tip

Use EF Core's full potential:

* Fluent API for detailed configuration
* Migrations for version control
* Raw SQL for complex queries

