using BenchmarkDotNet.Running;// Namespace الخاص بكلاس القياس

var summary = BenchmarkRunner.Run<LogQueryBenchmarks>();
// أو لرؤية النتائج بشكل أكثر تفصيلاً:
// var summary = BenchmarkRunner.Run<LogQueryBenchmarks>(config: ManualConfig.Create(DefaultConfig.Instance)
//     .WithOptions(ConfigOptions.DisableOptimizationsValidator));