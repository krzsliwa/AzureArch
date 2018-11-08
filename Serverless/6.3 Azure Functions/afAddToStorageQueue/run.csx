using System;

public static void Run(TimerInfo myTimer, ICollector<string> outputQueueItem, ILogger log)
{
    outputQueueItem.Add($"Msg inserted at {DateTime.UtcNow}");
}
