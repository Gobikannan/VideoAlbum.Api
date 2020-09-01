using FluentValidation;

namespace VideoAlbum.Application.Albums.Commands.AddNewAlbum
{
    public class AddNewAlbumCommandValidator : AbstractValidator<AddNewAlbumCommand>
    {

        public AddNewAlbumCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");

            RuleFor(v => v.Artist).NotEmpty().WithMessage("Artist is required...")
                .MaximumLength(200).WithMessage("Artist must not exceed 200 characters.");

            RuleFor(v => v.Label).NotEmpty().WithMessage("Label is required...")
                .MaximumLength(200).WithMessage("Label must not exceed 200 characters.");

            RuleFor(v => v.TypeId).NotNull().NotEmpty().WithMessage("Type is required.")
                .GreaterThan(0).WithMessage("Choose valid Type");

            RuleFor(v => v.Stock).NotNull().WithMessage("Stock is required...")
                .GreaterThanOrEqualTo(0).WithMessage("Stock can not be in the negative values");
        }
    }
}
