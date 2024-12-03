using System;
using LiveCharts;
using LiveCharts.Wpf;
using MahAppBase.Command;

namespace MahAppBase.ViewModel
{
    public class MainComponent:ViewModelBase
    {
		#region Declarations
		private int _TargetCount = 0;
		private int _Game1Count = 0;
		private int _Game2Count = 0;
		private int _Game3Count = 0;
		private int _Game4Count = 0;
		private int _Game5Count = 0;
		private int _Game6Count = 0;
		private int _Game7Count = 0;
		private int _Game8Count = 0;
		private int _Game9Count = 0;
		private int _Game10Count = 0;
		private int _Game11Count = 0;
		private int _Game12Count = 0;
		private int _Game13Count = 0;
		private int _Game14Count = 0;
		private int _Game15Count = 0;
		private double _CurrentPercent = 0.0;

		#endregion

		#region Property
		/// <summary>
		/// chart data
		/// </summary>
		public SeriesCollection SeriesCollection { get; set; }
		
		/// <summary>
		/// chart label
		/// </summary>
		public string[] Labels { get; set; }

		/// <summary>
		/// 非目標牌數量
		/// </summary>
		public int NonTargetCards { get; set; }

		/// <summary>
		/// 目標牌數量
		/// </summary>
		public int TargetCards { get; set; } = 8;
		/// <summary>
		/// 總共剩餘牌數
		/// </summary>
		public int TotalCards { get; set; } = 15;

		/// <summary>
		/// 自己有的目標牌數量
		/// </summary>
		public int TargetCount
		{
			get
			{
				return _TargetCount;
			}
			set
			{
				if(value != 0) 
				{
					_TargetCount = value;
					// 目標牌數(所有牌-自己有的)
					TargetCards -= TargetCount;
					// 非目標牌數
					NonTargetCards = TotalCards - TargetCards;
					OnPropertyChanged();
				}
			}
		}
		public NoParameterCommand ResetCommand { get; set; }
		
		/// <summary>
		/// 第一局出牌數
		/// </summary>
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

		/// <summary>
		/// 目前出牌都是目標牌的機率
		/// </summary>
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
		public LineSeries data { get; set; }
		public MainComponent()
        {
			Init();
		}

		

		public void Init() 
		{
			CurrentPercent = (double)1 / 20;
			InitCommand();
			InitChartData();
		}

		private void InitChartData()
		{
			try 
			{
				data = new LineSeries
				{
					Title = "Percentage",
					Values = new ChartValues<double> { 1, 5, 7, 3, 2 }
				};
				SeriesCollection = new SeriesCollection
				{
					data
				};

				Labels = new[] { "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8", "G9", "G10", "G11", "G12", "G13", "G14", "G15" };
				data.Values.Clear();
			}
			catch(Exception ex) 
			{

			}
		}

		public void InitCommand() 
		{
			ResetCommand = new NoParameterCommand(ResetCommandAction);
		}

		private void ResetCommandAction()
		{
			TargetCount = 0;
			data.Values.Clear();
			TargetCards = 0;
			NonTargetCards = 0;
			Game1Count = 0;
			Game2Count = 0;
			Game3Count = 0;
			Game4Count = 0;
			Game5Count = 0;
			Game6Count = 0;
			Game7Count = 0;
			Game8Count = 0;
			Game9Count = 0;
			Game10Count = 0;
			Game11Count = 0;
			Game12Count = 0;
			Game13Count = 0;
			Game14Count = 0;
			Game15Count = 0;
		}

		/// <summary>
		/// 計算目前出牌可能的機率
		/// </summary>
		/// <param name="Count">目前的人出牌數</param>
		public void Calculate(int Count) 
		{
			if (Count == 0)
				return;

			try 
			{
				TotalCards -= 3;
				// 計算各種情況的機率
				for (int k = 0; k <= Count; k++)
				{
					if (k > TargetCards || (Count - k) > NonTargetCards)
						continue; // 若超出可能範圍，跳過計算

					double probability = (double)(Combination(TargetCards, k) * Combination(NonTargetCards, Count - k))
										  / Combination(TotalCards, Count);
					if (probability > 1) 
					{
						CurrentPercent = 1.0;
						data.Values.Add(1.0);
					}
					else 
					{
						CurrentPercent = probability;
						data.Values.Add(probability);
					}
				}
			}
			catch(Exception ex) 
			{
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
		#endregion
	}
}