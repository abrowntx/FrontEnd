﻿#pragma checksum "..\..\NumberGen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3A78D5D977C125587AB0559B7CD387F87F79D7C5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FrontEndMain;
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


namespace FrontEndMain {
    
    
    /// <summary>
    /// NumberGen
    /// </summary>
    public partial class NumberGen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\NumberGen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbMatches;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\NumberGen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbQB_Copy;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\NumberGen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lPrefix;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\NumberGen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lBase;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\NumberGen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lSuffix;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\NumberGen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbExists;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\NumberGen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelect;
        
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
            System.Uri resourceLocater = new System.Uri("/FrontEndMain;component/numbergen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NumberGen.xaml"
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
            this.lbMatches = ((System.Windows.Controls.ListBox)(target));
            
            #line 17 "..\..\NumberGen.xaml"
            this.lbMatches.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbMatches_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbQB_Copy = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\NumberGen.xaml"
            this.tbQB_Copy.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Grid_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lPrefix = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.lBase = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.lSuffix = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.lbExists = ((System.Windows.Controls.ListBox)(target));
            
            #line 36 "..\..\NumberGen.xaml"
            this.lbExists.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbExists_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnSelect = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\NumberGen.xaml"
            this.btnSelect.Click += new System.Windows.RoutedEventHandler(this.btnSelect_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

