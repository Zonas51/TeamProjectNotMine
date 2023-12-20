using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidacticTrainClassLibrary.Interfaces
{
    public interface IUser
    {
        string Name { get; set; }
        string Group { get; set; }
        string Age { get; set; }
        Exercise Exercise { get; set; }
    }
}
