using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shipping.Data;
using Shipping.Data.Entities;
using Shipping.Helper;
using Shipping.Repostory.Interfaces;
using Shipping.Repostory.Repostories;
using Shipping.Serivec.EmailService;
using Shipping.Serivec.Login;
using Shipping.Serivec.Settings;
using Shipping.Serivec.Users;
using Shipping.Service.Service.BranchService;
using Shipping.Service.Service.DeliveryService;
using Shipping.Service.Service.MarchantService;
using Shipping.Service.Service.OrderService;
using Shipping.Service.Service.RejectionOrderService;
using Shipping.Service.Governemt;
using Shipping.Service.Products;
using Shipping.Service.ShippingTypes;
using Shipping.Service.WighPrice;
using Shipping.Services.Login;
using System.Text;

namespace Shipping
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ShippingDbContext>()
                .AddDefaultTokenProviders();

            // Configure DbContext
            builder.Services.AddDbContext<ShippingDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register application services
            builder.Services.AddScoped(typeof(IGenericRepo<,>), typeof(GenricRepo<,>));
            builder.Services.AddScoped<IShippingTypeRepository, ShippingTypeRepository>();
            builder.Services.AddScoped<IShippingTypeServices, ShippingTypeService>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IEmailService, EmailService>();

            builder.Services.AddScoped<IUsers, Users>();

            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IWeightPriceRepository, WeightPriceRepository>();
            builder.Services.AddScoped<IWeightPriceService, WeightPriceService>();
            builder.Services.AddScoped<IGovernmentRepository, GovernmentRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductServices, ProductService>();
            builder.Services.AddScoped<IGovernmentService, GovernmentService>();

            builder.Services.AddScoped<IUnitofwork, UnitOfWork>();
            


            // Configure Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShippingSys.APIs", Version = "v1" });

                // Enable JWT Authentication in Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your token."
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
                        Array.Empty<string>()
                    }
                });
            });

            // Configure JWT Authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.Configure<Jwt>(builder.Configuration.GetSection(nameof(Jwt)));
            builder.Services.Configure<Email>(builder.Configuration.GetSection(nameof(Email)));
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IBranchService, BranchService>();
            builder.Services.AddScoped<IMarchantService, MarchantService>();
            builder.Services.AddScoped<IDeliveryService, DeliveryService>();
            builder.Services.AddScoped<IRejectionOrderService, RejectionOrderService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            var app = builder.Build();

            // Apply database seeding
            await ApplySeeding.ApplyAsync(app);

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShippingSys.APIs v1"));
            }

            app.UseHttpsRedirection();

            // IMPORTANT: Authentication must come before Authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}