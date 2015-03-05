using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Data;

namespace ABCLogistics.Services.IService
{

    interface IBranchService
    {

        // CREATE ===================================================================
        // addBranch
        void addBranch(Branch branch);

        // READ =====================================================================
        // getBranches : Returns IList of all Branches of type Branch.
        IList<Branch> getBranches();

        // getBranch
        Branch getBranch(int id);

        // UPDATE ===================================================================
        // editBranch
        void editBranch(Branch branch);

        // DELETE ===================================================================
        // deleteBranch
        void deleteBranch(Branch branch);

    }

}
