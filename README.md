# Challenge3
｢ボウリングのスコア計算｣  
詳細  
JSON形式の投球データから最終的なスコアを求めよ  

## 入力
テキストファイル  
・文字コードはUTF-8  
・JSON形式の投球データが1行で入力されている  

## 形式  
```JSON
{
    "frame": 10,    //フレーム数
    "pin_max": 10,  //ゲームにおけるピンの最大数
    "game_data": [
        {
            "pin": 8,       //この投球で倒したピンの数
            "split": true,  //スプリットになったかどうか
            "foul": false,  //ファウルしたかどうか
            "date": "2016-08-06T12:34:56.789Z"
        },
        //...(省略)...
        {
            "pin": 2,
            "split": false,
            "foul": false,
            "date": "2016-08-06T13:01:23.456Z"
        }
    ]
}
```

## 条件
1. 標準的なボウリングのスコア計算の方法で求めてください（詳しくはググって）  
2. 全てのテストケースにおいて、以下の条件を満たします  
```
1 ≦ frame ≦ 100
1 ≦ pin_max ≦ 100
frame + 1 ≦ count(game_data) ≦ 2 * frame + 1
pin は 1≦ p_i ≦ b を満たす整数
```

## 期待する出力
最終的なスコアを計算して、何らかの形で表示してください  
・ロジックが見たいだけなので、コンソールでの結果確認でも良しとします  
・余力があれば、スコア表の出力にもチャレンジしてみましょう  

## 使用ライブラリ
[Json.NET](http://www.newtonsoft.com/json)  
>The MIT License (MIT)  
>Copyright (c) 2007 James Newton-King  

[Json.NET LICENSE](https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md)  

## イメージ
![challenge3_image](https://github.com/KeisukeKudo/ImageStorage/blob/master/challenge3_image.png)
