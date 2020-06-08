using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings
{
    public class PacienteMapping : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Nascimento)
               .IsRequired()
               .HasColumnType("datetime");

            builder.Property(p => p.Idade)
               .IsRequired()
               .HasColumnType("integer");

            builder.Property(p => p.Sexo)
              .IsRequired()
              .HasColumnType("integer");

            builder.Property(p => p.Cpf)
             .IsRequired()
             .HasColumnType("varchar(11)");

            builder.Property(p => p.TitularCpf)
              .IsRequired()
              .HasColumnType("varchar(100)");

            builder.Property(p => p.IndicadoPor)
               .IsRequired()
               .HasColumnType("varchar(100)");

            
            builder.HasOne(p => p.Endereco)
                    .WithOne(e => e.Paciente);

            builder.ToTable("Pacientes");
            
        }
    }
}
