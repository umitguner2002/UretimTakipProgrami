using FluentValidation;
using System.Xml.Linq;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        private UserRepository _userRepository;
        private string _editUserId;
        private string _editUserPassword;

        public UserValidator()
        {
            _editUserId = string.Empty;
            _editUserPassword = string.Empty;

            SetValidateRules(false); // add mode
        }

        public UserValidator(string editUserId, string editUserPassword)
        {
            _editUserId = editUserId;
            _editUserPassword = editUserPassword;

            SetValidateRules(true); // edit mode
        }

        private bool IsUniqueName(string name)
        {
            bool isUnique;

            if (string.IsNullOrEmpty(_editUserId))
                isUnique = !_userRepository.GetAll().Any(u => u.Name == name);
            else
                isUnique = !_userRepository.GetWhere(u => u.Id != Guid.Parse(_editUserId)).Any(u => u.Name == name);            

            return isUnique;
        }

        private bool IsUniqueUsername(string username)
        {
            bool isUnique;

            if (string.IsNullOrEmpty(_editUserId))
                isUnique = !_userRepository.GetAll().Any(u => u.Username == username);
            else
                isUnique = !_userRepository.GetWhere(u => u.Id != Guid.Parse(_editUserId)).Any(u => u.Username == username);

            return isUnique;
        }

        private void SetValidateRules(bool editMode)
        {
            RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Kullanıcı Adı Soyadı boş olamaz.")
            .Length(3, 100).WithMessage("Kullanıcı Adı Soyadı {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueName).WithMessage("Bu Kullanıcı Adı Soyadı zaten mevcut. Farklı bir Kullanıcı Ad Soyad giriniz.");

            RuleFor(u => u.Username)
            .NotEmpty().WithMessage("Kullanıcı Adı boş olamaz.")
            .Length(3, 100).WithMessage("Kullanıcı Adı {MinLength} ile {MaxLength} karakter arasında olmalı.")
            .Must(IsUniqueUsername).WithMessage("Bu Kullanıcı Adı zaten mevcut. Farklı bir Kullanıcı Adı giriniz.");

            if (!editMode)
            {
                // Burası sadece ekleme modunda çalışıyor.
                RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Kullanıcı Şifresi boş olamaz.")
                .Length(3, 20).WithMessage("Kullanıcı Şifresi {MinLength} ile {MaxLength} karakter arasında olmalı.");
            }
            else
            {
                if (!string.IsNullOrEmpty(_editUserPassword))
                {
                    RuleFor(u => u.Password)
                    .NotEmpty().WithMessage("Kullanıcı Şifresi boş olamaz.")
                    .Length(3, 20).WithMessage("Kullanıcı Şifresi {MinLength} ile {MaxLength} karakter arasında olmalı.");
                }                
            }

            RuleFor(u => u.Email)
            .EmailAddress().When(user => !string.IsNullOrEmpty(user.Email)).WithMessage("Geçerli bir e-posta adresi girin.");

            _userRepository = InstanceFactory.GetInstance<UserRepository>();
        }
    }
}
