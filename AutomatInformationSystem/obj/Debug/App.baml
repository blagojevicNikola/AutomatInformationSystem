   M S B A M L   `   `   `  ????S  OAutomatInformationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:AutomatInformationSystemAutomatInformationSystem  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      O,clr-namespace:AutomatInformationSystem.ViewsAutomatInformationSystem.Views  5      "    AutomatInformationSystem.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      8local&clr-namespace:AutomatInformationSystem     5      9system&clr-namespace:System;assembly=mscorlib     5      >views,clr-namespace:AutomatInformationSystem.Views     5        ?? 	Resources  5         PrimaryDarkBrush ?? Color  PrimaryLightBrush  NavigationListBoxStyle ?? 
TargetType ?? Property ?? Value ?? 
TargetType ?? Padding J? SnapsToDevicePixels  NavigationListBoxItemStyle ?? RelativeSource	 ?? AncestorType
 ??Name ?? Triggers P? Property P? Value ?? 
TargetName ]? 
Conditions ?? Property ?? Value  NavigationDataTemplate ?? CornerRadius ?? Triggers ?? Value ?? Binding  NavigationMenuItems ?? Type  CloudViewTemplate.   (AutomatInformationSystem.Views.CloudView  EmailViewTemplate.   (AutomatInformationSystem.Views.EmailView  HomeViewTemplate-   'AutomatInformationSystem.Views.HomeView??%?	  &	        &	 !     &	 B     7   &	 e    7  7  7  &	 |    &	     &	 ?    &	 ?    &	 	    ?? 5	   
   $ #ebebeb??63   ?? 5
   
   $ #c2c2c2??64   ?? 5   
   " ??6/   .?5      ??  ? ??8   6+   ?? 5       ? ??$ Disabled=?6K   ?? 5       ? ??$ Disabled=?6I   ?? 5       ? ??$ Center=?69   ?? 5       ? ??$ Center=?6;   ?? 5       ?@??SelectedIndex$ 0??6.   ?? 5       ? ??$ 70??6&   ?? 5       ? ?? 5      ?? 5      " ??6&   .R?5      ?? #??z??6!   $??0q?5   !   $ 0q?5   !    . ._?5      ?? #??z??6+   |?.  .??5   "   ?? # z 61   5      5      5       5"      5#      ?? 5%   
   " ??63   .?5&      ??  ? ??
 ???? 6+   ?? 5'       ? ??8   6+   ?? 5(       ? ??$ -1q?6'   ?? 5)       ?@?ToolTip 6(   ?? ?? 5*       ? ?? 5+      ?? *HorizontalContentAlignment+ ?? "	 ???? 5,       ? ?? 5-      ?? *VerticalContentAlignment+ ?? "	 ???? 5.       ? ?? 5/      ?? 50      " ??6&   .R?51      ?? $
 Bd??6!   #??z??52   !   #??z??53   !   #??z??54   !   # z??55   !    . ._?57      ?? #??z??6/   #??z??58   /   # z 59   /   5:       5;      P? 5<       ?@??
IsSelected . . ?5=   "   ?? $ Bd??6)   8   ? ??6O   ?? 5>   "    ? ??
 ?????6?   5?      ]? 5@       5A   "   ?? 5B   &    ?@??
IsSelected . 6F   ?? 5C   &    ?@??IsSelectionActive .  6V   ./?5E   "   ?? $ Bd??6?   8   ? ??6O   ?? 5F   "    ? ??
 ?????6?   5G      P? 5H       ? {? .  . ?5I   "   ?? # ? ??6?    ? ??5J      5L      5N      5O      ?? 5`   
   .R?5a      ?? $ 50??6   
???????$??50??5c      $??50??5d      $??0,5,0,5q?5e      ._?5f      ?? $??35??5g      $??35??5h      $??0,5,0,5q?5i       . ??5f      ?? 5j      5k       5n      ?? 5o      $
 Home??62    6   ?? 62   ?? 5p      $ Email??62    6   ?? 62   ?? 5q      $ Cloud??62    6   ?? 62   5s      ?? 5u   
   " ??6.   .s?5v      ??Assets/Images/automat.png??67   ??5w      Assets/Images/zaposleni.png??69   ??5x      Assets/Images/lokacija.png??68   5y      ?? 5{   
   .R?5|        5}      ?? 5~   
   .R?5        5?      ?? 5?   
   .R?5?        5?      5?      5?      