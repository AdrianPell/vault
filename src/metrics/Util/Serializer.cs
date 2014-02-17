﻿using System;
using System.Collections.Generic;
using System.Text;
using metrics.Core;

namespace metrics.Util
{
    public static class Serializer
    {
        public static Func<IEnumerable<CLRProfiler.ThreadInfo>, string> SerializeThreads = o => o.ToString();

        public static Func<IDictionary<MetricName, IMetric>, string> Serialize = metrics =>
        {
            var sb = new StringBuilder("[");

            foreach (var metric in metrics)
            {
                sb.Append("{\"name\":\"");
                sb.Append(metric.Key).Append("\",\"metric\":");
                metric.Value.LogJson(sb);
                sb.Append("}");
            }

            sb.Append("]");

            return sb.ToString();
        };

    }
}