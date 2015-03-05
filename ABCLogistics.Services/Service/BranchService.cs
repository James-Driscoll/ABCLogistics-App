using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Services.IService;
using ABCLogistics.Data;
using ABCLogistics.Data.DAO;
using ABCLogistics.Data.BEANS;

namespace ABCLogistics.Services.Service
{

    public class BranchService : IBranchService
    {

        private BranchDAO _BranchDAO;

        public BranchService()
        {
            _BranchDAO = new BranchDAO();
        }

        // CREATE ===================================================================
        // addBranch
        public void addBranch(Branch branch)
        {
            _BranchDAO.addBranch(branch);
        }

        // READ =====================================================================
        // getBranches : Returns IList of all Branches of type Branch.
        public IList<Branch> getBranches()
        {
            return _BranchDAO.getBranches();
        }

        // getBranch
        public Branch getBranch(int id)
        {
            return _BranchDAO.getBranch(id);
        }

        // UPDATE ===================================================================
        // editBranch
        public void editBranch(Branch branch)
        {
            _BranchDAO.editBranch(branch);
        }

        // DELETE ===================================================================
        // deleteBranch
        public void deleteBranch(Branch branch)
        {
            _BranchDAO.deleteBranch(branch);
        }

    }

}
