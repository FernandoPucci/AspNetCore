namespace vega.Models
{
    public class Model
    {
        public int Id { get; set; }

        public string Name { get; set; }


        #region Navigations
            public Make Make { get; set; }
            public int MakeId { get; set; }

        #endregion
    }
}