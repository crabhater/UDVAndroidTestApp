using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Core.Models;
using UDVAndroidTestApp.Core.Servies.Base;

namespace UDVAndroidTestApp.Core.Servies.FluentBuilder
{
    public class UserBuilder : ModelBuilderBase<User>
    {
        public UserBuilder()
        {
            model = new User();
        }
        public UserBuilder SetName(string name)
        {
            model.Name = name;
            return this;
        }
        public UserBuilder SetDescription(string description)
        {
            model.Description = description;
            return this;
        }
        public override User Build()
        {
            return model;
        }
    }
}
