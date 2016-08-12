using System;
using Challenge3.Model;
using Newtonsoft.Json;

namespace Challenge3 {
    class Program {

        #region テスト用JSONファイル名定義クラス

        private static class JsonFilePath {
            //JSONファイルディレクトリ
            private const string JsonDirectry = "./Json/";

            //各テストファイル
            public static readonly string Sample141 = $"{JsonDirectry}sample_data_141.json";
        }

        #endregion

        static void Main(string[] args) {
            var jsonData = System.IO.File.ReadAllText(JsonFilePath.Sample141);

            //JSONデータをデータモデルにシリアライズ
            var scoreData = JsonConvert.DeserializeObject<BowlingScoreModel>(jsonData);

            Console.WriteLine($"スコア: {new BowlingScoreCalculation(scoreData).Calc()}");
            Console.ReadKey();
        }
    }
}
