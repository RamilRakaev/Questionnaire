using MediatR;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Commands.Requests.Questionnaires;

namespace Questionnaire.Infrastructure.Commands.Handlers.Questionnaires
{
    public class CreateQuestionnaireHandler : IRequestHandler<CreateQuestionnaireCommand>
    {
        private readonly IRepository<Structure> _questionnaireRepository;
        private readonly IRepository<Property> _questionRepository;

        public CreateQuestionnaireHandler(IRepository<Structure> questionnaireRepository, IRepository<Property> questionRepository)
        {
            _questionnaireRepository = questionnaireRepository;
            _questionRepository = questionRepository;
        }

        public async Task<Unit> Handle(CreateQuestionnaireCommand request, CancellationToken cancellationToken)
        {
            await _questionnaireRepository.AddAsync(request.Questionnaire, cancellationToken);
            
            var properties = request.Properties
                .Select(property =>
                {
                    property.StructureId = request.Questionnaire.Id;
                    return property;
                }); 

            await _questionRepository.AddRangeAsync(properties, cancellationToken);

            return Unit.Value;
        }
    }
}
