   M S B A M L   `   `   `  ????D  @SuperHero, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SuperHero.ViewsSuperHero.Views  5   	   (    "SuperHero.Views.CustomHeroesWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   )localclr-namespace:SuperHero.Views  5   	   -   5        $??Customs??5	   	     ? Title$  Мои герои??5
   	   $	??480??6   $	??720??6(   $	??720??64   $	??480??6C   $
??1920??6S   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5       ? ColumnDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      .+?5   
   ?? ???#434343 ?? Padding$ 15q?6&   $??2??63   ._?5      ?  5      ?? 5      $
??Auto ?6'   ?? 5      ?? 5      ?? 5      $
??Auto ?6'   ?? 5      $
??Auto ?6'   .+?5      ?? $??Моя коллекция??6   
???????$??24(?6D   $??1??6R   $??2??6b   $??Center=?6v   ?? 5       $??0??6   $
??Left=?5!      $??На главную??5"      $
??10 0q?5#      $??14(?5$      $	??250??5&      ??5%      ?? *BackToMainWindow+5&      ?? 5'      $??3??6   $??Right=?5(      $
??10 0q?5)      $??14(?5*      $	??250??5+      $!??Добавить героя??5,       ? Cursor$
 Hand??5-   D   ??6   ?? *OpenHeroCreationWindow+6D   ?? 5.      $??4??6   $
??10 0q?5/      $??14(?50      $(??"На площадку героев??52      ??51      ?? *OpenPublicPlatform+52      53      54      ?? 57   
   ???#F6F6F6$??1??6,   $??0??69   $??Center=?6I   $??15q?6f   $
??True??6s   $
??Auto=?6?   .??58      ?? -   5         ??Name$ listBox??58      $
??15 5q?6'   ??65   ?? *CustomHeroes+ ?? SelectedItem 6Z   ?? *SelectedHero+??59      ?? 5:      .R?5;      ?? $
??Wrap=?6%   $??18(?69   $	??180??6b   ??6G   ??  ?? Path$
 Name?6b   5<      5>      5?      ?? 5B   
   $??1??6   $??1??6!   $ 	15 15 0 0q?6.   ._?5C      ?  5D      ?? 5E      $
??0.6* ?6'   ?? 5F       5H      ?? 5I      ?? 5J      ?? 5K      .+?5M      ?? -   5         ??Name$ image??5M      $??0 0 15 0q?6M   $??0??6_   $??0??6o   $??2??6|   ??6'   ?? *SelectedHero.Image+6|   ?? 5N      $??0??6   $??1??6*   $??3??6:   .+?5O      ?? $??32(?6    $
??Wrap=?6Q   ??6.   ?? *SelectedHero.Name+6Q   ?? 5P      $??20(?6    $
??Wrap=?6h   ??6.   ?? *SelectedHero.Id+	 ?? StringFormat$	 
• id:{0}??6h   ?? 5Q      $??20(?6    $
??Wrap=?6v   ??6.   ?? *SelectedHero.Biography+$	 • Bography: {0}??6v   ?? 5R      $??20(?6    $
??Wrap=?6m   ??6.   ?? *SelectedHero.PowerStats+$	 • {0}??6m   5S      ?? 5T      -   5        
 ??Name$
 button??5T      $??Удалить героя??6N   $??2??6f   $	??Top=?6s   $??15q?6?   $	??250??6?   $	??140??6?   $
 Hand??6?   ??6)   ?? *DeleteCustomHero+6?   5U      5V      5W      5X      