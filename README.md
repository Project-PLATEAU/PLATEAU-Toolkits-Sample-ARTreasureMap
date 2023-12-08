# AR Treasure Map
PLATEAU SDK-Toolkits for Unityを使ったサンプルアプリケーション

### 更新履歴

|  2023/12/13  |  AR サンプルシーン 初回リリース|
| :--- | :--- |

# 目次

- [1. サンプルプロジェクトの概要](#1-サンプルプロジェクトの概要)
  - [1-1. サンプルプロジェクトで体験できること](#1-1-サンプルプロジェクトで体験できること)
  - [1-2. Unityプロジェクト情報](#1-2-unityプロジェクト情報)
  - [1-3. 利用している PLATEAU SDK-Toolkits の機能](#1-3-利用している-plateau-sdk-toolkits-の機能)
- [2. 利用手順](#2-利用手順)
  - [2-1. 推奨環境](#2-1-推奨環境)
  - [2-2. サンプルプロジェクトのビルド方法](#2-2-サンプルプロジェクトのビルド方法)
  - [2-3. ビルドしたアプリケーションの操作方法](#2-3-ビルドしたアプリケーションの操作方法)
- [3. サンプルプロジェクトのカスタマイズ方法](#3-サンプルプロジェクトのカスタマイズ方法)
  - [3-1. アプリケーションを別の場所で利用したい場合](#3-1-アプリケーションを別の場所で利用したい場合)
  - [3-2. メダル（チェックポイント）の位置を変更する](#3-2-メダルチェックポイントの位置を変更する)
- [ライセンス](#ライセンス)
- [注意事項/利用規約](#注意事項利用規約)

# 1. サンプルプロジェクトの概要
## 1-1. サンプルプロジェクトで体験できること

- 本サンプルプロジェクトでは、PLATEAU 3D都市モデルおよびAR機能を活用した観光ARガイドアプリケーションを体験することができます。
- AR空間内に配置された3Dオブジェクトを探しながら目的地を目指すアプリケーションです。
- 本サンプルプロジェクトを改変し、任意のPLATEAU 3D都市モデルを利用することで、予め用意された地域以外でも同様の体験を提供することが可能です。

## 1-2. Unityプロジェクト情報

### Unity バージョン
- Unity 2021.3.30f1

### レンダリングパイプライン
- URP (Universal Rendering Pipeline)

## 1-3. 利用している PLATEAU SDK-Toolkits の機能

### PLATEAU SDK-AR-Extensions
- ARコンテンツを空間に配置する機能
- 3D都市モデルをオクルージョン用のモデルとして使用するシェーダー設定
- ランタイムで3D Tiles形式の3D都市モデルをストリーミングする機能
- 自己位置推定機能
- 手動での位置調整機能

# 2. 利用手順
## 2-1. 推奨環境

### 参考開発環境
以下は本プロジェクトに使用した開発環境です。

- Windows11
- macOS Ventura 13.2
- Android 13
- iOS 16.7.1

## 2-2. サンプルプロジェクトのビルド方法

1. メニューより "File" > "Build Settings" を選択し Build Settings ウィンドウを表示します。

<img width="600" alt="ar_sample_buildsettings" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/4982c26c-39e2-4063-b70e-ac872752eb58">

2. プラットフォームがAndroidかiOS以外になっている場合は、アプリケーションを動作させる端末に合わせてプラットフォームを選択し、画面下部にある「Switch Platform」ボタンからプラットフォームを切り替えます。<br>

3. Build Settings ウィンドウの画面下部にある「Build」ボタンを押下し、ビルドの出力先を選択してビルドを開始します。iOSの場合は Xcode プロジェクト、Androidの場合は .apk ファイルもしくはAndroid Gradleプロジェクトを生成します。<br />
ビルドが完了したら、各プラットフォームに合わせて端末へアプリケーションをインストールしてください。

## 2-3. ビルドしたアプリケーションの操作方法

### アプリケーションの説明

- このアプリケーションはAR空間に表示されるメダルを順序通り集めてゴールを目指すゲームアプリケーションです。
- 表示されるメダルはアプリケーションの自己位置推定により、予め設定された緯度経度上に配置されます。
- プレイヤーはメダルに近づくことでメダルを獲得することができます。
- 開始地点のメダルを獲得するとプレイヤーが次に獲得するメダルまでの道のりがAR空間上に表示されます。
- ゴールに配置されたメダルを獲得するとゴール達成を知らせるダイアログが表示され、アプリケーションが終了します。

### 対応エリア

サンプルプロジェクトでは東京銀座のGINZA SIX周辺の以下の地点にメダルと目的地を配置しています。<br>

<img width="600" alt="ar_sample_buildsettings" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/765ab0b6-4854-4dc5-9a84-40c7672ab17e">

### アプリケーションプレイ手順

1. ビルドしたアプリケーションを開くと、オープニング画面が表示されます。「始めましょう」のボタンをタップします。

<img width="400" alt="ar_sample_title" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/2b29a609-abe4-48c7-bf08-5619709dd754">

2. PLATEAU 3D都市モデルの表示方法を選択します。これらはサンプルとして主なARでの3D都市モデルの表示方法の実装例を紹介するためのものであり、どの方法でも体験できる内容は同じです。いずれかの表示方法を選択すると、メダル集めのメインシーンへ遷移します。
    - インポートしたモデル
        - Unityエディターで事前にインポートした3D都市モデルを表示します。
    - ストリーミングモデル
        - PLATEAU 3D都市モデルを実行時にストリーミングで取得して表示します。
    - ARマーカーモデル
        - Unityエディターで事前にインポートした3D都市モデルにARマーカーによる自己位置推定機能 ( `PlateauARMarkerCityModel` ) を設定しています。実行時、ARマーカーを読み取って3D都市モデルを表示します。

<img width="400" alt="ar_sample_selection" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/ee98f22d-3db0-4d1b-b730-2b72aaf03fc8">

3. それぞれの表示方法に応じた位置合わせの初期化処理が開始されます。位置合わせが完了すると、周囲にメダルなどのARコンテンツが表示されます。
    - インポートしたモデル、ストリーミングモデルでは周辺建物にカメラを向けて、自己位置推定を行います。
        - 天候などによっては位置合わせ処理が完了しないことがあります。別の角度から建物にカメラをかざしてください。
    - ARマーカーモデルでは用意されたARマーカーを読み取り、3D都市モデルを表示させてください。

<img width="400" alt="ar_sample_please_scan" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/6d83fd0b-310e-4b60-a65e-3a729ac4928f">

※仮画像です。

4. 開始点に設定されているGINZA SIXの入り口に配置されているメダルを最初に獲得すると次のメダルまでの道筋が表示されるので、目的地までメダル集めを進行してください。

<img width="400" alt="ar_sample_gotocheck" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/18492506-2791-4eb7-8b25-f5ade3fe35a2">

<br>
<img width="400" alt="ar_sample_ginzasix" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/12e12ddd-1279-4a5d-bb9d-439e57c30508">

5. 最後のメダルを集めると、メダル集め終了ウィンドウが表示されます。
    - 「終了」ボタンをタップすると、最初の画面に戻ります。

<img width="400" alt="ar_sample_end" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/62eac7de-0728-4863-b4eb-da074ee74e1d">

# 3. サンプルプロジェクトのカスタマイズ方法
## 3-1. アプリケーションを別の場所で利用したい場合

別の場所で利用したい場合は、利用する場所に合わせてPLATEAU 3D都市モデル変更する必要があります。

### 事前インポート形式
プロジェクトから "Assets/Scenes/Main" シーンを開きます。

ヒエラルキーから "PreimportedCityModel" の中にある "GinzaImportedCityModel" を削除し、PLATEAU SDK でインポートした別の3D都市モデルを "PreimportedCityModel" 内に配置します（インポートの方法は [PLATEAU SDK for Unityの使い方](https://project-plateau.github.io/PLATEAU-SDK-for-Unity/manual/ImportCityModels.html) をご確認ください）。

次に、 "PreimportedCityModel" にアタッチされている `Plateau AR Positioning` コンポーネントをインスペクタで開き、インポートした 3D都市モデルオブジェクトを `Plateau City Model` フィールドに設定してください。

<img width="800" alt="ar_sample_end" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/blob/main/SampleSceneReadmeImages/ARTreasureMap/ar_sample_customize_preimport_modelreplace.png">

<img width="800" alt="ar_sample_customize_preimport_modelreplace" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/f4c315b0-500b-47c3-bb6e-2948780f4544">

### ストリーミング形式

ヒエラルキーから "StreamingCityModel" の中にある "CesiumGeoreference" をクリックし、インスペクタを開きます。
 `Latitude` (緯度) と `Longitude` (経度) をアプリケーションを利用する場所のものに変更してください。緯度経度は地図サービスなどを利用して取得することができます。

次に、"CesiumGeoreference" 内の "GinzaCesium3DTiles" をインスペクタで開き、 `Cesium 3D Tileset` コンポーネントの `URL` に利用する地域のURLを [plateau-3D Tiles-streaming](https://github.com/Project-PLATEAU-Admin/plateau-streaming-tutorial/blob/main/3d-tiles/plateau-3dtiles-streaming.md) から選んで設定してください。

"StreamingCityModel" をアクティブにして、シーン上に設定した場所の3D都市モデルが表示されることを確認してください。

<img width="800" alt="ar_sample_customize_streaming_lonlat" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/1356dc4c-929a-4eb7-8fd7-01c81e4a7f05">

### ARマーカー形式

ヒエラルキーから "ARMarkerBasedCityModel" > "CityModels" > "GinzaImportedCityModel" を削除し、事前インポート形式と同様に任意の3D都市モデルをインポートして削除したオブジェクトと同様に "CityModels" 内に配置します。

次に、自己位置推定に利用するARマーカーの配置場所を変更します。サンプルプロジェクトでは "ARMarkerBasedCityModel" の中にある "ARMarkerPoint" をARマーカーの位置として利用しています。

ARマーカー位置の設定方法は[マーカによる3D都市モデルの位置合わせ機能](https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/blob/main/readme.md#4-ar%E3%83%9E%E3%83%BC%E3%82%AB%E3%83%BC%E3%82%92%E4%BD%BF%E3%81%A3%E3%81%9Fplateau%E3%83%A2%E3%83%87%E3%83%AB%E3%81%AE%E4%BD%8D%E7%BD%AE%E5%90%88%E3%82%8F%E3%81%9B%E6%A9%9F%E8%83%BD)をご確認ください。

<img width="800" alt="ar_sample_customize_markerposion" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/1d7ba663-2676-4fc4-89c1-6c7c9a270c06">

#### 複数のマーカーを配置する場合(WIP)

本サンプルではAR Extensionsの機能を利用し、複数のマーカーを配置した位置合わせを実施することも可能です。<br>
下記のフローをご確認ください。

1.新しいマーカーを"Referenced Image Library"に追加します。<br>

<img width="600" alt="ar_sample_multimarker_reflib" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/44cf56ba-57b7-4162-8e81-41fa244033ac">


2. 追加したマーカーをヒエラルキー内にある“PlateauARMarkerCityModel”に追加します。<br>

<img width="600" alt="ar_sample_multimarker_plateauarmarkermodel" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/3c768958-5d66-4a9b-a20d-8721c38b8cf9">


3. ヒエラルキー内において"ARMarkerPoint"を追加した数分だけ複製します。<br>

<img width="600" alt="スクリーンショット 2023-12-01 18 08 00" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/be7eba14-ac12-4d9c-908e-384f232a010d">


4. “PlateauARMarkerCityModel”の中でそれぞれのARMarkerの中にARMarkerPointをアタッチします。<br>

<img width="600" alt="スクリーンショット 2023-12-01 18 08 00" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/5305e957-4e96-4eee-9649-5b8e7689f320">

5. それぞれのARMakerPointをシーンビューの中でPLATEAU都市モデル中に配置して行きます。<br>
実際に実空間上でスキャンする想定の場所に配置してください。

<img width="600" alt="ar_sample_arpoint_place" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/c112c044-a907-4df8-8dbf-473ccb799d5e">

参考までに、本サンプルシーンでは下記の場所にマーカーを複数配置しています。<br>

<img width="600" alt="ar_sample_multimarker_map" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/c5b3b45e-de35-4139-abf9-b396f082fc69">


## 3-2. メダル（チェックポイント）の位置を変更する

新しく設定した3D都市モデルに合わせ、メダル（チェックポイント）の位置を変更します。それぞれの表示方法に対応したゲームオブジェクトの中にある "CheckPoints" の中にメダルの位置を設定するオブジェクトが配置されているので、新しい3D都市モデルの形状に合わせてルートを設定します。チェックポイントは2種類存在します。

- チェックポイント (CheckPoint)
    - メダルが表示され、プレイヤーが必ず経由する必要のあるポイント
- 経由点 (RoutePoint)
    - 経路を表示するためのポイント
    - 曲がり角など、最後のチェックポイントから次のチェックポイントへのルートが直接でない場合に利用します。

尚、これらのポイントは "CheckPointManager" によって管理されています。"CheckPointManager" に新しくポイントを追加することでチェックポイントや経由点を追加することができます。

<img width="800" alt="ar_sample_customize_checkpoint" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/73b6814e-7419-4736-a9bf-fa25c90dcd9a">

<img width="800" alt="ar_sample_customize_routepos" src="https://github.com/unity-shimizu/PLATEAU-Toolkits-Sample-ARTreasureMap/assets/137732437/591081d1-b059-4572-9c75-f7c740c6c449">

# ライセンス
- 本リポジトリはMITライセンスで提供されています。
- 本システムの開発はユニティ・テクノロジーズ・ジャパン株式会社が行っています。
- ソースコードおよび関連ドキュメントの著作権は国土交通省に帰属します。

# 注意事項/利用規約
- 本ツールはベータバージョンです。バグ、動作不安定、予期せぬ挙動等が発生する可能性があり、動作保証はできかねますのでご了承ください。
- 処理をしたあとにToolkitsをアンインストールした場合、建物の表示が壊れるなど挙動がおかしくなる場合がございます。
- 本ツールをアップデートした際は、一度Unity エディタを再起動してご利用ください。
- パフォーマンスの観点から、3D都市モデルをダウンロード・インポートする際は、3㎞2範囲内とすることを推奨しています。
- インポートエリアの広さや地物の種類（建物、道路、災害リスクなど）が増えると処理負荷が高くなる可能性があります。
- 本リポジトリの内容は予告なく変更・削除する可能性があります。
- 本リポジトリの利用により生じた損失及び損害等について、国土交通省はいかなる責任も負わないものとします。

