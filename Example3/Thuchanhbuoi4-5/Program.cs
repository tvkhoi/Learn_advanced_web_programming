using Microsoft.EntityFrameworkCore;
using Thuchanhbuoi4_5.Data;
using Thuchanhbuoi4_5.Models;
using Thuchanhbuoi4_5.Services;

var builder = WebApplication.CreateBuilder(args);

// Thêm cấu hình từ appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Cấu hình Database (In-Memory)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký các dịch vụ (DI Container)
builder.Services.AddScoped<IUserService, UserService>();

// Cấu hình MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

//    if (!dbContext.Users.Any())
//    {
//        dbContext.Users.AddRange(new List<User>
//        {
//            new User { Username = "testuser1", Email = "user1@example.com" },
//            new User { Username = "testuser2", Email = "user2@example.com" }
//        });

//        dbContext.SaveChanges();
//    }
//}


// Cấu hình Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Cấu hình Endpoint cho Controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();


