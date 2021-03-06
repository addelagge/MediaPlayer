﻿#pragma checksum "..\..\SlideShowPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3A42A174DCB444BF94C2B21D4E75EC52"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MediaPlayerApp {
    
    
    /// <summary>
    /// SlideShowPage
    /// </summary>
    public partial class SlideShowPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\SlideShowPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuAddFileToSlideShow;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\SlideShowPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView tree;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\SlideShowPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox picsPanel;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\SlideShowPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxAlbum;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\SlideShowPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddMedia;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\SlideShowPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemove;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\SlideShowPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUpdateInterval;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\SlideShowPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateSlideShow;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\SlideShowPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgPreview;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MediaPlayer;component/slideshowpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SlideShowPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.mnuAddFileToSlideShow = ((System.Windows.Controls.MenuItem)(target));
            
            #line 24 "..\..\SlideShowPage.xaml"
            this.mnuAddFileToSlideShow.Click += new System.Windows.RoutedEventHandler(this.mnuAddFileToSlideShow_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tree = ((System.Windows.Controls.TreeView)(target));
            return;
            case 3:
            this.picsPanel = ((System.Windows.Controls.ListBox)(target));
            
            #line 41 "..\..\SlideShowPage.xaml"
            this.picsPanel.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.picsPanel_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lbxAlbum = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.btnAddMedia = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\SlideShowPage.xaml"
            this.btnAddMedia.Click += new System.Windows.RoutedEventHandler(this.btnAddMedia_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnRemove = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\SlideShowPage.xaml"
            this.btnRemove.Click += new System.Windows.RoutedEventHandler(this.btnRemove_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtUpdateInterval = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnCreateSlideShow = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\SlideShowPage.xaml"
            this.btnCreateSlideShow.Click += new System.Windows.RoutedEventHandler(this.btnCreateSlideShow_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.imgPreview = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

