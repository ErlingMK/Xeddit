﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xeddit.Views.Comments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentsBackView : ContentView
    {
        public CommentsBackView()
        {
            InitializeComponent();
        }
    }
}