using System;
using System.Collections.Generic;
using Lemon.App.Application.Contracts.Entities;

namespace Lemon.Template.Application.Contracts.Account.Users.Dtos;

public class UserDataDto : EntityDto<long>
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
    public DateTime AllowStartTime { get; set; }

    /// <summary>
    /// 允许登录时间结束
    /// </summary>
    public DateTime AllowEndTime { get; set; }

    /// <summary>
    /// 暂停用户开始日期
    /// </summary>
    public DateTime LockStartTime { get; set; }

    /// <summary>
    /// 暂停用户结束日期
    /// </summary>
    public DateTime LockEndDate { get; set; }

    /// <summary>
    /// 第一次访问时间
    /// </summary>
    public DateTime FirstVisitTime { get; set; }

    /// <summary>
    /// 上一次访问时间
    /// </summary>
    public DateTime PreviousVisitTime { get; set; }

    /// <summary>
    /// 最后访问时间
    /// </summary>
    public DateTime LastVisitTime { get; set; }

    /// <summary>
    /// 最后修改密码日期
    /// </summary>
    public DateTime ChangPasswordDate { get; set; }

    public bool IsDeleted { get; set; }

    public List<UserRoleDto> UserRoles = new List<UserRoleDto>();
}