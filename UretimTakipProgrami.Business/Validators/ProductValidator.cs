using FluentValidation;
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

            _productRepository = InstanceFactory.GetInstance<ProductRepository>();
        }

        private bool IsUniqueName(string name)
        {
            // Veritabanında aynı isme sahip müşteri olup olmadığını kontrol ediyor.

            bool isUnique = !_productRepository.GetAll().Any(p => p.Name == name);

            return isUnique;
        }
    }
}
