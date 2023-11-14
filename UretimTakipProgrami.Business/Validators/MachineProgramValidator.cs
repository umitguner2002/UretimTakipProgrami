using FluentValidation;
using UretimTakipProgrami.DataAccess.Repositories.Concretes;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Validators
{
    public class MachineProgramValidator : AbstractValidator<MachineProgram>
    {
        private MachineProgramRepository _machineProgramRepository = new MachineProgramRepository(new DataAccess.ProductionDbContext());

        public MachineProgramValidator()
        {
            RuleFor(mp => mp.Code)
            .NotEmpty().WithMessage("Program Kodu boş olamaz.")
            .Length(3, 80).WithMessage("Program Kodu {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueCode).WithMessage("Bu Program Kodu zaten mevcut. Farklı bir Program Kodu giriniz.");

            RuleFor(mp => mp.Name)
            .NotEmpty().WithMessage("Program Adı boş olamaz.")
            .Length(3, 150).WithMessage("Program Adı {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueName).WithMessage("Bu Program Adı zaten mevcut. Farklı bir Program Adı giriniz.");
        }

        private bool IsUniqueCode(string code)
        {
            // Veritabanında aynı isme sahip müşteri olup olmadığını kontrol ediyor.

            bool isUnique = !_machineProgramRepository.GetAll().Any(mp => mp.Code == code);

            return isUnique;
        }

        private bool IsUniqueName(string name)
        {
            // Veritabanında aynı isme sahip müşteri olup olmadığını kontrol ediyor.

            bool isUnique = !_machineProgramRepository.GetAll().Any(mp => mp.Name == name);

            return isUnique;
        }
        
    }
}
