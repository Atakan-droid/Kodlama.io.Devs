using Application.Features.User.Dtos;
using Application.Utilities.Security.Hashing;
using Application.Utilities.Security.JWT;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.User.Commands.CreateUser;

public class CreateUserCommand:IRequest<UserForRegisterDto>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserForRegisterDto>
    {
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
        }

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        
        public async Task<UserForRegisterDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var mappedUser = _mapper.Map<CreateUserCommand,Domain.Entities.User>(request);
            byte[] passwordHash, passwordSalt;
            
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            mappedUser.PasswordHash = passwordHash;
            mappedUser.PasswordSalt = passwordSalt;
            
            await _userRepository.AddAsync(mappedUser);

            var token = _tokenHelper.CreateToken(mappedUser, new List<OperationClaim>());
            
            return new UserForRegisterDto();
        }
    }
}