﻿using CompanionApp.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanionApp.Services
{
    class MockIntuneDataStore : IIntuneDataStore
    {
        List<User> users;
        List<Device> devices;

        public MockIntuneDataStore()
        {
            users = new List<User>();
            users.Add(new User() { DisplayName = "Manoj Jain1", GivenName = "Manoj1", Surname = "Jain1", UserPrincipalName = "manoj1@microsoft.com" });
            users.Add(new User() { DisplayName = "Manoj Jain2", GivenName = "Manoj2", Surname = "Jain2", UserPrincipalName = "manoj2@microsoft.com" });
            users.Add(new User() { DisplayName = "Manoj Jain3", GivenName = "Manoj3", Surname = "Jain3", UserPrincipalName = "manoj3@microsoft.com" });
            users.Add(new User() { DisplayName = "Manoj Jain4", GivenName = "Manoj4", Surname = "Jain4", UserPrincipalName = "manoj4@microsoft.com" });

            devices = new List<Device>();
            devices.Add(new Device() { SerialNumber = "100", Manufacturer = "Microsoft", Model = "Surface Book", PurchaseOrderNumber = "PO01", GroupTag = "My Group", DeploymentProfile = "User Driven AAD", AddressableUserName = "Anna Anderson", UserPrincipalName = "anna@contosocm.com", ZtdId = Guid.NewGuid().ToString(), AzureActiveDirectoryDeviceId = Guid.NewGuid().ToString(), ManagedDeviceId = Guid.NewGuid().ToString() } );
            devices.Add(new Device() { SerialNumber = "101", Manufacturer = "Microsoft", Model = "Surface Pro 6", PurchaseOrderNumber = "PO02", GroupTag = "My Second Group", DeploymentProfile = "User Driven AAD", AddressableUserName = "Anna Anderson", UserPrincipalName = "anna@contosocm.com", ZtdId = Guid.NewGuid().ToString(), AzureActiveDirectoryDeviceId = Guid.NewGuid().ToString(), ManagedDeviceId = Guid.NewGuid().ToString() } );
        }

        public async Task<bool> UpdateDeviceAsync(Device device)
        {
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<User>> ListAllUsersAsync()
        {
            return await Task.FromResult(users);
        }

        public Task Sync()
        {
            return null;
        }

        public Task LogOutUser()
        {
            // throw new NotImplementedException();
            return null;
        }

        public async Task<IEnumerable<User>> SearchUserAsync(string userName)
        {
            return await Task.FromResult(users);
        }

        public async Task<Info> GetInfo()
        {
            Info i = new Info();
            i.TenantDisplayName = "Demo Tenant (Simulated)";
            i.TenantID = (new Guid()).ToString();
            i.TenantName = "contoso.onmicrosoft.com";
            return await Task.FromResult(i);
        }

        public async Task<IEnumerable<Device>> SearchDevicesBySerialAsync(string serial)
        {
            return await Task.FromResult(devices);
        }

        public async Task<IEnumerable<Device>> SearchDevicesByZtdIdAsync(string ztdId)
        {
            return await Task.FromResult(devices.GetRange(0,1));
        }
    }
}
