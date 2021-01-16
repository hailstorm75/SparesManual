using System.Threading;
using System.Threading.Tasks;
using Db.Interfaces;
using Models.Interfaces.Entities;
using MRI.MVVM.Helpers;
using ViewModels.Interfaces.Queries;

namespace ViewModels.Queries
{
  public class PartViewModel
    : BaseItemViewModel<IPart>, IPartViewModel
  {
    /// <inheritdoc />
    protected override async Task<IPart> GetItem(int id, CancellationToken cancellationToken = default)
      => await m_provider.GetPartAsync(id, cancellationToken).ConfigureAwait(false);

    /// <inheritdoc />
    public PartViewModel(IAPIProvider provider)
      : base(provider) { }
  }
}