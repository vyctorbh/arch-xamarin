﻿using Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.View
{
    public partial class AboutPage : BasePage
    {
        public AboutPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
			NavigationPage.SetTitleIcon(this, "icon.png");
        }
    }
}
