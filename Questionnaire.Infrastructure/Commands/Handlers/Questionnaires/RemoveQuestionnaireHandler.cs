using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Commands.Requests.Questionnaires;

namespace Questionnaire.Infrastructure.Commands.Handlers.Questionnaires
{
    public class RemoveQuestionnaireHandler : IRequestHandler<RemoveQuestionnaireCommand>
    {
        private readonly IRepository<Structure> _questionnaireRepository;
        private readonly IRepository<Property> _questionRepository;
        private readonly IRepository<Property> _answerRepository;

        public RemoveQuestionnaireHandler(IRepository<Structure> questionnaireRepository, IRepository<Property> questionRepository,
            IRepository<Property> answerRepository)
        {
            _questionnaireRepository = questionnaireRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        public async Task<Unit> Handle(RemoveQuestionnaireCommand request, CancellationToken cancellationToken)
        {
            await RemoveStructure(request.StructureId, cancellationToken);

            return Unit.Value;
        }

        private async Task RemoveStructure(int structureId, CancellationToken cancellationToken)
        {
            var structure = await _questionnaireRepository.GetAllAsNoTracking()
                .Where(structure => structure.Id == structureId)
                .Include(structure => structure.Answers)
                .Include(structure => structure.Properties)
                .FirstOrDefaultAsync(cancellationToken);

            if (structure == null)
            {
                throw new NullReferenceException("Questionnaire no found in DB");
            }

            var customProperties = _questionRepository.GetAllAsNoTracking().Where(property => property.CustomTypeId == structureId);

            foreach (var customProperty in customProperties)
            {
                await RemoveStructure(customProperty.StructureId, cancellationToken);
            }

            await _questionnaireRepository.RemoveAsync(structure, cancellationToken);
        }
    }
}
