﻿using CRUDApps.DataAccess.EF.Context;
using CRUDApps.DataAccess.EF.Models;
using CRUDApps.DataAccess.EF.Repositories;


namespace MVCSutoGameStudioAPP.Models
{
    public class LoyaltyChartViewModel
    {
        private readonly LoyaltyChartRepository _repo;

        public List<LoyaltyCharts> LoyaltyChartsList { get; set; }
        public LoyaltyCharts CurrentLoyaltyChart { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }

        public LoyaltyChartViewModel(SutoGameStudioContext context)
        {
            _repo = new LoyaltyChartRepository(context);
            LoyaltyChartsList = GetAllLoyaltyCharts();
            CurrentLoyaltyChart = LoyaltyChartsList.FirstOrDefault();
        }

        public LoyaltyChartViewModel(SutoGameStudioContext context, int loyaltyChartId)
        {
            _repo = new LoyaltyChartRepository(context);
            LoyaltyChartsList = GetAllLoyaltyCharts();

            if (loyaltyChartId >0)
            {
                CurrentLoyaltyChart = GetLoyaltyChartByID(loyaltyChartId);
            }
            else
            {
                CurrentLoyaltyChart = new LoyaltyCharts();
            }
        }

        public void SaveLoyaltyChart(LoyaltyCharts loyaltyChart)
        {
            if (loyaltyChart.LoyaltyChartId > 0)
            {
                _repo.Update(loyaltyChart);
            }
            else
            {
                loyaltyChart.LoyaltyChartId = _repo.Create(loyaltyChart);
            }

            LoyaltyChartsList = GetAllLoyaltyCharts();
            CurrentLoyaltyChart = LoyaltyChartsList.FirstOrDefault();
        }

        public void RemoveLoyaltyChart(int loyaltyChartId)
        {
            _repo.Delete(loyaltyChartId);
            LoyaltyChartsList = GetAllLoyaltyCharts();
            CurrentLoyaltyChart = LoyaltyChartsList.FirstOrDefault();
        }

        public List<LoyaltyCharts> GetAllLoyaltyCharts()
        {
            return _repo.GetAllLoyaltyCharts();
        }

        public LoyaltyCharts GetLoyaltyChartByID(int loyaltyChartId)
        {
            return _repo.GetLoyaltyChartByID(loyaltyChartId);
        }
    }
}