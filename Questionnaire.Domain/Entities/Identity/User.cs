﻿using Microsoft.AspNetCore.Identity;

namespace Questionnaire.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public List<AnswerEntity> Answers { get; set; }
    }
}
