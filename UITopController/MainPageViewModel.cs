using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace UITopController
{
	public class MainPageViewModel : BaseViewModel
	{
		private string searchText;
		private string selectedFilter;
		private List<string> filterList;

		public List<string> FilterList
		{
			get => filterList;
			set
			{
				if (filterList == value) return;
				filterList = value;
				RaisePropertyChanged(() => FilterList);
			}
		}

		public string SearchText
		{
			get => searchText;
			set
			{
				if (searchText == value) return;
				searchText = value;
				RaisePropertyChanged(() => SearchText);
			}
		}

		public string SelectedFilter
		{
			get => selectedFilter;
			set
			{
				if (selectedFilter == value) return;
				selectedFilter = value;
				RaisePropertyChanged(() => SelectedFilter);
			}
		}

		public ICommand SearchCommand => new Command((sender) => SearchChangedAsync(sender));
		public ICommand FilterChangingCommand => new Command((sender) => FilterChangedAsync(sender));

		public MainPageViewModel()
		{
			selectedFilter = string.Empty;
			searchText = string.Empty;
			filterList = new List<string>();
			InitFilterList();
		}

		private void InitFilterList()
		{
			FilterList.Add("Date");
			FilterList.Add("Name");
			FilterList.Add("IG No");
			FilterList.Add("NIC");
			FilterList.Add("Licenese");
		}

		private void SearchChangedAsync(object sender)
		{
		}

		private void FilterChangedAsync(object sender)
		{
		}
	}
}