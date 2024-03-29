using System.Threading.Tasks;
using System.Web;
using Email.Templates;
using FluentEmail.Core;
using Grpc.Core;

namespace Email.API.Services
{
  /// <summary>
  /// Mailing API service
  /// </summary>
  // ReSharper disable once ClassNeverInstantiated.Global
  public class MailerService
    : Mailer.MailerBase
  {
    private readonly IFluentEmail m_emailSender;

    /// <summary>
    /// Default constructor
    /// </summary>
    public MailerService(IFluentEmail emailSender)
    {
      m_emailSender = emailSender;
    }

    /// <inheritdoc />
    public override async Task<Boolean> SendPasswordRecovery(IdAndCode request, ServerCallContext context)
    {
      var response = await m_emailSender
        .To(request.Email)
        .Subject("Spares Manual - Password Recovery")
        .UsingTemplateFromEmbedded("Email.Templates.PasswordRecovery.cshtml", new PasswordRecoveryModel { Url = $"https://localhost:5468/reset?usr={request.UserId}&token={HttpUtility.UrlEncode(request.Code)}" }, typeof(PasswordRecoveryModel).Assembly)
        .SendAsync(context.CancellationToken)
        .ConfigureAwait(false);

      return new Boolean
      {
        Success = response.Successful
      };
    }

    /// <inheritdoc />
    public override async Task<Boolean> SendRegistrationConfirmation(IdAndCode request, ServerCallContext context)
    {
      var response = await m_emailSender
        .To(request.Email)
        .Subject("Action required: Please confirm your email")
        .UsingTemplateFromEmbedded("Email.Templates.RegistrationConfirmation.cshtml", new RegistrationConfirmationModel { Url = $"https://localhost:5468/verify?usr={request.UserId}&token={HttpUtility.UrlEncode(request.Code)}" }, typeof(RegistrationConfirmationModel).Assembly)
        .SendAsync(context.CancellationToken)
        .ConfigureAwait(false);

      return new Boolean
      {
        Success = response.Successful
      };
    }
  }
}