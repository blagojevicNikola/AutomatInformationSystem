   M S B A M L   `   `   `  ????S  OAutomatInformationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:AutomatInformationSystem.ViewsAutomatInformationSystem.Views  5   	   C&clr-namespace:AutomatInformationSystemAutomatInformationSystem  6D   7    1AutomatInformationSystem.Views.AddZaposleniWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:AutomatInformationSystem.Views     5   	   Kautomatinformationsystem&clr-namespace:AutomatInformationSystem     6D     ? Title$  AddZaposleniWindow??5   	   $	??500??6$   $	??400??61    ? WindowStartupLocation$ CenterScreen=?5	   	    ? 	Resources 5       ?? MergedDictionaries ?? Source?? 5   
    5      ?? 5      $ /Resources/Styles.xaml??6%   %    5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5   
   ?? $??	10,10,0,0q?6    ?? Orientation$ Vertical=?6(   $??0??6?   .+?5      ?? $	??Ime??6   $??SemiBold"?5       $??15(?5!      $??0,0,0,5q?5"      $??0q?5#      ?? 5$      $??SemiBold"?6   $??15(?5%      $	??250??5&      $
??Left=?5'      ??5(      ??  ?? Path$	 Ime? ?? Mode$ TwoWay=?5)      ?? 5+   
   $??	10,10,0,0q?6   $ Vertical=?6(   $??1??6?   .+?5,      ?? $??Prezime??6   $??SemiBold"?5-      $??15(?5.      $??0,0,0,5q?5/      $??0q?50      ?? 51      $??SemiBold"?6   $??15(?52      $	??250??53      $
??Left=?54      ??55      ?? $ Prezime?$ TwoWay=?56      ?? 58   
   $??	10,10,0,0q?6   $ Vertical=?6(   $??2??6?   .+?59      ?? $??Telefon??6   $??SemiBold"?5:      $??15(?5;      $??0,0,0,5q?5<      $??0q?5=      ?? 5>      -   5        	 ??Name$	 zaposleniTelefonTextBox??5>      $??SemiBold"?5?      $??15(?5@      $	??250??5A      $
??Left=?5B      .??61   ??5C      ?? 5D      $ Telefon?6   $ TwoWay=?6-   
 ?? UpdateSourceTrigger$
 PropertyChanged=?6;   5F      .??5G       5H      5I      ?? 5K   
   $??	10,10,0,0q?6   $ Vertical=?6(   $??3??6?   .+?5L      ?? $??Datum??6   $??SemiBold"?5M      $??15(?5N      $??0,0,0,5q?5O      $??0q?5P      ?? 5Q      -   5        $	 zaposleniDatumRodjTextBox??5Q      $??SemiBold"?5R      $??15(?5S      $	??250??5T      $
??Left=?5U      .??61   ??5V      ?? 5W      $ DatumRodjenja?6   $ TwoWay=?63   $
 PropertyChanged=?6A   5Y      .??5[       5\      5]      ?? 5_   
   $??	10,10,0,0q?6   $ Vertical=?6(   $??4??6?   .+?5`      ?? $	??Tip??6   $??SemiBold"?5a      $??15(?5b      $??0,0,0,5q?5c      $??0q?5d      ?? 5e      $	??250??6   $
??Left=?5f      $??Center=?5g      $??SemiBold"?5h       ?? SelectedIndex$ 0??5i      $??15(?5j       ?? Text 5k      ?? $	 Tip?$ OneWayToSource=?.@?5l      ?? .??6   Radnik6'   ?? 5m      .??6   
Serviser6)   5n      5o      ?? 5q   
   $??OK??5r      $??Right=?5s      $??Bottom=?5t      $??10q?5u      $??5??5v         OkButtonSytle#??[  5x      ??5w      ?? $ 	OkCommand?5y      5{      5|      