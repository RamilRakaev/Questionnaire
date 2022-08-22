using MediatR;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Commands.Requests.Questionnaires;

namespace Questionnaire.Infrastructure.Commands.Handlers.Questionnaires
{
    public class CreateQuestionnaireHandler : IRequestHandler<CreateQuestionnaireCommand>
    {
        private readonly IRepository<QuestionnaireEntity> _questionnaireRepository;
        private readonly IRepository<PropertyEntity> _questionRepository;

        public CreateQuestionnaireHandler(IRepository<QuestionnaireEntity> questionnaireRepository, IRepository<PropertyEntity> questionRepository)
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
                    property.QuestionnaireId = request.Questionnaire.Id;
                    return property;
                }); 

            await _questionRepository.AddRangeAsync(properties, cancellationToken);

            return Unit.Value;
        }
    }
}
