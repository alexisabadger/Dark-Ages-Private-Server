﻿#region

using System.Collections.Generic;
using Darkages.Templates;
using Newtonsoft.Json.Converters;

#endregion

namespace Darkages.Types
{
    public class WarpTemplate : Template
    {
        public WarpTemplate()
        {
            Activations = new List<Warp>();
        }

          public int ActivationMapId { get; set; }
        public List<Warp> Activations { get; set; }
          public byte LevelRequired { get; set; }

        public Warp To { get; set; }
        public int WarpRadius { get; set; }

        public WarpType WarpType { get; set; }

        public int WorldResetWarpId { get; set; }
        public int WorldTransionWarpId { get; set; }

        public override string[] GetMetaData()
        {
            return new[]
            {
                ""
            };
        }
    }
}