using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PuzzlersJordan
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();
			masterPage.masterMenuList.ItemSelected += OnItemSelected;
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterPageItem;
			if (item != null)
			{
				Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
				masterPage.masterMenuList.SelectedItem = null;
				IsPresented = false;
			}
		}
	}
}
