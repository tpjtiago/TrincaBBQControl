using TrincaBBQControl.Data.Repositories;
using TrincaBBQControl.Domain.Contracts.Repositories;
using TrincaBBQControl.Domain.Contracts.Services;
using TrincaBBQControl.Domain.Services;

namespace TrincaBBQControl.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void DependencyInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IBarbecueService, BarbecueService>();
            builder.Services.AddScoped<IParticipantService, ParticipantService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
