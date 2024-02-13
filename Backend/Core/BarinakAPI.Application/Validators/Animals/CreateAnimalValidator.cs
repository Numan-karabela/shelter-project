using BarinakAPI.Application.ViewModel.Animals;
using FluentValidation;
 

namespace BarinakAPI.Application.Validators.Animals
{
    public class CreateAnimalValidator:AbstractValidator<VM_Create_Animals>
    {
        public CreateAnimalValidator()
        {
            RuleFor(p => p.Name).
                NotEmpty()
                .NotNull()
                .WithMessage("Boş geçilemez")
                .MaximumLength(15)
                .MinimumLength(2)
                .WithMessage("2-15 karakter arasında değer giriniz");

            RuleFor(p => p.Age).NotEmpty().NotNull().
                WithMessage("Yaş geçilemez")
                .Must(s => s >= 0).WithMessage("0-15 arasında değer giriniz")
                .Must(s => s <= 20).WithMessage("0-15 arasında değer giriniz");

            RuleFor(p => p.Gender).
               NotEmpty()
               .NotNull()
               .WithMessage("Boş geçilemez")
               .MaximumLength(15)
               .MinimumLength(0)
               .WithMessage("0-15 karakter arasında değer giriniz");

            RuleFor(p => p.Vaccination).
               NotEmpty()
               .NotNull()
               .WithMessage("Boş geçilemez")
               .MaximumLength(10)
               .MinimumLength(0)
               .WithMessage("2-15 karakter arasında değer giriniz");

            RuleFor(p => p.Type).
               NotEmpty()
               .NotNull()
               .WithMessage("Boş geçilemez")
               .MaximumLength(15)
               .MinimumLength(2)
               .WithMessage("2-15 karakter arasında değer giriniz");

           


        }

    }
}
