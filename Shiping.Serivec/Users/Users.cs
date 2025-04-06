using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Serivec.Users.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Serivec.Users
{
    public class Users : IUsers
    {
        private readonly IUnitofwork _unitOfWork;

        public Users(IUnitofwork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // MAKE Admin add user
        public async Task<bool> AddUser(UserpassDTO userpassdto)
        {
            var user = new User
            {
                Id = userpassdto.Id,
                Name = userpassdto.Name,
                Email = userpassdto.Email,
                Password = userpassdto.Password,
                Data = userpassdto.Data,
                Status = userpassdto.Status,
                Type = userpassdto.Type,
                RoleId = userpassdto.RoleId
            };
            await _unitOfWork.GetRepository<User>().AddAsync(user);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<bool> UpdateUser(UsersDTO userDTO)
        {
            var user = await _unitOfWork.GetRepository<User>().GetByIdAsync(userDTO.Id);
            if (user == null)
            {
                return false;
            }

            user.Name = userDTO.Name;
            user.Email = userDTO.Email;
            user.Data = userDTO.Data;
            user.Status = userDTO.Status;
            user.Type = userDTO.Type;
            user.RoleId = userDTO.RoleId;

            await _unitOfWork.GetRepository<User>().UpdateAsync(user);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<List<UsersDTO>> GetAllUsers()
        {
            var users = await _unitOfWork.GetRepository<User>().GetAllAsync();
            if (users == null)
            {
                return null;
            }
            var userDTOs = users.Select(user => new UsersDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Data = user.Data,
                Status = user.Status,
                Type = user.Type,
                //RoleId = user.RoleId
            }).ToList();
            return userDTOs;
        }

        public async Task<bool> DeleteUser(string id)
        {
            var user = await _unitOfWork.GetRepository<User>().GetByIdAsync(id);
            if (user == null)
            {
                return false;
            }

            await _unitOfWork.GetRepository<User>().DeleteAsync(id);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<UsersDTO> GetUserById(string id)
        {
            var user = await _unitOfWork.GetRepository<User>().GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            return new UsersDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Data = user.Data,
                Status = user.Status,
                Type = user.Type,
                //RoleId = user.RoleId
            };
        }
    }

}