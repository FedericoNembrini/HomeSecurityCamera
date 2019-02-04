﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeSecurityApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StreamListManagement : ContentPage
	{
        public ObservableCollection<string> StreamUrl = new ObservableCollection<string>();
        private string Key = "StreamUrl_";
        private int CounterUrl = 0;

		public StreamListManagement ()
		{
			InitializeComponent ();
            LoadStreamList();
		}

        private void LoadStreamList()
        {
            //int counter = 0;
            //string stringTemp;

            //while(Preferences.ContainsKey(Key + Convert.ToString(counter)))
            //{
            //    stringTemp = Preferences.Get(Key + Convert.ToString(counter), string.Empty);
            //    if(!string.IsNullOrEmpty(stringTemp))
            //    {
            //        StreamUrl.Add(stringTemp);
            //    }
            //    counter++;
            //}
            //CounterUrl = counter;
            StreamUrl.Add("rtsp://184.72.239.149/vod/mp4:BigBuckBunny_175k.mov");
            StreamUrl.Add("rtsp://184.72.239.149/vod/mp4:BigBuckBunny_175k.mov");
            StreamUrl.Add("rtsp://184.72.239.149/vod/mp4:BigBuckBunny_175k.mov");
            streamList.ItemsSource = StreamUrl;
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            string itemElements = (sender as MenuItem).CommandParameter.ToString();
            int counter = StreamUrl.IndexOf(itemElements);

            //Preferences.Set(Key + Convert.ToString(counter), string.Empty);

            do
            {
                Preferences.Set(Key + Convert.ToString(counter), Preferences.Get(Key + Convert.ToString(counter + 1), string.Empty));
                counter++;
            }
            while (Preferences.ContainsKey(Key + Convert.ToString(counter + 1)));

            StreamUrl.Remove((sender as MenuItem).CommandParameter.ToString());
        }

        private void StreamList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            //string key = "StreamUrl_";
            //if(!string.IsNullOrEmpty(entryUrl.Text))
            //    Preferences.Set(key + CounterUrl, entryUrl.Text);
            StreamUrl.Add(entryUrl.Text);
            entryUrl.Text = string.Empty;
        }
    }
}