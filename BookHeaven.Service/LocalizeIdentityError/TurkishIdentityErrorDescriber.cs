using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookHeaven.Service.LocalizeIdentityError
{



    public class TurkishIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError()
        {
            return new IdentityError { Code = nameof(DefaultError), Description = "Bilinmeyen bir hata meydana geldi." };
        }

        public override IdentityError ConcurrencyFailure()
        {
            return new IdentityError { Code = nameof(ConcurrencyFailure), Description = "Bir eşzamanlılık hatası meydana geldi, lütfen tekrar deneyin." };
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError { Code = nameof(PasswordMismatch), Description = "Şifreler eşleşmiyor." };
        }

        public override IdentityError InvalidToken()
        {
            return new IdentityError { Code = nameof(InvalidToken), Description = "Üretilen eşleştirme kodu geçerli değil." };
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = "Bu bilgilere sahip bir kullanıcı sistemde zaten var." };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError { Code = nameof(InvalidUserName), Description = $"'{userName}' geçersiz bir kullanıcı adı; sadece harf ve rakam kullanılabilir." };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError { Code = nameof(InvalidEmail), Description = $"'{email}' geçersiz bir e-posta adresi." };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError { Code = nameof(DuplicateUserName), Description = $"'{userName}' bu e-posta adresi zaten kullanımda." };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError { Code = nameof(DuplicateEmail), Description = $"'{email}' bu e-posta adresi zaten kullanımda." };
        }

        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError { Code = nameof(InvalidRoleName), Description = $"'{role}' geçersiz bir rol adı." };
        }

        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError { Code = nameof(DuplicateRoleName), Description = $"'{role}' bu rol adı zaten kullanımda." };
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = "Bu kullanıcı için zaten bir şifre atanmış durumda." };
        }

        public override IdentityError UserLockoutNotEnabled()
        {
            return new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = "Bu kullanıcı için giriş engelleme özelliği aktif değil." };
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError { Code = nameof(UserAlreadyInRole), Description = $"Kullanıcı zaten '{role}' rolüne sahip." };
        }

        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError { Code = nameof(UserNotInRole), Description = $"Kullanıcı '{role}' rolüne sahip değil." };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError { Code = nameof(PasswordTooShort), Description = $"Parola en az {length} karakter uzunluğunda olmalıdır." };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "Parola en az bir özel karakter içermelidir (örn. *, !, _, - vb.)." };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = "Parola en az bir rakam içermelidir." };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError { Code = nameof(PasswordRequiresLower), Description = "Parola en az bir küçük harf içermelidir." };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "Parola en az bir büyük harf içermelidir." };
        }
    }

}
