namespace Helperland.ViewModels
{
    public class RatingViewModel
    {
        public int ServiceRequestId { get; set; }
        public int SPId { get; set; }
        public string SPName { get; set; }
        public decimal SPRating { get; set; } = 0M;
        public string SPProfile { get; set; }
        public int OnTimeArrival { get; set; } = 0;
        public int Friendly { get; set; } = 0;
        public int QualityOfService { get; set; } = 0;
        public string RatingComments { get; set; } = null;
        public int RatingId { get; set; } = 0;
    }
}
