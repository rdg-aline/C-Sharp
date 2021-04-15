using System;

namespace Countries
{
    class Country
    {

        #region Fields
        public string Name { get; }
        public string Code{ get; }
        public string Region { get; }
        public int Population { get; }
        #endregion

        /// <summary>
        /// Este método requer os seguintes dados de um país: nome, codigo,região,população 
        /// </summary>
        public Country( string name, string code, string region, int population)
        {
            this.Name = name;
            this.Code = code;
            this.Region = region;
            this.Population = population;
        }

    }
}
