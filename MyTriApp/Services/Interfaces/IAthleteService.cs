using Microsoft.AspNetCore.Mvc;
using MyTriApp.Services.DTOs;

namespace MyTriApp.Services.Interfaces
{
    public interface IAthleteService
    {
        Task<AthleteDTO> CreateAthlete(AthleteDTO athlete);
        Task<bool> DeleteAthleteById(int id);
        Task<List<AthleteDTO>> GetAllAthletes();
        Task<AthleteDTO?> GetAthleteById(int id);
        Task<AthleteDTO?> UpdateAthlete(AthleteDTO athlete);
    }
}
