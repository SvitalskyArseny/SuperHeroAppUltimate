   M S B A M L   `   `   `  ????D  @SuperHero, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SuperHero.ViewsSuperHero.Views  5   	   )    #SuperHero.Views.AddCustomHeroWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   )localclr-namespace:SuperHero.Views  5   	   -   5        $??CustomHeroCreation??5	   	     ? Title$!  Создание героя??5
   	   $	??450??6    $	??800??6-    ? 
ResizeMode$ NoResize=?69    ? WindowStartupLocation$ CenterScreen=?6O   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5      ?? 5      $
??Auto ?6   .+?5   
   ?? ???	#FFEBEBEB$??2q?6)   $??10q?6=   ._?5      ?? $
??Fill=?6   ??6#   ?? *	ImagePath+5      ?? 5   
   $??1??6   $??10q?6'   .??5      ?? .+?5      ?? -   5         ??Name$ heroName??5   5   $	??0 5q?6G    %  !MaterialDesignFloatingHintTextBox#??[  6T    ?? 	MaxLength$ 30??6?   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Имя??6?   ??6   ?? *	NameField+6?   ?? 5      -   5        $ heroBiography??5   :   $	??0 5q?6Q   #??[  6^   $	 300??6?   $ Биография??6?    ?? TextWrapping$
 Wrap=?6?   ??6   ?? *BiographyField+6?   ?? 5      $#??Характеристики:??6   $??0 10 0 0q?63   ?? 5      $??Интеллект??6   $??10(?6-   
???????$??0 10 0 0q?6M   ?? 5      	 ?? Orientation$	 
Horizontal=?6   $	??0 5q?66   .+?5      ?? -   5        
 ??Name$
 heroIntelligence??5   ]    ?? IsSnapToTickEnabled$
 True??6B   $	??300??6w    ? Maximum$	 100Q?6?    ? Minimum$ 0Q?6?    ? SmallChange$ 1Q?6?    ? LargeChange$ 10Q?6?   $??15 0 0 0q?6?    ? Value 6   ?? *IntelligenceSlider+6?   ?? 5       ?? Padding$ 10 2 0 0q?6    ??63   ?? *Value+ ?? ElementName$ heroIntelligence??5       ?? 5!      $??Скорость??6   $??10(?6,   
???????$??0 10 0 0q?6L   ?? 5"      $	 
Horizontal=?6   $	??0 5q?66   .+?5#      ?? -   5        $
 	heroSpeed??5#   V   $
 True??6;   $	??300??6i   $	 100Q?6u   $ 0Q?6?   $ 1Q?6?   $ 10Q?6?   $??15 0 0 0q?6?    6   ?? *SpeedSlider+6?   ?? 5$      $ 10 2 0 0q?6    ??63   ?? *Value+$ 	heroSpeed??5%      ?? 5&      $??Сила??6   $??10(?6(   
???????$??0 10 0 0q?6H   ?? 5'      $	 
Horizontal=?6   $	??0 5q?66   .+?5(      ?? -   5        $
 	heroPower??5(   V   $
 True??6;   $	??300??6i   $	 100Q?6u   $ 0Q?6?   $ 1Q?6?   $ 10Q?6?   $??15 0 0 0q?6?    6   ?? *PowerSlider+6?   ?? 5)      $ 10 2 0 0q?6    ??63   ?? *Value+$ 	heroPower??5*      ?? 5+      $	 
Horizontal=?6   $
??0 10q?66   .+?5,      ?? $'??!Сделать публичным??6    $	??5 5q?69    ? ToolTip$? ?Это позволит другим пользователям видеть вашего персонажа и оценивать его ставя лайки и дизлайки??50   -   51      ?? 52        MaterialDesignCheckBox#??[ 6    d? 	IsChecked 6O   ?? *IsPublicHero+$? ?Это позволит другим пользователям видеть вашего персонажа и оценивать его ставя лайки и дизлайки??56   ,   57      58      59      5:      ?? 5;   
   $??1??60   $??Выбрать файл??6=   $
??25 5q?6T   $	??Top=?6b   $	??175??6z    ? Cursor$
 Hand??6?   ??6   ?? *
ChooseFile+6?   ?? 5<   
   $??1??60   $??1??6@   $??Создать??6M   $	??175??6_   $
??25 5q?6k   ??6   ?? *
CreateHero+6k   5=      5>      