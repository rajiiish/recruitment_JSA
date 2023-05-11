using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace recruitment.DataLayers
{
    public class DisplayLayer
    {
        public string can_regno { get; set; }
        public string appregno { get; set; }

        public List<BasicDetailsEntity> BasicDetailsEntities 
        {
            get
            {
                return BasicDetailsDataAccessLayer.GetDetails(can_regno, appregno);

            }
        }
    }

    public class PreviewDisplayLayer
    {

    }

}