﻿#pragma checksum "..\..\CountryProizvodstvaOkno.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F75BAEA904AF38522FF4DF5CE0F27F0D1845D32C504AE1FE1F5B9D6C03294D8B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Laba5;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Laba5 {
    
    
    /// <summary>
    /// CountryProizvodstvaOkno
    /// </summary>
    public partial class CountryProizvodstvaOkno : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\CountryProizvodstvaOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid countryProizDG;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\CountryProizvodstvaOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackBtm;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\CountryProizvodstvaOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtm;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\CountryProizvodstvaOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditBtm;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\CountryProizvodstvaOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteBtm;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\CountryProizvodstvaOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CountryProizTbox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\CountryProizvodstvaOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock OshibkaTBlock;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\CountryProizvodstvaOkno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button VigruzkaBtm;
        
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
            System.Uri resourceLocater = new System.Uri("/Laba5;component/countryproizvodstvaokno.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CountryProizvodstvaOkno.xaml"
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
            this.countryProizDG = ((System.Windows.Controls.DataGrid)(target));
            
            #line 16 "..\..\CountryProizvodstvaOkno.xaml"
            this.countryProizDG.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.countryProizDG_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BackBtm = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\CountryProizvodstvaOkno.xaml"
            this.BackBtm.Click += new System.Windows.RoutedEventHandler(this.BackBtm_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddBtm = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\CountryProizvodstvaOkno.xaml"
            this.AddBtm.Click += new System.Windows.RoutedEventHandler(this.AddBtm_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EditBtm = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\CountryProizvodstvaOkno.xaml"
            this.EditBtm.Click += new System.Windows.RoutedEventHandler(this.EditBtm_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DeleteBtm = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\CountryProizvodstvaOkno.xaml"
            this.DeleteBtm.Click += new System.Windows.RoutedEventHandler(this.DeleteBtm_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CountryProizTbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.OshibkaTBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.VigruzkaBtm = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\CountryProizvodstvaOkno.xaml"
            this.VigruzkaBtm.Click += new System.Windows.RoutedEventHandler(this.VigruzkaBtm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

