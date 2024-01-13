using FluentValidation;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Validators
{
    public class MaterialShapeValidator : AbstractValidator<MaterialShape>
    {
        private MaterialShapeRepository _materialShapeRepository;

        public MaterialShapeValidator()
        {
            RuleFor(ms => ms.Name)
            .NotEmpty().WithMessage("Materyal Şekli alanı boş olamaz.")
            .Length(3, 100).WithMessage("Materyal Şekli {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueName).WithMessage("Bu Materyal Şekli zaten mevcut. Farklı bir Materyal Şekli giriniz.");

            _materialShapeRepository = InstanceFactory.GetInstance<MaterialShapeRepository>();
        }

        private bool IsUniqueName(string name)
        {
            bool isUnique = !_materialShapeRepository.GetAll().Any(ms => ms.Name == name);

            return isUnique;
        }
    }
}
