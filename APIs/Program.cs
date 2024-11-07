using APIs.APIsConfigs;
using APIs.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Clear existing providers and add Log4Net
builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();

// Add services
builder.Services.AddControllers().ConfigureApiBehaviorOptions(x => { x.SuppressMapClientErrors = true; });
builder.Services.RegisterIoCs(builder.Configuration);
builder.Services.AddRateLimiting();

// Configure services
builder.Services.AddSwagger();
builder.Services.AddJwtToken();
builder.Services.AddCors();

var app = builder.Build();

// Gọi tới wwwroot
app.UseStaticFiles();

// Configure middleware
app.UseRateLimiter();
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerUI(app.Environment);

app.MapControllers();
app.Run();
