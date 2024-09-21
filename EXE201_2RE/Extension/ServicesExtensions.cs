/*
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Text;
using Microsoft.Extensions.Configuration;
using EXE201_2RE.Middlewares;
using EXE201_2RE.Setting;
using EXE201_2RE.Repository;
using EXE201_2RE.Service;
using Microsoft.Extensions.DependencyInjection;

namespace EXE201_2RE.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ExceptionMiddleware>();
        services.AddController();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        //Add Mapper
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new ApplicationMapper());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        var jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();
        services.Configure<JwtSettings>(val =>
        {
            val.Key = jwtSettings.Key;
        });

        services.AddAuthorization();

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddDbContext<DiamondContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DiamondConnection"));
        });

        //services.Configure<MailSettings>(configuration.GetSection(nameof(MailSettings)));

        var mailConfigSection = configuration.GetSection("MailSettings");
        var mailConfig = mailConfigSection.Get<MailSettings>();
        services.Configure<MailSettings>(mailConfigSection);
        services.AddSingleton(mailConfig);

        var firebaseConfigSection = configuration.GetSection("Firebase");
        var firebaseConfig = firebaseConfigSection.Get<FirebaseConfiguration>();
        services.Configure<FirebaseConfiguration>(firebaseConfigSection);
        services.AddSingleton(firebaseConfig);

        AppContext.SetSwitch("System.Globalization.Invariant", true);
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<UnitOfWork>();
        services.AddScoped<UserService>();
        services.AddScoped<IdentityService>();

        return services;
    }
}*/