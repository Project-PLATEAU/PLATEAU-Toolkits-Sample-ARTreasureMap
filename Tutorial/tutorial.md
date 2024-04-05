# ARトレジャーマップ　チュートリアル

## 目次
- [1. ARトレジャーマップ　チュートリアルの概要](#1-ARトレジャーマップチュートリアルの概要)
    - [1-1. チュートリアルの目的](#1-1-チュートリアルの目的)
    - [1-2. 開発環境](#1-2-開発環境)
    - [1-3. 準備](#1-3-準備)
- [2. 環境作成](#2-環境作成)
    - [2-1. プロジェクト作成](#2-1-プロジェクト作成)
    - [2-2. PLATEAU SDKの追加](#2-2-PLATEAU-SDKの追加)
    - [2-3. 3D都市モデルの読み込み](#2-3-3D都市モデルの読み込み)
    - [2-4. PLATEAU SDK-Toolkits の追加](#2-4-PLATEAU-SDK-Toolkitsの追加)
    - [2-5. PLATEAU SDK-AR-Extensions の追加](#2-5-PLATEAU-SDK-AR-Extensionsの追加)
    - [2-6. PLATEAU SDK-Maps-Toolkit の追加](#2-6-PLATEAU-SDK-Maps-Toolkitの追加)
    - [2-7. Google ARCore APIの設定](#2-7-Google-ARCore-APIの設定)
    - [2-8. シーンの作成](#2-8-シーンの作成)
    - [2-9. AR環境およびGeospatialコントローラーの設定](#2-9-AR環境およびGeospatialコントローラーの設定)
    - [2-10. オクルージョンの設定](#2-10-オクルージョンの設定)
- [3. Geospatial API 位置合わせ機能の実装 (PLATEAU SDK)](#3-Geospatial-API-位置合わせ機能の実装-PLATEAU-SDK)
    - [3-1. PLATEAU SDKで3D都市モデルのインポート](#3-1-PLATEAU-SDKで3D都市モデルのインポート)
    - [3-2. 3D都市モデルのプレハブ化](#3-2-3D都市モデルのプレハブ化)
    - [3-3. 位置合わせコンポーネントの設定](#3-3-位置合わせコンポーネントの設定)
    - [3-4. オクルージョンの設定](#3-4-オクルージョンの設定)
- [4. Geospatial API 位置合わせ機能の実装 (Cesium)](#4-Geospatial-API-位置合わせ機能の実装-Cesium)
    - [4-1. Cesiumで3D都市モデルのストリーミング設定](#4-1-Cesiumで3D都市モデルのストリーミング設定)
    - [4-2. 位置合わせコンポーネントの設定](#4-2-位置合わせコンポーネントの設定)
    - [4-3. オクルージョンの設定](#4-3-オクルージョンの設定)
- [5. マーカー位置合わせ機能の実装](#5-マーカー位置合わせ機能の実装)
    - [5-1. 3D都市モデルの実装](#5-1-3D都市モデルの実装)
    - [5-2. マーカーの設定](#5-2-マーカーの設定)
    - [5-3. マーカー位置合わせコンポーネントの設定](#5-3-マーカー位置合わせコンポーネントの設定)
- [6. UI実装の準備](#5-UI実装の準備)
    - [6-1. キャンバス (Canvas) の作成](#6-1-キャンバス-Canvas-の作成)
    - [6-2. 各種ページの作成](#6-2-各種ページの作成)
    - [6-3. セーフエリアの作成](#6-3-セーフエリアの作成)
    - [6-4. フォントの準備](#6-4-フォントの準備)
- [7. タイトル画面の実装](#7-タイトル画面の実装)
- [8. ルート管理の実装](#8-ルート管理の実装)
    - [8-1. ルートポイントの実装](#8-1-ルートポイントの実装)
    - [8-2. 経路の作成](#8-2-経路の作成)
    - [8-3. パス表示用オブジェクトのプレハブ作成](#8-3-パス表示用オブジェクトのプレハブ作成)
    - [8-4. チェックポイント進捗管理UIの実装](#8-4-チェックポイント進捗管理UIの実装)
    - [8-5. スナックバーUIの実装](#8-5-スナックバーUIの実装)
    - [8-6. コンプリートポップアップUIの実装](#8-6-コンプリートポップアップUIの実装)
    - [8-7. ルートポイントマネージャーの実装](#8-7-ルートポイントマネージャーの実装)
    - [8-8. ルートポイントマネージャーオブジェクトの作成](#8-8-ルートポイントマネージャーオブジェクトの作成)
- [9. ARオブジェクト（メダル）の実装](#9-ARオブジェクトメダルの実装)
    - [9-1. メダルのプレハブ作成](#9-1-メダルのプレハブ作成)
    - [9-2. メダルのスクリプト実装](#9-2-メダルのスクリプト実装)
- [10. 利用するPLATEAU 3D都市モデルの切り替えUIの実装](#10-利用するPLATEAU3D都市モデルの切り替えUIの実装)
    - [10-1. 3D都市モデル切り替えUIの構築](#10-1-3D都市モデル切り替えUIの構築)
    - [10-2. メッセージテキストの作成](#10-2-メッセージテキストの作成)
    - [10-3. 切り替えボタンの実装](#10-3-切り替えボタンの実装)

# 1. ARトレジャーマップ　チュートリアルの概要
## 1-1. チュートリアルの目的
近年、観光用アプリケーションなど、AR技術を用いて現実の都市空間の中で体験可能な周遊型のARアプリケーションが多く見られます。都市におけるARアプリケーションでは、自己位置認識によるコンテンツの位置あわせや表示コンテンツのオクルージョン（遮蔽）表現が重要です。 <br>
このチュートリアルでは、PLATEAU SDK for Unity、 PLATEAU SDK-Toolkits for Unity および PLATEAU SDK-AR-Extensions for Unity を用いて、街に配置された観光コンテンツを閲覧するアプリケーションを開発します。 <br>

## 1-2. 開発環境
Unity 2021.3.35(LTS) 以降 <br>
PLATEAU SDK for Unity  2.3.2 <br>
PLATEAU SDK-Toolkits for Unity 1.0.0 <br>
PLATEAU SDK-AR-Extensions for Unity 1.0.0 <br>
PLATEAU SDK-Maps-Toolkit for Unity 1.0.0 <br>

## 1-3. 準備
Unityの開発環境の準備 <br>
PLATEAU SDK for Unity のダウンロード（[2-2. PLATEAU SDKの追加](#2-2-PLATEAUSDKの追加)） <br>
PLATEAU SDK Toolkit for Unity のダウンロード（[2-4. PLATEAU SDK-Toolkits の追加](#2-4-PLATEAU-SDK-Toolkitsの追加)） <br>
UI画像のダウンロード： [Assets/Images/UI](../Assets/Images/UI) 内の画像をダウンロードしてください。 <br>


# 2. 環境作成
## 2-1. プロジェクト作成
Unity Hub からプロジェクトを作成します。Unity バージョン 2021.3.35F1(LTS) で、3D(URP) を選択してプロジェクトを作成します。
<img width="800" alt="project_creation" src="./Images/project_creation.png">

## 2-2. PLATEAU SDKの追加
作成されたプロジェクトに、PLATEAU SDK for Unity を導入します。 <br>
https://project-plateau.github.io/PLATEAU-SDK-for-Unity/manual/Installation.html

## 2-3. 3D都市モデルの読み込み
PLATEAU SDK を使って3D都市モデルをインポートします。 <br>
https://project-plateau.github.io/PLATEAU-SDK-for-Unity/manual/ImportCityModels.html

## 2-4. PLATEAU SDK-Toolkitsの追加
[こちら](https://github.com/Project-PLATEAU/PLATEAU-SDK-Toolkits-for-Unity?tab=readme-ov-file#3-plateau-sdk-toolkits-for-unity-%E3%81%AE%E3%82%A4%E3%83%B3%E3%82%B9%E3%83%88%E3%83%BC%E3%83%AB)を参考にPLATEAU SDK-Toolkits for Unityをプロジェクトにインポートします。

## 2-5. PLATEAU SDK-AR-Extensionsの追加
[こちら](https://github.com/Project-PLATEAU/PLATEAU-SDK-AR-Extensions-for-Unity?tab=readme-ov-file#%E4%BA%8B%E5%89%8D%E6%BA%96%E5%82%99)を参考にPLATEAU SDK-AR-Extensions for Unity、 Google ARCore Extensions、Cesium for Unity をプロジェクトにインポートします。

## 2-6. PLATEAU SDK-Maps-Toolkitの追加
[こちら](https://github.com/Project-PLATEAU/PLATEAU-SDK-Maps-Toolkit-for-Unity?tab=readme-ov-file#plateau-sdk-maps-toolkit-for-unity-%E3%81%AE%E3%82%A4%E3%83%B3%E3%82%B9%E3%83%88%E3%83%BC%E3%83%AB)を参考にPLATEAU SDK-Maps-Toolkitをプロジェクトにインポートします。

## 2-7. Google ARCore APIの設定
Geospatial API を利用するためには、 Google Cloud プロジェクトを用意し、ARCore API の認証を設定する必要があります。ARCore API を有効化し、API認証を設定することで端末から Geospatial API を利用することができるようになります。設定方法については別のドキュメントにて解説されているため、そちらを参考に設定してください。 <br>
[PLATEAU Tutorials TOPIC14｜VR・ARでの活用[3/3]｜Google Geospatial APIで位置情報による3D都市モデルのARを作成する](https://www.mlit.go.jp/plateau/learning/tpc14-3/#p14_3_2)

## 2-8. シーンの作成
ARトレジャーマップを実装するシーンを作成します。File > New Scene を選択し、新しいシーンを作成します。ARアプリケーションでは、カメラはAR専用のカメラを後述の手順で用意して利用するため、デフォルトでシーンに含まれている “Main Camera” を削除してください。 <br>
上記が完了したら、File > Save を選択し（もしくは Ctrl + S / ⌘ + S）、”Assets/Scenes” に ”Main” の名前でシーンを保存します。 <br>
以下では一部解説用に “Tutorial” と命名したシーンでARトレジャーマップの構築手順について解説している場合があります。 <br>

## 2-9. AR環境およびGeospatialコントローラーの設定
ARアプリケーションを実装するには、AR Session や AR Session Origin などのAR環境を構築する必要があります。また、Geospatial APIをこのアプリケーションで利用するために、Geospatial APIの初期化や利用を管理するためのオブジェクトが必要です。 <br>
ここでは、PLATEAU SDK-AR-Extensions に同梱されているサンプルを利用します。 <br>
Window > Package Manager を開き、 “PLATEAU SDK AR Extensions for Unity” を選択し、Samples から “AR Samples” をインポートします。 <br>
<img width="800" alt="ARsample_import" src="./Images/ARsample_import.png">

サンプルに含まれる “Assets/Samples/PLATEAU SDK AR Extensions for Unity/0.3.0/AR Samples/Prefabs/AR.prefab” をシーン上にドラッグアンドドロップしてインスタンス化します。プレハブをシーン上に配置すると、青いアイコンと文字で表示され、プレハブ本体に変更が加えられるとシーン上のプレハブのインスタンスにも変更が反映されます。 <br>
<img width="400" alt="ARsample_instance" src="./Images/ARsample_instance.png">


ここでは、プレハブから不要なオブジェクトなどを削除して別のオブジェクトとして利用するため、生成したインスタンスを右クリックし、 Prefab > Unpack Completely を選択してプレハブの参照を削除します。 <br>
<img width="400" alt="ARsample_delete_reference" src="./Images/ARsample_delete_reference.png">

“AR” プレハブには、デバッグ用の設定ウィンドウや Geospatial API のトラッキング情報を表示するためのUIなどが含まれています。これらは以下の画像に表示されているメニューから開くことができます。開発中はARやGeospatial APIが正しく動作しているかを確認するのに有効なので、削除しなくても問題ありませんが、アプリケーションの利用者にとっては不要なデータであるため、完成済みのARトレジャーマップではこれらのUIなどは削除しています。 <br>
<img width="400" alt="ARsample_debugui" src="./Images/ARsample_debugui.png">

ARトレジャーマップで必須となるコンポーネントは以下のような構成です。 <br>
<img width="400" alt="ARsample_hierarchy" src="./Images/ARsample_hierarchy.png">

## 2-10. オクルージョンの設定
PLATEAU SDK でインポートした3D都市モデルにはLOD設定によって異なりますが、建物のテクスチャが設定されていたりするため、オクルージョン用に利用するためのマテリアルの設定が必要になります。 <br>
以下の AR Extensions のREADMEドキュメントを参考に、オクルージョンのための Renderer Feature やレイヤーの設定を行ってください。 <br>
[ARオクルージョン機能の利用方法](https://github.com/Project-PLATEAU/PLATEAU-SDK-AR-Extensions-for-Unity?tab=readme-ov-file#5-ar%E3%82%AA%E3%82%AF%E3%83%AB%E3%83%BC%E3%82%B8%E3%83%A7%E3%83%B3%E6%A9%9F%E8%83%BD%E3%81%AE%E5%88%A9%E7%94%A8%E6%96%B9%E6%B3%95)


# 3. Geospatial API 位置合わせ機能の実装 (PLATEAU SDK)
## 3-1. PLATEAU SDKで3D都市モデルのインポート
作成したシーンにPLATEAU SDKを用いてARトレジャーマップで使用する3D都市モデルをインポートします。 <br>
以下のPLATEAU SDK公式ドキュメントを参考に3D都市モデルをインポートしてください。ARトレジャーマップでは現実の建物のオクルージョンのために3D都市モデルを利用するため、「建築物」以外の要素はインポートする必要はありません。 <br>
[PLATEAU SDK - 都市モデルのインポート](https://project-plateau.github.io/PLATEAU-SDK-for-Unity/manual/ImportCityModels.html) <br>
インポートが完了すると、シーン上に3D都市モデルのゲームオブジェクトが生成されます。 <br>

## 3-2. 3D都市モデルのプレハブ化
<img width="800" alt="Plateau_imported_model" src="./Images/Plateau_imported_model.png">
インポートする範囲や地域によって異なりますが、インポートした3D都市モデルは比較的大きいサイズのデータであるため、シーンファイルが非常に大きくなる場合があります。FBXファイルに出力することで、シーンに同じように3D都市モデルを配置してもシーンが保持するデータはFBXファイルの参照と座標データのみになるため、シーン自体を軽量化することができます。また、シーン上にPLATEAU SDKでインポートされた3D都市モデルは CityGML の属性などの情報を保持していますが、FBXファイルにエクスポートすることでこれらの情報は削除されるため、3D都市モデル自体のファイルサイズも削減することができます。 <br>
※ARトレジャーマップではプロジェクトをGitHubにアップロードする都合上、シーンファイルが50MiB以上になるとアップロード時に警告メッセージが表示され、100MiB以上はアップロードができなくなるため、これを解決するために建物の本体のデータをFBXファイルとして出力して再構築することでこれを回避しています。 <br>

PLATEAU > PLATEAU SDK から PLATEAU SDK エディターウィンドウを開き、エクスポートタブを選択します。”選択オブジェクト” の”エクスポート対象” にインポートした3D都市モデルオブジェクトの参照を設定します。出力形式はFBXを選択し、テクスチャのチェックはオフにします（ARトレジャーマップではオクルージョン用に3D都市モデルを使用し、テクスチャが不要のため）。 <br>
<img width="500" alt="PlateauSDK" src="./Images/PlateauSDK.png"> <br>

出力設定が完了したら、”出力フォルダ” の “フォルダパス” を “参照...” をクリックして“Assets/Models/Ginza” フォルダを作成して選択し、 “エクスポート” を押下して3D都市モデルをFBXファイルに出力します。PLATEAU SDKのエクスポート機能ではエクスポートが完了してもアセットの更新が行われないため、Windows ファイルエクスプローラーや macOS Finder を開いてファイルが出力されていることを確認して再度Unityエディターを確認してください（Unityエディターを非アクティブにしてからアクティブにするとアセットの更新処理が行われ、出力されたFBXファイルがインポートされます）。出力されるFBXファイルは3D都市モデルの範囲によって複数の区画で分割されるため、複数になる場合があります。 <br>
シーン上に新しく空のゲームオブジェクトを作成し、”Buildings” と命名します。このオブジェクトの中に出力されたFBXファイルをすべて配置してください。出力されたFBXファイルはスケールが1/100になりX軸が反転しているため、すべての配置したFBXファイルのスケールは (-100, 100, 100) を設定します。 <br>
<img width="800" alt="Plateau_imported_model_scale" src="./Images/Plateau_imported_model_scale.png">


スケールに関して、FBXのデフォルトの単位設定がセンチメートルであり、Unityのインポート設定ではこれを解決するためのチェックボックスがあります。Unityからエクスポートした3D都市モデルのFBXファイルは単位を変換する必要なく正しい大きさで表示することができるため、このチェックボックスをオフにすることで正しい大きさで表示させることができます。一方で、X軸が反転する現象は設定からは解消されないためスケールのxを-1に設定してください。 <br>
尚、この反転が起こる現象はSDKバージョン2.3.2以降で解消されており、エクスポート時に座標軸をWUNに設定することで正しい向きで3D都市モデルを配置することができます。 <br>
<img width="500" alt="Plateau_imported_model_inspector" src="./Images/Plateau_imported_model_inspector.png">

プロジェクトビューから “Assets/Prefabs” フォルダを作成し、シーン上にある “Buildings” オブジェクトをドラッグアンドドロップしてプレハブを作成してください。 <br>
エクスポートの元になったシーン上の建物オブジェクトを削除し、作成したプレハブに差し替えます。3D都市モデルの親オブジェクトは “PLATEAU Instanced City Model” コンポーネントがアタッチされており、このコンポーネントから緯度経度などを取得して位置合わせをするため、このオブジェクトの子オブジェクトのみを削除します。 <br>
最後に3D都市モデルの親オブジェクトの中に、作成した “Buildings” プレハブを配置します。 <br>
以上で3D都市モデルの軽量化とプレハブ化は完了です。 <br>
<img width="400" alt="buildings_hierarcy" src="./Images/buildings_hierarcy.png">

## 3-3. 位置合わせコンポーネントの設定
ARトレジャーマップではオクルージョンのための3D都市モデルだけでなく、後述する手順で用意するメダルのARオブジェクトも位置合わせさせる必要があるため、これらをまとめて位置合わせするための親オブジェクトを作成します。 <br>
ヒエラルキー上で右クリックをして Create Empty を選択して空のゲームオブジェクトを作成します。ここでは PLATEAU SDK でインポートしたモデルを利用するため、 “PreImportedCityModel” という名前に設定します。 <br>
“PreImportedCityModel” の中にインポートした3D都市モデルオブジェクトを配置します。このとき、 “PreImportedCityModel” から見た3D都市モデルオブジェクトのローカル座標がずれるケースがあるため、3D都市モデルオブジェクトのローカル座標が (0, 0, 0) に設定されていることを確認してください。 <br>
<img width="800" alt="check_local_coordinate" src="./Images/check_local_coordinate.png">


“PreImportedCityModel” に位置合わせコンポーネントをアタッチします。インスペクターの “Add Component” から “PlateauARPositioning” コンポーネントを選択します。 <br>
このコンポーネントはジオイド高を取得するためのコンポーネントが必要になりますが、ジオイド高取得のコンポーネントは PLATEAU SDK-AR-Extensions では具体的な実装を持っていないため、サンプルで用意されている “GsiGeoidHeightProvider” を同様にアタッチします。この実装では国土地理院の提供するジオイド高取得APIを利用してジオイド高を取得するようになっています。本APIの詳細については国土地理院の[公式ドキュメント](https://vldb.gsi.go.jp/sokuchi/surveycalc/api_help.html)を参照してください。 <br>

次に、 “PlateauARPositioning” に必要な参照を設定します。 <br>
ここでは、 PLATEAU SDK でインポートしたモデルを利用するため、以下の設定が必要になります。  <br>
- 共通設定
  - Geospatial コントローラー
  - ジオイド高取得コンポーネント
- PLATEAU SDK でインポートした3D都市モデル用の設定
  - インポートした3D都市モデルの参照

“PlateauARPositioning” は PLATEAU SDK でインポートした3D都市モデルと Cesium でストリーミングされる3D都市モデルの両方に対応しているため、そのどちらかを設定すれば利用することができます。 <br>
“Geospatial Controller“ に生成した “AR” インスタンスの中の “GeospatialController”、 “Geoid Height Provider” にアタッチした “Gsi Geoid Height Provider” コンポーネント、 “Plateau City Model” にインポートした3D都市モデルの参照を設定します。 <br>
<img width="500" alt="plateau_ar_positioning" src="./Images/plateau_ar_positioning.png">

以上でビルドしたアプリケーションでこのシーンを起動すると、インポートした3D都市モデルの地域で3D都市モデルが現実の建物と同じ位置に表示されるようになります。 <br>

## 3-4. オクルージョンの設定
以下の手順に従い、インポートした3D都市モデルにオクルージョンの設定を行います。 <br>
[5-6. 遮蔽するオブジェクトのレイヤーを変更](https://github.com/Project-PLATEAU/PLATEAU-SDK-AR-Extensions-for-Unity?tab=readme-ov-file#5-6-%E9%81%AE%E8%94%BD%E3%81%99%E3%82%8B%E3%82%AA%E3%83%96%E3%82%B8%E3%82%A7%E3%82%AF%E3%83%88%E3%81%AE%E3%83%AC%E3%82%A4%E3%83%A4%E3%83%BC%E3%82%92%E5%A4%89%E6%9B%B4) <br>
[5-7. 遮蔽するオブジェクトのマテリアルをZWriteに変更](https://github.com/Project-PLATEAU/PLATEAU-SDK-AR-Extensions-for-Unity?tab=readme-ov-file#5-7-%E9%81%AE%E8%94%BD%E3%81%99%E3%82%8B%E3%82%AA%E3%83%96%E3%82%B8%E3%82%A7%E3%82%AF%E3%83%88%E3%81%AE%E3%83%9E%E3%83%86%E3%83%AA%E3%82%A2%E3%83%AB%E3%82%92zwrite%E3%81%AB%E5%A4%89%E6%9B%B4)

# 4. Geospatial API 位置合わせ機能の実装 (Cesium)
Geospatial API を用いてAR空間内にCesiumでストリーミングされたPLATEAUの3D都市モデルを表示させる実装を行います。PLATEAU SDK を用いてインポートした3D都市モデルと同じ手順で設定することができます。

## 4-1. Cesiumで3D都市モデルのストリーミング設定
メニューの Cesium > Cesium から Cesium のエディターウィンドウを開きます。 <br>
<img width="800" alt="cesium_editor_window" src="./Images/cesium_editor_window.png">

“Blank 3D Tiles  Tileset” を押下し、シーン上に Cesium 3D Tileset オブジェクトを作成します。このオブジェクトは次のように、Cesium 3D Tileset は緯度経度の座標を Unity 空間内の座標に変換するための CesiumGeoreference コンポーネントがアタッチされた親オブジェクトと一緒に作成されます。 <br>
<img width="500" alt="create_3d_tileset" src="./Images/create_3d_tileset.png">


作成された “Cesium3DTileset” オブジェクトを選択し、インスペクターを確認します。 <br>
“Tileset Source” を “From Url” に変更し、以下の PLATEAU 3D Tiles ストリーミングの配信データから、利用する地域のURLを選択します。 <br>
[plateau-3D Tiles-streaming - 4. 配信データ（3D Tiles）一覧](https://github.com/Project-PLATEAU/plateau-streaming-tutorial/blob/main/3d-tiles/plateau-3dtiles-streaming.md#4-%E9%85%8D%E4%BF%A1%E3%83%87%E3%83%BC%E3%82%BF3d-tiles%E4%B8%80%E8%A6%A7)
ARトレジャーマップでは、GINZA SIXを中心としたARアプリケーションを作成しているため、[中央区 LOD2（テクスチャなし）のURL](https://assets.cms.plateau.reearth.io/assets/3f/3dfe7e-e4a9-42b7-8b08-6fe528ed1245/13100_tokyo23-ku_2022_3dtiles_1_1_op_bldg_13102_chuo-ku_lod2_no_texture/tileset.json)を使用します。 <br>

## 4-2. 位置合わせコンポーネントの設定
PLATEAU SDKでインポートした3D都市モデルと同様に位置合わせコンポーネントを設定します（[3-3. 位置合わせコンポーネントの設定](#3-3-位置合わせコンポーネントの設定)）。ここでは、Cesium でストリーミングされる3D都市モデルを利用するため、位置合わせ用の親オブジェクトの名前は”StreamingCityModel”と設定します。 <br>
また、位置合わせコンポーネントの共通設定はPLATEAU SDKでインポートしたモデルと共通ですが、位置合わせの対象となる3D都市モデルはCesiumを用いるため、 “Cesium Georeference” と “Cesium 3D Tileset” に前の手順で作成したオブジェクトのコンポーネントを設定します。それぞれ、作成した “CesiumGeoreference” オブジェクトと “Cesium3DTileset” オブジェクトの参照を設定します。 <br>
<img width="500" alt="plateau_ar_positioning_attach" src="./Images/plateau_ar_positioning_attach.png">

## 4-3. オクルージョンの設定
以下の手順に従い、インポートした3D都市モデルにオクルージョンの設定を行います。 <br>
[5-6. 遮蔽するオブジェクトのレイヤーを変更](https://github.com/Project-PLATEAU/PLATEAU-SDK-AR-Extensions-for-Unity?tab=readme-ov-file#5-6-%E9%81%AE%E8%94%BD%E3%81%99%E3%82%8B%E3%82%AA%E3%83%96%E3%82%B8%E3%82%A7%E3%82%AF%E3%83%88%E3%81%AE%E3%83%AC%E3%82%A4%E3%83%A4%E3%83%BC%E3%82%92%E5%A4%89%E6%9B%B4) <br>
[5-7. 遮蔽するオブジェクトのマテリアルをZWriteに変更](https://github.com/Project-PLATEAU/PLATEAU-SDK-AR-Extensions-for-Unity?tab=readme-ov-file#5-7-%E9%81%AE%E8%94%BD%E3%81%99%E3%82%8B%E3%82%AA%E3%83%96%E3%82%B8%E3%82%A7%E3%82%AF%E3%83%88%E3%81%AE%E3%83%9E%E3%83%86%E3%83%AA%E3%82%A2%E3%83%AB%E3%82%92zwrite%E3%81%AB%E5%A4%89%E6%9B%B4)


# 5. マーカー位置合わせ機能の実装
Geospatial APIを利用せず、ARマーカーの機能を用いて実際の建物の位置に3D都市モデルを表示させる実装を行います。この方法では、ARマーカーと3D都市モデルの相対位置をあらかじめ設定し、建物からの相対位置に当たる場所にARマーカーを配置することで3D都市モデルを表示させます。 <br>

## 5-1. 3D都市モデルの実装
PLATEAU SDKを用いてインポートした3D都市モデルをマーカーで位置合わせしますが、利用する3D都市モデルは第3章と同様なので、第3章で作成した3D都市モデルをコピーして利用します。 <br>
シーン上の “PreImportedCityModel” オブジェクトを右クリックし “Duplicate” を押下してゲームオブジェクトを複製します。複製したオブジェクトを “CityModels” と命名します。このオブジェクトにアタッチされているコンポーネントの “Plateau AR Positioning” と “Gsi Geoid Height Provider” はマーカーによる位置合わせでは不要になるため、削除します。次に、新しく “ARMarkerBasedCityModel” という名前でゲームオブジェクトを作成し、 このオブジェクトの中に “CityModels” オブジェクトを配置します。他のAR用3D都市モデルと構成が異なるのは、ARマーカーの位置合わせでは位置を合わせるための別の親オブジェクトが必要になるためです。 <br>
<img width="500" alt="citymodels_hierarchy" src="./Images/citymodels_hierarchy.png">

## 5-2. マーカーの設定
位置合わせで利用するARマーカーの設定を行います。 <br>
 “Assets/Images” フォルダを作成し、ARマーカーに設定するために用意した以下の画像を配置します。ARマーカーを利用した位置合わせではGeospatial APIのようなVPSの機能を利用せず、端末のジャイロセンサーなどを利用した位置情報を利用するため、読み取ったマーカーから離れてしまうと、認識したマーカーのAR空間内の位置と実際にARマーカーを置いている位置にズレが発生します。そのため、一定距離ごとにマーカーを設定することで、最初に読み取ったマーカーの位置から移動したあとに再度マーカーを読み取って再度位置合わせを行うことができます。 <br>
<img width="400" alt="ARmarker" src="./Images/ARmarker.png">

    
ARマーカーはUnity AR Foundationの参照画像ライブラリ(Reference Image Library)によって設定することができます。プロジェクトビューで “Assets” フォルダを右クリックし、 Create > XR > Reference Image Library を選択して参照画像ライブラリ を作成します。 <br>
作成した参照画像ライブラリをプロジェクトビューで選択し、インスペクタを開きます。 “Add Image” から、先程用意した3つの画像を登録します。それぞれ、 “Specify Size” チェックボックスを有効化し、 “Physical Size (meters)” に 0.095 を設定します。この設定により、用意したARマーカー画像は9.5cm✕9.5cmの大きさに印刷することでARマーカーとして読み取ることができます。 <br>
次に、作成した参照画像ライブラリをシーンのAR設定に反映します。シーンの AR > AR Environment > AR Session Origin を選択し、 “AR Tracked Image Manager” コンポーネントの “Serialized Library” に作成した参照画像ライブラリを設定してください。 <br>
<img width="600" alt="ar_session_origin_inspector" src="./Images/ar_session_origin_inspector.png">

## 5-3. マーカー位置合わせコンポーネントの設定
ARマーカーを用いた位置合わせを行うコンポーネントを設定します。【1】で用意した “ARMarkerBasedCityModel” オブジェクトに “Plateau AR Marker City Model” コンポーネントをアタッチします。都市モデルオブジェクトに “CityModels” オブジェクト、マーカー画像ライブラリに “AR Tracked Image Manager” コンポーネントがアタッチされている “AR Origin Session” オブジェクトを設定してください。マーカー画像ライブラリを設定すると、”ARマーカー設定” 項目が表示されます。 <br>
<img width="500" alt="ar_tracked_image_manager" src="./Images/ar_tracked_image_manager.png">

ARマーカー設定を行うためには、相対位置を指定するためのゲームオブジェクトを選択する必要があります。 “CityModels” オブジェクト以下にゲームオブジェクトを作成します。このオブジェクトは3D都市モデルから見たマーカーを現実空間に配置する相対位置に設定する必要がありますが “Plateau AR Marker City Model” コンポーネントのマーカー設定が完了してから行います。 <br>
作成したオブジェクトは”ARMarkerPointと命名します。 <br>
“Plateau AR  Marker City Model” コンポーネントの “ARマーカー設定” の下部に表示されている “+” ボタンを押下し、マーカー設定を追加します。プルダウンから対象とするマーカー画像名を選択し、その下の Transform の参照には先程の手順で作成したゲームオブジェクトを以下のように設定します。 <br>
<img width="500" alt="ar_marker_registration" src="./Images/ar_marker_registration.png">

複数枚のARマーカーを設置する場合は別のマーカー画像を用意し、上記のステップを繰り返してください。  <br>

次に、位置合わせ用のオブジェクトを現実空間にマーカーを置く位置に合わせて配置します。このとき、マーカー設定が完了していると、配置されるマーカーのプレビューがシーンビュー上で表示されます。このプレビューはエディター用の実装のため、ゲームビューやビルドしたアプリケーションでは表示されません。 <br>
<img width="800" alt="ar_marker_preview" src="./Images/ar_marker_preview.png">

今回はスタート地点となるGINZA SIXの入り口付近に位置合わせ用のオブジェクトを配置します。この設定により、実際のGINZA SIX の入り口付近のこの位置に印刷したマーカー画像をこの向きに配置することで、この位置に3D都市モデルを表示させることができます。 <br>
<img width="400" alt="ar_marker_preview_zoom" src="./Images/ar_marker_preview_zoom.png">

# 6. UI実装の準備
以降の項目では、3D機能以外にもUIの機能を実装します。そのため、UIを取りまとめるキャンバスなどを事前に構築します。 <br>
ARトレジャーマップでは [Unity UI (com.unity.ugui)](https://docs.unity3d.com/Manual/com.unity.ugui.html) を用いてUIを実装します。 <br>


# 6-1. キャンバス (Canvas) の作成
ARシーンのヒエラルキーを右クリックから UI > Canvas を選択してキャンバスオブジェクトを作成します。 <br>
“CanvasScaler” コンポーネントのパラメータを次のように設定します。 <br>
<img width="400" alt="canvas_scaler" src="./Images/canvas_scaler.png">

この設定により、端末の解像度が変化した場合も画面比率に合わせてUIの大きさを調整させることができます。

# 6-2. 各種ページの作成
ARトレジャーマップでは、画面遷移ごとを取りまとめるゲームオブジェクトを作成し、アクティブ・非アクティブを切り替えることでページ遷移を実現します。 <br>
以下の3つのページに対応するゲームオブジェクトを作成します。 <br>
- TopPage
  - アプリケーションを起動した際に一番最初に表示されるページ
  - 「ARトレジャーマップ」のタイトルの表示
  - 「始めましょう」のボタンをタップして次のページへ遷移
- SelectModePage
  - 3D都市モデルの利用方法を選択するページ
  - 実装する3つの種類の3D都市モデルから一つを選択する
- GamePage
  - ARトレジャーマップのメインゲームページ
  - ゲームに必要な進捗管理UIやメッセージUIを表示する

この章以降では、これらのページオブジェクトの中にUIを配置してアプリケーションを構築します。基本的にUIのコールバックなどで各ページオブジェクトのアクティブ・非アクティブを切り替えるため、それぞれのページの実装時はページオブジェクトをアクティブにして開発を行ってください。


# 6-3. セーフエリアの作成
iPhoneなどの一部の端末では、液晶の一部にノッチやホームボタンなどがあるため、セーフエリアというUIを配置しても問題ない領域が設定されています。したがって、ボタンなどのインタラクティブなUIはこのセーフエリア内に収まるように実装する必要があります。 <br>
UIゲームオブジェクトを端末のセーフエリアの大きさに合わせて拡縮する機能はサンプルの “SafeAreaScaler” スクリプトで実装されているため、こちらを利用します。 <br>
各ページオブジェクトに “SafeArea” という名前でゲームオブジェクトを作成し、 “SafeAreaScaler” をアタッチします。RectTransform は次のように設定します。 <br>
<img width="500" alt="safearea_rect_transform" src="./Images/safearea_rect_transform.png">

このように設定することで、実行時にセーフエリアに広がるように RectTransfrom の大きさが変更されます。 <br>
尚、背景画像などはセーフエリアに制限されると欠けてしまうため、セーフエリアの外側に配置する必要があります。 <br>


# 6-4. フォントの準備
ARトレジャーマップでは Google フォントの Noto Sans 日本語フォントを TextMeshPro を用いて使用します。 <br>
[このページ](https://fonts.google.com/noto/specimen/Noto+Sans+JP)からフォントファイルをダウンロードします。 <br>

ダウンロードしたZIPファイルを解凍し、展開されたフォルダを “Assets/Fonts” フォルダに配置します。 <br>
TextMeshPro でフォントを使用するため、Unity エディターのプロジェクトビューから ”Assets/Fonts/Noto_Sans_JP/static/NotoSansJP-Regular” で右クリック、Create > TextMeshPro > Font Asset を選択し、フォントアセットを作成します。 <br>
Regular以外にも、Bold と ExtraBold を使用するため、これらのフォントファイルに対して同様にフォントアセットを作成します。 <br>


# 7. タイトル画面の実装
“Canvas/TopPage” に起動時に表示される画面を実装します。 <br>
<img width="400" alt="title" src="./Images/title.png">

タイトル画面は単にUIを並べ、一部UIにアニメーションを付与しているシンプルな構成であり、特筆するべき点がないため、ここでは大まかな構成と一部の実装のみ紹介します。 <br>
背景画像は次の画像を使用しています。 <br>
<img width="400" alt="background" src="./Images/background.png">

“Canvas/TopPage” の直下に ”Background” の名前で UI画像オブジェクトを作成し、上記の画像を設定します。 <br>
さらに、このオブジェクトの下に装飾のためのコイン画像を配置します。タイトル画面ではコインのアニメーションのため、画像オブジェクトの親オブジェクトを作成し、親オブジェクトを用いて位置を調整します。 <br>
<img width="800" alt="coin_inspector" src="./Images/coin_inspector.png">

“SafeArea” の中にタイトルロゴやPLATEAUロゴ、ゲーム開始ボタンを配置します。 <br>
ゲーム開始ボタンは以下の画像を使用します。 <br>
<img width="400" alt="start_button" src="./Images/start_button.png">

“Button” コンポーネントの “On Click ()” にページを切り替えるための処理を登録します。ボタンが押された際に、 “TopPage” を非アクティブにし、次のページである “SelectModePage” をアクティブにします。 <br>
<img width="500" alt="selectmodepage_active" src="./Images/selectmodepage_active.png">


# 8. ルート管理の実装
ARトレジャーマップでは、AR空間上に複数のチェックポイントを配置し、そのチェックポイントを実際に歩いて目指す体験を提供しています。この章ではそのチェックポイントやそれを管理する仕組みを実装します。 <br>

## 8-1. ルートポイントの実装
チェックポイントを含む、一連のルートを定義するための各点をルートポイントとして定義します。ルートポイントとチェックポイントを複数つなげることでルートを作成することができます。 <br>
以下のようなスクリプトを “Assets/Scripts” に作成します。

```C#
using UnityEngine;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// AR空間上のルート上の一点を表現します。
    /// </summary>
    /// <remarks>
    /// プレイヤーが目指すチェックポイントとそのチェックポイントの道を表現するルートポイントの
    /// 2種類の<see cref="RoutePoint" />が存在します。
    /// </remarks>
    public class RoutePoint : MonoBehaviour
    {
        /// <summary>チェックポイントかどうか</summary>
        [SerializeField] bool m_IsCheckPoint;

        /// <inheritdoc cref="m_IsCheckPoint" />
        public bool IsCheckPoint => m_IsCheckPoint;
    }
}
```

前述の通り、ルートポイントはチェックポイントと単にルートをつなぐためのルートポイントがあるため、それを設定するためのフラグを “SerializeField” で定義します。これにより、シーン上に作成した RoutePoint オブジェクトがチェックポイントかどうかを判定できるようになります。このフラグは「ルートポイントマネージャーの実装」の項目で実装するルートポイントマネージャーで使用します。 <br>

## 8-2. 経路の作成
前項で作成したスクリプトを用いて経路を作成します。まずは、ルートポイントのプレハブを作成します。 <br>
シーン上に ”RoutePoint” の名前で空のゲームオブジェクトを作成し、”RoutePoint” コンポーネントをアタッチします。コンポーネントのパラメーターはすべて初期値のままにします。 <br>
“RoutePoint” オブジェクトをヒエラルキーからプロジェクトの “Assets/Prefabs” にドラッグアンドドロップしてプレハブを作成します。正しく作成されると、”Assets/Prefabs” に “RoutePoint” が追加され、シーン上の “RoutePoint” オブジェクトは青色で表示されます。
プレハブの作成が完了したので、シーン上に作った “RoutePoint” オブジェクトは削除します。 <br>

次にチェックポイントのプレハブを作成します。  <br>
ARトレジャーマップのチェックポイントはメダルが表示され、メダルを獲得した際には獲得演出を行いますが、メダルの実装方法については第9章で解説します。ここでは、経路を作成する機能のみを持つチェックポイントのプレハブを作成します。 <br>
シーン上に ”RoutePoint” の名前で空のゲームオブジェクトを作成し、”RoutePoint” コンポーネントをアタッチします。コンポーネントのパラメーターは “Is Check Point” のチェックボックスをオンにします。 <br>
“RoutePoint” と同様にドラッグアンドドロップでプレハブを作成し、シーン上の “RoutePoint” オブジェクトは削除します。 <br>

ルートポイントとチェックポイントのプレハブが作成できたので、次にヒエラルキーに経路を構築します。 <br>
各モードの3D都市モデルオブジェクトの中に “CheckPoints” の名前で空のゲームオブジェクトを作成します。 <br>
プロジェクトビューの “Assets/Prefabs” から “CheckPoint” を3つ、 “RoutePoint” を2つ以下のように配置します。実際の経路の配置は[8-7. ルートポイントマネージャーの実装](#8-7-ルートポイントマネージャーの実装)後に行うことでシーンビューで経路を視覚的に確認しながらルートを設定することができます。 <br>

<img width="400" alt="checkpoints_hierarchy" src="./Images/checkpoints_hierarchy.png">

## 8-3. パス表示用オブジェクトのプレハブ作成
次の目的地までの道筋を表示するためのプレハブを作成します。 <br>
<img width="400" alt="checkpoints_inapp" src="./Images/checkpoints_inapp.png"> <br>
<img width="400" alt="checkpoint_preview" src="./Images/checkpoint_preview.png"> <br>

以下の画像をダウンロードし、 “Assets/Images/UI” フォルダに配置します。 <br>
<img width="400" alt="checkpoint" src="./Images/checkpoint.png"> 

シーン上に空のゲームオブジェクトを作成し、”PathPoint” に名前を変更します。 <br>
作成した “PathPoint” に “SpriteRenderer” コンポーネントをアタッチし、 “Sprite” に用意した画像を設定します。 <br>
<img width="800" alt="checkpoint_scene" src="./Images/checkpoint_scene.png"> 

 “SpriteRenderer” を用いることで、3D空間上に2D画像を表示させることができますが、カメラが移動するとUIのように常に正面に向きません。そのため、常にカメラに正面を向けるようなスクリプトを実装します。 <br>

```C#
using UnityEngine;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// 常にカメラの方を向くオブジェクトを設定します。
    /// </summary>
    class BillboardSprite : MonoBehaviour
    {
        const float k_TransparentDistance = 5;
        SpriteRenderer m_SpriteRenderer;

        void Awake(
        {
            TryGetComponent(out m_SpriteRenderer);
        }

        void Update()
        {
            if (Camera.main == null)
            {
                return;
            }

            transform.forward = -Camera.main.transform.forward;
            float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            m_SpriteRenderer.color = distance < k_TransparentDistance ?
                new Color(1, 1, 1, distance / k_TransparentDistance) :
                new Color(1, 1, 1, 1);
        }
    }
}
```

メインカメラの参照を取得し、スプライトがカメラが向いている方向のベクトルの逆ベクトルに向くような更新処理を実装しています。 <br>
また、カメラとの距離によってスプライトの透明度を変更させるような処理を実装します。”k_TransparentDistance” で定義する一定距離以下の距離になると、カメラに近づくにつれて透明度を低くします（カメラと同じ位置にあるとき、透明度を0にします）。パス表示オブジェクトがAR空間上で近くにあると、画面が埋まってしまうためこのように処理しています。 <br>
作成したスクリプトを “PathPoint” にアタッチします。 <br>
<img width="500" alt="pathpoint" src="./Images/pathpoint.png"> 

最後に、シーン上に作成した “PathPoint” オブジェクトを “Assets/Prefabs” にドラッグアンドドロップしてプレハブを作成します。


## 8-4. チェックポイント進捗管理UIの実装
目的地の進捗を表示するUIを実装します。 <br>
目的地であるメダルに到達すると、アイコンにメダルが表示されます。 <br>
<img width="500" alt="medal_meter_1" src="./Images/medal_meter_1.png"> 

1つ目の目的地に通過したときのUI <br>
<img width="500" alt="medal_meter_2" src="./Images/medal_meter_2.png"> 

全ての目的地を通過したときのUI <br>
以下のUI素材を “Assets/Images/UI” に配置します。 <br>
<img width="150" alt="CoinLeft" src="./Images/CoinLeft.png"> <img width="150" alt="CheckPointButton" src="./Images/CheckPointButton.png"> <img width="150" alt="OrangeBackground" src="./Images/OrangeBackground.png"> <img alt="PathPointLine" src="./Images/PathPointLine.png">

このUIはページの下部に表示されるため、下部のバーとして “BottomBar” の名前で新しく “GameScene” の “SafeArea” 内に ゲームオブジェクトを作成し、RectTransform を次のようなパラメータで設定します。これにより、画面の下部に高さ176pxの領域を設定することができます。 <br>
<img width="500" alt="bottombar_rect_transform" src="./Images/bottombar_rect_transform.png"> 

“BottomBar” を右クリックし、 UI > Image を選択してUI画像オブジェクトを作成します。”OrangeBackground.png” を画像に設定し、次のようにパラメータを設定します。 <br>
<img width="500" alt="background_rect_transform" src="./Images/background_rect_transform.png"> 

“BottomBar” の領域で引き伸ばすのではなく、300pxという高さで下方向にはみ出すように設定することで、スマートフォンのセーフエリアでUIの位置をずらしても背景画像が下方向に埋まるようにすることができます。 <br>
“BottomBar” 内に “CheckPointProgressUI” の名前で空のゲームオブジェクトを作成し、この中に進捗表示のメインUIを構築します。 <br>
“CheckPointProgressUI” に “HorizontalLayoutGroup” コンポーネントをアタッチし、”Spacing” を 24、 “Child Alignment” を “Middle Center” に設定します。 <br>
<img width="500" alt="CheckPointProgressUI_inspector" src="./Images/CheckPointProgressUI_inspector.png"> 

“CheckPointProgressUI” の中に空のゲームオブジェクトを作成し、”CheckPoint1” と命名します。このオブジェクトの中にメダルのアイコンとそのコンテナのUIを構築します。 <br>
<img width="400" alt="CheckPoint1" src="./Images/CheckPoint1.png"> 

作成した “CheckPoint1” はそれらを取りまとめるオブジェクトで、最終的にこれを複製して他のチェックポイントのUIオブジェクトを作成します。 <br>
“CheckPoint1” の RectTransform は幅と高さを 112px に設定します。 <br>
<img width="500" alt="CheckPoint1_inspector" src="./Images/CheckPoint1_inspector.png"> 

“CheckPoint1” を右クリックから UI > Image を選択し、子オブジェクトに “Base” の名前でUI画像オブジェクトを作成します。次の画像のようにパラメータを設定します。この設定で、”CheckPoint1” の大きさに広がるように画像が表示されます。 <br>
<img width="500" alt="base_rect_transform" src="./Images/base_rect_transform.png"> 

“Image” コンポーネントの画像には “CheckPointButton.png” を選択します。 <br>
“CheckPoint1” を右クリックから UI > Image を選択し、子オブジェクトに “Icon” の名前でUI画像オブジェクトを作成します。 “Image” コンポーネントの画像に “CoinLeft.png” を設定し、RectTransform は次のように設定します。 <br>
<img width="500" alt="icon_rect_transform" src="./Images/icon_rect_transform.png"> 

以上で次のようなコインのアイコンを作成することができます。 <br>
<img width="250" alt="coin_icon" src="./Images/coin_icon.png"> 

次に、アイコンとアイコンの間に表示するラインを実装します。 <br>
”CheckPointProgressUI” を右クリックし、 UI > Image からUI画像オブジェクトを作成し、”Image” コンポーネントの画像に “PathPointLine.png” を設定します。 <br>
RectTransform は次のように設定します。 <br>
<img width="500" alt="PathPointLine_recttransform" src="./Images/PathPointLine_recttransform.png"> 

最後に、アイコン1→ライン→アイコン2→ライン→アイコン3となるように作成したオブジェクトを複製し、ヒエラルキー上で並び替えます。 <br>
<img width="400" alt="line_hierarchy" src="./Images/line_hierarchy.png"> 

以上で、進捗表示UIオブジェクトの構築は完了です。次はスクリプトを作成します。
以下のスクリプトを “Assets/Scripts” に作成します。

```C#
using UnityEngine;
using UnityEngine.UI;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// チェックポイントの進捗を表示するUI
    /// </summary>
    public class CheckPointProgressUI : MonoBehaviour
    {
        [SerializeField] Image[] m_CheckPointImages;

        void Start()
        {
            foreach (Image checkPointImage in m_CheckPointImages)
            {
                checkPointImage.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
            }
        }

        /// <summary>
        /// すでにコンプリートしたチェックポイントの数を設定します。
        /// </summary>
        /// <param name="count"></param>
        public void SetCompletedCount(int count)
        {
            Debug.Log($"Set Complete Count: {count}");
            for (int i = 0; i < Mathf.Min(count, m_CheckPointImages.Length); i++)
            {
                Debug.Log($"Set complete {i} icon");
                m_CheckPointImages[i].color = new Color(1, 1, 1, 1);
            }
        }
    }
}
```

このスクリプトでは、進捗状況に合わせてアイコンの透明度を変更することで、メダルの獲得情報を管理します。”SetCompletedCount” メソッドを外部から呼び出し、進捗状況を反映することができます。 <br>
作成したスクリプトを “CheckPointProgressUI” オブジェクトにアタッチします。 <br>
“m_CheckPointImages” は “CheckPoint1” 等の中のメダルアイコン (“Icon”) の参照を配列で全て指定します。この配列の順序が進捗の順序になるため、”CheckPoint1” から “CheckPoint3” の順序でUI画像の参照を設定してください。 <br>
<img width="500" alt="CheckPointProgressUI_elements" src="./Images/CheckPointProgressUI_elements.png"> 

以上で進捗状況UIの構築は完了です。


## 8-5. スナックバーUIの実装
特定の状況でメッセージを表示するスナックバーを実装します。ARトレジャーマップはアイコンの異なる2種類のスナックバーを用意します。 <br>
<img width="500" alt="coin_acquired_message" src="./Images/coin_acquired_message.png"> 

以下の画像を “Assets/Images/UI” に保存します。<br>
<img height="100" alt="Snackbar" src="./Images/Snackbar.png"> <img alt="Camera" src="./Images/Camera.png"> <img alt="Flag" src="./Images/Flag.png">

“Snackbar.png” をプロジェクトビューで選択し、インスペクタを開きます。 <br>
<img width="500" alt="snackbar_inspector" src="./Images/snackbar_inspector.png"> 

”Sprite Editor” ボタンを押下してスプライトエディターを開き、右下のウィンドウの “Border” を
- L: 62
- R: 62
- T: 48
- B: 80
に設定します。 <br>
<img width="500" alt="snackbar_sprine_editor" src="./Images/snackbar_sprine_editor.png"> 

この設定により、UIの高さと幅の比率が素材の画像と異なった場合でも、適切に拡大されるようになります。 <br>
シーンの “Canvas/GamePage/SafeArea” に “CheckPointSnackBar” の名前で新しく Image オブジェクトを作成します（右クリック > UI > Image）。 <br>
RectTransform は次のように設定します。 <br>
<img width="500" alt="snackbar_rect_transform" src="./Images/snackbar_rect_transform.png"> 

Image コンポーネントの画像にはポリゴンの設定をした “snackbar.png” 、 “Image Type” を “Sliced” に指定します。 <br>
“CheckPointSnackBar” の子オブジェクトとして、右クリック > UI > Text - TextMeshPro を選択してメッセージ表示用のテキストオブジェクトを作成します。 <br>
“Font Asset” は “NotoSansJP-ExtraBold” を指定します。 <br>
メッセージが正しい領域に表示されるように、次のように RectTransform を設定します。 <br>
<img width="800" alt="camera_snackbar_rect_transform" src="./Images/camera_snackbar_rect_transform.png"> 

“CheckPointSnackBar” の子オブジェクトとして、右クリック > UI > Image を選択してアイコン表示用のUI画像オブジェクトを作成し、次のように RectTransform を設定します。Image コンポーネントの画像には “Flag.png” を指定します。 <br>
<img width="800" alt="flag_snackbar_rect_transform" src="./Images/flag_snackbar_rect_transform.png"> 

次に、スナックバーに表示するメッセージを管理するスクリプトを実装します。
以下のスクリプトを “Assets/Scripts/SnackbarUI.cs” に作成します。

```C#
using TMPro;
using UnityEngine;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// 画面上部スナックバーUI
    /// </summary>
    public class SnackbarUI : MonoBehaviour
    {
        [SerializeField] TMP_Text m_Message;

        /// <summary>
        /// スナックバーに表示するメッセージを設定します。
        /// </summary>
        /// <param name="message"></param>
        public void SetMessage(string message)
        {
            m_Message.text = message;
        }
    }
}
```

作成したスクリプトを “CheckPointSnackBar” にアタッチし、メッセージ表示用テキストの参照を “m_Message” に設定します。 <br>
以上で “CheckPointSnackBar” のセットアップは完了です。 <br>
<img width="400" alt="checkpoint_snackbar_hierarchy" src="./Images/checkpoint_snackbar_hierarchy.png"> 

前述の通り、アイコンの異なる別のスナックバーを用意するため、作成した “CheckPointSnackBar” を複製し、”CameraSnackBar” と命名します。アイコンの Image コンポーネントの画像を “Camera.png” に変更します。

## 8-6. コンプリートポップアップUIの実装
全ての目的地に到達したときのポップアップUIを実装します。 <br>
<img width="450" alt="complete_popup" src="./Images/complete_popup.png"> 

以下のUI画像を “Assets/Images/UI” に保存します。 <br>
<img alt="PopupWindow" src="./Images/PopupWindow.png"> <img alt="PopupButton" src="./Images/PopupButton.png"> <img alt="PopupEmoji" src="./Images/PopupEmoji.png">

背景のボックスとボタンの画像アセットはスプライトエディターを用いてポリゴンを設定します。 <br>
<img width="500" alt="popup_sprite_editor" src="./Images/popup_sprite_editor.png"> <br>
<img width="500" alt="popupbutton_sprite_editor" src="./Images/popupbutton_sprite_editor.png">

シーンの “Canvas/GamePage” に空のゲームオブジェクトを “CongraturationsModal” の名前で作成します。モーダルは常に画面中央に表示されるため、セーフエリアの中にいれる必要はありません。 <br>
RectTransform は次のように設定します。 <br>
<img width="400" alt="popup_hierarchy" src="./Images/popup_hierarchy.png"> 

コンプリートポップアップUIのコンテンツは以下のように作成します。

それぞれ、以下のようにセットアップします。
- Background: Image
  - <img width="500" alt="popup_background_rect_transform" src="./Images/popup_background_rect_transform.png"> 
- Icon: Image
  - <img width="500" alt="popup_image" src="./Images/popup_image.png"> 
- Message: Text - TextMeshPro (NotoSansJP-Bold)
  - <img width="500" alt="popup_message_tmp" src="./Images/popup_message_tmp.png"> 
  - フォントカラー: #000000
- Button: Button - TextMeshPro (NotoSansJP-Bold)
  - ボタン本体 (Button)
    - <img width="500" alt="popup_button_rect_transform" src="./Images/popup_button_rect_transform.png"> 
  - ボタンテキスト (Text (TMP))
    - <img width="500" alt="popup_button_tmp" src="./Images/popup_button_tmp.png">
    - フォントカラー: #FFFFFF

このポップアップはスクリプトから表示物を変更することがないため、特に専用のスクリプトを作成する必要はありません。 <br>
演出のため、ポップアップを表示する際の次のようなアニメーションを実装します。 <br>
- 透明度・スケールを0 → 1へアニメーションさせる
- スケールの 0 → 1 への移行はアニメーションカーブを調整することで、跳ねるような演出を実現する

まず、ポップアップの表示物全体の透明度を変更できるように “CanvasGroup” コンポーネントを “CongraturationsModal” にアタッチします。 <br>
次に、アニメーションを設定するために、 “Animation” コンポーネントをアタッチします。 <br>
メニューの Window > Animation > Animation から Animation ウィンドウを開き、ヒエラルキー上で “Animation” コンポーネントがアタッチされたゲームオブジェクトを選択すると Animation ウィンドウに表示される “Create” ボタンからアニメーションクリップを作成することができます。 <br>
<img width="800" alt="popup_animation_settings" src="./Images/popup_animation_settings.png">

“Create” ボタンを押下すると、アニメーションクリップのファイル保存先を選択する必要があるため、 “Assets/Animations/UI” フォルダを作り、 “ShowModal” の名前でファイルを作成します。 <br>
以下の “Add Property” から、スケールと透明度に関するプロパティを作成します。 <br>
<img width="400" alt="popup_animation_add" src="./Images/popup_animation_add.png">

それぞれ、以下のようなカーブに調整します。
<img width="800" alt="popup_animation_curve" src="./Images/popup_animation_curve.png">

アニメーションクリップが作成できたら、 “Animation” コンポーネントの “Play Automatically” のチェックボックスをオンにします。これにより、シーン上で非アクティブで開始するこのポップアップUIのオブジェクトはスクリプトからアクティブに変更されたタイミングでアニメーションが開始されます。
最後にボタンのイベントを実装します。コンプリートポップアップのボタンは全ての目的地に到達し、ゲームを終了するためのボタンであるため、この処理を実現するためのスクリプトを準備します。具体的には、ゲームの本体である “Main” シーンを再度読み込むことでアプリケーションをリセットさせます。 <br>
次のスクリプトを “Assets/Scripts/SceneLoader.cs” に保存します。

```C#
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// シーン操作機能を提供します。
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        /// <summary>
        /// メインシーンを再読み込みします。
        /// </summary>
        /// <remarks>
        /// ゲームクリア時にゲームを終了する際に使用されます。
        /// </remarks>
        [Preserve]
        public void ReloadMainScene()
        {
            SceneManager.LoadScene("Main");
        }
    }
}
```

作成したスクリプトは “GamePage” オブジェクトにアタッチし、 “Button” コンポーネントの “On Click ()” のリストに “ReloadMainScene” のメソッドを指定します。 <br>
<img width="500" alt="onclick_reloadmainscene" src="./Images/onclick_reloadmainscene.png">

## 8-7. ルートポイントマネージャーの実装
プレイヤーの位置情報によるメダルの獲得判定や進捗を管理する機能を実装します。ARトレジャーマップの中心となる機能であり、様々なコンポーネントと連携するため、多くのフィールドとロジックを持ちます。
クラス全体は非常に長いため、この項目では断片的にソースコードを添付し、解説します。完成済みのソースコードは GitHub から確認してください。 <br>
https://github.com/Project-PLATEAU/PLATEAU-Toolkits-Sample-ARTreasureMap/blob/main/Assets/Scripts/CheckPointManager.cs

まずは、クラスのデータ部分であるフィールドの定義とプロパティの実装を行います。 <br>
以下のソースコードを “Assets/Scripts/CheckPointManager.cs” に保存します。 <br>

```C#
using Google.XR.ARCoreExtensions;
using PlateauToolkit.AR;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// チェックポイントを管理します。
    /// </summary>
    public class CheckPointManager : MonoBehaviour
    {
        const float k_CheckPointDistance = 5;
        const float k_RoutePointMargin = 5;

        [SerializeField] RoutePoint[] m_CheckPoints;
        [SerializeField] Camera m_ARCamera;
        [SerializeField] GameObject m_PathPointPrefab;

        [SerializeField] Transform m_PathPointParent;

        [SerializeField] CheckPointProgressUI m_CheckPointProgressUI;
        [SerializeField] GameObject m_CompleteModalUI;
        [SerializeField] SnackbarUI m_SnackbarUI;
        [SerializeField] SnackbarUI m_CameraSnackbarUI;

        [SerializeField] bool m_IsShowingCompletedCheckpointEffect;

        [SerializeField] AREarthManager m_EarthManager;
        [SerializeField] PlateauARMarkerCityModel m_ARMarkerCityModel;

        public event Action<int> OnCheckPointCompleted;

        readonly List<GameObject> m_PathPointGameObjects = new();

        int m_CheckPointCount;
        int m_CompletedCheckPointCount;
        int m_LastCompletedCheckPoint = -1;
    }
}
```

登録されたルートポイントと最後に到達した地点を保持するフィールド “m_LastCompletedCheckPoint” から、次の地点までの道筋を “PathPoint” プレハブを用いて表示させるメソッドを実装します。 <br>
次の目的地がある場合に true を返し、そうでない場合に false を返します。 <br>

```C#
  bool ShowPathPointsToNextCheckPoint()
        {
            Debug.Log($"{nameof(ShowPathPointsToNextCheckPoint)}: LastCompletedCheckPoint = {m_LastCompletedCheckPoint}");

            int nextCheckPointIndex = 0;
            RoutePoint nextCheckPoint = null;
            for (int i = m_LastCompletedCheckPoint + 1; i < m_CheckPoints.Length; i++)
            {
                if (m_CheckPoints[i].IsCheckPoint)
                {
                    nextCheckPoint = m_CheckPoints[i];
                    nextCheckPointIndex = i;
                    break;
                }
            }

            if (nextCheckPoint == null)
            {
                return false;
            }

            for (int i = Mathf.Max(m_LastCompletedCheckPoint, 0); i < nextCheckPointIndex; i++)
            {
                RoutePoint routePoint = m_CheckPoints[i];
                RoutePoint nextPoint = m_CheckPoints[i + 1];

                if (!routePoint.IsCheckPoint)
                {
                    GameObject pathPoint = Instantiate(m_PathPointPrefab, m_PathPointParent, false);
                    m_PathPointGameObjects.Add(pathPoint);
                    pathPoint.transform.position = routePoint.transform.position;
                }

                Vector3 currentToNext = nextPoint.transform.position - routePoint.transform.position;
                Vector3 currentToNextDirection = currentToNext.normalized;
                float currentToNextDistance = currentToNext.magnitude;

                int pathPointCount = Mathf.CeilToInt(currentToNextDistance / k_RoutePointMargin) - 1;
                for (int j = 0; j < pathPointCount; j++)
                {
                    GameObject pathPoint = Instantiate(m_PathPointPrefab, m_PathPointParent, false);
                    m_PathPointGameObjects.Add(pathPoint);
                    pathPoint.transform.position =
                        routePoint.transform.position + (j + 1) * k_RoutePointMargin * currentToNextDirection;
                }

                Debug.Log($"Show Path: {i} -> {i + 1} ({pathPointCount} path points)");

                if (nextPoint.IsCheckPoint)
                {
                    break;
                }
            }

            return true;
        }
```
“ShowPathPointsToNextCheckPoint” で作成される道筋を示すゲームオブジェクトをすべて削除するメソッドを実装します。 <br>
```C#
        void ClearPathPoints()
        {
            foreach (GameObject pathPoint in m_PathPointGameObjects)
            {
                Destroy(pathPoint);
            }
            m_PathPointGameObjects.Clear();
        }
```

プレイヤーが目的地に到達したときの処理を実装します。ルートポイントはチェックポイント以外にも道筋を定義するためのルートポイントがあるため、最後に到達したチェックポイントのインデックス “m_LastCompletedCheckPoint” の次のチェックポイントを “m_LastCompletedCheckPoint” として保持します。 <br>
最後に到達したチェックポイントの更新が終わったあと、現在表示している道筋を削除し、新たに次の目的地までの道筋を “ShowPathPointsToNextCheckPoint” で表示させます。 <br>

```C#
     bool CompleteCheckPoint()
        {
            Debug.Log($"{nameof(CompleteCheckPoint)}");

            for (int i = m_LastCompletedCheckPoint + 1; i < m_CheckPoints.Length; i++)
            {
                if (m_CheckPoints[i].IsCheckPoint)
                {
                    Debug.Log($"Completed a check point: {i}");
                    m_LastCompletedCheckPoint = i;
                    break;
                }
            }

            ClearPathPoints();
            return ShowPathPointsToNextCheckPoint();
        }
```
到達済みのチェックポイントの数からスナックバーに表示されるメッセージを更新するメソッドを実装します。
```C#
        void UpdateSnackbarText()
        {
            if (m_CompletedCheckPointCount < m_CheckPointCount - 1)
            {
                m_SnackbarUI.SetMessage("次のチェックポイントを目指してください。");
            }
            else if (m_CompletedCheckPointCount == m_CheckPointCount - 1)
            {
                m_SnackbarUI.SetMessage("最後のチェックポイントを目指してください。");
            }
        }
```

ルート管理マネージャーの初期化処理を “Start” メソッドに実装します。 <br>
- 登録されたルートポイントの配列からチェックポイントの数をカウントし、”m_CheckPointCount” フィールドに保持する
- スナックバーにメッセージを設定する
- 開始地点までのルートポイントが設定されている場合に開始地点までのルートを表示させる

```C#
        void Start()
        {
            m_CheckPointCount = m_CheckPoints.Count(p => p.IsCheckPoint);
            m_SnackbarUI.SetMessage("最初のチェックポイントを目指してください。");
            ShowPathPointsToNextCheckPoint();
        }
```

ルート管理マネージャーの更新処理を ”Update” メソッドに実装します。 <br>
AR関連のコンポーネントが初期化され、利用可能になるまでは具体的なルート管理処理は実行されません。 <br>
プレイヤーの位置（ “m_ARCamera” ）が次の目的地に近づいた際に “CompleteCheckPoint” とイベントの呼び出しを行い、到達済みの目的地のカウントをインクリメントします。 <br>

```C#
        void Update()
        {
            if (m_EarthManager != null)
            {
                GeospatialPose pose = m_EarthManager.CameraGeospatialPose;
                if (m_EarthManager.EarthTrackingState != TrackingState.Tracking ||
                    pose.HorizontalAccuracy > 1f ||
                    pose.VerticalAccuracy > 1f ||
                    pose.OrientationYawAccuracy > 30)
                {
                    m_CameraSnackbarUI.gameObject.SetActive(true);
                    m_CameraSnackbarUI.SetMessage("周囲の建物にカメラをかざしてください。");
                    return;
                }

                m_CameraSnackbarUI.gameObject.SetActive(false);
            }

            if (m_ARMarkerCityModel != null)
            {
                if (m_ARMarkerCityModel.CurrentTrackingStatus is null or TrackingState.None)
                {
                    m_CameraSnackbarUI.gameObject.SetActive(true);
                    m_CameraSnackbarUI.SetMessage("ARマーカーを読み取ってください。");
                    return;
                }

                m_CameraSnackbarUI.gameObject.SetActive(false);
            }

            RoutePoint nextCheckPoint = null;
            for (int i = m_LastCompletedCheckPoint + 1; i < m_CheckPoints.Length; i++)
            {
                if (m_CheckPoints[i].IsCheckPoint)
                {
                    nextCheckPoint = m_CheckPoints[i];
                    break;
                }
            }

            if (nextCheckPoint == null)
            {
                return;
            }

            var nextCheckPointPosition = Vector3.ProjectOnPlane(
                nextCheckPoint.transform.position,
                nextCheckPoint.transform.up);
            var cameraPosition = Vector3.ProjectOnPlane(
                m_ARCamera.transform.position,
                nextCheckPoint.transform.up);
            float checkPointDistance = Vector3.Distance(nextCheckPointPosition, cameraPosition);

            if (checkPointDistance <= k_CheckPointDistance)
            {
                CompleteCheckPoint();
            }
            else
            {
                return;
            }

            m_CompletedCheckPointCount++;
            OnCheckPointCompleted?.Invoke(m_CompletedCheckPointCount);
            Debug.Log($"Completed Check Points: {m_CompletedCheckPointCount}");

            m_CheckPointProgressUI.SetCompletedCount(m_CompletedCheckPointCount);
        }
```

全てのチェックポイントに到達したときの処理を実装します。 <br>
外部から “m_IsShowingCompletedCheckpointEffect” が false から true になることでこの処理が実行され、具体的な処理自体は最後のチェックポイントに到達したときのみ実行されます。 <br>
”IsShowingCompletedCheckpointEffect” は後述するメダルオブジェクトのコンポーネントから、メダルオブジェクトの到達エフェクトの開始・終了時に true → false の順序で代入されます。 <br>
したがって、最後の目的地に到達し、その目的地のエフェクト表示が終了したタイミングですべての目的地に到達したことを示すダイアログを表示することができます。 <br>

```C#
        public bool IsShowingCompletedCheckpointEffect
        {
            get => m_IsShowingCompletedCheckpointEffect;
            set
            {
                if (m_IsShowingCompletedCheckpointEffect != value)
                {
                    m_IsShowingCompletedCheckpointEffect = value;
                    OnCompletedCheckpointEffectChanged();
                }
            }
        }

        void OnCompletedCheckpointEffectChanged()
        {
            if (m_IsShowingCompletedCheckpointEffect)
            {
                // Nothing special is done while the completion effect is displayed.
            }
            else
            {
                if (m_CompletedCheckPointCount == m_CheckPointCount)
                {
                    m_SnackbarUI.gameObject.SetActive(false);
                    Debug.Log("All checkpoints completed!");
                    m_CompleteModalUI.SetActive(true);
                }
                else
                {
                    UpdateSnackbarText();
                }
            }
        }
```

“OnDrawGizmos” メソッドを以下のように実装することで、シーンビューで “m_CheckPoints” に登録された 一連の道筋を表示させることができます。 <br>
<img width="800" alt="checkpoints_preview" src="./Images/checkpoints_preview.png">

```C#
        void OnDrawGizmos()
        {
            if (m_CheckPoints == null)
            {
                return;
            }

            Gizmos.color = new Color(1, 1, 0, 0.7f);
            foreach (RoutePoint checkPoint in m_CheckPoints)
            {
                if (checkPoint != null && checkPoint.IsCheckPoint)
                {
                    Gizmos.DrawCube(checkPoint.transform.position, new Vector3(1, 3, 1));
                }
            }

            Gizmos.color = Color.green;
            for (int i = 0; i < m_CheckPoints.Length - 1; i++)
            {
                RoutePoint a = m_CheckPoints[i];
                RoutePoint b = m_CheckPoints[i + 1];

                if (a == null || b == null)
                {
                    continue;
                }

                Gizmos.DrawLine(a.transform.position, b.transform.position);
            }
        }
```
        
## 8-8. ルートポイントマネージャーオブジェクトの作成
作成したスクリプトを動作させるため、シーン上に新しくゲームオブジェクトを作成し、スクリプトをアタッチします。 <br>
簡単な構成にするため、各モードごとに専用のルートポイントマネージャーオブジェクトを作成して利用します。同じ責務を持ったオブジェクトがシーン内に重複することになりますが、一つのモードだけを見た場合にこの構成がシンプルかつわかりやすいためこのようなに実装しています。したがって、一つのモードの中でルートポイントマネージャーを構築したあと、同様に他のモードでもルートポイントマネージャーを構成してください（複製する場合は別のモードの参照が残らないように注意してください）。 <br>
作成したルートポイントマネージャーの各フィールドを設定します。 <br>
<img width="500" alt="routepointmanager" src="./Images/routepointmanager.png">

| 設定項目 | 概要 |
| :--- | :--- |
| Check Points | チェックポイントと経路を示すルートポイントを経路の順で登録する配列です。 |
| AR Camera | “AR/AR Environment/AR Origin Session/AR Camera” を指定します。 |
| Path Point Prefab | 作成した PathPoint プレハブを指定します。| 
| Path Point Parent | 経路を表示するために生成された PathPoint のインスタンスを取りまとめる親オブジェクトを指定します。“PathPoints” の名前でオブジェクトを作成して指定します。 |
| Check Point Progress UI | 作成した “CheckPointProgressUI” を指定します。 | 
| Complete Modal UI |  作成した “CongraturaionsModal” を指定します。 | 
| Snackbar UI | 作成した ”CheckPointSnackBar” を指定します。 |
| Camera Snackbar UI | 作成した “CameraSnackBar” を指定します。 | 
| Is Showing Completed CheckPoint | 設定不要（デバッグ用に表示させているため、インスペクタから設定することはありません）。| 
| Earth Manager |  Geospatial API を用いるモードの場合に “AR/AR Environment/AR Origin Session” を指定します。 | 
| AR Marker City Model | マーカー位置合わせ3D都市モデルの場合に、その参照を指定します。|


# 9. ARオブジェクト（メダル）の実装
## 9-1. メダルのプレハブ作成
<img width="500" alt="medal_preview" src="./Images/medal_preview.png">


メダルのメッシュ：３Dソフトで円盤形の基本形状のメッシュを用意します。 <br>
<img width="500" alt="medal_mesh" src="./Images/medal_mesh.png">

マテリアル：メダルの内側と外側で二つ用意します。 <br>
① 内側部分：目的地の画像がテクスチャ設定されたマテリアルを適用 <br>
② 外側部分：単色のマテリアルを適用 <br>
<img width="500" alt="medal_mesh_detail" src="./Images/medal_mesh_detail.png">

ポータルメッシュ：ゲームのエフェクト表現等で一般的ならせん形状メッシュを用意。 <br>
<img width="500" alt="portal_mesh" src="./Images/portal_mesh.png">

以下はメッシュのＵＶです。シェーダー側でメッシュのＵＶのスクロール機能を実装し、エフェクトが下から上に沿って流れるような表現を作成します。 <br>
<img width="500" alt="portal_mesh_uv" src="./Images/portal_mesh_uv.png">

ＵＶスクロール表現はシェーダーグラフで実装します。シェーダーグラフ (Shader Graph) はUnityのツールで、ノーコードでシェーダーを作成できるように設計されています。ノードと呼ばれるビジュアル要素をつなげることで、シェーダーを直感的に設計でき,複雑なコードを書かずに、3Dオブジェクトの見た目をカスタマイズすることが可能です。 <br>
エフェクト用のマテリアルを新規で作成します。「プロジェクトウインドウ > 右クリックメニュー > Create > Material 」を押下します。 <br>
<img width="700" alt="create_material" src="./Images/create_material.png">

プロジェクトウィンドウに新しくマテリアルが作成されます。 <br>
<img width="400" alt="new_material_created" src="./Images/new_material_created.png">

プロジェクトウィンドウから作成したマテリアルを選択してメッシュにドラッグアンドドロップし、作成したマテリアルをエフェクトのメッシュに割り当てます。 <br>
<img width="800" alt="attach_material" src="./Images/attach_material.png">

シェーダーグラフのアセットを新規作成します。Unityのプロジェクトウインドウ > 右クリックメニュー > Create > Shader Graph > URP > Unlit Shader Graph を押下します。 <br>
<img width="800" alt="create_shader_graph" src="./Images/create_shader_graph.png">

新しいシェーダーグラフのアセットが作成されます。 <br>
<img width="400" alt="shader_graph_created" src="./Images/shader_graph_created.png">

モデルに割り当てた New Material に作成したシェーダーを割り当てます。マテリアルを選択してインスペクターから「New Shader Graph」を選択します。 <br>
<img width="600" alt="material_attach_shader" src="./Images/material_attach_shader.png">

作成したシェーダーグラフのアセットをダブルクリックしシェーダーグラフの編集ウインドウを表示します。 <br>
<img width="800" alt="shader_graph_edit" src="./Images/shader_graph_edit.png">

シェーダーグラフの編集ウインドウ内で右クリック > Create Node を押下して、Create Nodeのパネルを表示します。 <br>
<img width="400" alt="create_node" src="./Images/create_node.png">

Create Nodeのパネルから適宜必要なノードを追加していきます。検索ボックスにキーワードを入力することで、任意のノードを検索することができます。 <br>
<img width="400" alt="create_node_ui" src="./Images/create_node_ui.png"> <img width="400" alt="create_node_search" src="./Images/create_node_search.png">


以下のノードグラフはメッシュのＵＶをアニメーションする為の最小構成となります。 <br>
<img width="800" alt="node_graph" src="./Images/node_graph.png">

① Timeノードを追加し、時間経過に伴う値を加算 <br>
② スクロールの移動速度「Speed」パラメーターを追加 <br>
③ Timeノードに上記の値をそれぞれ接続し、速度の調整を可能にする <br>
④ Vector2ノードのXを0に設定。YにのみUVの移動を適用し、縦方向にのみアニメーションを適用 <br>
⑤ エフェクトの透明度用のテクスチャをマテリアルに設定可能にする <br>
⑥ SamplerTexture２DノードにテクスチャとUVを設定 <br>
⑦ 最終的なアルファ値を出力側に接続 <br>

シェーダーグラフの編集ウインドウ右側のGraph Inspectorを以下の設定にします。 <br>
<img width="400" alt="graph_inspector" src="./Images/graph_inspector.png">



編集作業の完了後、シェーダーグラフの編集ウインドウの右上の「Save Asset」を押すと、ここまでの作業がアセットに保存されます。 <br>
<img width="600" alt="save_asset" src="./Images/save_asset.png">


シーンに戻りエフェクトがアニメーションすることを確認します。 <br>
<img width="500" alt="effect_animation_preview" src="./Images/effect_animation_preview.png">

マテリアルのパラメーターについて <br>
<img width="600" alt="material_parameters" src="./Images/material_parameters.png">

| 設定項目 | 概要 |
| :--- | :--- |
| Base Color | エフェクトの色 |
| Base Texture | アルファ用のテクスチャ |
| Speed | エフェクトのアニメーション速度 |
| Alpha | 全体のエフェクトの不透明度 |


メダルのオブジェクトのプレハブを各状態ごとに用意します。具体的には「通常」、「取得時」、「取得後」のプレハブを用意します。 <br>
取得後時にはメダル単体が表示され、取得後にはメダルは非表示になり、ポータルのエフェクトの色が白色になります。 <br>

| 通常 | 取得時 | 取得後 |
| :--- | :--- | :--- |
| <img width="250" alt="medal_normal" src="./Images/medal_normal.png">| <img width="250" alt="medal_getting" src="./Images/medal_getting.png"> | <img width="250" alt="medal_got" src="./Images/medal_got.png"> |



作成した各プレハブは「CheckPointObject」コンポーネントの「NormalStatePrefab」、「Complete Effect Prefab」、「CompletedStatePrefab」に設定します。 <br>
<img width="800" alt="checkpoint_attach_prefabs" src="./Images/checkpoint_attach_prefabs.png">

## 9-2. メダルのスクリプト実装

以下のソースコードを “Assets/Scripts/CheckPointObject.cs” に保存します。 <br>

```C#
using UnityEngine;
using System.Collections;

namespace PlateauSamples.TreasureMap
{
    /// <summary>
    /// チェックポイントのコイン型3Dオブジェクト
    /// </summary>
    public class CheckPointObject : MonoBehaviour
    {
        [SerializeField] CheckPointManager m_CheckPointManager;

        [SerializeField] GameObject m_NormalStatePrefab;
        [SerializeField] GameObject m_CompleteEffectPrefab;
        [SerializeField] GameObject m_CompletedStatePrefab;
        [SerializeField] int m_CheckPointIndex;
        [SerializeField] float m_CompleteEffectDuration = 10f;

        Camera m_MainCamera;
        GameObject m_NormalStateObject;
        GameObject m_CompleteEffectObject;

        void Start()
        {
            m_CheckPointManager.OnCheckPointCompleted += HandleCheckPointCompleted;

            m_MainCamera = Camera.main;
            m_NormalStateObject = Instantiate(m_NormalStatePrefab, transform.position, Quaternion.identity, transform);
        }

        void Update()
        {
            if (m_CompleteEffectObject != null && m_MainCamera != null)
            {
                AdjustEffectPositionAndRotation();
            }
        }

        void OnDestroy()
        {
            m_CheckPointManager.OnCheckPointCompleted -= HandleCheckPointCompleted;
        }
        void HandleCheckPointCompleted(int completedIndex)
        {
            if (completedIndex == m_CheckPointIndex)
            {
                Destroy(m_NormalStateObject);
                m_CheckPointManager.IsShowingCompletedCheckpointEffect = true;
                StartCoroutine(ShowAndDestroyCompleteEffect());
            }
        }

        IEnumerator ShowAndDestroyCompleteEffect()
        {
            ShowCompleteEffect();
            yield return new WaitForSeconds(m_CompleteEffectDuration);
            Destroy(m_CompleteEffectObject);
            Instantiate(m_CompletedStatePrefab, transform.position, Quaternion.identity, transform);
            m_CheckPointManager.IsShowingCompletedCheckpointEffect = false;
        }

        void ShowCompleteEffect()
        {
            m_CompleteEffectObject = Instantiate(m_CompleteEffectPrefab, transform.position, Quaternion.identity, transform);
        }

        void AdjustEffectPositionAndRotation()
        {
            const float distanceFromCamera = 5f;

            Vector3 cameraForward = m_MainCamera.transform.forward;
            Vector3 effectPosition = m_MainCamera.transform.position + cameraForward * distanceFromCamera;

            m_CompleteEffectObject.transform.position = effectPosition;
            m_CompleteEffectObject.transform.LookAt(m_MainCamera.transform);
        }
    }
}
```

# 10. 利用するPLATEAU 3D都市モデルの切り替えUIの実装
ARトレジャーマップでは、利用する3D都市モデルの方式（PLATEAU SDKでインポートしたモデル、Cesiumでストリーミングされる3D都市モデル、マーカーで位置合わせを行う3D都市モデル）を選択するUIやタイトル画面などの簡易な機能を実装しています。 <br>
ARトレジャーマップで実装するUIなどの機能は、可能な限りシンプルな実装になっています。 <br>
<img width="400" alt="model_selection" src="./Images/model_selection.png">

## 10-1. 3D都市モデル切り替えUIの構築
“Canvas/SelectModePage” 内に、右クリックから Create > UI > Image を選択し、背景画像のUI画像オブジェクトを作成します。 <br>
画面幅に広がるように RectTransform を設定し、Image コンポーネントの画像には[8-4. チェックポイント進捗管理UIの実装](#8-4-チェックポイント進捗管理UIの実装)で用意したオレンジ色の背景を利用します。 <br>
<img width="600" alt="selection_bg_rect_transform" src="./Images/selection_bg_rect_transform.png">

メッセージと3つのボタンを縦方向に並べるため、 “VerticalLayoutGroup” コンポーネントを利用します。
“Canvas/SelectModePage” 内に空のゲームオブジェクトを作成し、RectTransform を設定して “VerticalLayoutGroup” コンポーネントをアタッチします。ゲームオブジェクトの名前は “VerticalLayout”とします。

インスペクタから、“VerticalLayoutGroup” の “Child Alignment” を “Middle Center” に設定します。 <br>
“Control Child Size” などのプロパティは全てオフにします。 <br>
<img width="400" alt="control_child_size_off" src="./Images/control_child_size_off.png">

この設定により、このオブジェクト内の子オブジェクトは縦方向に並んでレイアウトされます。 


## 10-2. メッセージテキストの作成
“VerticalLayout“ オブジェクトを右クリックし、 Create > UI > Text - TextMeshPro からテキストUIオブジェクトを作成します。 <br>
RectTransform は以下のように設定します。位置は親の “VerticalLayoutGroup” コンポーネントによって制御されるため、特に設定する必要はありません（設定不可）。  <br>
<img width="600" alt="verticallayout_rect_transform" src="./Images/verticallayout_rect_transform.png">

フォントの設定は以下のように設定します。
- Font Asset: NotoSansJP-ExtraBold
- Font Size: 48
- Alignment: Middle Center

テキストは改行付きで以下の文言を設定します。 <vr>

どの方法で
PLATEAUモデルを
使用しますか？

## 10-3. 切り替えボタンの実装
ボタンに使用する以下の画像を “Assets/Images/UI” に保存します。 <br>
<img alt="ModeSelectButton" src="./Images/ModeSelectButton.png">

“VerticalLayout“ オブジェクトを右クリックし、 Create > UI > Button - TextMeshPro からボタンUIオブジェクトを作成します。 <br>
作成したボタンオブジェクトにアタッチされている Image コンポーネントの画像を用意した “ModeSelectButton.png” に差し替え、Image コンポーネント下部に表示されている “Set Native Size” ボタンを押下し、この画像サイズに合わせてボタンオブジェクトの大きさを設定します。 <br>
<img width="400" alt="ModeSelectButton_inspector" src="./Images/ModeSelectButton_inspector.png">

ボタン内のテキストは次のように設定します。
- Font Asset: NotoSansJP-Bold
- Font Size: 32
- Child Alignment: Middle Center
- Vertex Color: #FFFFFF

作成したボタンオブジェクトを3つに複製し、以下のように文言を設定します。 <br>
<img width="400" alt="three_buttons" src="./Images/three_buttons.png">

“Button” コンポーネントの “On Click ()” を用いて、使用するモードの3D都市モデルの切り替えとUIの切り替えを行います。 <br>
シーンには全てのモードの3D都市モデルのゲームオブジェクトを非アクティブにした状態で配置し、各モード選択のボタンではモードに対応したゲームオブジェクトをアクティブにすることで選択したモードの3D都市モデルを利用できるようにします。 <br>
また、すべてのボタンの共通処理として、モード選択のページ “SelectModePage” を非アクティブにし、 メインページ “GamePage” をアクティブにすることでページ切り替えを実現します。 <br>
<img width="600" alt="disable_selectmodepage" src="./Images/disable_selectmodepage.png">


