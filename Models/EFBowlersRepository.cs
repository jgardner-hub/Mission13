using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlingDbContext _context { get; set; }
        public EFBowlersRepository(BowlingDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;


        //fix all of these methods
        public void AddBowler(Bowler b)
        {
            throw new NotImplementedException();
        }

        public void SaveBowler(Bowler b)
        {
            throw new NotImplementedException();
        }

        public void DeleteBowler(Bowler b)
        {
            throw new NotImplementedException();
        }
    }
}
