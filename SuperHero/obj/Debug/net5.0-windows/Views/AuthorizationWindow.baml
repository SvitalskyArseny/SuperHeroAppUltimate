   M S B A M L   `   `   `  ????D  @SuperHero, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SuperHero.ViewsSuperHero.Views  5   	   )    #SuperHero.Views.AuthorisationWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   )localclr-namespace:SuperHero.Views  5   	   ???#EBEBEB  ? WindowStartupLocation$  CenterScreen=?5
   	    ? 
ResizeMode$ NoResize=?5   	    ? Title$ Авторизация??5   	   $	??350??6   $	??400??6*   .??5      ?? .+?5   
   ?? ???#434343 ?? Padding$ 15q?6&   ._?5      ?? $??Авторизация??6   
???????$??Center=?6>   $??22(?6[   5      ?? 5   
    ?? CornerRadius$ 10??6   ???#F6F6F6$
 10 5q?68   $??70 25q?6G    J? Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray??6#      
BlurRadius$ 10Q?60      ShadowDepth$	 0.5Q?6@   	   	Direction$	 0Q?6R   ._?5      ?? 
 ?? 	MaxLength$
 30??5      
???   ?)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин??5       %  !MaterialDesignFloatingHintTextBox#??[  5      ??5      ?? *
LoginField+5      5      ?? 5   
   $ 10??6   ???#F6F6F6$
 10 5q?68   $??70 15q?6G    5        5      $
 Gray??6#   $ 10Q?60   $	 0.5Q?6@   $	 0Q?6R   ._?5      ?? $
 30??5       #??[  5!      
???????$ Пароль??5#      ??5      ?? *PasswordField+5#      5$      ? 5%   
    ? ColumnDefinitions 5&      ?? 5'      ?? 5(       ? RowDefinitions 5*      ?? 5+      ?? 5,      .+?5.      ?? -   5         ??Name$ AuthorizationButton??5.      $??1??6T   $??
Войти??6a   $	??150??6q    ? Cursor$
 Hand??6}   ??62   ?? *Authorization+6}   ?? 5/      $??1??6   
???????$??11(?6:   $%??Ещё нет аккаунта???6H   $??Bottom=?6a   $??25,0,0,0q?6|   ?? 50      -   5        $ RegistrationButton??50      $??Регистрация??6R   $	??150??6h   $??1??6t   $??1??6?      MaterialDesignOutlinedButton#??[ 6?   $
 Hand??6?   ??61   ?? *Registration+6?   51      52      53      