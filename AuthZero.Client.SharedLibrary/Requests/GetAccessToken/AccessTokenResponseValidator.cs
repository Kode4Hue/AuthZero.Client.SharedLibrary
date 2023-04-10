using FluentValidation;

namespace AuthZero.Client.SharedLibrary.Requests.GetAccessToken
{
    public class AccessTokenResponseValidator: AbstractValidator<AccessTokenResponse>
    {
        public AccessTokenResponseValidator()
        {
            RuleFor(x => x.AccessToken)
                .NotEmpty();
            RuleFor(x => x.ExpiresIn)
                .GreaterThan(0);
        }
    }
}
