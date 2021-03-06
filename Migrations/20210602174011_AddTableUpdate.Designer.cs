// <auto-generated />
using System;
using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210602174011_AddTableUpdate")]
    partial class AddTableUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Property<int>("NIK")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIK");

                    b.ToTable("TB_M_Account");
                });

            modelBuilder.Entity("API.Models.AccountRole", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountNIK")
                        .HasColumnType("int");

                    b.Property<int>("NIK")
                        .HasColumnType("int");

                    b.Property<int>("Roleid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("AccountNIK");

                    b.HasIndex("Roleid");

                    b.ToTable("TB_T_AccountRole");
                });

            modelBuilder.Entity("API.Models.Education", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Universityid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Universityid");

                    b.ToTable("TB_M_Education");
                });

            modelBuilder.Entity("API.Models.Person", b =>
                {
                    b.Property<int>("NIK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.ToTable("TB_M_Person");
                });

            modelBuilder.Entity("API.Models.Profiling", b =>
                {
                    b.Property<int>("NIK")
                        .HasColumnType("int");

                    b.Property<int>("Educationid")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.HasIndex("Educationid");

                    b.ToTable("TB_T_Profiling");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("TB_M_Role");
                });

            modelBuilder.Entity("API.Models.University", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("TB_M_University");
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.HasOne("API.Models.Person", "Person")
                        .WithOne("Account")
                        .HasForeignKey("API.Models.Account", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("API.Models.AccountRole", b =>
                {
                    b.HasOne("API.Models.Account", "Account")
                        .WithMany("AccountRole")
                        .HasForeignKey("AccountNIK");

                    b.HasOne("API.Models.Role", "Role")
                        .WithMany("AccountRole")
                        .HasForeignKey("Roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("API.Models.Education", b =>
                {
                    b.HasOne("API.Models.University", "University")
                        .WithMany("Education")
                        .HasForeignKey("Universityid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("API.Models.Profiling", b =>
                {
                    b.HasOne("API.Models.Education", "Education")
                        .WithMany("Profiling")
                        .HasForeignKey("Educationid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Account", "Account")
                        .WithOne("Profiling")
                        .HasForeignKey("API.Models.Profiling", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Education");
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Navigation("AccountRole");

                    b.Navigation("Profiling");
                });

            modelBuilder.Entity("API.Models.Education", b =>
                {
                    b.Navigation("Profiling");
                });

            modelBuilder.Entity("API.Models.Person", b =>
                {
                    b.Navigation("Account");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Navigation("AccountRole");
                });

            modelBuilder.Entity("API.Models.University", b =>
                {
                    b.Navigation("Education");
                });
#pragma warning restore 612, 618
        }
    }
}
