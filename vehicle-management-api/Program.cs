using vehicle_management_api.Helpers.Filters;
using vehicle_management_api.Helpers.Swagger;
using vehicle_management_api.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
GlobalServices.AddDefaultServices(builder);

// Add swagger
SwaggerHelper.AddSwagger(builder);

// Add transient services
GlobalServices.AddTransientDependencies(builder);

// Add DB Context (Entity Framework)
GlobalServices.AddDbContext(builder);

// add jwt authorization
GlobalServices.AddAuthorization(builder);

// Build application
var app = builder.Build();

// use general exceptions handler (use error-response-model)
ExceptionsHandler.Configure(app);

// Use development middlewares
if (app.Environment.IsDevelopment())
    GlobalServices.UseDevelopmentMiddlewares(app);

// use all middlewares
GlobalServices.UseMiddlewares(app);

// run application
app.Run();