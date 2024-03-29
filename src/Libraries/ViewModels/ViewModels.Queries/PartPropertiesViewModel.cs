using System.Threading;
using System.Threading.Tasks;
using Db.Interfaces;
using Microsoft.Extensions.Logging;
using Models.Interfaces.Entities;
using MRI.MVVM.Helpers;
using ViewModels.Interfaces.Queries;

namespace ViewModels.Queries
{
  /// <summary>
  /// View model for paging all part properties
  /// </summary>
  public class PartPropertiesViewModel
    : BasePagedViewModel<IProperty>, IPartPropertiesViewModel
  {
    /// <inheritdoc />
    public string PartId { get; set; } = string.Empty;

    /// <inheritdoc />
    public PartPropertiesViewModel(IAPIProvider provider, ILogger<PartPropertiesViewModel> logger)
      : base(provider, logger)
    {
    }

    /// <inheritdoc />
    protected override ValueTask<IPaging<IProperty>> GetItemsAsync(int pageSize, int pageIndex, string? search, CancellationToken cancellationToken = default)
      => m_provider.GetPartPropertiesAsync(IdToInt(PartId), pageSize, pageIndex, search, cancellationToken);
  }
}