using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Challenge3.Model {
    [JsonObject("rootobject")]
    public class BowlingScoreModel {
        [JsonProperty("frame")]
        public int Frame { get; set; }
        [JsonProperty("game_data")]
        public IEnumerable<FrameData> FramesData { get; set; }
        [JsonProperty("pin_max")]
        public int PinMax { get; set; }

        [JsonObject("game_data")]
        public class FrameData {
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
