using CustomerRelationManager.Data;
using CustomerRelationManager.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

// configure CORS setting
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// configure CORS setting to accept incoming request from the react + vite frontend server.
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


// register DB Context class to the main program container.
builder.Services.AddDbContext<CrmDBContext>(options => options.UseSqlite(builder.Configuration["WebAPIConnection"]));
builder.Services.AddScoped<ICrmRepo, CrmRepo>();

//register an authentication scheme
builder.Services.AddAuthentication()
    .AddScheme<AuthenticationSchemeOptions, CrmAuthHandler>("Authentication", null);

// register an authorization policy (in the below example, I have 2 policies defined)
// one is Admin only, and another one is All users, which corresponding to do the function
// they describe when it's being applied to the controller class.
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

// configure CORS setting
app.UseCors(MyAllowSpecificOrigins);

//add authentication to the processing pipeline
app.UseAuthentication();

//add authorisation to the processing pipeline
app.UseAuthorization();

app.MapControllers();

app.Run();
