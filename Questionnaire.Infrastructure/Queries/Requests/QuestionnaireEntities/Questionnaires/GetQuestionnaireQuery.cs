﻿using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Queries.Requests.QuestionnaireEntities.Questionnaires
{
    public class GetQuestionnaireQuery : IRequest<QuestionnaireEntity>
    {
    }
}
