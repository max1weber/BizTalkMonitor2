using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Biztalk.Monitor.Data.Entities;

namespace Biztalk.Monitor.Data.Context
{
    public partial class EsbExceptionDbContext : DbContext
    {
        public EsbExceptionDbContext()
        {
        }

        public EsbExceptionDbContext(DbContextOptions<EsbExceptionDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActionType> ActionType { get; set; }
        public virtual DbSet<Alert> Alert { get; set; }
        public virtual DbSet<AlertCondition> AlertCondition { get; set; }
        public virtual DbSet<AlertEmail> AlertEmail { get; set; }
        public virtual DbSet<AlertHistory> AlertHistory { get; set; }
        public virtual DbSet<AlertSubscription> AlertSubscription { get; set; }
        public virtual DbSet<AlertSubscriptionHistory> AlertSubscriptionHistory { get; set; }
        public virtual DbSet<AuditLog> AuditLog { get; set; }
        public virtual DbSet<AuditLogMessageData> AuditLogMessageData { get; set; }
        public virtual DbSet<Batch> Batch { get; set; }
        public virtual DbSet<Configuration> Configuration { get; set; }
        public virtual DbSet<ContextProperty> ContextProperty { get; set; }
        public virtual DbSet<Fault> Fault { get; set; }
        public virtual DbSet<MarkLog> MarkLog { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<MessageData> MessageData { get; set; }
        public virtual DbSet<ProcessedFault> ProcessedFault { get; set; }
        public virtual DbSet<UserSetting> UserSetting { get; set; }
        public virtual DbSet<VwAggregatedFaults> VwAggregatedFaults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EsbExceptionDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionType>(entity =>
            {
                entity.Property(e => e.ActionTypeId)
                    .HasColumnName("ActionTypeID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ActionName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Alert>(entity =>
            {
                entity.Property(e => e.AlertId)
                    .HasColumnName("AlertID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConditionsString)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.InsertedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AlertCondition>(entity =>
            {
                entity.Property(e => e.AlertConditionId)
                    .HasColumnName("AlertConditionID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AlertId).HasColumnName("AlertID");

                entity.Property(e => e.InsertedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.LeftSide)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Operator)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.RightSide)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.Alert)
                    .WithMany(p => p.AlertCondition)
                    .HasForeignKey(d => d.AlertId)
                    .HasConstraintName("fk_AlertCondition_AlertID_NC_NU");
            });

            modelBuilder.Entity<AlertEmail>(entity =>
            {
                entity.Property(e => e.AlertEmailId)
                    .HasColumnName("AlertEmailID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AlertSubscriptionHistoryId).HasColumnName("AlertSubscriptionHistoryID");

                entity.Property(e => e.BatchId).HasColumnName("BatchID");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.To)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AlertHistory>(entity =>
            {
                entity.Property(e => e.AlertHistoryId)
                    .HasColumnName("AlertHistoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlertName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Application)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.FaultId).HasColumnName("FaultID");

                entity.Property(e => e.InsertedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AlertSubscription>(entity =>
            {
                entity.Property(e => e.AlertSubscriptionId)
                    .HasColumnName("AlertSubscriptionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AlertId).HasColumnName("AlertID");

                entity.Property(e => e.BlackOutEndDate).HasColumnType("datetime");

                entity.Property(e => e.BlackOutStartDate).HasColumnType("datetime");

                entity.Property(e => e.CustomEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EndUtchour).HasColumnName("EndUTCHour");

                entity.Property(e => e.EndUtcminute).HasColumnName("EndUTCMinute");

                entity.Property(e => e.InsertedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.InsertedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.LastFired).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartUtchour).HasColumnName("StartUTCHour");

                entity.Property(e => e.StartUtcminute).HasColumnName("StartUTCMinute");

                entity.Property(e => e.Subscriber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Alert)
                    .WithMany(p => p.AlertSubscription)
                    .HasForeignKey(d => d.AlertId)
                    .HasConstraintName("fk_AlertSubscription_Alert");
            });

            modelBuilder.Entity<AlertSubscriptionHistory>(entity =>
            {
                entity.Property(e => e.AlertSubscriptionHistoryId)
                    .HasColumnName("AlertSubscriptionHistoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlertHistoryId).HasColumnName("AlertHistoryID");

                entity.Property(e => e.CustomEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate).HasColumnType("datetime");

                entity.Property(e => e.Subscriber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.AlertHistory)
                    .WithMany(p => p.AlertSubscriptionHistory)
                    .HasForeignKey(d => d.AlertHistoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AlertSubscriptionHistory_AlertHistory");
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.Property(e => e.AuditLogId)
                    .HasColumnName("AuditLogID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ActionTypeId).HasColumnName("ActionTypeID");

                entity.Property(e => e.Application)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.AuditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.AuditUserName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ContentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaultId).HasColumnName("FaultID");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.MessageName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NativeFaultId)
                    .HasColumnName("NativeFaultID")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.NativeMessageId)
                    .HasColumnName("NativeMessageID")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.ResubmitCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ResubmitMessage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResubmitUrl)
                    .HasColumnName("ResubmitURL")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AuditLogMessageData>(entity =>
            {
                entity.HasKey(e => e.AuditLogId);

                entity.Property(e => e.AuditLogId)
                    .HasColumnName("AuditLogID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MessageData)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Batch>(entity =>
            {
                entity.HasKey(e => e.BatchId)
                    .HasName("pk_BatchExecution_BatchExecutionID")
                    .IsClustered(false);

                entity.Property(e => e.BatchId)
                    .HasColumnName("BatchID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EndDatetime).HasColumnType("datetime");

                entity.Property(e => e.ErrorMessage).IsUnicode(false);

                entity.Property(e => e.StartDatetime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.HasIndex(e => e.ConfigurationId)
                    .HasName("ix_Configuration_Name_U_NC")
                    .IsUnique();

                entity.Property(e => e.ConfigurationId)
                    .HasColumnName("ConfigurationID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContextProperty>(entity =>
            {
                entity.Property(e => e.ContextPropertyId)
                    .HasColumnName("ContextPropertyID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsertedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(4096)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fault>(entity =>
            {
                entity.HasIndex(e => e.NativeMessageId)
                    .HasName("ix_Fault_NativeMessageID_U_NC")
                    .IsUnique();

                entity.Property(e => e.FaultId)
                    .HasColumnName("FaultID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivityId)
                    .HasColumnName("ActivityID")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.Application)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(4096)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorType)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionMessage)
                    .IsRequired()
                    .HasMaxLength(4096)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionSource)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionStackTrace)
                    .IsRequired()
                    .HasMaxLength(4096)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionTargetSite)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FailureCategory)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.FaultCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FaultDescription)
                    .HasMaxLength(4096)
                    .IsUnicode(false);

                entity.Property(e => e.FaultGenerator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InnerExceptionMessage)
                    .IsRequired()
                    .HasMaxLength(4096)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.MachineName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NativeMessageId)
                    .HasColumnName("NativeMessageID")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.Scope)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceInstanceId)
                    .IsRequired()
                    .HasColumnName("ServiceInstanceID")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MarkLog>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.MarkName).HasMaxLength(128);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.MessageId)
                    .HasColumnName("MessageID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivityId)
                    .HasColumnName("ActivityID")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.ContentType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaultId).HasColumnName("FaultID");

                entity.Property(e => e.InsertedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.InterchangeId)
                    .HasColumnName("InterchangeID")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.MessageName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NativeMessageId)
                    .HasColumnName("NativeMessageID")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.RoutingUrl)
                    .HasMaxLength(512)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MessageData>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.Property(e => e.MessageId)
                    .HasColumnName("MessageID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MessageData1)
                    .IsRequired()
                    .HasColumnName("MessageData")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProcessedFault>(entity =>
            {
                entity.Property(e => e.ProcessedFaultId)
                    .HasColumnName("ProcessedFaultID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<UserSetting>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.SettingName)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.SettingValue)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwAggregatedFaults>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_AggregatedFaults");

                entity.Property(e => e.Application)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.ErrorType)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FailureCategory)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.FaultCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.TrueDateTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
