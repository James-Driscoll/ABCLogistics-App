using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Data.IDAO;
using ABCLogistics.Data.BEANS;

namespace ABCLogistics.Data.DAO
{

    public class BranchDAO : IBranchDAO
    {

        private ABCLogisticsDataEntities _context;

        // CONSTRUCTOR ===============================================================
        public BranchDAO()
        {
            _context = new ABCLogisticsDataEntities();
        }

        // CREATE ====================================================================
        // addBranch : Method to add a new Branch to the database.
        public void addBranch(Branch branch)
        {
            _context.Branches.Add(branch);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getBranches : Returns IList of all Branchs of type Branch.
        public IList<Branch> getBranches()
        {
            IQueryable<Branch> _branches;
            _branches = from Branch
                       in _context.Branches
                       select Branch;
            return _branches.ToList<Branch>();
        }

        // getBranch
        public Branch getBranch(int id)
        {
            IQueryable<Branch> _branch;
            _branch = from Branch
                          in _context.Branches
                      where Branch.Id == id
                      select Branch;
            return _branch.ToList<Branch>().First();
        }

        // UPDATE ====================================================================
        // editBranch
        public void editBranch(Branch branch)
        {
            Branch record = (from rec
                             in _context.Branches
                             where rec.Id == branch.Id
                             select rec).ToList<Branch>().First();
            record.Name = branch.Name;
            record.AddressLine1 = branch.AddressLine1;
            record.AddressLine2 = branch.AddressLine2;
            record.Town = branch.Town;
            record.County = branch.County;
            record.Postcode = branch.Postcode;
            _context.SaveChanges();
        }

        // DELETE ====================================================================
        // deleteBranch
        public void deleteBranch(Branch branch)
        {
            _context.Branches.Remove(branch);
            _context.SaveChanges();
        }

    }

}
