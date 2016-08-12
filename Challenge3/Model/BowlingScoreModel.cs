using System;
using Newtonsoft.Json;

namespace Challenge3.Model {
    [JsonObject("rootobject")]
    public class BowlingScoreModel {
        [JsonProperty("frame")]
        public int Frame { get; set; }
        [JsonProperty("game_data")]
        public GamesData[] GameData { get; set; }
        [JsonProperty("pin_max")]
        public int PinMax { get; set; }

        [JsonObject("game_data")]
        public class GamesData {
            [JsonProperty("date")]
            public DateTime Date { get; set; }
            [JsonProperty("pin")]
            public int Pin { get; set; }
            [JsonProperty("split")]
            public bool Split { get; set; }
            [JsonProperty("”foul”")]
            public bool Foul { get; set; }
        }
    }
}
