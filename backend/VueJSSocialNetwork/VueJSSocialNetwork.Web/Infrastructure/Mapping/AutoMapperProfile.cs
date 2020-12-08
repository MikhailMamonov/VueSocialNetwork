using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Reflection;
using System.Threading.Tasks;
using VueJSSocialNetwork.Common.Mapping;

namespace VueJSSocialNetwork.Web.Infrastructure.Mapping
{
    public class AutoMapperProfile : Profile
    {
        private readonly string[] _assemblies = new[]
        {
            "VueJSSocialNetwork.Web",
            "VueJSSocialNetwork.Data",
            "VueJSSocialNetwork.Services",
            "VueJSSocialNetwork.Common"
        };

        public AutoMapperProfile()
        {
            var types = new List<Type>();

            foreach (var assemblyName in this._assemblies)
            {
                types.AddRange(Assembly.Load(assemblyName).GetTypes());
            }

            types
                .Where(t => t.IsClass
                            && !t.IsAbstract
                            && t.GetInterfaces().Where(i => i.IsGenericType).Select(i => i.GetGenericTypeDefinition()).Contains(typeof(IMapFrom<>)))
                .Select(t => new
                {
                    Source = t
                        .GetInterfaces()
                        .Where(i => i.IsGenericType)
                        .Select(i => new
                        {
                            Definition = i.GetGenericTypeDefinition(),
                            Arguments = i.GetGenericArguments()
                        })
                        .Where(i => i.Definition == typeof(IMapFrom<>))
                        .SelectMany(i => i.Arguments)
                        .First(),
                    Destination = t
                })
                .ToList()
                .ForEach(m => this.CreateMap(m.Source, m.Destination));

            types
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IHaveCustomMapping).IsAssignableFrom(t))
                .Select(Activator.CreateInstance)
                .Cast<IHaveCustomMapping>()
                .ToList()
                .ForEach(m => m.ConfigureMapping(this));
        }
    }
}
