using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MemoApp.Models
{
    /// <summary>
    /// [5] DbContext Class
    /// </summary>
    public class MemoAppDbContext : DbContext
    {
        // Install-Package Microsoft.EntityFrameworkCore
        // Install-Package Microsoft.EntityFrameworkCore.SqlServer
        // Install-Package Microsoft.EntityFrameworkCore.Tools
        // Install-Package Microsoft.EntityFrameworkCore.InMemory
        // Install-Package System.Configuration.ConfigurationManager
        // Install-Package Microsoft.Data.SqlClient

        public MemoAppDbContext()
        {
            // Empty
            // ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public MemoAppDbContext(DbContextOptions<MemoAppDbContext> options)
            : base(options)
        {
            // 공식과 같은 코드
            // ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 닷넷 프레임워크 기반에서 호출되는 코드 영역: 
            // App.config 또는 Web.config의 연결 문자열 사용
            // 직접 데이터베이스 연결문자열 설정 가능
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager.ConnectionStrings[
                    "ConnectionString"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Memos 테이블의 Created 열은 자동으로 GetDate() 제약 조건을 부여하기 
            modelBuilder.Entity<Memo>().Property(m => m.Created).HasDefaultValueSql("GetDate()");
        }

        //[!] MemoApp 솔루션 관련 모든 테이블에 대한 참조 
        public DbSet<Memo> Memos { get; set; }
    }
}
