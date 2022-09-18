using Application.Features.User.Dtos;
using Application.Utilities.CrossCuttingConcerns.Exceptions;
using Application.Utilities.Security.Hashing;
using Application.Utilities.Security.JWT;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Features.User.Commands.LoginUser;

public class LoginUserCommand:IRequest<UserForLoginDto>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserForLoginDto>
    {
        public LoginUserCommandHandler(IMapper mapper, IUserRepository userRepository, ITokenHelper tokenHelper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        public async Task<UserForLoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(src => src.Email == request.Email);

            var verifyHash = HashingHelper.VerifyPasswordHash(request.Password,user.PasswordHash,user.PasswordSalt);
            if (!verifyHash)
            {
                throw new BusinessException("Hatalı giriş");
            }
            var mappedUser = _mapper.Map<Domain.Entities.User,UserForLoginDto>(user);

            return mappedUser;
        }
    }
}