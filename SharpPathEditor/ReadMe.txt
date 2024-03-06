Sharp Path Editor ver1.x.x
Copyright © 2022 Mashiro Tamane

○このソフトについて
Windows の環境変数の"PATH"を編集するためのツールです。

○推奨動作環境
Windows 10/Windows 11

.NET Desktop Runtime 8.0 が必要です。

○開発環境
Microsoft Windows 11 Insider Preview Dev
Microsoft Visual Studio 2022
.NET 8.0

○ソースコード
ソースコードはGitHubに公開しています。
https://github.com/armadillo-winX/SharpPathEditor

○免責事項
・本ソフトウェアはレジストリを編集します。
  編集される値は下に示す通りです。
  ・HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment\Path
  ・HKEY_CURRENT_USER\Environment\Path

・本ソフトウェアによって生じたいかなる損害についても開発者は一切の責任を負いません。

○更新履歴

ver1.2.1-beta
・ランタイムを .NET 8.0 に更新。
・バージョン情報ダイアログにランタイム情報を表示するようにした。
・バージョン付与に関する修正。

ver1.2.0 beta
・ツールバー追加。
・Windowsツールの起動コマンド追加。

ver1.1.0
・設定保存機能を追加。
pull request by kaonashi_biwa
 ・Path の編集機能追加。
 ・Path の上下移動。
 ・その他軽微な修正。

ver1.0.0
最初のバージョン。
