using Mapster;
using MapsterMapper;
using System.ComponentModel;

namespace SwfBox.MappingTests
{
    public class SimpleMappingExampleTests
    {
        [Fact]
        public void Map_SubMemberWithInterfaceType_Without_ConstructUsing_ThrowsMapsterCompileException()
        {
            IMapper mapper = new Mapper(TypeAdapterConfig.GlobalSettings);
            TestInfo testInfo = new TestInfo { Name = "Some name", Sub = new TestSubInfo { Description = "123" } };

            Assert.Throws<Mapster.CompileException>(() =>
            {
                _ = mapper.Map<TestDataModel>(testInfo);
            });
        }

        [Fact]
        public void Map_SubMemberWithInterfaceType_With_ConstructUsing_MappingIsSuccesful()
        {
            TypeAdapterConfig<TestSubInfo, ITestSubDataModel>.NewConfig()
                .ConstructUsing(() => new TestSubDataModel());

            IMapper mapper = new Mapper(TypeAdapterConfig.GlobalSettings);
            TestInfo testInfo = new TestInfo { Name = "Some name", Sub = new TestSubInfo { Description = "123" } };

            TestDataModel testDataModel = mapper.Map<TestDataModel>(testInfo);

            Assert.Equal(testInfo.Name, testDataModel.Name);
            Assert.NotNull(testDataModel.Sub);
            Assert.Equal(testInfo.Sub.Description, testDataModel.Sub.Description);
        }
    }

    public class TestInfo
    {
        public string Name { get; set; }
        public TestSubInfo Sub { get; set; }
    }

    public class TestSubInfo
    {
        public string Description { get; set; }
    }

    public class TestDataModel
    {
        public string Name { get; set; }
        public ITestSubDataModel Sub { get; set; }
    }

    public class TestSubDataModel : ITestSubDataModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Description { get; set; }
    }

    public interface ITestSubDataModel
    {
        event PropertyChangedEventHandler PropertyChanged;
        string Description { get; set; }
    }
}