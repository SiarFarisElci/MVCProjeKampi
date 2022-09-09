using FluentValidation;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x=> x.CategoryName).NotEmpty().WithMessage("Kategori Adını Bos gecemezsiniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Aciklamayı Bos gecemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lutfen en az 3 karakter girizi yapınız");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lutfen en fazla 20 karakter girizi yapınız");

        }
    }
}
