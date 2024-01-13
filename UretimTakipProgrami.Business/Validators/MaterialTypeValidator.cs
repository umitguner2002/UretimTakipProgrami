using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Validators
{
    public class MaterialTypeValidator : AbstractValidator<MaterialType>
    {
        private MaterialTypeRepository _materialTypeRepository;

        public MaterialTypeValidator()
        {
            RuleFor(mt => mt.Name)
            .NotEmpty().WithMessage("Materyal Türü alanı boş olamaz.")
            .Length(3, 100).WithMessage("Materyal Türü {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueName).WithMessage("Bu Materyal Türü zaten mevcut. Farklı bir Materyal Türü giriniz.");

            _materialTypeRepository = InstanceFactory.GetInstance<MaterialTypeRepository>();
        }

        private bool IsUniqueName(string name)

        {
            bool isUnique = !_materialTypeRepository.GetAll().Any(mt => mt.Name == name);

            return isUnique;
        }
    }
}
