   M S B A M L   `   `   `  ????I  EDevData_Loader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DevData_LoaderDevData_Loader  5   	       DevData_Loader.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:DevData_Loader     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   .??5	      ? .+?5
   
   ?? -   5        $??LoginHeading??5      $??20??5      $
??Left=?5      $??	10,10,0,0q?5      $??Login:??5      $	??Top=?5      $??12(?5      $
??Bold"?5      ?? 5   
   -   5        $??tbLogin??5      $??20??5      $
??Left=?5      $??	50,10,0,0q?5      $	??Top=?5      $	??150??5      5      ?? 5   
   -   5        $??PasswordHeading??5!      $??20??5      $
??Left=?5      $??	10,40,0,0q?5       $??Hasło:??5"      $	??Top=?5#      $??12(?5$      $
??Bold"?5%      G? 5'   
   -   5        $??
pwPassword??5+      $??20??5(      $
??Left=?5)      $??	50,40,0,0q?5*      $	??Top=?5,      $	??150??5-      5.      ?? 50   
   -   5        $??btnTest??55      $??Testuj połączenie??51      $??20??52      $
??Left=?53      $??	50,70,0,0q?54      $	??Top=?56      $	??150??57      58      ?? 5:   
   -   5        $??btnLoadData??5?      $??Załaduj dane??5;      $??20??5<      $
??Left=?5=      $??	50,0,0,10q?5>      $??Bottom=?5@      $	??150??5A      ${?False??5C      &   System.Windows.Controls.DataGrid  5E   
   -   5        $??dgData??5F         AutoGenerateColumns$
 True??5G      $??210,10,10,10q?5H      ??5I      ?? 5K      5L      