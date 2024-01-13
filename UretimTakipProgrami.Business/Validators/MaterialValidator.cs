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
    public class MaterialValidator : AbstractValidator<Material>
    {
        private MaterialRepository _materialRepository;

        public MaterialValidator()
        {
            RuleFor(mt => mt.Name)
            .NotEmpty().WithMessage("Malzeme Adı alanı boş olamaz.")
            .Length(3, 100).WithMessage("Malzeme Adı {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueName).WithMessage("Bu Malzeme Adı zaten mevcut. Farklı bir Malzeme Adı giriniz.");

            _materialRepository = InstanceFactory.GetInstance<MaterialRepository>();
        }

        private bool IsUniqueName(string name)

        {
            bool isUnique = !_materialRepository.GetAll().Any(mt => mt.Name == name);

            return isUnique;
        }
    }
}
