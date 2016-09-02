using System.IO;
using Challenge3.Model;
using Newtonsoft.Json;
using static System.Console;

namespace Challenge3 {
    class Program {
        
        static void Main(string[] args) {
            //Jsonディレクトリ内の全てのJsonファイルパスを取得
            var smpleFiles = Directory.EnumerateFiles(@".\Json", "*.json", SearchOption.AllDirectories);
            foreach (var path in smpleFiles) {
                var jsonData = File.ReadAllText(path);

                //JSONデータをデータモデルにデシリアライズ
                var scoreData = JsonConvert.DeserializeObject<BowlingScoreModel>(jsonData);

                WriteLine($"ファイル名: {Path.GetFileName(path)}");
                WriteLine($"スコア: {new BowlingScoreCalculation(scoreData).Calc()}");
                WriteLine();
            }
            
            ReadKey();
        }
    }
}
