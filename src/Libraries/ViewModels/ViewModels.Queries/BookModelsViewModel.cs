using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Db.Interfaces;
using Models.Interfaces.Entities;
using MRI.Helpers;
using MRI.MVVM.Helpers;
using ViewModels.Interfaces.Queries;

namespace ViewModels.Queries
{
  /// <summary>
  /// View model for displaying book models
  /// </summary>
  public class BookModelsViewModel
    : BaseItemViewModel<IReadOnlyDictionary<string, IReadOnlyCollection<IModel>>>, IBookModelsViewModel
  {
    private readonly IAPIProvider m_provider;

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="provider">Injected API provider instance</param>
    public BookModelsViewModel(IAPIProvider provider)
    {
      m_provider = provider;
    }

    /// <inheritdoc />
    protected override async Task<IReadOnlyDictionary<string, IReadOnlyCollection<IModel>>> GetItem(string id, CancellationToken cancellationToken = default)
    {
      // Get the models
      var models = await m_provider
        // Query the models from a given book
        .GetBookModelsAsync(IdToInt(id), cancellationToken)
        // Materialize the result
        .ToListAsync(cancellationToken)
        .ConfigureAwait(false);

      // Return the result
      return models
        // Group the models by their names
        .GroupBy(model => model.Name)
        // Materialize the items into a map of model name to concrete models
        .ToDictionary(group => group.Key, group => group.ToReadOnlyCollection());
    }
  }
}