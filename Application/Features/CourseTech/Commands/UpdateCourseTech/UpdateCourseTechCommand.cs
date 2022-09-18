using Application.Features.CourseTech.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.CourseTech.Commands.UpdateCourseTech;

public class UpdateCourseTechCommand:IRequest<UpdateCourseTechDto>
{
    public Guid id { get; set; }
    public string Name { get; set; }
    public Guid CourseId { get; set; }
    
    public class UpdateCourseTechCommandHandler:IRequestHandler<UpdateCourseTechCommand,UpdateCourseTechDto>
    {
        public UpdateCourseTechCommandHandler(ICourseTechRepository courseTechRepository, IMapper mapper)
        {
            _courseTechRepository = courseTechRepository;
            _mapper = mapper;
        }

        private readonly ICourseTechRepository _courseTechRepository;
        private readonly IMapper _mapper;
        public async Task<UpdateCourseTechDto> Handle(UpdateCourseTechCommand request, CancellationToken cancellationToken)
        {
            var courseTech = await _courseTechRepository.GetAsync(src=>src.Id==request.id);

            var mapObject = _mapper.Map(request,courseTech);

            await _courseTechRepository.UpdateAsync(mapObject);

            var mappedCourseTech = _mapper.Map<CourseTechs,UpdateCourseTechDto>(courseTech);
            return mappedCourseTech;
        }
    }
}