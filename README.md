Step 1: Install packages. This is for linux ubuntu

bash :
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package Microsoft.EntityFrameworkCore.Tools


Step 2: Connect to DataBase ONly need to do it once for a database

Go to appsettings.json and add

:
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=Demo8_db;user=demo_user2;password=12345678;"
  }
}

The final code looks like :

{ 
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=Demo8_db;user=demo_user2;password=12345678;"
  },
  
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

Step 3 : Create a Model to store DB data

Lets create a folder name is anyname Here we use Emp_Models inside it create EmpModel.cs

:
namespace Demo8.Models.DB_Models
{
    public class Emp
    {
        public int Emp_Id { get; set; }
        public string? Emp_Name { get; set; }
        public int? Emp_Age { get; set; }
        public string? Emp_Gender { get; set; }
        public string? Emp_Dept { get; set; }
    }
}


Step 4
: Build DB Context. 1 DB Context for 1 Database.
Create a folder, name it Data. Put all DB Context files there. Create a file inside and name it anything, here lets name it as Demo8dbContext.cs
Add each table and each table configuration here and include each models used for the database.

using Microsoft.EntityFrameworkCore;
using Demo8.Models.DB_Models;  // Add the corresponding Model of the table
using Demo8.Configurations.EmpConfig; //Add the corrsponding Configurations we want.

namespace Demo8.Data
{
    public class Demo8dbContext : DbContext
    {
        public Demo8dbContext(DbContextOptions<Demo8dbContext> options) : base(options) { }

        public DbSet<Emp> Emp_table { get; set; } // Add the table here. add more tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicit configuration mapping
            modelBuilder.ApplyConfiguration(new EmpConfig());

            // If you add more tables later:
            // modelBuilder.ApplyConfiguration(new ProjectConfig());
            // modelBuilder.ApplyConfiguration(new SalaryConfig());
            // ...
        }
    }
}


Step 5 : Configure the Table and columns
Create a folder name it Configurations. From now put all config here.
Create a file name it EmpConfig.cs
 Templete - builder table, primary key, all other properties
: 
using Demo8.Models.DB_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo8.Configurations.EmpConfig
{
    public class EmpConfig : IEntityTypeConfiguration<Emp>
    {
        public void Configure(EntityTypeBuilder<Emp> builder)
        {
            builder.ToTable("Emp_table");

            builder.HasKey(e => e.Emp_Id);

            builder.Property(e => e.Emp_Id)
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.Emp_Name)
                   .HasMaxLength(60)
                   .HasDefaultValue("Unknown");

            builder.Property(e => e.Emp_Gender)
                   .HasMaxLength(45)
                   .HasDefaultValue("Unknown");

            builder.Property(e => e.Emp_Age)
                   .HasDefaultValue(0);

            builder.Property(e => e.Emp_Dept)
                   .HasMaxLength(45)
                   .HasDefaultValue("Unknown");
        }
    }
}

Step 6 : Register the Database connection and Database Context in the Program.cs file

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Demo8dbContext>(options =>  //Write the name of the context class
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    
 Add 
using Microsoft.EntityFrameworkCore;
using Demo8.Data;

at the top of the file

The final code looks like 
:
using Microsoft.EntityFrameworkCore;
using Demo8.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Demo8dbContext>(options =>  //Write the name of the context class
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();


Step 7 :
Build the Html form import the models and use it
@models namespace.classname is the format to use models for the page

The final code look like
:
@model Demo8.Models.DB_Models.Emp
@{
    Layout = null; 
}
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Hello</title>

    <link rel="stylesheet" href="~/lib/bootstrap/css/bootstrap.min.css" />
    <script src="~/lib/bootstrap/js/bootstrap.bundle.min.js"></script>

    <link rel="stylesheet" href="~/css/actiondesign.css" />

</head>
<body>
    <div class="row">
        <div class="form-box">
            <form asp-action="MysqlInput" method="POST">
                <h3>Employee Details</h3>
                <div class="row">
                    <input asp-for="Emp_Name" type="text" class="form-control mt-3" placeholder="Enter Name" style="width: 350px"/>
                </div>
                <div class="row">
                    <div class="col-2">
                        <input asp-for="Emp_Age" type="number" class="form-control mt-3" placeholder="Age"style="width: 150px"  />
                    </div>
                    <div class="col-2">
                        <input asp-for="Emp_Gender" type="text" class="form-control mt-3" placeholder="Gender" style="width: 150px; margin-left: 35px" />
                    </div>
                </div>
                <div class="row">
                    <input asp-for="Emp_Dept" type="text" class="form-control mt-3" placeholder="Department" style="width: 350px" />
                </div>
                <div class="row">
                    <button type="submit" class="btn btn-primary mt-3" style="width: 150px">Add</button>
                </div>
            </form>
        </div>
    </div>
</body>
</html>


Step 8 :
Create the controller

Import data
Import Models

using Microsoft.AspNetCore.Mvc;
using Demo8.Data;
using Demo8.Models.DB_Models;

namespace Demo8.Controllers
{
    public class ActionController : Controller
    {
        private readonly Demo8dbContext _context;

        public ActionController(Demo8dbContext context)
        {
            _context = context;
        }

        // Display form
        public IActionResult MysqlInput()
        {
            return View();
        }

        // Handle form submission
        [HttpPost]
        public IActionResult MysqlInput(Emp emp)
        {
            if (ModelState.IsValid)
            {
                // ✅ Use DbSet name (Emp), not the table name
                _context.Emp_table.Add(emp);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(emp);
        }
    }
}
