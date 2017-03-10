using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PuzzlersJordan
{
	public partial class ContactUsPage : ContentPage
	{
		public ContactUsPage()
		{
			InitializeComponent();
		}

		public void facebook_clicked(object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("https://www.facebook.com/PuzzlersJordan"));
		}
		public void youtube_clicked(object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("https://www.youtube.com/user/puzzlersjo"));
		}
		public void twitter_clicked(object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("https://twitter.com/Puzzlersjordan"));
		}
		public void phone_clicked(object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("tel:+962799892728"));
		}
	}
}
