using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Serivec.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Serivec.Users
{
    public class Users : IUsers
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public Users(IUnitofwork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;

        }

        // MAKE Admin add user
        public async Task<bool> AddUser(AddUserDTO userDTO)
        {
            var user = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                NormalizedEmail = userDTO.Email.ToUpper(),
                Date = DateTime.Now,
                Status = "Active"
            };
            await _userManager.CreateAsync(user, "Admin@123");
            var repo = _unitOfWork.GetRepository<User, string>();
            await repo.AddAsync(user);
            //await _userManager.AddToRoleAsync(user, "Admin");
            return await _unitOfWork.CompleteAsync() > 0;
            
        }
    public async Task<bool> UpdateUser(UsersDTO userDTO)
        {
            var repo = _unitOfWork.GetRepository<User, string>();
            var user = await repo.GetByIdAsync(userDTO.Id);
            if (user == null)
            {
                return false;
            }
            user.Name = userDTO.Name;
            user.Email = userDTO.Email;
            user.Date = DateTime.Now;
            user.Status = "Active";
            repo.UpdateAsync(user);
            return await _unitOfWork.CompleteAsync() > 0;
        }
        public async Task<bool> DeleteUser(string id)
        {

            var repo = _unitOfWork.GetRepository<User, string>();
            var user = await repo.GetByIdAsync(id);
            if (user == null)
            {
                return false;
            }
            var deriverycount = user.Deliveries.Count();
            var userbranchcount = user.UserBranches.Count();
            var marchantcount = user.Marchants.Count();
            if (deriverycount > 0 || userbranchcount > 0 || marchantcount > 0)
            {
                user.IsDeleted = true;

               return await _unitOfWork.CompleteAsync() > 0;
            }

            repo.DeleteAsync(user.Id);
            return await _unitOfWork.CompleteAsync() > 0;
        }
        public async Task<UsersDTO> GetUserById(string id)
        {
            var repo = _unitOfWork.GetRepository<User, string>();
            var user = await repo.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return new UsersDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Date = user.Date,
                Status = "Active"
            };
        }
        public async Task<List<UsersDTO>> GetAllUsers()
        {
            var repo = _unitOfWork.GetRepository<User, string>();
            var users = await repo.GetAllAsync();
            return users.Select(user => new UsersDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Date = user.Date,
                Status = "Active"
            }).ToList();
        }
    }

}