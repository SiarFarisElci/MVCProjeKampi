using FluentValidation;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ValidationRules
{
    public
        class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresi Bos gecemezsiniz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Message Bos gecemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Message Bos gecemezsiniz");
            RuleFor(x => x.UserMail).MinimumLength(3).WithMessage("Lutfen en az 3 karakter girizi yapınız");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lutfen en az 3 karakter girizi yapınız");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lutfen en fazla 50 karakter girizi yapınız");

        }
    }
}
