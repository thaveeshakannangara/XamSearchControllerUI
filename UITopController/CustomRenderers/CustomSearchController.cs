using System.Collections;
using System.Windows.Input;
using Xamarin.Forms;

namespace UITopController.CustomRenderers
{
	public class CustomSearchController : StackLayout
	{
		private CustomEntry _entry;
		private Label _searchIcon;
		private Label _arrowIcon;
		private BoxView _boxView;
		private Frame _frame;
		private CustomPicker _picker;
		private static Color defaultTextColor = Color.FromHex("#f3f9f9");
		private static Color defaultInnerBackgroundColor = Color.FromHex("#2361ae");

		public static readonly BindableProperty FilterPlaceholderProperty =
			BindableProperty.Create(nameof(FilterPlaceholder), typeof(string), typeof(CustomSearchController), defaultValue: "Filter Options", defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (bo, ov, nv) => (bo as CustomSearchController).UpdateText());

		public static readonly BindableProperty SearchPlaceholderProperty =
			BindableProperty.Create(nameof(SearchPlaceholder), typeof(string), typeof(CustomSearchController), defaultValue: "search", defaultBindingMode: BindingMode.TwoWay,
				propertyChanged: (bo, ov, nv) => (bo as CustomSearchController).UpdateText());

		public static readonly BindableProperty InnerBackgroundColorProperty =
			BindableProperty.Create(nameof(InnerBackgroundColor), typeof(Color), typeof(CustomSearchController), defaultValue: defaultInnerBackgroundColor,
				propertyChanged: (bo, ov, nv) => (bo as CustomSearchController).UpdateColors());

		public static readonly BindableProperty SeperatorColorProperty =
			BindableProperty.Create(nameof(SeperatorColor), typeof(Color), typeof(CustomSearchController), defaultValue: defaultTextColor,
				propertyChanged: (bo, ov, nv) => (bo as CustomSearchController).UpdateColors());

		public static readonly BindableProperty FilterPlaceholderColorProperty =
			BindableProperty.Create(nameof(FilterPlaceholderColor), typeof(Color), typeof(CustomSearchController), defaultValue: defaultTextColor,
				propertyChanged: (bo, ov, nv) => (bo as CustomSearchController).UpdateColors());

		public static readonly BindableProperty FilterTextColorProperty =
			BindableProperty.Create(nameof(FilterTextColor), typeof(Color), typeof(CustomSearchController), defaultValue: defaultTextColor,
				propertyChanged: (bo, ov, nv) => (bo as CustomSearchController).UpdateColors());

		public static readonly BindableProperty SearchPlaceholderColorProperty =
			BindableProperty.Create(nameof(SearchPlaceholderColor), typeof(Color), typeof(CustomSearchController), defaultValue: defaultTextColor,
				propertyChanged: (bo, ov, nv) => (bo as CustomSearchController).UpdateColors());

		public static readonly BindableProperty SearchTextColorProperty =
			BindableProperty.Create(nameof(SearchTextColor), typeof(Color), typeof(CustomSearchController), defaultValue: defaultTextColor,
				propertyChanged: (bo, ov, nv) => (bo as CustomSearchController).UpdateColors());

		public static readonly BindableProperty SearchIconColorProperty =
			BindableProperty.Create(nameof(SearchIconColor), typeof(Color), typeof(CustomSearchController), defaultValue: defaultTextColor,
				propertyChanged: (bo, ov, nv) => (bo as CustomSearchController).UpdateColors());

		public static readonly BindableProperty ArrowIconColorProperty =
			BindableProperty.Create(nameof(ArrowIconColor), typeof(Color), typeof(CustomSearchController), defaultValue: defaultTextColor,
				propertyChanged: (bo, ov, nv) => (bo as CustomSearchController).UpdateColors());

		public static readonly BindableProperty SearchTextProperty =
			BindableProperty.Create(nameof(SearchText), typeof(string), typeof(CustomSearchController), default(string), defaultBindingMode: BindingMode.TwoWay);

		public static readonly BindableProperty ItemsSourceProperty =
			BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(CustomSearchController), default(IList),
				propertyChanged: (bo, ov, nv) => (bo as CustomSearchController).OnItemsSourceChanged(ov, nv));

		public static readonly BindableProperty SearchCommandProperty =
			BindableProperty.Create(nameof(SearchCommand), typeof(ICommand), typeof(CustomSearchController), null,
				propertyChanged: (bo, ov, nv) => (bo as CustomSearchController).SearchCommand = (ICommand)nv);

		public static readonly BindableProperty SelectionChangedCommandProperty =
			BindableProperty.Create(nameof(SelectionChangedCommand), typeof(ICommand), typeof(CustomSearchController), null,
				propertyChanged: (bo, ov, nv) => (bo as CustomSearchController).SelectionChangedCommand = (ICommand)nv);

		public static readonly BindableProperty SelectionChangedCommandParameterProperty =
			BindableProperty.Create(nameof(SelectionChangedCommandParameter), typeof(object), typeof(CustomSearchController),
				propertyChanged: (bo, ov, nv) => (bo as CustomSearchController).SelectionChangedCommandParameter = nv);

		public static readonly BindableProperty SelectedItemProperty =
			BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(CustomSearchController), null, BindingMode.TwoWay,
				propertyChanged: (bo, ov, nv) => (bo as CustomSearchController).OnSelectedItemChanged(ov, nv));

		public string FilterPlaceholder
		{
			get => (string)GetValue(FilterPlaceholderProperty);
			set => SetValue(FilterPlaceholderProperty, value);
		}

		public string SearchPlaceholder
		{
			get => (string)GetValue(SearchPlaceholderProperty);
			set => SetValue(SearchPlaceholderProperty, value);
		}

		public Color InnerBackgroundColor
		{
			get => (Color)GetValue(InnerBackgroundColorProperty);
			set => SetValue(InnerBackgroundColorProperty, value);
		}

		public Color SeperatorColor
		{
			get => (Color)GetValue(SeperatorColorProperty);
			set => SetValue(SeperatorColorProperty, value);
		}

		public Color FilterTextColor
		{
			get => (Color)GetValue(FilterTextColorProperty);
			set => SetValue(FilterTextColorProperty, value);
		}

		public Color FilterPlaceholderColor
		{
			get => (Color)GetValue(FilterPlaceholderColorProperty);
			set => SetValue(FilterPlaceholderColorProperty, value);
		}

		public Color SearchTextColor
		{
			get => (Color)GetValue(SearchTextColorProperty);
			set => SetValue(SearchTextColorProperty, value);
		}

		public Color SearchPlaceholderColor
		{
			get => (Color)GetValue(SearchPlaceholderColorProperty);
			set => SetValue(SearchPlaceholderColorProperty, value);
		}

		public Color SearchIconColor
		{
			get => (Color)GetValue(SearchIconColorProperty);
			set => SetValue(SearchIconColorProperty, value);
		}

		public Color ArrowIconColor
		{
			get => (Color)GetValue(ArrowIconColorProperty);
			set => SetValue(ArrowIconColorProperty, value);
		}

		public string SearchText
		{
			get => (string)GetValue(SearchTextProperty);
			set => SetValue(SearchTextProperty, value);
		}

		public IList ItemsSource
		{
			get => (IList)GetValue(ItemsSourceProperty);
			set => SetValue(ItemsSourceProperty, value);
		}

		public ICommand SearchCommand
		{
			get => (ICommand)GetValue(SelectionChangedCommandProperty);
			set => SetValue(SelectionChangedCommandProperty, value);
		}

		public ICommand SelectionChangedCommand
		{
			get => (ICommand)GetValue(SelectionChangedCommandProperty);
			set => SetValue(SelectionChangedCommandProperty, value);
		}

		public object SelectionChangedCommandParameter
		{
			get => GetValue(SelectionChangedCommandParameterProperty);
			set => SetValue(SelectionChangedCommandParameterProperty, value);
		}

		public object SelectedItem
		{
			get => GetValue(SelectedItemProperty);
			set => SetValue(SelectedItemProperty, value);
		}

		public CustomSearchController()
		{
			AddControls();
		}

		private void AddControls()
		{
			this.Padding = new Thickness(10, 10, 10, 10);
			this.VerticalOptions = LayoutOptions.Center;

			//Inner Frame
			_frame = new Frame()
			{
				BackgroundColor = InnerBackgroundColor,
				Padding = new Thickness(1, 1, 1, 1),
				HasShadow = false,
				CornerRadius = 7
			};

			Grid _grid = new Grid
			{
				ColumnDefinitions =
				{
					new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Auto)},
					new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star)},
					new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Auto)},
					new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Auto)},
					new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Auto)},
				}
			};

			//Search Icon
			_searchIcon = new Label()
			{
				Text = "\uf002",
				FontFamily = "FontAwesomeSolid",
				TextColor = SearchIconColor,
				FontSize = 20,
				VerticalOptions = LayoutOptions.Center,
				Margin = new Thickness(15, 0, 0, 0),
			};
			var searchGestureRecognizer = new TapGestureRecognizer();
			searchGestureRecognizer.Tapped += (sender, e) => Entry_Completed(sender, e);
			_searchIcon.GestureRecognizers.Add(searchGestureRecognizer);

			//Arrow Icon
			_arrowIcon = new Label()
			{
				Text = "\uf078",
				FontFamily = "FontAwesomeSolid",
				TextColor = ArrowIconColor,
				FontSize = 17,
				VerticalOptions = LayoutOptions.Center,
				Margin = new Thickness(0, 0, 10, 0),
			};
			var pickerGestureRecognizer = new TapGestureRecognizer();
			pickerGestureRecognizer.Tapped += (sender, e) => _picker.Focus();
			_arrowIcon.GestureRecognizers.Add(pickerGestureRecognizer);

			//Entry
			_entry = new CustomEntry()
			{
				Placeholder = SearchPlaceholder,
				PlaceholderColor = SearchPlaceholderColor,
				TextColor = SearchTextColor,
				FontSize = 16,
			};
			_entry.Completed += Entry_Completed;
			_entry.TextChanged += Entry_TextChanged;

			//Seperator
			_boxView = new BoxView()
			{
				WidthRequest = 1,
				BackgroundColor = SeperatorColor,
				Margin = new Thickness(0, 10, 0, 10)
			};

			//Filter
			_picker = new CustomPicker()
			{
				Title = FilterPlaceholder,
				TitleColor = FilterPlaceholderColor,
				TextColor = FilterTextColor,
				FontSize = 16,
				VerticalOptions = LayoutOptions.Center,
			};
			_picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

			_grid.Children.Add(_searchIcon, 0, 0);
			_grid.Children.Add(_entry, 1, 0);
			_grid.Children.Add(_boxView, 2, 0);
			_grid.Children.Add(_picker, 3, 0);
			_grid.Children.Add(_arrowIcon, 4, 0);

			_frame.Content = _grid;
			this.Children.Add(_frame);
		}

		private void Entry_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (SearchText != _entry.Text)
				SearchText = _entry.Text;
		}

		private void Entry_Completed(object sender, System.EventArgs e)
		{
			_entry.Unfocus();
			SearchCommand?.Execute(SearchText);
		}

		private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			var obj = (Picker)sender;
			SelectedItem = obj.SelectedItem;

			if (string.IsNullOrEmpty(SelectionChangedCommandParameter.ToString()))
				SelectionChangedCommand?.Execute(obj.SelectedItem);
			else
				SelectionChangedCommand?.Execute(SelectionChangedCommandParameter);
		}

		private void OnItemsSourceChanged(object oldValue, object newValue)
		{
			if ((IList)oldValue == (IList)newValue) return;

			_picker.ItemsSource = (IList)newValue;
		}

		private void OnSelectedItemChanged(object oldValue, object newValue)
		{
			if (oldValue == newValue) return;

			_picker.SelectedItem = newValue;
		}

		private void UpdateColors()
		{
			_searchIcon.TextColor = SearchIconColor;
			_arrowIcon.TextColor = ArrowIconColor;
			_entry.TextColor = SearchTextColor;
			_entry.PlaceholderColor = SearchPlaceholderColor;
			_picker.TextColor = FilterTextColor;
			_picker.TitleColor = FilterPlaceholderColor;
			_boxView.BackgroundColor = SeperatorColor;
			_frame.BackgroundColor = InnerBackgroundColor;
		}

		private void UpdateText()
		{
			_entry.Placeholder = SearchPlaceholder;
			_picker.Title = FilterPlaceholder;
		}
	}
}