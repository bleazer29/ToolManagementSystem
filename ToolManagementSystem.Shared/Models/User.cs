using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class User
    {
        public User()
        {
            Cycle = new HashSet<Cycle>();
            Document = new HashSet<Document>();
            InverseCreator = new HashSet<User>();
            InverseLastUpdator = new HashSet<User>();
            OrderCreator = new HashSet<Order>();
            OrderHistory = new HashSet<OrderHistory>();
            OrderResponsibleUser = new HashSet<Order>();
            OrderToolOperatingTime = new HashSet<OrderToolOperatingTime>();
            RepairTool = new HashSet<RepairTool>();
            ReportHistory = new HashSet<ReportHistory>();
            RoleCreator = new HashSet<Role>();
            RoleLastUpdator = new HashSet<Role>();
            RolePermissionCreator = new HashSet<RolePermission>();
            RolePermissionLastUpdator = new HashSet<RolePermission>();
            RolePermissionRightCreator = new HashSet<RolePermissionRight>();
            RolePermissionRightLastUpdator = new HashSet<RolePermissionRight>();
            ToolHistory = new HashSet<ToolHistory>();
            UserRoleCreator = new HashSet<UserRole>();
            UserRoleLastUpdator = new HashSet<UserRole>();
            UserRoleUser = new HashSet<UserRole>();
            WorkOrderCreator = new HashSet<WorkOrder>();
            WorkOrderHistory = new HashSet<WorkOrderHistory>();
            WorkOrderResponsibleUser = new HashSet<WorkOrder>();
        }

        public int UserId { get; set; }
        public string Fio { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorId { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int? LastUpdatorId { get; set; }

        public virtual User Creator { get; set; }
        public virtual Department Department { get; set; }
        public virtual User LastUpdator { get; set; }
        public virtual ICollection<Cycle> Cycle { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<User> InverseCreator { get; set; }
        public virtual ICollection<User> InverseLastUpdator { get; set; }
        public virtual ICollection<Order> OrderCreator { get; set; }
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
        public virtual ICollection<Order> OrderResponsibleUser { get; set; }
        public virtual ICollection<OrderToolOperatingTime> OrderToolOperatingTime { get; set; }
        public virtual ICollection<RepairTool> RepairTool { get; set; }
        public virtual ICollection<ReportHistory> ReportHistory { get; set; }
        public virtual ICollection<Role> RoleCreator { get; set; }
        public virtual ICollection<Role> RoleLastUpdator { get; set; }
        public virtual ICollection<RolePermission> RolePermissionCreator { get; set; }
        public virtual ICollection<RolePermission> RolePermissionLastUpdator { get; set; }
        public virtual ICollection<RolePermissionRight> RolePermissionRightCreator { get; set; }
        public virtual ICollection<RolePermissionRight> RolePermissionRightLastUpdator { get; set; }
        public virtual ICollection<ToolHistory> ToolHistory { get; set; }
        public virtual ICollection<UserRole> UserRoleCreator { get; set; }
        public virtual ICollection<UserRole> UserRoleLastUpdator { get; set; }
        public virtual ICollection<UserRole> UserRoleUser { get; set; }
        public virtual ICollection<WorkOrder> WorkOrderCreator { get; set; }
        public virtual ICollection<WorkOrderHistory> WorkOrderHistory { get; set; }
        public virtual ICollection<WorkOrder> WorkOrderResponsibleUser { get; set; }
    }
}
