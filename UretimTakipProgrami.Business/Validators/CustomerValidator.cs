
using FluentValidation;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        private CustomerRepository _customerRepository;

        public CustomerValidator() 
        {

            RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Müşteri Adı boş olamaz.")
            .Length(3, 100).WithMessage("Müşteri Adı {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueName).WithMessage("Bu Müşteri Adı zaten mevcut. Farklı bir Müşteri Adı giriniz.");

            RuleFor(c => c.Mail)
            .EmailAddress().When(customer => !string.IsNullOrEmpty(customer.Mail)).WithMessage("Geçerli bir e-posta adresi girin.");

            _customerRepository = InstanceFactory.GetInstance<CustomerRepository>();
        }

        private bool IsUniqueName(string name)
        {
            // Veritabanında aynı isme sahip müşteri olup olmadığını kontrol ediyor.

            bool isUnique = !_customerRepository.GetAll().Any(c => c.Name == name);

            return isUnique;
        }
    }
}
