using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Bader.Core.Data
{
    public partial class BaderContext : DbContext
    {
        public BaderContext()
        {
        }

        public BaderContext(DbContextOptions<BaderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Charity> Charities { get; set; }
        public virtual DbSet<DonationCampaign> DonationCampaigns { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<Initiative> Initiatives { get; set; }
        public virtual DbSet<Link> Links { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionType> QuestionTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<SiteDonar> SiteDonars { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<UserSuervy> UserSuervies { get; set; }
        public virtual DbSet<UserSurveyAnswer> UserSurveyAnswers { get; set; }
        public virtual DbSet<VerficatioCode> VerficatioCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-7945E40\\SQLEXPRESS;Database=Bader;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.BuildingNumber).HasMaxLength(50);

                entity.Property(e => e.CharityId).HasColumnName("CharityID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CharityId)
                    .HasConstraintName("FK_Address_Charity");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Name)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Charity>(entity =>
            {
                entity.ToTable("Charity");

                entity.Property(e => e.CharityId).HasColumnName("CharityID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PreviewVideoPath).IsUnicode(false);

                entity.Property(e => e.ProfileImagePath).IsUnicode(false);
            });

            modelBuilder.Entity<DonationCampaign>(entity =>
            {
                entity.HasKey(e => e.DonationCampaignsId);

                entity.Property(e => e.DonationCampaignsId).HasColumnName("DonationCampaignsID");

                entity.Property(e => e.CharityId).HasColumnName("CharityID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EndAt).HasColumnType("datetime");

                entity.Property(e => e.StartAt).HasColumnType("datetime");

                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.DonationCampaigns)
                    .HasForeignKey(d => d.CharityId)
                    .HasConstraintName("FK_DonationCampaigns_Charity");
            });

            modelBuilder.Entity<Donor>(entity =>
            {
                entity.HasKey(e => e.DonorsId);

                entity.Property(e => e.DonorsId).HasColumnName("DonorsID");

                entity.Property(e => e.DonationCampaignsId).HasColumnName("DonationCampaignsID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.DonationCampaigns)
                    .WithMany(p => p.Donors)
                    .HasForeignKey(d => d.DonationCampaignsId)
                    .HasConstraintName("FK_Donors_DonationCampaigns");
            });

            modelBuilder.Entity<Initiative>(entity =>
            {
                entity.HasKey(e => e.InitiativesId)
                    .HasName("PK_Table_1");

                entity.Property(e => e.InitiativesId).HasColumnName("InitiativesID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EndAt).HasColumnType("datetime");

                entity.Property(e => e.ScheduleType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartAt).HasColumnType("datetime");

                entity.Property(e => e.SurveyId).HasColumnName("SurveyID");

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Link>(entity =>
            {
                entity.HasKey(e => e.LinksId);

                entity.Property(e => e.LinksId).HasColumnName("LinksID");

                entity.Property(e => e.CharityId).HasColumnName("CharityID");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Instgram)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LinkedIn)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Twitter)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.WebSite)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.WhatsApp)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.Links)
                    .HasForeignKey(d => d.CharityId)
                    .HasConstraintName("FK_Links_Charity");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.LastLogout).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_Login_Admin");

                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.CharityId)
                    .HasConstraintName("FK_Login_Charity");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Login_Role");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.SenderMail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Text)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.ToTable("Option");

                entity.Property(e => e.OptionId).HasColumnName("OptionID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.Text)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PaymentMethod");

                entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Cvv2)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CVV2");

                entity.Property(e => e.ExpireDate).HasColumnType("date");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionId)
                    .ValueGeneratedNever()
                    .HasColumnName("QuestionID");

                entity.Property(e => e.QuestionTypeId).HasColumnName("QuestionTypeID");

                entity.Property(e => e.SurveyId).HasColumnName("SurveyID");

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.QuestionType)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .HasConstraintName("FK_Question_QuestionType");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SurveyId)
                    .HasConstraintName("FK_Question_Survey1");
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.ToTable("QuestionType");

                entity.Property(e => e.QuestionTypeId).HasColumnName("QuestionTypeID");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.CharityId).HasColumnName("CharityID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StartAt).HasColumnType("datetime");

                entity.Property(e => e.TargetUser)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.TotalBeneficiaries).HasColumnName("totalBeneficiaries");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.CharityId)
                    .HasConstraintName("FK_Service_Charity");
            });

            modelBuilder.Entity<SiteDonar>(entity =>
            {
                entity.HasKey(e => e.SiteDonarsId);

                entity.Property(e => e.SiteDonarsId).HasColumnName("SiteDonarsID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.ToTable("Subscriber");

                entity.Property(e => e.SubscriberId).HasColumnName("SubscriberID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JoiningDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("Survey");

                entity.Property(e => e.SurveyId).HasColumnName("SurveyID");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserSuervy>(entity =>
            {
                entity.ToTable("UserSuervy");

                entity.Property(e => e.UserSuervyId).HasColumnName("UserSuervyID");

                entity.Property(e => e.Age)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Initiatives)
                    .WithMany(p => p.UserSuervies)
                    .HasForeignKey(d => d.InitiativesId)
                    .HasConstraintName("FK_UserSuervy_Initiatives");
            });

            modelBuilder.Entity<UserSurveyAnswer>(entity =>
            {
                entity.HasKey(e => e.UserSurveyAnswersId);

                entity.ToTable("UserSurveyAnswer");

                entity.Property(e => e.Answer)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.UserSurveyAnswers)
                    .HasForeignKey(d => d.OptionId)
                    .HasConstraintName("FK_UserSurveyAnswer_Option");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.UserSurveyAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_UserSurveyAnswer_Question");
            });

            modelBuilder.Entity<VerficatioCode>(entity =>
            {
                entity.ToTable("VerficatioCode");

                entity.Property(e => e.VerficatioCodeId).HasColumnName("VerficatioCodeID");

                entity.Property(e => e.Code)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.GeneratedAt).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
