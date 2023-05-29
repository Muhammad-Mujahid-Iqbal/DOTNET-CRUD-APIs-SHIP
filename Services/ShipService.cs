namespace WebApi.Services;

using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Ships;
using WebApi.Repositories;
using WebApi.Helpers;

public interface IShipService
{
    Task<IEnumerable<Ship>> GetAll();
    Task<Ship> GetById(int id);
    Task Create(CreateRequest model);
    Task Update(int id, UpdateRequest model);
    Task Delete(int id);
}

public class ShipService : IShipService
{
    private IShipRepository _shipRepository;
    private readonly IMapper _mapper;

    public ShipService(IShipRepository shipRepository,IMapper mapper)
    {
        _shipRepository = shipRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Ship>> GetAll()
    {
        return await _shipRepository.GetAll();
    }

    public async Task<Ship> GetById(int id)
    {
        var ship = await _shipRepository.GetById(id);

        if (ship == null)
            throw new KeyNotFoundException("Ship not found");

        return ship;
    }

    public async Task Create(CreateRequest model)
    {
        var existing_ship = await _shipRepository.GetByCode(model.Code);

        if (existing_ship != null)
            throw new AppException("Ship with same code found!. It must be unique");

        // map model to new ship object
        var ship = _mapper.Map<Ship>(model);

        // save ship
        await _shipRepository.Create(ship);
    }

    public async Task Update(int id, UpdateRequest model)
    {
        var ship = await _shipRepository.GetById(id);

        if (ship == null)
            throw new KeyNotFoundException("Ship not found");

        var existing_ship = await _shipRepository.GetByCode(model.Code);

        if (existing_ship != null)
            throw new AppException("Ship with same code found!. It must be unique");   

        // copy model props to ship
        _mapper.Map(model, ship);

        // save ship
        await _shipRepository.Update(ship);
    }

    public async Task Delete(int id)
    {
        await _shipRepository.Delete(id);
    }
}