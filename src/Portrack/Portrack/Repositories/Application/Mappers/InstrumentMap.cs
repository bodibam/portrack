﻿using Portrack.Models.Application;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Portrack.Repositories.Application.Mappers
{
    public class InstrumentMap : EntityTypeConfiguration<Instrument>
    {
        public InstrumentMap()
        {
            ToTable("Instruments", "Portrack");
            HasKey(i => i.InstrumentId);
            Property(i => i.InstrumentId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Ignore(t => t.InstrumentData);
            Ignore(t => t.Quote);

            Property(i => i.Ticker).IsRequired();
        }
    }
}