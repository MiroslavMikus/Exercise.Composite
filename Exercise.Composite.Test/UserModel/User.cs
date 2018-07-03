using Exercise.Composite.CompositeInterfaces;
using System;
using System.Collections.Generic;

namespace Exercise.Composite.Test.UserModel
{
    public class User : ICompositeChild<string>, ICompositeParent<string>
    {
        public string Name { get; set; }
        public List<Car> Cars { get; set; }

        #region ICompositeChild
        public ICompositeParent<string> Parent { get; set; }

        public string BubbleDown(string input)
        {
            return $"{input},{ToString()}";
        }
        #endregion

        #region ICompositeParent
        public IEnumerable<ICompositeChild<string>> Childs => Cars;

        public string BubbleUp(string input)
        {
            throw new NotImplementedException();
        }
        #endregion

        public bool StopBubble() => false;

        public override string ToString() => $"User: {Name}";
    }
}
