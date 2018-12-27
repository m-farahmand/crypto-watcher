﻿using System.Collections.Generic;
using CryptoWatcher.Application.Charts.Responses;
using CryptoWatcher.Domain.Models;
using CryptoWatcher.UI.Models;
using Chart = CryptoWatcher.UI.Models.Chart;


namespace CryptoWatcher.UI.Builders
{
    public static class ChartBuilder
    {
        public static ChartViewModel BuildChartViewModel(List<ChartResponse> response)
        {
            var chartViewModel = new ChartViewModel();
            foreach (var item in response)
            {
                    var chart = new Chart
                    {
                        ChartId = item.ChartId,
                        CurrencyName = item.CurrencyName,
                        IndicatorName = item.IndicatorName,
                        Rows = BuildRows(item.Rows)
                    };
                    chartViewModel.Charts.Add(chart);
            }

            // Return
            return chartViewModel;
        }

        public static string BuildRows(List<ChartRow> chartRows)
        {
            // Rows
            var rows = string.Empty;
            foreach (var chartRow in chartRows)
            {
                var time = chartRow.Time;
                var value = chartRow.Value;
                var averagebuy = chartRow.AverageBuy.HasValue ? chartRow.AverageBuy.ToString() : "null";
                var averageSell = chartRow.AverageSell.HasValue ? chartRow.AverageSell.ToString() : "null";
  
                var dateTime = $"new Date({time.Year},{time.Month:D2},{time.Day:D2},{time.Hour:D2},{time.Minute:D2})";
                rows += ", " + $"[{dateTime}, {value}, {averagebuy}, {averageSell}]";
            }

            if (!string.IsNullOrEmpty(rows)) rows = rows.Substring(2);

            // Return
            return rows;
        }
    }
}
