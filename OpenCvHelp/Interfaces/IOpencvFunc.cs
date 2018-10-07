using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvHelp.Interfaces
{
    public interface IOpencvFunc
    {
        
        /// <summary>
        /// 角度纠正
        /// </summary>
        /// <param name="absoluteFilePath  要纠正的图片的全路径"></param>
        void handle1(string absoluteFilePath);

    }
}
