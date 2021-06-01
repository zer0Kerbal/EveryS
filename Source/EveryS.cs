using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EveryS
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class EveryS : MonoBehaviour
    {
        public static void SetBadS()
        {
            if (HighLogic.CurrentGame == null)
                return;

            foreach (ProtoCrewMember kerbal in HighLogic.CurrentGame.CrewRoster.Crew)
            {
                BadSify(kerbal);
            }

            if (HighLogic.CurrentGame.CrewRoster.Unowned != null)
            {
                foreach (ProtoCrewMember kerbal in HighLogic.CurrentGame.CrewRoster.Unowned)
                {
                    BadSify(kerbal);
                }
            }

            if (HighLogic.CurrentGame.CrewRoster.Tourist != null)
            {
                foreach (ProtoCrewMember kerbal in HighLogic.CurrentGame.CrewRoster.Tourist)
                {
                    BadSify(kerbal);
                }
            }
        }

        private static void BadSify(ProtoCrewMember kerbal)
        {
            if (!kerbal.isBadass)
            {
                if (kerbal.KerbalRef != null)
                {
                    kerbal.KerbalRef.isBadass = true;
                }

                kerbal.isBadass = true;
            }
        }
    }

    [KSPAddon(KSPAddon.Startup.Flight, false)]
    class Launcher : MonoBehaviour
    {
        public void Start()
        {
            EveryS.SetBadS();
        }
    }
}
