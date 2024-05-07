var builder = WebApplication.CreateBuilder(args);

// إضافة خدمات Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// إضافة دعم Controllers
builder.Services.AddControllers();

var app = builder.Build();

// تفعيل Swagger فقط في بيئة التطوير
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// تحديد التوجيه (routing) الافتراضي
app.MapControllers();

app.Run();