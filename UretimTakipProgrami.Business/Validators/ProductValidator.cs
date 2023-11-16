using FluentValidation;
using Ninject.Activation;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        private ProductRepository _productRepository;

        public ProductValidator() 
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Ürün Adı boş olamaz.")
            .Length(3, 100).WithMessage("Ürün Adı {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueName).WithMessage("Bu Ürün Adı zaten mevcut. Farklı bir Ürün Adı giriniz.");

            RuleFor(p => p.MachineProgramId)
            .Must(machineProgramId => IsUniqueMachineProgramId(machineProgramId))
            .WithMessage("Bu Program daha önce farklı bir ürün için kaydedilmiş.");

            _productRepository = InstanceFactory.GetInstance<ProductRepository>();
        }

        private bool IsUniqueName(string name)
        {
            // Veritabanında aynı isme sahip müşteri olup olmadığını kontrol ediyor.

            bool isUnique = !_productRepository.GetAll().Any(p => p.Name == name);

            return isUnique;
        }

        private bool IsUniqueMachineProgramId(Guid machineProgramId)
        {
            bool existingRecord = _productRepository.GetAll().Any(p => p.MachineProgramId == machineProgramId);
            return !existingRecord;
        }
    }
}
