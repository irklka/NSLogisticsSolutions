using Ardalis.Specification;

using MediatR;

using NSLogistics.Application.Common.Security.Password;
using NSLogistics.Application.Common.Services.User.Interfaces;
using NSLogistics.Application.User.Commands.Register;
using NSLogistics.Core.User;
using NSLogistics.Core.User.Specifications;

using static NSLogistics.Core.User.Enums.Roles;

namespace NSLogistics1.Application.User.Commands.Register;

public class RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand, RegisterUserCommandResponse>
{
    private readonly IRepositoryBase<UserEntity> _userRepository;
    private readonly ICurrentUserService _currentUserService;

    public RegisterUserCommandHandler(IRepositoryBase<UserEntity> userRepository,
        ICurrentUserService currentUserService)
    {
        _userRepository = userRepository;
        _currentUserService = currentUserService;
    }

    public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        if (!_currentUserService.IsAdmin())
            throw new UnauthorizedAccessException("Only admins can register new users");

        var userExists = await _userRepository.AnyAsync(
            new GetUserByEmailSpec(request.Email),
            cancellationToken);

        if (userExists)
            throw new UserAlreadyExistsException($"user already exist with email:{request.Email}");

        var (passwordHash, passwordSalt) = PasswordManager.CreatePasswordHash(request.Password);

        var userEntity = new UserEntity
        {
            Firstname = request.Firstname,
            Lastname = request.Lastname,
            IdNumber = request.IdNumber,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            Role = UserRole.Customer,
            Password = passwordHash,
            Salt = passwordSalt
        };

        var user = await _userRepository.AddAsync(userEntity, cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);

        return new RegisterUserCommandResponse(new(user.Id, $"{user.Firstname} {user.Lastname}"));
    }
}
