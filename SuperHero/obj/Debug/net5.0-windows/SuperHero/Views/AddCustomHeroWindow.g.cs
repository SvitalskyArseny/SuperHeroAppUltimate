#pragma checksum "..\..\..\..\..\SuperHero\Views\AddCustomHeroWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5A07EFA0D139DE979D68A1310F298225CB811E5D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using SuperHero.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace SuperHero.Views {
    
    
    /// <summary>
    /// AddCustomHeroWindow
    /// </summary>
    public partial class AddCustomHeroWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\..\SuperHero\Views\AddCustomHeroWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SuperHero.Views.AddCustomHeroWindow CustomHeroCreation;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\SuperHero\Views\AddCustomHeroWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox heroName;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\SuperHero\Views\AddCustomHeroWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox heroBiography;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\SuperHero\Views\AddCustomHeroWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider heroIntelligence;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\SuperHero\Views\AddCustomHeroWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider heroSpeed;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\SuperHero\Views\AddCustomHeroWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider heroPower;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.14.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SuperHero;component/superhero/views/addcustomherowindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\SuperHero\Views\AddCustomHeroWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.14.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CustomHeroCreation = ((SuperHero.Views.AddCustomHeroWindow)(target));
            return;
            case 2:
            this.heroName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.heroBiography = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.heroIntelligence = ((System.Windows.Controls.Slider)(target));
            return;
            case 5:
            this.heroSpeed = ((System.Windows.Controls.Slider)(target));
            return;
            case 6:
            this.heroPower = ((System.Windows.Controls.Slider)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

