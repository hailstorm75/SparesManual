﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Db.Core.Entities
{
  /// <summary>
  /// Entity representing a section in a manual containing <see cref="SectionParts"/> entities
  /// </summary>
  // ReSharper disable once ClassNeverInstantiated.Global
  public class Section
    : BaseEntity
  {
    /// <summary>
    /// Foreign key reference to the parent <see cref="Entities.Book"/> entity
    /// </summary>
    [Required]
    public int BookId { get; set; }

    /// <summary>
    /// Reference to the parent <see cref="Entities.Book"/> entity
    /// </summary>
    public Book? Book { get; set; }

    /// <summary>
    /// Header of the section
    /// </summary>
    public string? SectionHeader { get; set; }

    /// <summary>
    /// Start of the section span in the given <see cref="Book"/>
    /// </summary>
    [Required]
    public int StartPage { get; set; }

    /// <summary>
    /// End of the section span in the given <see cref="Book"/>
    /// </summary>
    [Required]
    public int EndPage { get; set; }

    /// <summary>
    /// Number of the figure covered by this section
    /// </summary>
    public int FigureNumber { get; set; }

    /// <summary>
    /// Description of the figure covered by this section
    /// </summary>
    [MaxLength(128)]
    public string? FigureDescription { get; set; }

    /// <summary>
    /// Name of the model to which this section is specifically dedicated to
    /// </summary>
    [MaxLength(64)]
    public string? SpecificToModel { get; set; }

    /// <summary>
    /// <see cref="Part"/> entities inside this given section
    /// </summary>
    // ReSharper disable once CollectionNeverUpdated.Global
    public List<SectionParts> SectionParts { get; set; } = new List<SectionParts>();
  }
}