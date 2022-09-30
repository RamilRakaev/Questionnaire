using MediatR;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Commands.Requests.QuestionnaireLinks;

namespace Questionnaire.Infrastructure.Commands.Handlers.QuestionnaireLinks
{
    public class CreateQuestionnaireLinkHandler : IRequestHandler<CreateQuestionnaireLinkCommand, string>
    {
        private readonly IRepository<QuestionnaireLink> _questionnaireLinksRepository;

        public CreateQuestionnaireLinkHandler(IRepository<QuestionnaireLink> questionnaireLinksRepository)
        {
            _questionnaireLinksRepository = questionnaireLinksRepository;
        }

        public async Task<string> Handle(CreateQuestionnaireLinkCommand request, CancellationToken cancellationToken)
        {
            var token = Guid.NewGuid().ToString();

            QuestionnaireLink link = new()
            {
                DateOfCreation = DateTime.UtcNow,
                BaseAddress = $"{request.Request.Scheme}://{request.Request.Host}",
                PageAddress = request.PageAddress,
                QuestionnaireId = request.QuestionnaireId,
                Token = token,
            };
            await _questionnaireLinksRepository.AddAsync(link, cancellationToken);

            return $"{link.BaseAddress}/{link.PageAddress}/{link.QuestionnaireId}/{link.Token}".Replace("//", "/");
        }
    }
}
