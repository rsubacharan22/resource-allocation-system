public interface IRecommendationService
{
    Task<List<RecommendationDto>>
        GetRecommendations(int resourceDemandId);
}