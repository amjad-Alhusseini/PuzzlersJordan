using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PuzzlersJordan
{
	public class MasterPageItem
	{
		public string Title { get; set;}
		public Type TargetType { get; set; }

	}

	public partial class MasterPage : ContentPage
	{

		public ListView masterMenuList
		{
			get
			{
				return MenuListView;
			}
		}

		public MasterPage()
		{
			InitializeComponent();
			var masterPageItems = new List<MasterPageItem>();

			masterPageItems.Add(new MasterPageItem
			{
				Title = "Home",
				TargetType = typeof(HomePage)
			});

			masterPageItems.Add(new MasterPageItem
			{
				Title = "Products",
				TargetType = typeof(ProductsPage)
			});

			masterPageItems.Add(new MasterPageItem
			{
				Title = "Contact us",
				TargetType = typeof(ContactUsPage)
			});

			MenuListView.ItemsSource = masterPageItems;
		}
	}
}
