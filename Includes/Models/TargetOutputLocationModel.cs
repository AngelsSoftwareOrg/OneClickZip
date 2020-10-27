using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Models
{
    [Serializable]
    public class TargetOutputLocationModel: ICloneable
    {
        private String mainTargetLocation;
        private List<String> addedTargetLocations = new List<string>();

        public TargetOutputLocationModel(String mainLocation)
        {
            mainTargetLocation = mainLocation;
        }

        public void AddLocation(String newLocation)
        {
            addedTargetLocations.Add(newLocation);
        }

        public void AddRange(String[] newLocations)
        {
            addedTargetLocations.AddRange(newLocations);
        }

        public void AddRange(List<String> newLocations)
        {
            addedTargetLocations.AddRange(newLocations);
        }

        public List<String> GetTargetLocations()
        {
            return new List<String>(addedTargetLocations.ToArray());
        }
        public string MainTargetLocation { get => mainTargetLocation; }

        public object Clone()
        {
            TargetOutputLocationModel output = new TargetOutputLocationModel(MainTargetLocation);
            output.AddRange(addedTargetLocations);
            return output;
        }
    }
}
