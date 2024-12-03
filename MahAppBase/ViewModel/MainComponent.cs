using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MahAppBase.Command;
using MahAppBase.CustomerUserControl;

namespace MahAppBase.ViewModel
{
    public class MainComponent:ViewModelBase
    {
		#region Declarations
		private int _Game1Count;
		private int _Game2Count;
		private int _Game3Count;
		private int _Game4Count;
		private int _Game5Count;
		private int _Game6Count;
		private int _Game7Count;
		private int _Game8Count;
		private int _Game9Count;
		private int _Game10Count;
		private int _Game11Count;
		private int _Game12Count;
		private int _Game13Count;
		private int _Game14Count;
		private int _Game15Count;
		private double _CurrentPercent;

		ucDonate donate = new ucDonate();
		#endregion

		#region Property
		private int _TargetCount = 0;
		public int TargetCount
		{
			get
			{
				return _TargetCount;
			}
			set
			{
				_TargetCount = value;
				CalculatePercent();
				OnPropertyChanged();
			}
		}
		public NoParameterCommand ButtonDonateClick { get; set; }
        public bool DonateIsOpen { get; set; }

		
		public int Game1Count
		{
			get
			{
				return _Game1Count;
			}
			set
			{
				_Game1Count = value;
				Calculate(value);
				OnPropertyChanged();
			}
		}

		public int Game2Count
		{
			get
			{
				return _Game2Count;
			}
			set
			{
				_Game2Count = value;
				Calculate(value);
				OnPropertyChanged();
			}
		}
		public int Game3Count
		{
			get
			{
				return _Game3Count;
			}
			set
			{
				_Game3Count = value;
				Calculate(value);
				OnPropertyChanged();
			}
		}
		public int Game4Count
		{
			get
			{
				return _Game4Count;
			}
			set
			{
				_Game4Count = value;
				Calculate(value);
				OnPropertyChanged();
			}
		}
		public int Game5Count
		{
			get
			{
				return _Game5Count;
			}
			set
			{
				_Game5Count = value;
				Calculate(value);
				OnPropertyChanged();
			}
		}
		public int Game6Count
		{
			get
			{
				return _Game6Count;
			}
			set
			{
				_Game6Count = value;
				Calculate(value);
				OnPropertyChanged();
			}
		}
		public int Game7Count
		{
			get
			{
				return _Game7Count;
			}
			set
			{
				_Game7Count = value;
				Calculate(value);
				OnPropertyChanged();
			}
		}
		public int Game8Count
		{
			get
			{
				return _Game8Count;
			}
			set
			{
				_Game8Count = value;
				Calculate(value);
				OnPropertyChanged();
			}
		}
		public int Game9Count
		{
			get
			{
				return _Game9Count;
			}
			set
			{
				_Game9Count = value;
				Calculate(value);
				OnPropertyChanged();
			}
		}
		public int Game10Count
		{
			get
			{
				return _Game10Count;
			}
			set
			{
				_Game10Count = value;
				Calculate(value);
				OnPropertyChanged();
			}
		}
		public int Game11Count
		{
			get
			{
				return _Game11Count;
			}
			set
			{
				_Game11Count = value;
				Calculate(value);
				OnPropertyChanged();
			}
		}
		public int Game12Count
		{
			get
			{
				return _Game12Count;
			}
			set
			{
				_Game12Count = value;
				Calculate(value);
				OnPropertyChanged();
			}
		}
		public int Game13Count
		{
			get
			{
				return _Game13Count;
			}
			set
			{
				_Game13Count = value;
				Calculate(value);
				OnPropertyChanged();
			}
		}
		

		public int Game14Count
		{
			get
			{
				return _Game14Count;
			}
			set
			{
				_Game14Count = value;
				Calculate(value);
				OnPropertyChanged();
			}
		}
		public int Game15Count
		{
			get
			{
				return _Game15Count;
			}
			set
			{
				_Game15Count = value;
				Calculate(value);
				OnPropertyChanged();
			}
		}

		public double CurrentPercent
		{
			get
			{
				return _CurrentPercent;
			}
			set
			{
				_CurrentPercent = value;
				OnPropertyChanged();
			}
		}
		#endregion

		#region MemberFunction
		public MainComponent()
        {
			CurrentPercent = (double)1 / 20;
		}

		public void CalculatePercent() 
		{
			CurrentPercent = (double)(20 - TargetCount) / 20;
		}


		int totalCards = 15; // 總共剩餘牌數
		
		public void Calculate(int Count) 
		{
			// 目標牌數(所有牌-自己有的)
			int targetCards = 8 - TargetCount;
			// 非目標牌數
			int nonTargetCards = totalCards - targetCards;
			// 目前的人出牌數
			int drawCount = Count; 

			// 計算各種情況的機率
			for (int k = 0; k <= drawCount; k++)
			{
				if (k > targetCards || (drawCount - k) > nonTargetCards)
					continue; // 若超出可能範圍，跳過計算

				double probability = (double)(Combination(targetCards, k) * Combination(nonTargetCards, drawCount - k))
									  / Combination(totalCards, drawCount);
				CurrentPercent = probability;
			}
		}

		static long Combination(int n, int r)
		{
			if (r > n) return 0;
			if (r == 0 || r == n) return 1;
			long result = 1;
			for (int i = 1; i <= r; i++)
			{
				result *= n--;
				result /= i;
			}
			return result;
		}

		private void Donate_Closed(object sender, EventArgs e)
        {
            DonateIsOpen = false;
        }

        #endregion
    }
}