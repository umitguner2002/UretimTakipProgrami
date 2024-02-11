using FluentValidation;
using Ninject.Activation;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        private ProductRepository _productRepository;
        private string _editProductId;

        public ProductValidator() 
        {
            _editProductId = string.Empty;

            SetValidateRules(); // add mode
        }

        public ProductValidator(string editProductId)
        {
            _editProductId = editProductId;

            SetValidateRules(); // edit mode
        }

        private bool IsUniqueName(string name)
        {
            // Veritabanında aynı isme sahip ürün olup olmadığını kontrol ediyor.
            bool isUnique;

            if (string.IsNullOrEmpty(_editProductId))
                isUnique = !_productRepository.GetAll().Any(c => c.Name == name);
            else
                isUnique = !_productRepository.GetWhere(c => c.Id != Guid.Parse(_editProductId)).Any(c => c.Name == name);

            return isUnique;
        }

        private void SetValidateRules()
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Ürün Adı boş olamaz.")
            .Length(3, 100).WithMessage("Ürün Adı {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueName).WithMessage("Bu Ürün Adı zaten mevcut. Farklı bir Ürün Adı giriniz.");

            _productRepository = InstanceFactory.GetInstance<ProductRepository>();
        }
    }
}
