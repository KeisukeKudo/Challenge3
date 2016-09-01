using System.Collections.Generic;
using System.Linq;
using Challenge3.Model;
using static Challenge3.Model.BowlingScoreModel;

namespace Challenge3 {
    public class BowlingScoreCalculation {
        private readonly IEnumerable<FrameData> FramesData;
        private readonly int FrameCount;
        private readonly int PinMax;


        public BowlingScoreCalculation(BowlingScoreModel bowlingScoreModel) {
            //フレーム数とピンの最大値を取得
            this.FrameCount = bowlingScoreModel.Frame;
            this.PinMax = bowlingScoreModel.PinMax;

            //Date基準で昇順ソート
            this.FramesData = bowlingScoreModel.FramesData.OrderBy(g => g.Date);
        }

        /// <summary>
        /// スコア計算
        /// </summary>
        /// <returns></returns>
        public int Calc() {

            if (this.IsPerfect()) {
                return this.GetPerfectScore();
            }
            
            //倒したピンの数を単純集計
            var score = this.FramesData.Sum(g => g.Pin);

            //集計値が0の場合は全てガターと判断し､結果を返す
            if(score == 0) {
                return score;
            }

            //forの最初でインクリメントするので-1から始める
            //※迷ったポイント ここでは0代入で､for文頭でif(throwIndex != 0)で加算のほうがよかったかも
            //どっちが良いか意見が欲しいです
            var throwIndex = -1;
            //フレーム数分ループ ※最終フレームは単純集計なので無視
            for (var i = 0; i < this.FrameCount - 1; i++) {
                //次の投球へ進む
                throwIndex++;
                var frameData = this.FramesData.ElementAt(throwIndex);

                var numberOfKnockingDown = frameData.Pin;
                
                //ストライク判定
                if (numberOfKnockingDown == this.PinMax) {
                    score += this.StrikeAddend(throwIndex);
                    continue;
                }

                //1フレーム最大2投は保証されているので､ストライクでない場合は次の投球へ進む
                throwIndex++;
                frameData = this.FramesData.ElementAt(throwIndex); ;

                //前回の投球で倒したピンの数に今回の投球で倒したピンの数を加算
                numberOfKnockingDown += frameData.Pin;

                //スペア判定
                if (numberOfKnockingDown == this.PinMax) {
                    score += this.SpareAddend(throwIndex);
                }
            }

            return score;
        }

        /// <summary>
        /// ストライク時の加算スコアを計算
        /// </summary>
        /// <param name="throwIndex"></param>
        /// <returns></returns>
        private int StrikeAddend(int throwIndex) {
            //次回の投球､次々回の投球で倒したピンの数を集計して返す
            return this.FramesData.Skip(++throwIndex).Take(2).Sum(g => g.Pin);
        }

        /// <summary>
        /// スペア時の加算スコアを計算
        /// </summary>
        /// <param name="throwIndex"></param>
        /// <returns></returns>
        private int SpareAddend(int throwIndex) {
            //次回の投球で倒したピンの数を返す
            return this.FramesData.ElementAt(++throwIndex).Pin;
        }

        /// <summary>
        /// 全ての投球でストライクかどうか
        /// </summary>
        /// <returns></returns>
        private bool IsPerfect() {
            return this.FramesData.All(f => f.Pin == this.PinMax);
        }

        /// <summary>
        /// パーフェクトゲームのスコア
        /// </summary>
        /// <returns></returns>
        private int GetPerfectScore() {
            return this.FrameCount * (this.PinMax * 3);
        }

    }
}
