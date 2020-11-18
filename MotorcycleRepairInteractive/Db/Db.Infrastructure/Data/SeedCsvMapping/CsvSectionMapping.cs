﻿using Db.Core.Entities;
using TinyCsvParser.Mapping;

namespace Db.Infrastructure.Data.SeedCsvMapping
{
  internal class CsvSectionMapping
    : CsvMapping<Section>
  {
    public CsvSectionMapping()
    {
      MapProperty(0, x => x.Id);
      MapProperty(1, x => x.BookId);
      MapProperty(2, x => x.StartPage);
      MapProperty(3, x => x.EndPage);
      MapProperty(4, x => x.SectionHeader);
      MapProperty(5, x => x.FigureNumber);
      MapProperty(6, x => x.FigureDescription);
      MapProperty(7, x => x.SpecificToModel);
    }
  }

  internal class CsvSectionPartsMapping
    : CsvMapping<SectionParts>
  {
    public CsvSectionPartsMapping()
    {
      MapProperty(0, x => x.Id);
      MapProperty(2, x => x.PartId);
      MapProperty(3, x => x.PageNumber);
      MapProperty(4, x => x.AdditionalInfo);
      MapProperty(5, x => x.Quantity);
      MapProperty(6, x => x.Remarks);
    }
  }
}