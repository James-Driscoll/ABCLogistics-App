using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Data.IDAO;

namespace ABCLogistics.Data.DAO
{

    public class UserDAO : IUserDAO
    {

        private ABCLogisticsDataEntities _context;

        // CONSTRUCTOR ===============================================================
        public UserDAO()
        {
            _context = new ABCLogisticsDataEntities();
        }

        // CREATE ====================================================================
        // addUser
        public void addUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getUsers
        public IList<User> getUsers()
        {
            IQueryable<User> _users;
            _users = from user
                          in _context.Users
                     select user;
            return _users.ToList<User>();
        }

        // getUser
        public User getUser(int id)
        {
            IQueryable<User> _user;
            _user = from user
                          in _context.Users
                    where user.Id == id
                    select user;
            return _user.ToList<User>().First();
        }

        // UPDATE ====================================================================
        // editUser
        public void editUser(User user)
        {
            User record = (from rec
                                      in _context.Users
                           where rec.Id == user.Id
                           select rec).ToList<User>().First();
            record.Name = user.Name;
            record.ContactNumber = user.ContactNumber;
            record.EmailAddress = user.EmailAddress;
            _context.SaveChanges();
        }

        // DELETE ====================================================================
        // deleteUser
        public void deleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

    }

}
