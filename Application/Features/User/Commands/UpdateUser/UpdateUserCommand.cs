using Application.Features.User.Dtos;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Features.User.Commands.UpdateUser;

public class UpdateUserCommand:IRequest<UpdateUserDto>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string GithubLink { get; set; }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserDto>
    {
        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        
        public async Task<UpdateUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(src => src.Id == request.Id);

            _mapper.Map(request, user);

            await _userRepository.UpdateAsync(user);
            
            
            var mappedUser = _mapper.Map<Domain.Entities.User,UpdateUserDto>(user);
            return mappedUser;
        }
    }
}