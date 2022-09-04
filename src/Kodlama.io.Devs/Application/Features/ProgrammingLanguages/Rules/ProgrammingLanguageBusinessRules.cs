using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository ProgrammingLanguageRepository)
        {
            _programmingLanguageRepository = ProgrammingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("ProgrammingLanguage name exists.");
            //bunu yaptım ama olmadı...
            //IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository
            //if (result.Items==null) throw new BusinessException("ProgrammingLanguage name is empty.");
        }
    }
}
