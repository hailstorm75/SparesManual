﻿using Models.Interfaces.Entities;

namespace Models.Entities
{
  public record PartModel
    : IPart
  {
    /// <inheritdoc />
    public int Id { get; init; }

    /// <inheritdoc />
    public string PartNumber { get; init; }

    /// <inheritdoc />
    public string MakersPartNumber { get; init; }

    /// <inheritdoc />
    public string Description { get; init; }
  }
}