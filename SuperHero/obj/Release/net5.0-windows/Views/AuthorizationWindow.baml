   M S B A M L   `   `   `  ???? D  @SuperHero, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SuperHero.ViewsSuperHero.Views  )    #SuperHero.Views.AuthorisationWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  )localclr-namespace:SuperHero.Views  ???#EBEBEB  ? WindowStartupLocation$  CenterScreen=? ? 
ResizeMode$ NoResize=? ? Title$ Авторизация??$	??350??$	??400??.???? .+??? ???#434343 ?? Padding$ 15q?._??? $??Авторизация??
???????$??Center=?$??22(???  ?? CornerRadius$ 10?????#F6F6F6$
 10 5q?$??70 25q? J? Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$
 Gray??   
BlurRadius$ 10Q?   ShadowDepth$	 0.5Q?	   	Direction$	 0Q?._??? 
 ?? 	MaxLength$
 30??
???   ?)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин?? %  !MaterialDesignFloatingHintTextBox#??[  ???? *
LoginField+?? $ 10?????#F6F6F6$
 10 5q?$??70 15q?   $
 Gray??$ 10Q?$	 0.5Q?$	 0Q?._??? $
 30??#??[  
???????$ Пароль?????? *PasswordField+?  ? ColumnDefinitions ?? ??  ? RowDefinitions ?? ?? .+??? -    ??Name$ AuthorizationButton??$??1??$??
Войти??$	??150?? ? Cursor$
 Hand?????? *Authorization+?? $??1??
???????$??11(?$%??Ещё нет аккаунта???$??Bottom=?$??25,0,0,0q??? -   $ RegistrationButton??$??Регистрация??$	??150??$??1??$??1??   MaterialDesignOutlinedButton#??[ $
 Hand?????? *Registration+