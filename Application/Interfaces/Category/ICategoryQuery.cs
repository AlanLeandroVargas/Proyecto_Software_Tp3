using Domain.Entities;

namespace Application.Interfaces;

public interface ICategoryQuery
{
    Task<List<Domain.Entities.Category>> GetListCategories();
    Task<Domain.Entities.Category> GetCategoryById(int categoryId);
}
