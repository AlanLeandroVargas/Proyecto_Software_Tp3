using Application.Request;
using Domain.Entities;

namespace Application.Interfaces;

public interface ICategoryCommands
{
    Task<Domain.Entities.Category> InsertCategory(Domain.Entities.Category category);
    Task<Domain.Entities.Category> UpdateCategory(UpdateCategoryRequest request);
    Task DeleteCategory(int id);
}
