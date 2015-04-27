﻿using TheGapFillers.Portrack.Models.Application;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace TheGapFillers.Portrack.Repositories.Application
{
	public class ApplicationRepository : IApplicationRepository
	{
		private ApplicationDbContext _context;


		public ApplicationRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<int> SaveAsync()
		{
			int count = await _context.SaveChangesAsync();
			return count;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_context != null)
					_context.Dispose();
			}
		}


		public async Task<ICollection<Portfolio>> GetPortfoliosAsync(string userName, IEnumerable<string> portfolioNames = null, bool includeHoldings = false, bool includeTransactions = false)
		{
			IQueryable<Portfolio> query = _context.Portfolios;

			if (includeHoldings)
				query = query
					.Include(p => p.PortfolioHolding)
					.Include(p => p.PortfolioHolding.Instrument)
					.Include(p => p.PortfolioHolding.Children)
					.Include(p => p.PortfolioHolding.Children.Select(h => h.Instrument));

			if (includeTransactions)
				query = query
					.Include(p => p.PortfolioHolding.Transactions)
					.Include(p => p.PortfolioHolding.Children.Select(h => h.Transactions));

			query = query
				.Where(p => p.UserName.Equals(userName));

			if (portfolioNames != null && portfolioNames.Any())
				query = query.Where(p => portfolioNames.Contains(p.PortfolioName));

			return await query.ToListAsync<Portfolio>();
		}

		public async Task<Portfolio> GetPortfolioAsync(string userName, string portfolioName, bool includeHoldings = false, bool includeTransactions = false)
		{
			IEnumerable<string> portfolioNames = new List<string> { portfolioName };
			return (await GetPortfoliosAsync(userName, portfolioNames, includeHoldings, includeTransactions)).SingleOrDefault();
		}

		public async Task<Portfolio> AddPortfolio(Portfolio portfolio)
		{
			if (await GetPortfolioAsync(portfolio.UserName, portfolio.PortfolioName) != null)
				throw new PortfolioException(
					string.Format("Portfolio '{0}' | '{1}' exists already.", portfolio.UserName, portfolio.PortfolioName));

			return _context.Portfolios.Add(portfolio);
		}

		public async Task<Portfolio> DeletePortfolioAsync(string userName, string portfolioName)
		{
			Portfolio portfolio = await GetPortfolioAsync(userName, portfolioName);
			Portfolio deletedPortfolio = _context.Portfolios.Remove(portfolio);

			return deletedPortfolio;
		}

		public async Task<ICollection<Holding>> GetHoldingsAsync(string userName, string portfolioName, IEnumerable<string> tickers = null, bool includeChildren = false, bool includeTransactions = false)
		{
			IQueryable<Holding> query = _context.Holdings.Include(h => h.Instrument);

			if (includeChildren)
				query = query.Include(h => h.Children);

			if (includeTransactions)
				query = query
					.Include(h => h.Transactions)
					.Include(h => h.Children.Select(ch => ch.Transactions));

			query = query
				.Include(h => h.Portfolio)
				.Include(h => h.Instrument)
				.Where(h => 
					h.Portfolio.UserName.Equals(userName)
					&& h.Portfolio.PortfolioName.Equals(portfolioName));

			if (tickers != null && tickers.Any())
				query = query.Where(h => tickers.Contains(h.Instrument.Ticker));

			return await query.ToListAsync<Holding>();
		}

		public Holding AddHolding(Holding holding)
		{
			return _context.Holdings.Add(holding);
		}

		public Holding DeleteHoldingAsync(Holding holding)
		{
			return _context.Holdings.Remove(holding);
		}

		public async Task<ICollection<Transaction>> GetTransactionsAsync(string userName, IEnumerable<string> portfolioNames = null, IEnumerable<string> tickers = null)
		{
			var query = _context.Transactions
				.Where(t => t.Holding.Portfolio.UserName.Equals(userName));

			if (portfolioNames != null && portfolioNames.Any())
				query = query.Where(t => portfolioNames.Contains(t.PortfolioName));

			if (tickers != null && tickers.Any())
				query = query.Where(t => tickers.Contains(t.Ticker));

			return await query.ToListAsync<Transaction>();
		}

		public Task<ICollection<Transaction>> GetTransactionsAsync(string userName, string portfolioName, IEnumerable<string> tickers = null)
		{
			IEnumerable<string> portfolioNames = new List<string> { portfolioName };
			return GetTransactionsAsync(userName, portfolioNames, tickers);
		}


		public Transaction AddTransaction(Transaction transaction)
		{
			return _context.Transactions.Add(transaction);
		}

		public async Task<Transaction> RemoveLastTransactionAsync(string userName, string portfolioName)
		{
			Transaction transaction = await _context.Transactions.OrderByDescending(t => t.Date)
				.FirstOrDefaultAsync<Transaction>(t =>
				t.Holding.Portfolio.UserName.Equals(userName)
				&& t.PortfolioName.Equals(portfolioName));

			Transaction deletedTransaction = _context.Transactions.Remove(transaction);

			return deletedTransaction;
		}

		public async Task<Transaction> RemoveLastTransactionAsync(string userName, string portfolioName, string ticker)
		{
			Transaction transaction = await _context.Transactions.OrderByDescending(t => t.Date)
				.FirstOrDefaultAsync<Transaction>(t => 
				t.Holding.Portfolio.UserName.Equals(userName)
				&& t.PortfolioName.Equals(portfolioName)
				&& t.Ticker.Equals(ticker));

			Transaction deletedTransaction = _context.Transactions.Remove(transaction);

			return deletedTransaction;
		}


		public async Task<ICollection<Instrument>> GetInstrumentsAsync(IEnumerable<string> tickers = null)
		{
			IQueryable<Instrument> query = _context.Instruments;

			if (tickers != null && tickers.Any())
				query = query.Where(i => tickers.Contains(i.Ticker));

			return await query.ToListAsync();
		}

		public async Task<Instrument> GetInstrumentAsync(string ticker)
		{
			IEnumerable<string> tickers = new List<string> { ticker };
			return (await GetInstrumentsAsync(tickers)).SingleOrDefault();
		}


		public Instrument AddInstrument(Instrument instrument)
		{
			return _context.Instruments.Add(instrument);
		}

		public Instrument DeleteInstrument(Instrument instrument)
		{
			Instrument deletedInstrument = _context.Instruments.Remove(instrument);

			return deletedInstrument;
		}	
	}
}