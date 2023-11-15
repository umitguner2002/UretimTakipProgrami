using FluentValidation;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        private UserRepository _userRepository;

        public UserValidator()
        {

            RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Kullanıcı Adı Soyadı boş olamaz.")
            .Length(3, 100).WithMessage("Kullanıcı Adı Soyadı {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueName).WithMessage("Bu Kullanıcı Adı Soyadı zaten mevcut. Farklı bir Kullanıcı Ad Soyad giriniz.");

            RuleFor(u => u.Username)
            .NotEmpty().WithMessage("Kullanıcı Adı boş olamaz.")
            .Length(3, 100).WithMessage("Kullanıcı Adı {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueUsername).WithMessage("Bu Kullanıcı Adı zaten mevcut. Farklı bir Kullanıcı Adı giriniz.");

            RuleFor(u => u.Email)
            .EmailAddress().When(user => !string.IsNullOrEmpty(user.Email)).WithMessage("Geçerli bir e-posta adresi girin.");

            _userRepository = InstanceFactory.GetInstance<UserRepository>();

        }

        private bool IsUniqueName(string name)
        {
            bool isUnique = !_userRepository.GetAll().Any(u => u.Name == name);

            return isUnique;
        }

        private bool IsUniqueUsername(string username)
        {
            bool isUnique = !_userRepository.GetAll().Any(u => u.Username == username);

            return isUnique;
        }
    }
}
