using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Services.IService;
using ABCLogistics.Data;
using ABCLogistics.Data.DAO;

namespace ABCLogistics.Services.Service
{

    public class UserService : IUserService
    {

        private UserDAO _UserDAO;

        public UserService()
        {
            _UserDAO = new UserDAO();
        }

        // CREATE ===================================================================
        // addUser
        public void addUser(User user)
        {
            _UserDAO.addUser(user);
        }

        // READ =====================================================================
        // getUsers
        public IList<User> getUsers()
        {
            return _UserDAO.getUsers();
        }

        // getUser
        public User getUser(int id)
        {
            return _UserDAO.getUser(id);
        }

        // UPDATE ===================================================================
        // editUser
        public void editUser(User user)
        {
            _UserDAO.editUser(user);
        }

        // DELETE ===================================================================
        // deleteUser
        public void deleteUser(User user)
        {
            _UserDAO.deleteUser(user);
        }

    }
}

