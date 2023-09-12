using MyTriApp.Data;

namespace MyTriApp.Services
{
    public class AthleteService
    {
        private readonly MyTriAppDbContext _context;

        public AthleteService(MyTriAppDbContext context)
        {
            _context = context;
        }

        //public async Task<StravaAthlete> CreateAthlete(StravaAthlete athlete)
        //{
        //    await _context.AddAsync(athlete);
        //    await _context.SaveChangesAsync();
        //    return athlete;
        //}

        //public async Task<bool> DeleteAthleteById(int id)
        //{
        //    var athlete = await _context.Athletes.FindAsync(id);
        //    if (athlete == null)
        //    {
        //        return false;
        //    }
        //    _context.Remove(athlete);

        //    await _context.SaveChangesAsync();
        //    return true;
        //}

        //public async Task<List<StravaAthlete>> GetAllAthletes()
        //{
        //    return await _context.Athletes.ToListAsync();
        //}

        //public async Task<StravaAthlete?> GetAthleteById(int id)
        //{
        //    return await _context.Athletes.FindAsync(id);
            
        //}

        //public async Task<StravaAthlete?> UpdateAthlete(StravaAthlete athlete)
        //{
        //    var athleteToUpdate = await _context.Athletes.FindAsync(athlete.Id);
        //    if (athleteToUpdate == null)
        //    {
        //        return athleteToUpdate;
        //    }

        //    athleteToUpdate.FirstName = athlete.FirstName;
        //    athleteToUpdate.LastName = athlete.LastName;
        //    athleteToUpdate.PictureUrl = athlete.PictureUrl;
        //    athleteToUpdate.City = athlete.City;
        //    athleteToUpdate.Country = athlete.Country;
        //    athleteToUpdate.Sex = athlete.Sex;
        //    athleteToUpdate.FTP = athlete.FTP;
        //    athleteToUpdate.Weight = athlete.Weight;
        //    athleteToUpdate.Length = athlete.Length;

        //    await _context.SaveChangesAsync();

        //    return athleteToUpdate;
        //}
    }
}
