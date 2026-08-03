using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CompiledQueries
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
     DbContextOptions<AppDbContext> options)
     : base(options)
        {
        }
        public DbSet<LogModel> tbLog => Set<LogModel>();


        // Compiled query to get logs by employee ID
        // 1. تعريف استعلام مترجم متزامن (Sync) - بحث بواسطة Id
        private static Func<AppDbContext, int, IEnumerable<LogModel?>> GetLogsCompiled =
            EF.CompileQuery((AppDbContext context, int employeeId) =>
            context.Set<LogModel>().Where(x => x.EmployeeID == employeeId).AsNoTracking());

        // 2. تعريف استعلام مترجم غير متزامن (Async) - بحث بواسطة Id
        private static readonly
      Func<AppDbContext, int, IAsyncEnumerable<LogModel>>
      GetLogsCompiledAsync =
          EF.CompileAsyncQuery(
              (AppDbContext context, int employeeId) =>
                  context.tbLog
                      .AsNoTracking()
                      .Where(log => log.EmployeeID == employeeId));

        // دالة لتنفيذ الاستعلام المتزامن
        public IEnumerable<LogModel?> GetLogs(int employeeId)
        {
            return GetLogsCompiled(this, employeeId);
        }

        // دالة لتنفيذ الاستعلام غير المتزامن
        public IAsyncEnumerable<LogModel> GetLogsAsync(int employeeId)
        {
            return GetLogsCompiledAsync(this, employeeId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=MI2;User ID=sa;Password=Sql@2026StrongPass!;Trust Server Certificate=True");
            }
        }
    }
}
