﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace OddNumbers
{
    public class OddGenerator : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            int i = 1;
            yield return i;
            while (true)
            {
                i += 2;
                yield return i;
            }

        }
        /// <summary>
        /// Explicit Implementation uso--> interface.nome do método
        ///                              IEnumerable.GetEnumerator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            //return this.GetEnumerator();
                throw new Exception("I'm >>> Explicit Implementation");
        }
    }
}
