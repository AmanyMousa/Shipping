using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.CityDTO;

// Shipping.Service/CityService.cs
public interface ICityService
{
    Task<IEnumerable<CityDto>> GetAllCitiesAsync();
    Task<CityDetailsDto> GetCityByIdAsync(int id);
    Task<CityDto> CreateCityAsync(CityDto cityDto);
    Task UpdateCityAsync(int id, CityDto cityDto);
    Task DeleteCityAsync(int id);
}

public class CityService : ICityService
{
    private readonly IUnitofwork _unitOfWork;
    private readonly IMapper _mapper;

    public CityService(IUnitofwork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CityDto>> GetAllCitiesAsync()
    {
        var cities = await _unitOfWork.CityRepo.GetAllActiveAsync();
        return _mapper.Map<IEnumerable<CityDto>>(cities);
    }
    public async Task<CityDetailsDto> GetCityByIdAsync(int id)
    {
        var city = await _unitOfWork.CityRepo.GetActiveByIdAsync(id);
        return _mapper.Map<CityDetailsDto>(city);
    }

    public async Task<CityDto> CreateCityAsync(CityDto cityDto)
    {
        var city = _mapper.Map<City>(cityDto);
        await _unitOfWork.CityRepo.AddAsync(city);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<CityDto>(city);
    }

    public async Task UpdateCityAsync(int id, CityDto cityDto)
    {
        var existingCity = await _unitOfWork.CityRepo.GetActiveByIdAsync(id);
        _mapper.Map(cityDto, existingCity);
        _unitOfWork.CityRepo.UpdateAsync(existingCity);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteCityAsync(int id)
    {
        await _unitOfWork.CityRepo.SoftDeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }
}