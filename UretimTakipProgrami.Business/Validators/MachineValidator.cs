using FluentValidation;
using UretimTakipProgrami.DataAccess.Repositories.Concretes;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Validators
{
    public class MachineValidator : AbstractValidator<Machine>
    {
        private MachineRepository _machineRepository = new MachineRepository(new DataAccess.ProductionDbContext());

        public MachineValidator()
        {
            RuleFor(m => m.Name)
            .NotEmpty().WithMessage("Tezgah/Makina Adı boş olamaz.")
            .Length(3, 100).WithMessage("Tezgah/Makina Adı {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueName).WithMessage("Bu Tezgah/Makina Adı zaten mevcut. Farklı bir Tezgah/Makina Adı giriniz.");
        }

        private bool IsUniqueName(string name)
        {
            // Veritabanında aynı isme sahip müşteri olup olmadığını kontrol ediyor.

            bool isUnique = !_machineRepository.GetAll().Any(m => m.Name == name);

            return isUnique;
        }
    }
}
