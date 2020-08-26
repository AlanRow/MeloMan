using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScaner
{
    interface IFile
    {
        Channel GetChannel(int number);
    }
}
