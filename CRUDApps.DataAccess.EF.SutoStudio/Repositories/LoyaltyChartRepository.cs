using CRUDApps.DataAccess.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDApps.DataAccess.EF.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace CRUDApps.DataAccess.EF.Repositories
{
    public class LoyaltyChartRepository
    {
        private SutoGameStudioContext _dbContext;

        public LoyaltyChartRepository(SutoGameStudioContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(LoyaltyCharts loyaltyChart)
        {
            _dbContext.Add(loyaltyChart);
            _dbContext.SaveChanges();

            return loyaltyChart.LoyaltyChartId;
        }

        public int Update(LoyaltyCharts loyaltyChart)
        {
            LoyaltyCharts existingLoyalty = _dbContext.LoyaltyCharts.Find(loyaltyChart.LoyaltyChartId);

            existingLoyalty.UserName = loyaltyChart.UserName;
            existingLoyalty.OwnFpsblastGame = loyaltyChart.OwnFpsblastGame;
            existingLoyalty.OwnMmoslasherGame = loyaltyChart.OwnMmoslasherGame;
            existingLoyalty.OwnRpgstoryMakerGame = loyaltyChart.OwnRpgstoryMakerGame;
            existingLoyalty.IsLoyalCustomer = loyaltyChart.IsLoyalCustomer;

            _dbContext.SaveChanges();

            return existingLoyalty.LoyaltyChartId;
        }

        public bool Delete(int loyaltyChartId)
        {
            LoyaltyCharts loyaltyChart = _dbContext.LoyaltyCharts.Find(loyaltyChartId);
            _dbContext.Remove(loyaltyChart);
            _dbContext.SaveChanges();

            return true;
        }

        public List<LoyaltyCharts> GetAllLoyaltyCharts()
        {
            List<LoyaltyCharts> loyaltyCharts = _dbContext.LoyaltyCharts.ToList();

            return loyaltyCharts;
        }

        public LoyaltyCharts GetLoyaltyChartByID(int loyaltyChartID)
        {
            LoyaltyCharts loyaltyChart = _dbContext.LoyaltyCharts.Find(loyaltyChartID);

            return loyaltyChart;
        }
    }
}
