using Application.Common.Interfaces;
using Application.Employees.Create;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;
using Moq;
using Domain.Entities;

namespace Tests.Application.Employees.Create
{
    public class CreateEmployeeHandlerTests
    {
        private readonly Mock<IEmployeeRepository> _repositoryMock;
        private readonly Mock<ICurrentUser> _currentUserMock;
        private readonly CreateEmployeeHandler _handler;

        public CreateEmployeeHandlerTests()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
            _currentUserMock = new Mock<ICurrentUser>();

            _handler = new CreateEmployeeHandler(
                _repositoryMock.Object,
                _currentUserMock.Object
            );
        }

        [Fact]
        public async Task Should_create_employee_when_data_is_valid()
        {
            // Arrange
            _currentUserMock.Setup(x => x.Role).Returns(Role.Leader);

            var command = new CreateEmployeeCommand(
                FirstName: "Gabriel",
                LastName: "Teixeira",
                Email: "gabriel@email.com",
                Document: "123456789",
                BirthDate: DateTime.Today.AddYears(-25),
                Role: Role.Employee,
                ManagerId: Guid.NewGuid(),
                Phones: new List<Phone>
                {
                    new("11999999999"),
                    new("11888888888")
                },
                Password: "StrongPassword123!"
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);

            _repositoryMock.Verify(
                r => r.CreateAsync(It.IsAny<Employee>(), It.IsAny<CancellationToken>()),
                Times.Once
            );
        }

        [Fact]
        public async Task Should_fail_when_creating_employee_with_higher_role_than_current_user()
        {
            // Arrange
            _currentUserMock.Setup(x => x.Role).Returns(Role.Employee);

            var command = new CreateEmployeeCommand(
                FirstName: "Gabriel",
                LastName: "Teixeira",
                Email: "gabriel@email.com",
                Document: "123456789",
                BirthDate: DateTime.Today.AddYears(-30),
                Role: Role.Leader, // 👈 hierarquia inválida
                ManagerId: null,
                Phones: new List<Phone>
                {
                    new("11999999999"),
                    new("11888888888")
                },
                Password: "StrongPassword123!"
            );

            // Act + Assert
            await Assert.ThrowsAsync<DomainException>(async () =>
            {
                await _handler.Handle(command, CancellationToken.None);
            });

            _repositoryMock.Verify(
                r => r.CreateAsync(It.IsAny<Employee>(), It.IsAny<CancellationToken>()),
                Times.Never
            );
        }

        [Fact]
        public async Task Should_fail_when_employee_is_minor()
        {
            // Arrange
            _currentUserMock.Setup(x => x.Role).Returns(Role.Director);

            var command = new CreateEmployeeCommand(
                FirstName: "Junior",
                LastName: "User",
                Email: "junior@email.com",
                Document: "987654321",
                BirthDate: DateTime.Today.AddYears(-16), // 👈 menor de idade
                Role: Role.Employee,
                ManagerId: null,
                Phones: new List<Phone>
                {
                    new("11999999999"),
                    new("11888888888")
                },
                Password: "StrongPassword123!"
            );

            // Act + Assert
            await Assert.ThrowsAsync<DomainException>(async () =>
            {
                await _handler.Handle(command, CancellationToken.None);
            });
        }
    }
}
