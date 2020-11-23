﻿using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Db.Interfaces;
using MRI.MVVM.Interfaces;

namespace MRI.MVVM.Helpers
{
  /// <summary>
  /// Base View model with paging support
  /// </summary>
  /// <typeparam name="T">Paged item type</typeparam>
  public abstract class BasePagedViewModel<T>
    : BasePropertyChanged, IViewModel
  {
    #region Fields

    private int m_pageIndex = 1;
    private int m_pageSize = 10;
    private int m_pageItems;
    private int m_totalItems;
    private bool m_loading;

    #endregion

    #region Properties

    /// <summary>
    /// Index of the current page
    /// </summary>
    public int PageIndex
    {
      get => m_pageIndex;
      set
      {
        m_pageIndex = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Number of maximum items to query
    /// </summary>
    public int PageSize
    {
      get => m_pageSize;
      set
      {
        m_pageSize = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Number of currently displayed items
    /// </summary>
    public int PageItems
    {
      get => m_pageItems;
      set
      {
        m_pageItems = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Total items available for paging
    /// </summary>
    public int TotalItems
    {
      get => m_totalItems;
      set
      {
        m_totalItems = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Is paging loading
    /// </summary>
    public bool Loading
    {
      get => m_loading;
      set
      {
        m_loading = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Paged items to display
    /// </summary>
    public ObservableCollection<T> Items { get; } = new ObservableCollection<T>();

    #endregion

    /// <summary>
    /// Queries the items
    /// </summary>
    /// <param name="pageSize">Maximum number of items to return</param>
    /// <param name="pageIndex">Index of batch</param>
    /// <param name="cancellationToken">Process cancellation</param>
    /// <returns>Queried items</returns>
    protected abstract Task<IPaging<T>> GetItems(int pageSize, int pageIndex, CancellationToken cancellationToken = default);

    /// <summary>
    /// Loads items
    /// </summary>
    public async Task LoadItems()
    {
      Items.Clear();

      Loading = true;

      var result = await GetItems(PageSize, PageIndex).ConfigureAwait(true);

      PageItems = result.PageItems;
      PageIndex = result.PageIndex;
      TotalItems = result.TotalItems;

      await foreach (var item in result.ReadAll().ConfigureAwait(true))
        Items.Add(item);

      Loading = false;
    }
  }
}