   M S B A M L   `   `   `  ????S  OAutomatInformationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:AutomatInformationSystem.ViewsAutomatInformationSystem.Views  5   	   6    0AutomatInformationSystem.Views.AddProizvodWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:AutomatInformationSystem.Views     5   	     ? Title$  AddProizvodWindow??5   	   $	??350??6#   $	??600??60    ? WindowStartupLocation$ CenterScreen=?5	   	    ? 	Resources 5       ?? MergedDictionaries ?? Source?? 5   
    5      ?? 5      $ /Resources/Styles.xaml??6%   %    5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5      ? $??0??6    ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5!   
   ?? $??10q?6    ?? Orientation$ Vertical=?6!   $??0??68   .+?5"      ?? $??Naziv proizvoda??6   $??SemiBold"?5#      $??20(?5$      $??0q?5%      ?? 5&      $??20(?6   $	??200??5'      $
??Left=?5(      $??0,5,0,0q?5)      ??5*      ??  ?? Path$ Naziv?	 ?? Mode$	 TwoWay=?5+      ?? 5-   
   $??10q?6   $ Vertical=?6!   $??1??68   .+?5.      ?? $??Tip proizvoda??6   $??SemiBold"?5/      $??20(?50      $??0q?51      ?? 52      $??20(?6   $??SemiBold"?53      $??0,5,0,0q?54      $	??120??55      $
??Left=?56      
 ?? SelectedIndex$
 0??57      $??Center=?58       ?? Text 59      ?? $	 Tip?$	 OneWayToSource=?.@?5:      ?? .??6   Hrana6&   ?? 5;      .??6   Kafa6%   5<      5=      5A      ? 5C   
   $??1??6    5D      ?? 5E      $
??auto ?6    ?? 5F      $??* ?6    ?? 5G      $
??auto ?6    .+?5J      ?? $??Lista sastojaka??6   $??SemiBold"?5K      $??20(?5L      $??0q?5M      $??
10,10,10,0q?5N      $??0??5O      ?? 5Q      ???#f2f2f2 ?? CornerRadius$ 15??6*   $??1??6=   ._?5R      ?? .??5S      ?? ??6$   ?? *SastojciList+??5T      ?? 5U      .R?5V   "   ?? $ 
Horizontal=?6-   $??
10,10,10,0q?6F   .+?5W   &   ?? $??Center=?6c   $??Center=?6?   $??0,0,5,0q?6?    d? 	IsChecked 6/   ?? *
Izabrano+$	 OneWayToSource=?6?   ?? 5X   &   $??0q?6C   $??0,0,5,0q?6O   ??6,   ?? *ID+6O   ?? 5Y   &   $??0q?6F   $??0,0,5,0q?6R   ??6,   ?? *Naziv+6R   5Z   #   5[      5]      5^      5_      ?? 5d      $??2??6   $??Right=?5e      $??Bottom=?5f      $??10q?5g         OkButtonSytle#??[  5i      ??5h      ?? $ 	OkCommand?.??5i   8   OK5k      5l      5n      5o      