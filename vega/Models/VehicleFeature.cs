using System.ComponentModel.DataAnnotations.Schema;

namespace vega.Models
{
    /// <summary>
    /// Many-to-many mapper relationship
    /// </summary>
    [Table("VehicleFeatures")]
    public class VehicleFeature
    {
        #region Composed Key

            public int VehicleId { get; set; }

            public int FeatureId { get; set; }

        #endregion

        public Vehicle Vehicle { get; set; }

        public Feature Feature { get; set; }

    }
}