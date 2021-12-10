using System;
using System.Collections.Generic;
using Lemon.Common;
using Lemon.Template.Domain.Shared;

namespace Lemon.Template.Domain.Account.Users
{

    /// <summary>
    /// 用户数据
    /// </summary>
    public sealed class UserData : Entity
    {
        /// <summary>
        /// 账号
        /// </summary>
        /// <value>The account.</value>
        public string Account { get; set; } = "";

        /// <summary>
        /// 昵称
        /// </summary>
        /// <value>The name of the nike.</value>
        public string NickName { get; set; } = "";

        /// <summary>
        /// 头像
        /// </summary>
        /// <value>The head icon.</value>
        public string HeadIcon { get; set; } = "";

        /// <summary>
        /// 手机号码
        /// </summary>
        /// <value>The mobile.</value>
        public string Mobile { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }
        
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = "";

        /// <summary>
        /// 用户密钥
        /// </summary>
        public string SecretKey { get; set; } = "";

        /// <summary>
        /// 允许同时有多用户登录
        /// </summary>
        public bool MultiUserLogin { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int LogonCount { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        public bool UserOnline { get; set; } = false;

        /// <summary>
        /// 允许登录时间开始
        /// </summary>
        public DateTime AllowStartTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 允许登录时间结束
        /// </summary>
        public DateTime AllowEndTime { get; set; } = DateTime.Now.AddYears(100);

        /// <summary>
        /// 暂停用户开始日期
        /// </summary>
        public DateTime LockStartTime { get; set; } = DateTime.Now.AddYears(100);

        /// <summary>
        /// 暂停用户结束日期
        /// </summary>
        public DateTime LockEndDate { get; set; } = DateTime.Now.AddYears(100);

        /// <summary>
        /// 第一次访问时间
        /// </summary>
        public DateTime FirstVisitTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 上一次访问时间
        /// </summary>
        public DateTime PreviousVisitTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 最后访问时间
        /// </summary>
        public DateTime LastVisitTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 最后修改密码日期
        /// </summary>
        public DateTime ChangPasswordDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }

        public List<UserRole> UserRoles = new List<UserRole>();

        public UserData()
        {
        }

        public UserData(string password, string name, string email)
            : this(null, password, name, null, email)
        {

        }

        public UserData(string account, string password, string name = "", string mobile = null, string email = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(password, nameof(password));

            NickName = name;
            Account = string.IsNullOrWhiteSpace(account) ? Guid.NewGuid().ToString("N") : account;
            Mobile = mobile;
            Email = email;
            Password = Cryptography.PasswordStorage.CreateHash(password, out string secretKey);
            SecretKey = secretKey;
        }

        public void RemoveRole(string roleId)
        {
            UserRoles.RemoveAll(x => x.RoleId == roleId);
        }

        public void AddRole(string roleId)
        {
            UserRoles.Add(new UserRole(this.Id, roleId));
        }

        public void Set(string name, string account, string email, string mobile)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(account, nameof(account));
            Check.NotNullOrWhiteSpace(email, nameof(email));
            Check.NotNullOrWhiteSpace(mobile, nameof(mobile));

            this.NickName = name;
            this.Account = account;
            this.Email = email;
            this.Mobile = mobile;
        }

        public void SetPassword(string password)
        {
            string passwordHash = Cryptography.PasswordStorage.CreateHash(password, out string secretKey);
            Password = passwordHash;
            SecretKey = secretKey;
            ChangPasswordDate = DateTime.Now;
        }

        public void UpdateLoginInfo()
        {
            FirstVisitTime = LogonCount == 0 ? DateTime.Now : FirstVisitTime;
            LogonCount += 1;
            PreviousVisitTime = LastVisitTime;
            LastVisitTime = DateTime.Now;
        }

        public void VerifyPassword(string password)
        {
            if(!Cryptography.PasswordStorage.VerifyPassword(password, Password, SecretKey))
            {
                throw new Exception("密码错误");
            }
        }

        public void LockUser(DateTime startTime, DateTime endTime)
        {
            LockStartTime = startTime;
            LockEndDate = endTime;
        }

        public void AllowUser(DateTime startTime, DateTime endTime)
        {
            AllowStartTime = startTime;
            AllowEndTime = endTime;
        }
    }
}