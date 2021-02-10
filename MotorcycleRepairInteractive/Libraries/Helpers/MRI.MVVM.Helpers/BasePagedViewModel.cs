﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Db.Interfaces;
using MRI.MVVM.Interfaces.ViewModels;

namespace MRI.MVVM.Helpers
{
  /// <summary>
  /// Base View model with paging support
  /// </summary>
  /// <typeparam name="T">Paged item type</typeparam>
  public abstract class BasePagedViewModel<T>
    : BasePropertyChanged, IPagedViewModel<T>
  {
    #region Fields

    /// <summary>
    /// API provider instance
    /// </summary>
    protected readonly IAPIProvider m_provider;
    private int m_pageIndex = 1;
    private int m_pageSize = 10;
    private int m_pageItems;
    private int m_totalItems;
    private bool m_loading;
    private string m_search = string.Empty;
    private static readonly List<T> EMPTY = new();

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
    /// Filter search expression
    /// </summary>
    public string Search
    {
      get => m_search;
      set
      {
        m_search = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Paged items to display
    /// </summary>
    public IReadOnlyCollection<T> Items { get; private set; } = EMPTY;

    #endregion

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="provider">Injected API provider</param>
    protected BasePagedViewModel(IAPIProvider provider)
      => m_provider = provider;

    /// <summary>
    /// Queries the items
    /// </summary>
    /// <param name="pageSize">Maximum number of items to return</param>
    /// <param name="pageIndex">Index of batch</param>
    /// <param name="search">Optional search filter</param>
    /// <param name="cancellationToken">Process cancellation</param>
    /// <returns>Queried items</returns>
    protected abstract Task<IPaging<T>> GetItemsAsync(int pageSize, int pageIndex, string? search, CancellationToken cancellationToken = default);

    /// <summary>
    /// Loads items
    /// </summary>
    public async Task LoadItemsAsync()
    {
      // Remove old items
      //ClearItems();

      // Enter loading state
      Loading = true;

      // Get the items
      var items = await GetItemsAsync(PageSize, PageIndex, Search).ConfigureAwait(true);

      if (items is not null)
      {
        // TODO: This is page size not items count
        PageItems = items.PageItems;
        // TODO: Is this required?
        // Set the current page index
        PageIndex = items.PageIndex;
        // Set the total available items
        TotalItems = items.TotalItems;
        // Add it to the list
        Items = items.Items;
      }

      // Exit loading state
      Loading = false;

      // Notify the view of the data update
      OnPropertyChanged(nameof(Items));
    }

    /// <inheritdoc />
    public void ClearItems()
    {
      // Clear the current items
      Items = EMPTY;
      // Notify the view of the data update
      OnPropertyChanged(nameof(Items));
    }
  }
}