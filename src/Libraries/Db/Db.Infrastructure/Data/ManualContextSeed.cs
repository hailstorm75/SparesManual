﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Infrastructure.Data.SeedCsvMapping;
using Db.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace Db.Infrastructure.Data
{
  /// <summary>
  /// Helper class for seeding data into the database
  /// </summary>
  public static class ManualContextSeed
  {
    /// <summary>
    /// Seeds test data into the database <paramref name="context"/>
    /// </summary>
    /// <param name="context">Database context</param>
    /// <param name="loggerFactory">Logger provider</param>
    public static async Task SeedAsync(this ManualContext context, ILoggerFactory loggerFactory)
    {
      var csvParserOptions = new CsvParserOptions(true, ';');

      async Task Populate<T>(Func<ManualContext, DbSet<T>> extractor, string path, ICsvMapping<T> mapping)
        where T : class, IEntity
      {
        const string root = @"..\..\Db\Db.Infrastructure\Data\SeedData";
        var extracted = extractor(context);

        if (extracted.Any())
          return;

        var parser = new CsvParser<T>(csvParserOptions, mapping);

        var result = parser
          .ReadFromFile(Path.Combine(root, path), Encoding.Default)
          .Where(mapped => mapped.IsValid)
          .Select(mapped => mapped.Result);

        await extracted.AddRangeAsync(result).ConfigureAwait(false);
        await context.SaveChangesAsync().ConfigureAwait(false);
      }

      try
      {
        await Populate(c => c.Books!, "books.csv", new CsvBookMapping()).ConfigureAwait(false);
        await Populate(c => c.Makes!, "makes.csv", new CsvMakeMapping()).ConfigureAwait(false);
        await Populate(c => c.Carburetors!, "carburetors.csv", new CsvCarburetorMapping()).ConfigureAwait(false);
        await Populate(c => c.Engines!, "engines.csv", new CsvEngineMapping()).ConfigureAwait(false);
        await Populate(c => c.Models!, "models.csv", new CsvModelMapping()).ConfigureAwait(false);
        await Populate(c => c.Parts!, "parts.csv", new CsvPartMapping()).ConfigureAwait(false);
        await Populate(c => c.PropertyTypes!, "propertyTypes.csv", new CsvPropertyTypeMapping()).ConfigureAwait(false);
        await Populate(c => c.FormatTypes!, "formatTypes.csv", new CsvFormatTypeMapping()).ConfigureAwait(false);
        await Populate(c => c.Properties!, "properties.csv", new CsvPropertyMapping()).ConfigureAwait(false);
        await Populate(c => c.Sections!, "sections.csv", new CsvSectionMapping()).ConfigureAwait(false);
        await Populate(c => c.SectionParts!, "sectionParts.csv", new CsvSectionPartsMapping()).ConfigureAwait(false);
        await Populate(c => c.SectionPartParents!, "sectionPartParents.csv", new CsvSectionPartParentsMapping()).ConfigureAwait(false);
        await Populate(c => c.ImagePoints!, "imagePoints.csv", new CsvImagePointsMapping()).ConfigureAwait(false);
      }
      catch (Exception e)
      {
        var logger = loggerFactory.CreateLogger<ManualContext>();
        logger.LogError(e, "Failed to seed data");
      }
    }
  }
}
