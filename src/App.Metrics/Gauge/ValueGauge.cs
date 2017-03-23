﻿// <copyright file="ValueGauge.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using App.Metrics.Abstractions.MetricTypes;
using App.Metrics.Concurrency;

namespace App.Metrics.Gauge
{
    public sealed class ValueGauge : IGaugeMetric
    {
        private AtomicDouble _gauge = new AtomicDouble(0.0);

        /// <inheritdoc />
        public double Value => _gauge.GetValue();

        /// <inheritdoc />
        public double GetValue(bool resetMetric = false)
        {
            return resetMetric ? _gauge.GetAndReset() : _gauge.GetValue();
        }

        /// <inheritdoc />
        public void Reset()
        {
            _gauge.SetValue(0.0);
        }

        /// <inheritdoc />
        public void SetValue(double value)
        {
            _gauge.SetValue(value);
        }
    }
}