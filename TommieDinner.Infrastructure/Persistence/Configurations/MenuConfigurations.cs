using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TommieDinner.Domain.HostAggregate.ValueObjects;
using TommieDinner.Domain.Menu.ValueObjects;
using TommieDinner.Domain.MenuAggregate;
using TommieDinner.Domain.MenuAggregate.Entities;
using TommieDinner.Domain.MenuAggregate.ValueObjects;

namespace TommieDinner.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, dib =>
        {
            dib.ToTable("MenuReviewIds");

            dib.WithOwner().HasForeignKey("MenuId");

            dib.HasKey("Id");

            dib.Property(d => d.Value)
                .HasColumnName("MenuReviewId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, dib =>
        {
            dib.ToTable("MenuDinnerIds");

            dib.WithOwner().HasForeignKey("MenuId");

            dib.HasKey("Id");

            dib.Property(d => d.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuSections, sb =>
        {
            sb.ToTable("MenuSections");

            sb.WithOwner().HasForeignKey("MenuId");

            sb.HasKey("Id", "MenuId");

            sb.Property(s => s.Id)
                .HasColumnName("MenuSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value));

            sb.Property(s => s.Name)
                .HasMaxLength(100);

            sb.Property(s => s.Description)
                .HasMaxLength(100);

            sb.OwnsMany(s => s.MenuItems, ib =>
            {
                ib.ToTable("MenuItems");

                ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

                ib.Property(i => i.Id)
                    .HasColumnName("MenuItemId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuItemId.Create(value));

                ib.Property(s => s.Name)
                   .HasMaxLength(100);

                ib.Property(s => s.Description)
                    .HasMaxLength(100);
            });

            sb.Navigation(s => s.MenuItems).Metadata.SetField("_menuItems");
            sb.Navigation(s => s.MenuItems).UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        builder.Metadata.FindNavigation(nameof(Menu.MenuSections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

        builder.Property(m => m.Name)
            .HasMaxLength(100);

        builder.Property(m => m.Description)
            .HasMaxLength(100);

        builder.OwnsOne(m => m.AverageRating);

        builder.Property(m => m.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));
    }
}
