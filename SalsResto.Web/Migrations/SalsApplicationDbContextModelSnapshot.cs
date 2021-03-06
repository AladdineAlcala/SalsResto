// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalsResto.Data;

namespace SalsResto.Web.Migrations
{
    [DbContext(typeof(SalsApplicationDbContext))]
    partial class SalsApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SalsResto.Data.Models.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BookingId");

                    b.Property<bool?>("apply_extendedAmount")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("b_createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("b_createdbyUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("b_updatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("booktype")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("cId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("enddate")
                        .HasColumnType("datetime2");

                    b.Property<string>("eventcolor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("extendedAreaId")
                        .HasColumnType("int");

                    b.Property<bool?>("is_cancelled")
                        .HasColumnType("bit");

                    b.Property<bool?>("is_deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("noofperson")
                        .HasColumnType("int");

                    b.Property<string>("occasion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("p_amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("p_id")
                        .HasColumnType("int");

                    b.Property<string>("reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("serve_stat")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("startdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("transdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("typeofservice")
                        .HasColumnType("int");

                    b.Property<string>("venue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("cId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("SalsResto.Data.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CustomerId");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("datereg")
                        .HasColumnType("datetime2");

                    b.Property<string>("firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SalsResto.Data.Models.Booking", b =>
                {
                    b.HasOne("SalsResto.Data.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("cId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SalsResto.Data.Models.Customer", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
