# TickTackBanBan 
## 概要  
* チクタクバンバンっぽいゲームを作る  
## 開発環境
* Unity2021.3.4f1
* Microsoft Visual Stdio 2022
### やった事  
__マップパイルの作成__  
* 3Dのキューブオブジェクトで作成
* マップの種類を定義、それぞれに情報を持たせて表示させた。  

__マップを作る__  
* パイル射出後のマップ上のレイアウトを作った。  
* レーン数を指定可能なリスト配列を作成し、凸凹地形を再現できるようにした。  
### やること
__マップパイルの作成__  
* マップパイルの情報に対して、マップ内でルート形成ができるかの検証  

__マップを作る__  
* スタート地点を作る(手動or決め打ち)  
* 自動でスクロールする  

__ゲームシーン__  
_パイルを射出させる_  
* フッター(画面下の部分)に4枚パイルを並べる  
* フッターのパイルをタップして、タップした地点からXポイント以上タップしたまま動かす(ドラッグしようとした)場合、射出モードになる。  
  * 射出モードになると、画面下、射出予定のラインにパイルが移動する  
  * タップのX位置にあわさる。Yは変化しない。  
* 指を話すと、パイルが射出され、くっつく  
_自機_
* スタートから一定数出てきて、ルートに沿って歩く  
  * パイルに侵入したらまずパイルの中央を目指して動きその後、次の面に向かう  
  * ルートは複数存在しない  
  * 進めなくなるか、スクロールに巻き込まれたらゲームオーバー  

## 思った事(適当な自問自答とか気付きのメモ)
__NavMeshAgentで射出後にベイクするのって非効率なのかな？__  
_少し前に経路探索するのにNavMeshを使って、その時にNavMeshAgentってのを使うとゲーム再生中に経路のベイクが出来るって知った_  
* マップパイル個々に情報を保持させてゲームシーン上で管理するより、適当な通行可能領域を指定した後にゲーム中に自機からゴールである下に向かってNavMeshする方がコード的にも複雑にならないんじゃない？
  * 複数のルート、無限ループ時の処理が出来なくなる…？  
  * そもそもNavMeshのベイク自体重たくなかった…？  

__そもそもこれ3Dでやる意味ある？__  
~~* そもそも俺が3D苦手で2Dの方が好きだし楽ってのもある~~  
* 真剣に考えて、ハイカジュって遊んでるとほとんど3D系のゲームだし、売れるハイカジュを作りたいなら2Dってのは愚策なのか…？  

__配列リストって頭悪い？？？？__  
_全体を扱う配列親クラス、縦のタイルをリストで管理する子クラス、その直下に個々のタイルを管理するという方法を取った。_
* タイルの横の数は定数で決まってるからいいけど、射出してくっつく方(縦)のタイルって数に決まりがあるわけじゃない。  
* 歪にタイルを組んでいくと凸凹になるのを再現するにはどうしたらいいか？↓  
  * 今の自分には縦に積まれていくタイルのリストを作って、それをマップとして制御する横の配列を作って管理する方法しか思いつかなかった。  
  * 一応ほぼ配列的な組み方だし、凸部分でカーブするとタイルがない(行き止まりの)判定も出来るし問題ないかな…？って~~楽観的に~~考えてる。  

___ヤベェ___  
_☆作業が終わらない☆_  
* 主な原因は設計不良？  
* パイルの情報とか管理に必要なものは粗方作れたけど、それをゲーム上で管理するにはどうしたらいいのかが分からん。  
* そもそもパイルに必要な情報を組み込めたところでデータをどう扱うか考えられていないのってダメじゃん。  
  * どのデータをどこで扱っているかもう少し整理してから(ってやってたら時間ないけど)全体を慎重に組み直す必要あり。  
* ~~3D用のGridLayoutGroupがあれば楽だったのかな…？~~  
  * 違ｪ、あれって子オブジェクトを詰めて表示するから、このゲームの設計には向かないか。  
