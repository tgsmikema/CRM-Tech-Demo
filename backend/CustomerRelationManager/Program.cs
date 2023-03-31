using CustomerRelationManager.Data;
using CustomerRelationManager.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173").AllowAnyHeader()
                                                  .AllowAnyMethod(); ;
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CrmDBContext>(options => options.UseSqlite(builder.Configuration["WebAPIConnection"]));
builder.Services.AddScoped<ICrmRepo, CrmRepo>();

//register an authentication scheme
builder.Services.AddAuthentication()
    .AddScheme<AuthenticationSchemeOptions, CrmAuthHandler>("Authentication", null);

//register an authorization policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly",
                                    policy => policy.RequireClaim("admin"));
    options.AddPolicy("AllUsers", policy =>
    {
        policy.RequireAssertion(context => context.User.HasClaim(c =>
        (c.Type == "admin" || c.Type == "user")));
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

//add authentication to the processing pipeline
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
