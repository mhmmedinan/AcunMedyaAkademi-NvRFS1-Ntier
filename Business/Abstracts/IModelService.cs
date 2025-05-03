using Business.Dtos.Requests.Model;
using Business.Dtos.Responses.Model;

namespace Business.Abstracts;

public interface IModelService
{

    CreatedModelResponse Add(CreateModelRequest request);
    List<GetListModelResponse> GetList();
}
