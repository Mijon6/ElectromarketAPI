using AutoMapper;
using ElectromarketAPI.Entities;
using ElectromarketAPI.Exceptions;
using ElectromarketAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectromarketAPI.Services
{
    public interface IElectromarketService
    {
        ElectromarketDto GetById(int id);
        IEnumerable<ElectromarketDto> GetAll();
        int Create(CreateElectromarketDto dto);

        void Delete(int id);
        void Update(int id, UpdateElectromarketDto dto);
    }
    public class ElectromarketService : IElectromarketService
    {
        private readonly ElectromarketDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ElectromarketService(ElectromarketDbContext dbContext, IMapper mapper, ILogger<ElectromarketService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public void Delete(int id)
        {
            _logger.LogWarning($"Electromarket with Id: {id} DELETE action invoked");

            var electromarket = _dbContext
                .Electromarkets
                .FirstOrDefault(r => r.Id == id);
            if (electromarket is null)
                throw new NotFoundException("Restaurant not found"); ;

            _dbContext.Electromarkets.Remove(electromarket);
            _dbContext.SaveChanges();

            
        }
        public ElectromarketDto GetById(int id)
        {
            var electromarket = _dbContext
                .Electromarkets
                .Include(e => e.Address)
                .Include(e => e.Stuffs)
                .FirstOrDefault(r => r.Id == id);

            if (electromarket is null)
                throw new NotFoundException("Restaurant not found");

            var result = _mapper.Map<ElectromarketDto>(electromarket);
            return result;

        }
        public IEnumerable<ElectromarketDto> GetAll()
        {
            var electromarkets = _dbContext
               .Electromarkets
               .Include(e => e.Address)
               .Include(e => e.Stuffs)
               .ToList();
            var electromarketsDtos = _mapper.Map<List<ElectromarketDto>>(electromarkets);
            return electromarketsDtos;
        }
        public int Create(CreateElectromarketDto dto)
        {
            var electromarket = _mapper.Map<Electromarket>(dto);
            _dbContext.Electromarkets.Add(electromarket);
            _dbContext.SaveChanges();
            return electromarket.Id;
        }
        public void Update(int id, UpdateElectromarketDto dto)
        {
            var electromarket = _dbContext
                .Electromarkets
                .FirstOrDefault(r => r.Id == id);
            if (electromarket is null)
                throw new NotFoundException("Restaurant not found");
            electromarket.Name = dto.Name;
            electromarket.Description = dto.Description;
            electromarket.HasDelivery = dto.HasDelivery;
            _dbContext.SaveChanges();
            

        }
    }
}
