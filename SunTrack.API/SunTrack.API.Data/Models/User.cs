using System;
using System.Collections.Generic;

namespace SunTrack.API.Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public virtual ICollection<Customer> CustomerCreatedByNavigations { get; set; } = new List<Customer>();

    public virtual ICollection<Customer> CustomerUpdatedByNavigations { get; set; } = new List<Customer>();

    public virtual ICollection<FinancialStatus> FinancialStatusCreatedByNavigations { get; set; } = new List<FinancialStatus>();

    public virtual ICollection<FinancialStatus> FinancialStatusUpdatedByNavigations { get; set; } = new List<FinancialStatus>();

    public virtual ICollection<InstallationStatus> InstallationStatusCreatedByNavigations { get; set; } = new List<InstallationStatus>();

    public virtual ICollection<InstallationStatus> InstallationStatusUpdatedByNavigations { get; set; } = new List<InstallationStatus>();

    public virtual ICollection<Lead> LeadCreatedByNavigations { get; set; } = new List<Lead>();

    public virtual ICollection<Lead> LeadResposibles { get; set; } = new List<Lead>();

    public virtual ICollection<Lead> LeadUpdatedByNavigations { get; set; } = new List<Lead>();

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();

    public virtual ICollection<Project> ProjectCreatedByNavigations { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectUpdatedByNavigations { get; set; } = new List<Project>();
}
