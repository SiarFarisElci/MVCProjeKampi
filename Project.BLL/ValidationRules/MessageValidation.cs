using FluentValidation;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ValidationRules
{
    public class MessageValidation : AbstractValidator<Message>
    {
        public MessageValidation()
        {
            RuleFor(x => x.SenderMail).NotEmpty().WithMessage(" Bos gecemezsiniz");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage(" Bos gecemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bos gecemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Bos gecemezsiniz");
            RuleFor(x => x.SenderMail).MinimumLength(3).WithMessage("Lutfen en az 3 karakter girizi yapınız");
            RuleFor(x => x.ReceiverMail).MinimumLength(3).WithMessage("Lutfen en az 3 karakter girizi yapınız");
            RuleFor(x => x.SenderMail).MaximumLength(20).WithMessage("Lutfen en fazla 20 karakter girizi yapınız");
            RuleFor(x => x.ReceiverMail).MaximumLength(20).WithMessage("Lutfen en fazla 20 karakter girizi yapınız");
        }
    }
}
