﻿using System;

namespace Portrack.Providers.MarketData.Yahoo
{

    public class YahooRootQuotes
    {
        public YahooQueryQuotes query { get; set; }
    }

    public class YahooQueryQuotes
    {
        public int count { get; set; }
        public DateTime created { get; set; }
        public string lang { get; set; }
        public YahooResultsQuotes results { get; set; }
    }

    public class YahooResultsQuotes
    {
        public YahooQuote[] quote { get; set; }
    }

    public class YahooRootQuote
    {
        public YahooQueryQuote query { get; set; }
    }

    public class YahooQueryQuote
    {
        public int count { get; set; }
        public DateTime created { get; set; }
        public string lang { get; set; }
        public YahooResultsQuote results { get; set; }
    }

    public class YahooResultsQuote
    {
        public YahooQuote quote { get; set; }
    }

    public class YahooQuote
    {
        public string symbol { get; set; }
        public string Ask { get; set; }
        public string AverageDailyVolume { get; set; }
        public string Bid { get; set; }
        public string AskRealtime { get; set; }
        public string BidRealtime { get; set; }
        public string BookValue { get; set; }
        public string Change_PercentChange { get; set; }
        public string Change { get; set; }
        public object Commission { get; set; }
        public string Currency { get; set; }
        public string ChangeRealtime { get; set; }
        public string AfterHoursChangeRealtime { get; set; }
        public string DividendShare { get; set; }
        public string LastTradeDate { get; set; }
        public object TradeDate { get; set; }
        public string EarningsShare { get; set; }
        public object ErrorIndicationreturnedforsymbolchangedinvalid { get; set; }
        public string EPSEstimateCurrentYear { get; set; }
        public string EPSEstimateNextYear { get; set; }
        public string EPSEstimateNextQuarter { get; set; }
        public string DaysLow { get; set; }
        public string DaysHigh { get; set; }
        public string YearLow { get; set; }
        public string YearHigh { get; set; }
        public string HoldingsGainPercent { get; set; }
        public object AnnualizedGain { get; set; }
        public object HoldingsGain { get; set; }
        public string HoldingsGainPercentRealtime { get; set; }
        public object HoldingsGainRealtime { get; set; }
        public string MoreInfo { get; set; }
        public object OrderBookRealtime { get; set; }
        public string MarketCapitalization { get; set; }
        public object MarketCapRealtime { get; set; }
        public string EBITDA { get; set; }
        public string ChangeFromYearLow { get; set; }
        public string PercentChangeFromYearLow { get; set; }
        public string LastTradeRealtimeWithTime { get; set; }
        public string ChangePercentRealtime { get; set; }
        public string ChangeFromYearHigh { get; set; }
        public string PercebtChangeFromYearHigh { get; set; }
        public string LastTradeWithTime { get; set; }
        public string LastTradePriceOnly { get; set; }
        public object HighLimit { get; set; }
        public object LowLimit { get; set; }
        public string DaysRange { get; set; }
        public string DaysRangeRealtime { get; set; }
        public string FiftydayMovingAverage { get; set; }
        public string TwoHundreddayMovingAverage { get; set; }
        public string ChangeFromTwoHundreddayMovingAverage { get; set; }
        public string PercentChangeFromTwoHundreddayMovingAverage { get; set; }
        public string ChangeFromFiftydayMovingAverage { get; set; }
        public string PercentChangeFromFiftydayMovingAverage { get; set; }
        public string Name { get; set; }
        public object Notes { get; set; }
        public string Open { get; set; }
        public string PreviousClose { get; set; }
        public object PricePaid { get; set; }
        public string ChangeinPercent { get; set; }
        public string PriceSales { get; set; }
        public string PriceBook { get; set; }
        public string ExDividendDate { get; set; }
        public string PERatio { get; set; }
        public string DividendPayDate { get; set; }
        public object PERatioRealtime { get; set; }
        public string PEGRatio { get; set; }
        public string PriceEPSEstimateCurrentYear { get; set; }
        public string PriceEPSEstimateNextYear { get; set; }
        public string Symbol { get; set; }
        public object SharesOwned { get; set; }
        public string ShortRatio { get; set; }
        public string LastTradeTime { get; set; }
        public string TickerTrend { get; set; }
        public string OneyrTargetPrice { get; set; }
        public string Volume { get; set; }
        public object HoldingsValue { get; set; }
        public object HoldingsValueRealtime { get; set; }
        public string YearRange { get; set; }
        public string DaysValueChange { get; set; }
        public string DaysValueChangeRealtime { get; set; }
        public string StockExchange { get; set; }
        public string DividendYield { get; set; }
        public string PercentChange { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
        public string Adj_Close { get; set; }
    }





    public class YahooRootHistoricalPrices
    {
        public QueryHistoricalPrices query { get; set; }
    }

    public class QueryHistoricalPrices
    {
        public int count { get; set; }
        public DateTime created { get; set; }
        public string lang { get; set; }
        public ResultsHistoricalPrices results { get; set; }
    }

    public class ResultsHistoricalPrices
    {
        public HistoricalPrice[] quote { get; set; }
    }


    public class YahooRootHistoricalPrice
    {
        public QueryHistoricalPrice query { get; set; }
    }

    public class QueryHistoricalPrice
    {
        public int count { get; set; }
        public DateTime created { get; set; }
        public string lang { get; set; }
        public ResultsHistoricalPrice results { get; set; }
    }

    public class ResultsHistoricalPrice
    {
        public HistoricalPrice quote { get; set; }
    }

    public class HistoricalPrice
    {
        public string Symbol { get; set; }
        public string Date { get; set; }
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
        public string Volume { get; set; }
        public string Adj_Close { get; set; }
    }

}




