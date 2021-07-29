using AutoMapper;

namespace MoviesApi.Infra.CrossCutting.Test.Config
{
    public abstract class BaseTestService
    {
        public IMapper mapper { get; set; }

        public BaseTestService()
        {
            mapper = new AutoMapperFixture().GetMapper();
        }
    }
}
