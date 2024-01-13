
using FluentValidation;
using System;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        private CustomerRepository _customerRepository;
        private string _editCustomerId;

        public CustomerValidator() 
        {
            _editCustomerId = string.Empty;
            
            SetValidateRules(); // add mode
        }

        public CustomerValidator(string editCustomerId)
        {
            _editCustomerId = editCustomerId;

            SetValidateRules(); // edit mode
        }

        private bool IsUniqueName(string name)
        {
            // Veritabanında aynı isme sahip müşteri olup olmadığını kontrol ediyor.
            bool isUnique;

            if (string.IsNullOrEmpty(_editCustomerId))
                isUnique = !_customerRepository.GetAll().Any(c => c.Name == name);
            else
                isUnique = !_customerRepository.GetWhere(c => c.Id != Guid.Parse(_editCustomerId)).Any(c => c.Name == name);

            return isUnique;
        }

        private void SetValidateRules()
        {
            RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Müşteri Adı boş olamaz.")
            .Length(3, 100).WithMessage("Müşteri Adı {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueName).WithMessage("Bu Müşteri Adı zaten mevcut. Farklı bir Müşteri Adı giriniz.");

            RuleFor(c => c.Mail)
            .EmailAddress().When(customer => !string.IsNullOrEmpty(customer.Mail)).WithMessage("Geçerli bir e-posta adresi girin.");

            _customerRepository = InstanceFactory.GetInstance<CustomerRepository>();
        }
    }
}
