using FluentValidation;
using System.Xml.Linq;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Validators
{
    public class MachineProgramValidator : AbstractValidator<MachineProgram>
    {
        private MachineProgramRepository _machineProgramRepository;

        private string _editMachineProgramId;

        public MachineProgramValidator()
        {
            SetValidateRules();
        }

        public MachineProgramValidator(string editMachineProgramId)
        {
            _editMachineProgramId = editMachineProgramId;

            SetValidateRules();
        }

        private bool IsUniqueCode(string code)
        {
            bool isUnique;

            if (string.IsNullOrEmpty(_editMachineProgramId))
                isUnique = !_machineProgramRepository.GetAll().Any(mp => mp.Code == code);
            else
                isUnique = !_machineProgramRepository.GetWhere(mp => mp.Id != Guid.Parse(_editMachineProgramId)).Any(mp => mp.Code == code);

            return isUnique;
        }

        private bool IsUniqueName(string name)
        {
            bool isUnique;

            if (string.IsNullOrEmpty(_editMachineProgramId))
                isUnique = !_machineProgramRepository.GetAll().Any(mp => mp.Name == name);
            else
                isUnique = !_machineProgramRepository.GetWhere(mp => mp.Id != Guid.Parse(_editMachineProgramId)).Any(mp => mp.Name == name);

            return isUnique;
        }

        private void SetValidateRules()
        {
            RuleFor(mp => mp.Code)
            .NotEmpty().WithMessage("Program Kodu boş olamaz.")
            .Length(3, 80).WithMessage("Program Kodu {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueCode).WithMessage("Bu Program Kodu zaten mevcut. Farklı bir Program Kodu giriniz.");

            RuleFor(mp => mp.Name)
            .NotEmpty().WithMessage("Program Adı boş olamaz.")
            .Length(3, 150).WithMessage("Program Adı {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueName).WithMessage("Bu Program Adı zaten mevcut. Farklı bir Program Adı giriniz.");

            _machineProgramRepository = InstanceFactory.GetInstance<MachineProgramRepository>();
        }


    }
}
