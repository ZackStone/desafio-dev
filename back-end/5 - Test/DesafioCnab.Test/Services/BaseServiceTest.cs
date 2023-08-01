namespace DesafioCnab.Test.Services;

public class DumbTestEntity : BaseEntity { }

public class BaseServiceTest
{
    private readonly AutoMocker _mocker = new();
    private readonly Faker<DumbTestEntity> _faker = new("pt_BR");

    private readonly IService<DumbTestEntity> _service;

    private readonly Mock<IRepository<DumbTestEntity>> _repositoryMock;

    public BaseServiceTest()
    {
        _repositoryMock = _mocker.GetMock<IRepository<DumbTestEntity>>();

        _service = _mocker.CreateInstance<BaseService<DumbTestEntity>>();
    }

    [Fact]
    public async Task GetAllTest()
    {
        // Arrange

        var objs = _faker.GenerateBetween(1, 99);

        _repositoryMock
            .Setup(x => x.GetAll())
            .ReturnsAsync(objs);


        // Act

        var result = await _service.GetAll();


        // Assert

        result.Should().BeEquivalentTo(objs);
    }

    [Fact]
    public async Task GetTest()
    {
        // Arrange

        var obj = _faker.Generate();
        obj.Id = Guid.NewGuid();

        _repositoryMock
            .Setup(x => x.Get(obj.Id))
            .ReturnsAsync(obj);


        // Act

        var result = await _service.Get(obj.Id);


        // Assert

        result.Should().BeEquivalentTo(obj);
    }

    [Fact]
    public async Task InsertTest()
    {
        // Arrange

        var obj = _faker.Generate();

        _repositoryMock
            .Setup(x => x.Insert(obj))
            .ReturnsAsync(obj);


        // Act

        var result = await _service.Insert(obj);


        // Assert

        result.Should().BeEquivalentTo(obj);
    }

    [Fact]
    public async Task UpdateTest()
    {
        // Arrange

        var obj = _faker.Generate();

        _repositoryMock
            .Setup(x => x.Update(obj))
            .ReturnsAsync(obj);


        // Act

        var result = await _service.Update(obj);


        // Assert

        result.Should().BeEquivalentTo(obj);
    }

    [Fact]
    public async Task DeleteTest()
    {
        // Arrange

        var obj = _faker.Generate();
        obj.Id = Guid.NewGuid();

        _repositoryMock
            .Setup(x => x.Delete(obj.Id))
            .ReturnsAsync(obj);


        // Act

        var result = await _service.Delete(obj.Id);


        // Assert

        result.Should().BeEquivalentTo(obj);
    }

    [Fact]
    public async Task InsertRangeTest()
    {
        // Arrange

        var objs = _faker.GenerateBetween(1, 99);

        _repositoryMock
            .Setup(x => x.InsertRange(objs.ToArray()))
            .ReturnsAsync(objs.ToArray());


        // Act

        var result = await _service.InsertRange(objs);


        // Assert

        result.Should().BeEquivalentTo(objs);
    }
}