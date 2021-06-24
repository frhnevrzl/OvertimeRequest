﻿using Microsoft.EntityFrameworkCore;
using OvertimeRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OvertimeRequest.Context
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<OvertimeApply> OvertimeApplies { get; set; }
        public DbSet<OvertimeApplyEmployee> overtimeApplyEmployees { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(p => p.Department)
                .WithOne(a => a.Employee)
                .HasForeignKey<Department>(a => a.DepartmentId);
            modelBuilder.Entity<Employee>()
                .HasOne(p => p.Account)
                .WithOne(a => a.Employee)
                .HasForeignKey<Account>(a => a.AccountId);
            modelBuilder.Entity<Role>()
                .HasMany(p => p.AccountRoles)
                .WithOne(a => a.Role);
            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountRoles)
                .WithOne(ar => ar.Account);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.OvertimeApplyEmployees)
                .WithOne(oe => oe.Employee);
            modelBuilder.Entity<OvertimeApply>()
                .HasMany(oa => oa.OvertimeApplyEmployees)
                .WithOne(oe => oe.OvertimeApply);

            modelBuilder.Entity<AccountRole>().HasKey(ar => new { ar.AccountId, ar.RoleId });
        }

    }
}