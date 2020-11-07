using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MemoApp.Models
{
    /// <summary>
    /// [3] DbContext Class
    /// </summary>
    public class MemoAppDbContext : DbContext
    {
        // PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer
        // PM> Install-Package Microsoft.Data.SqlClient
        // PM> Install-Package System.Configuration.ConfigurationManager
        //// PM> Install-Package Microsoft.EntityFrameworkCore
        //// PM> Install-Package Microsoft.EntityFrameworkCore.Tools
        //// PM> Install-Package Microsoft.EntityFrameworkCore.InMemory

        public MemoAppDbContext()
        {
            // Empty
            // ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public MemoAppDbContext(DbContextOptions<MemoAppDbContext> options)
            : base(options)
        {
            // 공식과 같은 코드, 교과서다운 코드
            // ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 닷넷 프레임워크 또는 Windows Forms/WPF 기반에서 호출되는 코드 영역: 
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
