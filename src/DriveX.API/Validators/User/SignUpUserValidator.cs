using DriveX.API.Dto;
using FastEndpoints;
using FluentValidation;

namespace DriveX.API.Validators.User;

public class SignUpUserValidator : Validator<SignUpUserDto>
{
    public SignUpUserValidator()
    {
        RuleFor(dto => dto.FIO)
            .NotNull()
            .NotEmpty()
            .Matches("^[А-ЯЁA-Z][а-яёa-z-]{1,49}(?:\\s[А-ЯЁA-Z][а-яёa-z-]{1,49}){2}$")
            .WithMessage("Укажите вашу фамилию имя и отчество в корректном формате");

        RuleFor(dto => dto.Email)
            .NotNull()
            .NotEmpty()
            .Matches("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")
            .WithMessage("Некорректный email");

        RuleFor(dto => dto.Password)
            .NotNull()
            .NotEmpty()
            .Matches("^(?=.*\\d)(?=.*[a-zA-Z])[a-zA-Z0-9]{6,}$")
            .WithMessage("Пароль должен состоять из букв и цифр");

        RuleFor(dto => dto.ConfirmedPassword)
            .Must((dto, confirmedPassword) => dto.Password == confirmedPassword)
            .WithMessage("Введенные пароли должны совпадать");

        RuleFor(dto => dto.UserName)
            .NotNull()
            .NotEmpty()
            .Matches("^[a-zA-Z0-9._-]{3,}$")
            .WithMessage("Введен некорректный логин");

        RuleFor(dto => dto.PhoneNumber)
            .Matches("^\\+375\\s\\(\\d{2}\\)\\s\\d{3}-\\d{2}-\\d{2}$")
            .WithMessage("Номер телефона не соответствует допустимому формату")
            .When(phoneNumber => phoneNumber != null);
    }
}
