using Application.Features.User.Dtos;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommand:IRequest<UserDto>
{
    public Guid Id { get; set; }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserDto>
    {
        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper; 
        public async Task<UserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(src=>src.Id==request.Id);

            await _userRepository.DeleteAsync(user);
            var mappedUser = _mapper.Map<Domain.Entities.User,UserDto>(user);

            return mappedUser;
        }
    }
}