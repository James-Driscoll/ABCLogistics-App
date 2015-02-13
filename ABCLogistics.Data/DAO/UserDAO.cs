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
                    where user.PK_UserID == id
                    select user;
            return _user.ToList<User>().First();
        }

        // UPDATE ====================================================================
        // editUser
        public void editUser(User user)
        {
            User record = (from rec
                                      in _context.Users
                           where rec.PK_UserID == user.PK_UserID
                           select rec).ToList<User>().First();
            record.EmailAddress = user.EmailAddress;
            record.FirstName = user.FirstName;
            record.Lastname = user.Lastname;
            record.MobileNumber = user.MobileNumber;
            record.LandlineNumber = user.LandlineNumber;
            record.SystemRole = user.SystemRole;
            record.Password = user.Password;
            record.FK_BillingAddressID = user.FK_BillingAddressID;
            record.FK_DeliveryAddressID = user.FK_DeliveryAddressID;
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
