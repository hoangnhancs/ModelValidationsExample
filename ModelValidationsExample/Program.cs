using ModelValidationsExample.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(option =>
{
    //option.ModelBinderProviders.Insert(0, new PersonBinderProvider());
    //phai input index 0, de uu tien thuc hien binderprovider nay dau tien, neu khong no se thuc hien cai provider khac truoc
    //Console.WriteLine($"{option.ModelBinderProviders}");
});
builder.Services.AddControllers().AddXmlSerializerFormatters();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
