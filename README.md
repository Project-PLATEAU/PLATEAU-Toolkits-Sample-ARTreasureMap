# PLATEAU SDK-AR-Extensions for Unity ARサンプルシーン

AR-Extensions-for-Unityを用いたサンプルアプリケーションの利用方法についてご紹介します。

### 更新履歴

|  2023/12/13  |  AR サンプルシーン　初回リリース|
| :--- | :--- |

# 目次
- [1. サンプルシーンの概要](#1-サンプルシーンの概要)
  * [1-1. 体験の概要](#1-1-体験の概要)
  * [1-2. AR Extensionsの利用機能](#1-2-AR-Extensionsの利用機能)
- [2. サンプルシーンの利用手順](#2-サンプルシーンの利用手順)
  * [2-1. 必要環境](#2-1-必要環境)
  * [2-2. サンプルシーンのビルド方法](#2-2-サンプルシーンのビルド方法)
  * [2-3. サンプルシーンの使い方](#2-3-サンプルシーンの使い方)
    + [2-3-1. 対応エリア](#2-3-1-対応エリア)
    + [2-3-2. ビルドしたアプリケーションの操作方法](#2-3-2-ビルドしたアプリケーションの操作方法)
    + [2-3-3. トラブルシューティング](#2-3-3-トラブルシューティング)
- [3. サンプルシーンのカスタマイズ方法](#3-サンプルシーンのカスタマイズ方法)
  * [3-1. アプリケーションを別の場所で利用したいとき](#3-1-アプリケーションを別の場所で利用したいとき)
  * [3-2. メダルの位置を変更する](#3-2-メダルの位置を変更する)
  * [3-3. 経由点の位置を変更する](#3-3-経由点の位置を変更する)
 

# 1. サンプルシーンの概要
## 1-1. 体験の概要
このサンプルシーンを使うことで、観光向けの都市ARアプリケーションを構築することができます。<br>
街の中に配置されたARコンテンツを探して歩き、目的地を目指す体験です。<br>
PLATEAU SDK-AR-Extensions for Unityを利用しているため、PLATEAUの3D都市モデルが整備された都市であれば同様の体験を他の場所でも構築することができます。<br>


## 1-2. AR Extensionsの利用機能
このサンプルシーンでは、PLATEAU SDK-AR-Extensions for Unityで提供されている以下の機能を活用しています。<br>
- ARコンテンツを空間に配置する機能
- 3D都市モデルをオクルージョン用のモデルとして使用するシェーダー設定
- ランタイムで3D Tiles形式の3D都市モデルをストリーミングする機能
- 自己位置推定機能
- 手動での位置調整機能


# 2. サンプルシーンの利用手順
## 2-1. 必要環境
### OS環境
- Windows11
- macOS Ventura 13.2
- Android 13
- iOS 16.7.1

### Unity Version
- Unity 2021.3.31f1 (2023/10/10現在 2021 LTSバージョン)
    - Unity 2021.3系であれば問題なく動作する見込みです。

### Rendering Pipeline
- URP

HDRP, Built-in Rendering Pipelineでは動作しません。<br>
※必要環境はPLATEAU SDK-AR-Extensions for Unityと同様です。

## 2-2. サンプルシーンのビルド方法

①Assets/Main.unityを開きます。<br>
<img width="600" alt="ar_sample_scene" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/blob/main/SampleSceneReadmeImages/ARTreasureMap/ar_sample_scene.png">

②メニューよりFile > Build Settingsを選択します。<br>

<img width="600" alt="ar_sample_buildsettings" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/blob/main/SampleSceneReadmeImages/ARTreasureMap/ar_sample_buildsettings.png">

③android, ios以外になっている場合は、android, iosを選択して、画面下部にある「Switch Platform」ボタンを押下し、Platformを切り替えます。<br>
④画面下部にある「Build」ボタンを押下します。出力先を選択してビルドを開始します。

## 2-3. サンプルシーンの使い方
### 対応エリア
サンプルシーンのアプリケーションは東京銀座エリアに対応しています。<br>
デフォルトでは、以下の地点にコンテンツが配置されています。<br>
![image](https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/assets/127069970/20a7a0ae-bfd4-443b-8e5b-70df62da8d7d)


### ビルドしたアプリケーションの操作方法
①ビルドしたアプリケーションを開くと、オープニング画面が表示されます。<br>
「始めましょう」のボタンをタップします。<br>

<img width="400" alt="ar_sample_ginzasix" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/assets/127069970/9451dcee-7a6c-4cce-b1d9-130cf56ef803">


②PLATEAUモデルの使い方を選択してください。<br>

- インポートしたモデル・・・Unity Editorで事前にPLATEAUモデルをインポートしておき、そのモデルをオクルージョンとして利用する機能です。
- ストリーミングモデル・・・PLATEAUモデルをストリーミングでダウンロードしながら利用する機能です。
- ARマーカーモデル・・・Unity Editorで事前にPLATEAUモデルをインポートしておきかつARマーカーポジションを設定した上で、マーカーを使って位置合わせを行いながら利用する機能です。


<img width="400" alt="ar_sample_ginzasix" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/blob/main/SampleSceneReadmeImages/ARTreasureMap/ar_sample_selection.png">

すると、ARを体験が開始されます。

③カメラを周囲の建物にかざすと、ユーザーの自己位置を認識するための位置合わせ処理が行われます。<br>
位置合わせが完了すると、周囲にARコンテンツが表示されます。<br>
※天候などによっては位置合わせ処理が完了しないことがあります。別の角度から建物にカメラをかざしてください。<br>

<img width="400" alt="スクリーンショット 2023-11-28 10 51 59" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/assets/137732437/849af2f7-ef36-4476-a184-cfd2b4aa7191"><br>
※仮画像です。




④配置されたコインに近づくと、コインを取得することができます。<br>
エリアには複数のコインが配置されているので、周囲を歩き回ってコインを集めましょう。<br>

<img width="400" alt="ar_sample_ginzasix" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/assets/137732437/f3119614-1186-4765-8eb8-9de59019d5ea">


<img width="400" alt="ar_sample_ginzasix" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/blob/main/SampleSceneReadmeImages/ARTreasureMap/ar_sample_ginzasix.png">

⑤アプリを終了するときは終了ボタンを押し、アプリを終了します。<br>

<img width="400" alt="ar_sample_end" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/blob/main/SampleSceneReadmeImages/ARTreasureMap/ar_sample_end.png">


# 3. サンプルシーンのカスタマイズ方法
## 3-1. アプリケーションを別の場所で利用したいとき

別の場所で利用したい場合は、利用位置に合わせて対象となるPLATEAUの都市モデル変更する必要があります。事前インポート形式、ストリーミング形式、マーカー形式で異なるので下記を確認してください。

### 事前インポート形式
"PreimportCityModel"の中にある"GinzaImportedCityModel"をPLATEAU SDKでインポートした別のPLATEAUモデルに置き換えて利用してください。<br>
詳しくは[PLATEAU SDK for Unityの使い方](https://project-plateau.github.io/PLATEAU-SDK-for-Unity/manual/ImportCityModels.html)をご確認ください。

<img width="800" alt="ar_sample_end" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/blob/main/SampleSceneReadmeImages/ARTreasureMap/ar_sample_customize_preimport_modelreplace.png">

### ストリーミング形式
"StreamingCityModel"の中にある"CesiumGeoreference"をクリックし、Inspectorビューの中でLatitudeとLongitudeを変更して対象位置を変更してください。<br>
<img width="800" alt="ar_sample_end" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/blob/main/SampleSceneReadmeImages/ARTreasureMap/ar_sample_customize_streaming_lonlat.png">

### ARマーカー形式
"ARMarkerBasedCityModel"の中にある"GinzaImportedCityModel"をPLATEAU SDKでインポートした別のPLATEAUモデルに置き換えて利用してください。<br>
詳しくは[PLATEAU SDK for Unityの使い方](https://project-plateau.github.io/PLATEAU-SDK-for-Unity/manual/ImportCityModels.html)をご確認ください。

また、利用場所に変更に伴い、マーカーの配置場所を変更してください。"ARMarkerBasedCityModel"の中にある"ARMarkerPoint"の位置を変更してください。
詳しくは[マーカによる3D都市モデルの位置合わせ機能](https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/blob/main/readme.md#4-ar%E3%83%9E%E3%83%BC%E3%82%AB%E3%83%BC%E3%82%92%E4%BD%BF%E3%81%A3%E3%81%9Fplateau%E3%83%A2%E3%83%87%E3%83%AB%E3%81%AE%E4%BD%8D%E7%BD%AE%E5%90%88%E3%82%8F%E3%81%9B%E6%A9%9F%E8%83%BD)をご確認ください。

<img width="800" alt="ar_sample_end" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/blob/main/SampleSceneReadmeImages/ARTreasureMap/ar_sample_customize_markerposion.png">


#### 複数のマーカーを配置する場合(WIP)

本サンプルではAR Extensionsの機能を利用し、複数のマーカーを配置した位置合わせを実施することも可能です。<br>
下記のフローをご確認ください。

1.新しいマーカーを"Referenced Image Library"に追加します。<br>

<img width="600" alt="スクリーンショット 2023-12-01 18 14 01" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/assets/137732437/5221e9e5-8e81-440d-b325-3d79a47519d3">


2. 追加したマーカーをヒエラルキー内にある“PlateauARMarkerCityModel”に追加します。<br>

<img width="600" alt="スクリーンショット 2023-12-01 18 08 00" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/assets/137732437/58e7535e-d05c-43a3-9aa1-3ca0ba8bbb9c">

3. ヒエラルキー内において"ARMarkerPoint"を追加した数分だけ複製します。<br>

<img width="600" alt="スクリーンショット 2023-12-01 18 08 00" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/assets/137732437/79d5dc55-09a8-4782-8087-16085a8868a3">

4. “PlateauARMarkerCityModel”の中でそれぞれのARMarkerの中にARMarkerPointをアタッチします。<br>
<img width="600" alt="スクリーンショット 2023-12-01 18 08 00" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/assets/137732437/d0301eb3-c212-4ffa-a677-75490d7c76bd">


5. それぞれのARMakerPointをシーンビューの中でPLATEAU都市モデル中に配置して行きます。<br>
実際に実空間上でスキャンする想定の場所に配置してください。
<img width="600" alt="スクリーンショット 2023-12-01 18 08 00" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/assets/137732437/d0956e5c-ffdb-411b-a9d3-4746b6c878c8">

※参考までに、本サンプルシーンでは下記の場所にマーカーを複数配置しています。<br>

<img width="600" alt="スクリーンショット 2023-12-04 10 36 37" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/assets/137732437/7a9ec677-5aa8-44fb-8a4b-316774830994">


## 3-2. メダル（チェックポイント）の位置を変更する

設定し直したPLATEAUモデルに合わせ、メダル（チェックポイント）の位置を変更したい場合は、"PreimportCityModel", "ARMarkerBasedCityModel"それぞれの中にあるCheckPointの位置を変更してください。

<img width="800" alt="ar_sample_end" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/blob/main/SampleSceneReadmeImages/ARTreasureMap/ar_sample_customize_checkpoint.png">


## 3-3. 経由点の位置を変更する

設定し直したPLATEAUモデルに合わせ、メダル（チェックポイント）の位置を変更したい場合は、"PreimportCityModel", "ARMarkerBasedCityModel"それぞれの中にあるRoutePointの位置を変更してください。

<img width="800" alt="ar_sample_end" src="https://github.com/unity-takeuchi/PLATEAU-SDK-AR-Extensions-for-Unity-drafts/blob/main/SampleSceneReadmeImages/ARTreasureMap/ar_sample_customize_routepos.png">

