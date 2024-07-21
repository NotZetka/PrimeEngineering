using Moq;
using AutoMapper;
using PrimeEngineeringApi.Data;
using PrimeEngineeringApi.Data.Dtos;
using PrimeEngineeringApi.Data.Repositories.EmployeesRepository;
using PrimeEngineeringApi.Data.Repositories;
using MockQueryable.Moq;

namespace PrimeEngineeringTests.UnitTests
{
    public class EmployeeRepositoryTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
        private readonly IMapper _mapper;
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeRepositoryTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();

            _employeeRepository = new EmployeeRepository(_unitOfWorkMock.Object, _mapper);
        }

        [Fact]
        public async Task GetTasks_ShouldReturnTasks_ForGivenUserId()
        {
            var userId = 1;
            var tasks = new List<EmployeeTask>
            {
                new EmployeeTask { Id = 1, Header = "Task 1", Employees = new List<Employee> { new Employee { Id = userId } } },
                new EmployeeTask { Id = 2, Header = "Task 2", Employees = new List<Employee> { new Employee { Id = userId } } }
            }.AsQueryable();

            var tasksDbSetMock = tasks.BuildMockDbSet();
            _unitOfWorkMock.Setup(x => x.Tasks).Returns(tasksDbSetMock.Object);

            var result = await _employeeRepository.GetTasks(userId);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetTask_ShouldReturnTask_ForGivenTaskId()
        {
            var taskId = 1;
            var task = new EmployeeTask { Id = taskId, Header = "Task 1", Employees = new List<Employee> { new Employee { Id = 1 } } };

            var tasks = new List<EmployeeTask> { task }.AsQueryable();

            var tasksDbSetMock = tasks.BuildMockDbSet();
            _unitOfWorkMock.Setup(x => x.Tasks).Returns(tasksDbSetMock.Object);

            var result = await _employeeRepository.GetTask(taskId);

            Assert.NotNull(result);
            Assert.Equal(taskId, result.Id);
        }

        private class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<EmployeeTask, EmployeeTaskDto>()
                    .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.ToString()));
                CreateMap<Employee, EmployeeDto>();
            }
        }
    }
}
