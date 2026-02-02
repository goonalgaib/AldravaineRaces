using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;

namespace AldravaineRaces.src.BlockBehaviors {

    public class POITrackerDummyBlockEntity : BlockEntity {

        public override void Initialize(ICoreAPI api) {
            //AldravaineRacesModSystem.Logger.Warning("A POITrackerDummyBlockEntity has been Initialized! Hello!");
            base.Initialize(api);
        }
    }
}
