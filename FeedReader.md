# はじめに

C#でRSSやFeedなどを扱うには、「LINQ to XMLを使うといいよ」という記事をいくつか見つけました。
もちろん、LINQ to XMLでも扱えますが、RSSの様々なバージョンやATOMなどに対応するのが面倒なため、プラグインを探していたところ「CodeHollow.FeedReader」を見つけたので、使い方などを残しておきます。

# CodeHollow.FeedReaderとは

https://github.com/arminreiter/FeedReader

> FeedReader is a .net library used for reading and parsing RSS and ATOM feeds. Supports RSS 0.91, 0.92, 1.0, 2.0 and ATOM. Developed because tested existing libraries do not work with different languages, encodings or have other issues. Library tested with multiple languages, encodings and feeds.

簡単に言うと、RSSとATOMを扱いやすくしてくれるプラグインです。
NuGetパッケージから使用することができます。

# 使い方

前提として、CodeHollow.FeedReaderをNuGetパッケージからインストールしたものとします。

```c#:Main.cs
using CodeHollow.FeedReader;

static class Program
{
    static void Main()
    {
        string url = @"https://kyoko-np.net/index.xml";
        var feedTask = FeedReader.ReadAsync(url);
        var feed = feedTask.Result;

        // ヘッダー情報
        Console.WriteLine("Feed Title: " + feed.Title);
        Console.WriteLine("Feed Description: " + feed.Description);
        Console.WriteLine("Feed Images: " + feed.ImageUrl);

        // 明細情報
        foreach (var item in feed.Items)
        {
            Console.WriteLine(item.Title + " - " + item.Link);
        }
    }
}
```

```bash:実行結果
Feed Title: 虚構新聞社（Kyoko Shimbun News）
Feed Description: 虚構報道専門のニュースサイト「虚構新聞」です。
Feed Images: http://kyoko-np.net/images/kyoko.gif
ＡＩ、掲示板を乗っ取る　「私は人間ではありません」認証に研究者困惑 - http://kyoko-np.net/2022040801.html
虚構の歴史が現代に根付くメカニズム　偽文書研究『椿井文書』著者に聞く - http://kyoko-np.net/2022040101.html
「新しい『端』にようこそ」　宇宙の果て示す星雲、新たに見つかる - http://kyoko-np.net/2022032801.html
メタバース用「メタファクス」、仮想オフィスで人気　クインジム開発 - http://kyoko-np.net/2022031801.html
人間の温室ガス排出、６割はため息　千葉電波大研究 - http://kyoko-np.net/2022031101.html
「「辛くて苦手」に新商品　「種なし柿の種」登場」についてお詫び - http://kyoko-np.net/owabi_220302.html
神「さい銭届かぬ」　硬貨手数料で合格祈願成就率、過去最低に - http://kyoko-np.net/2022022601.html
ニャー「ニャーニャーニャー」　ニャーニャー、ニャーニャーニャー - http://kyoko-np.net/2022022202.html
便器に金網　ワイヤレスイヤホン落下防止で　意外な効果も - http://kyoko-np.net/2022021901.html
投票用紙に陶片採用　「一票の重み」解消目指す - http://kyoko-np.net/2022021201.html
有志連合軍、鬼ヶ島に限定豆空爆　負傷鬼多数の情報 - http://kyoko-np.net/2022020301.html
千葉電波大のゴリラ、新聞を理解？　高い知性獲得か - http://kyoko-np.net/2022012901.html
「思春期のブログ音読」にダイエット効果　千葉電波大 - http://kyoko-np.net/2022011401.html
七福神きょう仕事納め　全国巡業最終日 - http://kyoko-np.net/2022010701.html
アベノマスク活用した巨大スプラウト園が開園　東京ドーム２個分 - http://kyoko-np.net/2021122401.html
ユビノマスク、マフラー…　指の防寒具、じわり人気 - http://kyoko-np.net/2021121701.html
「琵琶湖の愛称、『チチカカ湖』に」　ジェンダーニュートラル求める - http://kyoko-np.net/2021121101.html
「見分けつかない」　ゲーム「ぷよｉＰｈｏｎｅ」、ツイッターで話題 - http://kyoko-np.net/2021120301.html
世界最古の酢豚レシピ見つかる　「酢豚パイン論争」に終止符 - http://kyoko-np.net/2021112901.html
落札直後に刈られた田んぼアート、１８億円で落札 - http://kyoko-np.net/2021111701.html
四季の秋メンバーが行方不明　有力情報なく３週間 - http://kyoko-np.net/2021110801.html
衆院選から一夜、死票悼む墓に多くの献花 - http://kyoko-np.net/2021110101.html
引退宣言のインフルさん、１年ぶり「再起動」発表 - http://kyoko-np.net/2021102501.html
データ削除「ゴミ箱」に有料ゴミ袋導入へ　デジタル環境庁 - http://kyoko-np.net/2021101801.html
神、世界の「ロールバック」を啓示　親ガチャ不具合で - http://kyoko-np.net/2021101101.html
ひしめく人工衛星に３色の光明　信号機衛星「シグナライト」打ち上げ成功 - http://kyoko-np.net/2021100401.html
```

尚、`ReadAsync`メソッドの戻り値は`Feed`となります。
保有しているプロパティなどはソースを参照するのが早いです。

https://github.com/arminreiter/FeedReader/blob/master/FeedReader/Feed.cs


# その他サンプル

公式さんがSampleを用意してくださっているので、そちらを参照すると良いです。

https://github.com/arminreiter/FeedReader/blob/master/FeedReader.ConsoleSample/Program.cs

