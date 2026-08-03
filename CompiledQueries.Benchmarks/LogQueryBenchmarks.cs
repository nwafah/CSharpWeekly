using BenchmarkDotNet.Attributes;
using CompiledQueries;
using Microsoft.EntityFrameworkCore;

[MemoryDiagnoser]
public class LogQueryBenchmarks
{
    private const string ConnectionString =
     "Data Source=localhost,1433;" +
     "Initial Catalog=MI2;" +
     "User ID=sa;" +
     "Password=Sql@2026StrongPass!;" +
     "Trust Server Certificate=True";

    private static readonly Func<
        AppDbContext,
        int,
        int,
        IAsyncEnumerable<int>> _compiledQuery =
            EF.CompileAsyncQuery(
                (AppDbContext context, int employeeId, int take) =>
                    context.tbLog
                        .AsNoTracking()
                        .Where(log => log.EmployeeID == employeeId)
                        .OrderBy(log => log.LogID)
                        .Select(log => log.LogID)
                        .Take(take));

    private AppDbContext _context = null!;

    private readonly int _employeeId = 23493;

    [Params(1, 10, 100)]
    public int RowsToReturn { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(ConnectionString)
            .Options;

        _context = new AppDbContext(options);
    }

    [Benchmark(Baseline = true)]
    public async ValueTask<int> WithoutCompiledQuery()
    {
        var sum = 0;

        await foreach (var logId in _context.tbLog
                           .AsNoTracking()
                           .Where(log => log.EmployeeID == _employeeId)
                           .OrderBy(log => log.LogID)
                           .Select(log => log.LogID)
                           .Take(RowsToReturn)
                           .AsAsyncEnumerable())
        {
            sum += logId;
        }

        return sum;
    }

    [Benchmark]
    public async ValueTask<int> WithCompiledQuery()
    {
        var sum = 0;

        await foreach (var logId in
                       _compiledQuery(
                           _context,
                           _employeeId,
                           RowsToReturn))
        {
            sum += logId;
        }

        return sum;
    }

    [GlobalCleanup]
    public ValueTask Cleanup()
    {
        return _context.DisposeAsync();
    }
}