// في أي مكان في التطبيق
using CompiledQueries;

//using var dbContext = new AppDbContext();

////// استخدام الدالة المتزامنة
//var logsSync = dbContext.GetLogs(23949);
//foreach (var log in logsSync)
//{
//    Console.WriteLine($"Log: {log.LogID}");
//}

// استخدام الدالة غير المتزامنة
//var logsAsync = await dbContext.GetLogsAsync(23949);
//await foreach (var log in logsAsync)
//{
//    Console.WriteLine($"Log Async: {log.LogID}");
//}

//// استخدام الطريقة المبسطة
//var logsList = await dbContext.GetLogsListAsync(1);
Console.WriteLine("Hello, World!");