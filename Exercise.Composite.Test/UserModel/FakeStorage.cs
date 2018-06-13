using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Composite.Test.UserModel
{
    public static class FakeStorage
    {
        public static Group GetSimpleGroup()
        {
            return new Group
            {
                Name = "Root Group", 
                Users = new List<User>
                {
                    new User
                    {
                        Name = "Miro",
                        Cars = new List<Car>
                        {
                            new Car
                            {
                                Color = "Red"
                            },
                            new Car
                            {
                                Color = "Blue"
                            }
                        }
                    },
                    new User
                    {
                        Name = "John",
                        Cars = new List<Car>
                        {
                            new Car
                            {
                                Color = "Black"
                            }
                        }
                    }
                }
            };
        }
    }
}
