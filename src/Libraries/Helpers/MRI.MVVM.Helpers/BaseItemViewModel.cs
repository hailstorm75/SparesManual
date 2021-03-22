using System.Threading;
using System.Threading.Tasks;
using MRI.MVVM.Interfaces.ViewModels;

namespace MRI.MVVM.Helpers
{
  /// <summary>
  /// Base view model for displaying an item
  /// </summary>
  /// <typeparam name="T">Item type</typeparam>
  public abstract class BaseItemViewModel<T>
    : BasePropertyChanged, IItemViewModel<T>
  {
    #region Fields

    private bool m_loading;

    #endregion

    #region Properties

    /// <inheritdoc />
    public bool Loading
    {
      get => m_loading;
      private set
      {
        m_loading = value;
        OnPropertyChanged();
      }
    }

    /// <inheritdoc />
    public int Id { get; set; }

    /// <inheritdoc />
    public T? Item { get; protected set; }

    #endregion

    /// <summary>
    /// Queries the item
    /// </summary>
    /// <param name="id">Item id</param>
    /// <param name="cancellationToken">Process cancellation</param>
    /// <returns>Queried item</returns>
    protected abstract Task<T> GetItem(int id, CancellationToken cancellationToken = default);

    /// <inheritdoc />
    public async Task LoadItem()
    {
      // Enter loading state
      Loading = true;

      // Retrieve the item by its id
      Item = await GetItem(Id).ConfigureAwait(true);

      // Exit loading state
      Loading = false;

      // Notify the view of data update
      OnPropertyChanged(nameof(Item));
    }
  }
}