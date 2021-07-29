using AutoMapper;
using MoviesApi.Infra.CrossCutting.Mappings;
using System;

namespace MoviesApi.Infra.CrossCutting.Test.Config
{
    class AutoMapperFixture : IDisposable
    {
        public IMapper Mapper { get; set; }

        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
            });

            return config.CreateMapper();
        }

        public void Dispose()
        {
        }
    }
}
