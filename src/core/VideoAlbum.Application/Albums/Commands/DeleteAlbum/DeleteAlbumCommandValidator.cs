using FluentValidation;

namespace VideoAlbum.Application.Albums.Commands.DeleteAlbum
{
    public class DeleteAlbumCommandValidator : AbstractValidator<DeleteAlbumCommand>
    {
        public DeleteAlbumCommandValidator()
        {
            RuleFor(v => v.Id).NotNull().NotEmpty().WithMessage("Id is required...")
                .GreaterThan(0).WithMessage("Invalid Album.");
        }
    }
}
