using System;
using System.Collections.Generic;
using PuzzlersJordan.Common;
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
            Device.OpenUri(new Uri(Constants.FacebookUrl));
		}
		public void youtube_clicked(object sender, EventArgs e)
		{
            Device.OpenUri(new Uri(Constants.YoutubeUrl));
		}
		public void twitter_clicked(object sender, EventArgs e)
		{
            Device.OpenUri(new Uri(Constants.TwitterUrl));
		}
		public void phone_clicked(object sender, EventArgs e)
		{
			Device.OpenUri(new Uri("tel:+962799892728"));
		}
	}
}
