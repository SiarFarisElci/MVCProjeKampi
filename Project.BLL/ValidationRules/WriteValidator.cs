using FluentValidation;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ValidationRules
{
    public class WriteValidator : AbstractValidator<Write>
    {
        public WriteValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar Adını Bos gecemezsiniz");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Yazar SoyAdını Bos gecemezsiniz");
            RuleFor(x => x.WriteAbout).NotEmpty().WithMessage("Hakkında Bos gecemezsiniz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lutfen en az 2 karakter girizi yapınız");
            RuleFor(x => x.LastName).MaximumLength(20).WithMessage("Lutfen en fazla 20 karakter girizi yapınız");
        }
    }
}
