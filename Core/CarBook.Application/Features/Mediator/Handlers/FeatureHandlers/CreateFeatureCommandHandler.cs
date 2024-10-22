using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
{
    private readonly IRepository<Feature> _repository;

    // Dependency Injection ile IRepository'yi alıyoruz
    public CreateFeatureCommandHandler(IRepository<Feature> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Feature
        {
            Name = request.Name
        });
    }
}
