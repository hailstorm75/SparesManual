using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRI.MVVM.Interfaces.ViewModels
{
  /// <summary>
  /// Interface for view models displaying items without paging
  /// </summary>
  /// <typeparam name="T">Item type</typeparam>
  public interface IItemsViewModel<out T>
    : IViewModel
  {
    #region Properties

    /// <summary>
    /// Are items loading
    /// </summary>
    bool Loading { get; set; }

    /// <summary>
    /// Items to display
    /// </summary>
    IReadOnlyCollection<T> Items { get; }

    #endregion

    /// <summary>
    /// Loads items
    /// </summary>
    Task LoadItemsAsync();

    /// <summary>
    /// Clears loaded items
    /// </summary>
    void ClearItems();
  }
}