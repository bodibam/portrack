﻿using System;

namespace TheGapFillers.MarketData.Models
{
    public class HistoricalPrice : MarketDataBase
    {
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
    }
}