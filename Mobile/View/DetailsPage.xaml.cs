﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Mobile.View
{
    public partial class DetailsPage : BasePage
    {
        public DetailsPage()
        {
            InitializeComponent();
			NavigationPage.SetTitleIcon(this, "icon.png");
        }
    }
}
