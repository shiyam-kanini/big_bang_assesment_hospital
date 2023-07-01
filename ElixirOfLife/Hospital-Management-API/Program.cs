using Hospital_Management_API.Models;
using Hospital_Management_API.Repositories.AdminRepo;
using Hospital_Management_API.Repositories.DrugInventoryRepo;
using Hospital_Management_API.Repositories.LabReportRepo;
using Hospital_Management_API.Repositories.LoginRepo;
using Hospital_Management_API.Repositories.PatientProfileRepo;
using Hospital_Management_API.Repositories.PrescriptionRepo;
using Hospital_Management_API.Repositories.ProfileRepo;
using Hospital_Management_API.Repositories.RegisterRepo;
using Hospital_Management_API.Repositories.RoleRepo;
using Hospital_Management_API.Repositories.RoomRepo;
using Hospital_Management_API.Repositories.SpecializationRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services.AddScoped<IRepoRegister, RepoRegister>();
        builder.Services.AddScoped<IRepoLogin, RepoLogin>();
        builder.Services.AddScoped<IRepoRole, RepoRole>();
        builder.Services.AddScoped<IRepoDrugInventory, RepoDrugInventory>();
        builder.Services.AddScoped<IRepoSpecialization, RepoSpecialization>();
        builder.Services.AddScoped<IRepoAdmin, RepoAdmin>();
        builder.Services.AddScoped<IRepoEmployeeProfile, RepoEmployeeProfile>();
        builder.Services.AddScoped<IRepoPatientProfile, RepoPatientProfile>();
        builder.Services.AddScoped<IRepoLabReport, RepoLabReport>();
        builder.Services.AddScoped<IRepoRoomPatient, RepoRoomPatient>();
        builder.Services.AddScoped<IRepoPrescription, RepoPrescription>();

        builder.Services.AddDbContext<HospitalDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

        //For Authorize in swagger
        builder.Services.AddSwaggerGen(c => {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                           new OpenApiSecurityScheme
                             {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id = "Bearer"
                                 }
                             },
                             new string[] {}
                     }
                 });
        });

        //Newtonsoft loop haandling
        builder.Services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


        //JWT
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
             .AddJwtBearer(options =>
             {
                 options.SaveToken = true;
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidAudience = builder.Configuration["JWT:ValidAudience"],
                     ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                 };
             });

        //CORS Policy

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("MyPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
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

        app.UseCors("MyPolicy");

        app.UseAuthentication();

        app.UseAuthorization();
        app.Use(async (context, next) =>
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var user = context.User;
            }
            await next.Invoke();
        });


        app.MapControllers();

        app.Run();
    }
}